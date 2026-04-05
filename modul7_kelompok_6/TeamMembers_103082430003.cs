using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace modul7_kelompok_6
{
    public class Members
    {
        public string firstName;
        public string lastName;
        public string gender;
        public int age;
        public string nim;
    }

    public class MemberConfig
    {
        public List<Members> members;
    }
    internal class TeamMembers_103082430003
    {
        public void ReadJSON()
        {
            string filename = "Jurnal7_2_103082430003.json";
            string json = File.ReadAllText(filename);
            try
            {
                var options = new JsonSerializerOptions
                {
                    IncludeFields = true,
                };

                MemberConfig config = JsonSerializer.Deserialize<MemberConfig>(json,options);
                Console.WriteLine("Team Member List:");
                foreach (var m in config.members)
                {
                    Console.WriteLine($"{m.nim} {m.firstName} {m.lastName} ({m.age} {m.gender})");
                }
            }
            catch(JsonException ex)
            {
                Console.WriteLine("Error parsing JSON :" + ex.Message);
            }
        }
    }
}
