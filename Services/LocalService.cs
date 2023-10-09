using Newtonsoft.Json;
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
    }
}
