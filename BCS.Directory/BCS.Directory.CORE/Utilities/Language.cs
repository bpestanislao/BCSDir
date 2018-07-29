using BCS.Directory.CORE.Language;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BCS.Directory.CORE.Utilities
{
    public static class Language
    {
        public static int GetLabel(string culture)
        {
            string startupPath = System.IO.Directory.GetCurrentDirectory();

            string startupPath1 = Environment.CurrentDirectory;

            string subfoldername = "Script";
            //Your fileName
            string filename = "jquery.js";
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, subfoldername, filename);
            using (StreamReader r = new StreamReader("en-lang.json"))
            {
                string json = r.ReadToEnd();
                List<LanguageModel> items = JsonConvert.DeserializeObject<List<LanguageModel>>(json);
            }
            return 1;
        }
    }
}
