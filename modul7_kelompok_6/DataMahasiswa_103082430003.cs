using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace modul7_kelompok_6
{
    public class Address
    {
        public string streetaddress;
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
    internal class DataMahasiswa_103082430003
    {
        public void ReadJSON()
        {
            string filename = "jurnal7_1_103082430003.json";
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
                Console.WriteLine($"Jalan : {mhs.address.streetaddress}, Kota {mhs.address.city}, Provinsi : {mhs.address.state}");
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
