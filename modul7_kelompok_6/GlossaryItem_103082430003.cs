using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.Json;

namespace modul7_kelompok_6
{
    public class GlossaryWrap
    {
        public  Glossary glossary;
    }

    public class Glossary
    {
        public string title;
        public GlossDiv GlossDiv;
    }

    public class GlossDiv
    {
        public string title;
        public GlossList GlossList;
    }

    public class GlossList
    {
        public GlossEntry GlossEntry;
    }

    public class GlossEntry
    {
        public string ID;
        public string SortAs;
        public string GlossTerm;
        public string Acronym;
        public string Abbrev;
        public GlossDef GlossDef;
        public string GlossSee;
            
    }

    public class GlossDef
    {
        public string para;
        public List<string> GlossSeeAlso;
    }
    internal class GlossaryItem_103082430003
    {
        public void ReadJSON()
        {
            string filename = "Jurnal7_3_103082430003.json";
            string json = File.ReadAllText(filename);
            try
            {
                var options = new JsonSerializerOptions
                {
                    IncludeFields = true,
                };
                GlossaryWrap data = JsonSerializer.Deserialize<GlossaryWrap>(json, options);

                var entry = data.glossary.GlossDiv.GlossList.GlossEntry;

                Console.WriteLine(new string('=',20) + "Gloss Entry" +new string('=',20));
                Console.WriteLine($"ID           : {entry.ID}");
                Console.WriteLine($"Term         : {entry.GlossTerm}");
                Console.WriteLine($"Sort AS      : {entry.SortAs}");
                Console.WriteLine($"Acronym      : {entry.Acronym}");
                Console.WriteLine($"Abbreviation : {entry.Abbrev}");
                Console.WriteLine($"See Also     : {string.Join(",",entry.GlossDef.GlossSeeAlso)}");
                Console.WriteLine($"Definition   : {entry.GlossDef.para}");
                Console.WriteLine($"Gloss See    : {entry.GlossSee}");
                Console.WriteLine(new string('=',50));

                
            }
            catch(JsonException ex)
            {
                Console.WriteLine("Json parsing ERROR"+ex.Message);
            }
            
        }
    }
}
