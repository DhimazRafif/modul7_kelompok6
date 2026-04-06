using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace modul7_kelompok_6
{
    public class Address
    {
        public string streetAddress;
        public string city;
        public string state;
    }

    public class Course
    {
        public string code;
        public string name;
    }
    public class Mahasiswa
    {
        public string firstName;
        public string lastName;
        public string gender;
        public Address address;
        public List<Course> courses;
    }
    internal class DataMahasiswa_103082400050
    {
        public void ReadJSON()
        {
            string filename = "tp7_1_103082400050.json";
            string json = File.ReadAllText(filename);
            try
            {
                var options = new JsonSerializerOptions
                {
                    IncludeFields = true,
                };
                Mahasiswa mhs = JsonSerializer.Deserialize<Mahasiswa>(json,options);
                Console.WriteLine(new String('=',32) + "Profil Mahasiswa" + new string('=',32));
                Console.WriteLine($"Nama depan {mhs.firstName} + nama belakang {mhs.lastName}");
                Console.WriteLine($"Alamat : ");
                Console.WriteLine($"Jalan : {mhs.address.streetAddress}, Kota {mhs.address.city}, Provinsi : {mhs.address.state}");
                Console.WriteLine("Mata kuliah yang diambil : ");
                foreach (var i in mhs.courses)
                {
                    Console.WriteLine($"Nama mata kuliah : {i.name} - {i.code}");
                }
                Console.WriteLine(new string('=',79));
            }
            catch(JsonException ex)
            {
                Console.WriteLine("Error Json parsong : "+ ex.Message);
            }
        }

    }
}
