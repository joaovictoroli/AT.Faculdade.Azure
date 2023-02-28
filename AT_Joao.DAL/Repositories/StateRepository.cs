using AT_Joao.BLL.Models.Entities;
using AT_Joao.DAL.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AT_Joao.DAL.Repositories
{
    public class StateRepository : IStateRepository
    {

        private readonly CountryDbContext countryDbContext;
        public StateRepository(CountryDbContext countryDbContext)
        {
            this.countryDbContext = countryDbContext;
        }        

        public async Task<State> AddAsync(State state)
        {
            await countryDbContext.AddAsync(state);
            await countryDbContext.SaveChangesAsync();
            return state;
        }

        public async Task<State> DeleteAsync(int id)
        {
            var state = await countryDbContext.States.FindAsync(id);

            if (state == null)
            {
                return null;
            }

            countryDbContext.States.Remove(state);
            await countryDbContext.SaveChangesAsync();
            return state;
        }

        public async Task<IEnumerable<State>> GetAllAsync()
        {
            return await countryDbContext.States
                .Include(x => x.Country)
                .ToListAsync();
        }

        public async Task<State> GetAsync(int id)
        {
            return await countryDbContext.States
                .Include(x => x.Country)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<State> UpdateAsync(int id, State state)
        {
            var existingState = await countryDbContext.States.FirstOrDefaultAsync(x => x.Id == id);

            if (existingState == null)
            {
                return null;
            }

            existingState.Name = state.Name;
            existingState.ImageUrl = state.ImageUrl;
            existingState.CountryId = state.CountryId;


            await countryDbContext.SaveChangesAsync();

            return existingState;
        }
    }
}
