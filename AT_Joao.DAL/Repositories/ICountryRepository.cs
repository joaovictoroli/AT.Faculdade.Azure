using AT_Joao.BLL.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AT_Joao.DAL.Repositories
{
    public interface ICountryRepository
    {
        Task<IEnumerable<Country>> GetAllAsync();
        Task<Country> GetAsync(int id);
        Task<Country> AddAsync(Country contact);
        Task<Country> UpdateAsync(int id, Country contact);
        Task<Country> DeleteAsync(int id);
    }
}
