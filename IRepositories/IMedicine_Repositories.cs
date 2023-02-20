using PharmacyEdition_2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyEdition_2._0.IRepositories
{
    public interface IMedicine_Repositories
    {
        Task<Medicine_products> Create(Medicine_products Md);
        Task<Medicine_products> GetbyId(string name);
        Task<Medicine_products> GetAll();
        Task<bool> Delete(string name);
        Task<Medicine_products> Update(Medicine_products Md);


    }
}
