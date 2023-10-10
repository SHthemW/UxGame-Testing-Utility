using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NPOI.SS.Formula.Functions;
using Org.BouncyCastle.Asn1.X509.Qualified;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using UxGame_Testing_Utility.Entities;

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

        public static bool TryLoadConfigDataFromLocal<T>(out T config, out string? errmsg) where T : class, new()
        {
            config = new();

            string jsonStr;
            try
            {
                jsonStr = ReadFrom(typeof(T).ToString(), Encoding.UTF8);
            }
            catch (ArgumentException) 
            {
                errmsg = "failed to read json from local.";
                return false;
            }
            catch (FileNotFoundException) 
            {
                errmsg = "json file is not exists.";
                return true;
            }

            JObject jsonObj;
            try
            {          
                jsonObj = JObject.Parse(jsonStr);
            }
            catch (JsonReaderException)
            {
                errmsg = "failed to parse json str.";
                return false;
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
                    errmsg = $"type <{type}> cannot be convert.";
                    return false;
                }

                prop.SetValue(config, result);
            }

            errmsg = default;
            return true;
        }
    }
}
