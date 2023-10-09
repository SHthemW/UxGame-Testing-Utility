using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using UxGame_Testing_Utility.Entities;

namespace UxGame_Testing_Utility.Services
{
    internal static class LocalService
    {
        private const string CONF_FILE_NAME = "config_save";

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

        public static void SaveConfigDataToLocal(ConfigData config)
        {
            var jsonStr = JsonConvert.SerializeObject(config, Formatting.Indented);
            WriteTo(CONF_FILE_NAME, jsonStr, Encoding.UTF8);
        }

        public static bool TryLoadConfigDataFromLocal(out ConfigData config, out ErrInfo err) 
        {
            string jsonStr;
            try
            {
                jsonStr = ReadFrom(CONF_FILE_NAME, Encoding.UTF8);
            }
            catch (ArgumentException) 
            {
                err = new ErrInfo(nameof(jsonStr), nameof(ArgumentException));
                config = default;
                return false;
            }

            JObject jsonObj;
            try
            {          
                jsonObj = JObject.Parse(jsonStr);
            }
            catch (JsonReaderException)
            {
                err = new ErrInfo(nameof(jsonObj), nameof(JsonReaderException));
                config = default;
                return false;
            }

            err = default;
            config = new ConfigData(
                (string)jsonObj[nameof(ConfigData.DataSrcPath)]!,
                (string)jsonObj[nameof(ConfigData.DplProgPath)]!
                );
            return true;
        }
    }
}
