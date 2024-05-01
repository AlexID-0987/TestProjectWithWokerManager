using Newtonsoft.Json;
using ProjectForEmploee.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectForEmploee.Services
{
    class FileService
    {
        private readonly string Pash;

        public FileService(string path)
        {
            Pash = path;
        }
        public BindingList<Emploee> FileEmploee()
        {
            bool file = File.Exists(Pash);
            if(!file)
            {
                File.CreateText(Pash).Dispose();
                return new BindingList<Emploee>();
            }
            using (var read = File.OpenText(Pash))
            {
                var fileText = read.ReadToEnd();
                return JsonConvert.DeserializeObject<BindingList<Emploee>>(fileText);
            }
        }
        public void SaveFile(object emploees)
        {
            using (System.IO.StreamWriter writer = File.CreateText(Pash))
            {
                string output = JsonConvert.SerializeObject(emploees);
                writer.Write(output);
            }
        }
    }
}
