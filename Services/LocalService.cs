using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;

namespace UxGame_Testing_Utility.Services
{
    internal static class LocalService
    {
        private static string ReadFrom(string filePath, Encoding encoding)
        {
            using StreamReader sr = new(filePath, encoding);
            return sr.ReadToEnd();
        }
        private static void WriteTo(string filePath, string content, Encoding encoding)
        {
            using StreamWriter sw = new(filePath, false, encoding);
            sw.Write(content);
        }

        /*
         *  details
         */

        public static void SaveConfigDataToLocal<T>(T config) where T : class
        {
            var jsonStr = JsonConvert.SerializeObject(config, Formatting.Indented);
            WriteTo(typeof(T).ToString(), jsonStr, Encoding.UTF8);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="Exception">issues when load config.</exception>
        public static async Task<T> TryLoadConfigDataFromLocal<T>() where T : class, new()
        {           
            return await Task.Run(() =>
            {
                T config = new();

                string jsonStr;
                try
                {
                    jsonStr = ReadFrom(typeof(T).ToString(), Encoding.UTF8);
                }
                catch (ArgumentException)
                {
                    var errmsg = "failed to read json from local.";
                    throw new Exception(errmsg);
                }
                catch (FileNotFoundException)
                {
                    var errmsg = "json file is not exists.";
                    throw new Exception(errmsg);
                }

                JObject jsonObj;
                try
                {
                    jsonObj = JObject.Parse(jsonStr);
                }
                catch (JsonReaderException)
                {
                    var errmsg = "failed to parse json str.";
                    throw new Exception(errmsg);
                }

                foreach (var prop in typeof(T).GetProperties())
                {
                    var type = prop.PropertyType;
                    var value = jsonObj[prop.Name];

                    dynamic? result = type switch
                    {
                        Type t when t == typeof(string) => Convert.ToString(value),
                        Type t when t == typeof(float) => Convert.ToSingle(value),
                        Type t when t == typeof(bool) => Convert.ToBoolean(value),
                        Type t when t == typeof(int) => Convert.ToInt32(value),
                        _ => null
                    };

                    if (result is null)
                    {
                        var errmsg = $"type <{type}> cannot be convert.";
                        throw new Exception(errmsg);
                    }

                    prop.SetValue(config, result);
                }
                return config;
            });     
        }
    }
}
