using AT_Joao.BLL.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AT_Joao.DAL.Repositories
{
    public interface IStateRepository
    {
        Task<IEnumerable<State>> GetAllAsync();
        Task<State> GetAsync(int id);
        Task<State> AddAsync(State state);
        Task<State> UpdateAsync(int id, State state);
        Task<State> DeleteAsync(int id);
    }
}
