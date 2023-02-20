using PharmacyEdition_2._0.Constants;
using PharmacyEdition_2._0.IRepositories;
using PharmacyEdition_2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PharmacyEdition_2._0.Repositories
{

    public class Medicine_Service
    {
        private readonly string path = DataBase_Paths.MEDICINE_DATABASE_PATH;
        public async Task<Medicine_products> Create(Medicine_products user)
        {
            string s = $"{user.Id}|{user.Name}|{user.Description}|{user.Price}|{user.CreatedAt}\n";

            File.WriteAllText(path, s);
            return user;
        }

        public async Task<bool> Delete(string name)
        {
            var UserInfo = await GetAllAsync();
            File.WriteAllText(path, "");
            foreach (var element in UserInfo)
            {
                if (element.Name == name)
                    continue;
                
                Create(element);
                return true;
            }
            return false;

        }

        public async Task<List<Medicine_products>> GetAllAsync()
        {
            string[] infom = File.ReadAllText(path).Split("\n");
            var Ruyxat = new List<Medicine_products>();
   
            foreach (string info in infom)
            {
                string[] pieces = info.Split('|');
                Medicine_products Md = new Medicine_products()
                {
                    Id = int.Parse(pieces[0]),
                    Name = pieces[1],
                    Description = pieces[2],
                    Price = int.Parse( pieces[3]),
                    CreatedAt = int.Parse(pieces[4]),
                    
                };
                Ruyxat.Add(Md);
            }  
            return Ruyxat;
        } 

        public async Task<Medicine_products> GetbyId(string name)
        {
            var UserInfo  = await GetAllAsync();
            foreach (var element in UserInfo)
            {
                if (element.Name == name)
                    return element;
            }
            return null;
        }

        public async Task<Medicine_products> Update(string name,Medicine_products Md)
        {
            var info = await GetAllAsync();
            File.WriteAllText(path, "");
            foreach (var inf in info)
            {
                if (inf.Name == name)
                {
                    inf.Name = Md.Name;
                    inf.Description = Md.Description;
                    inf.Price = Md.Price;
                }
                Create(inf);
            }
            return Md;
        }
    }
}
