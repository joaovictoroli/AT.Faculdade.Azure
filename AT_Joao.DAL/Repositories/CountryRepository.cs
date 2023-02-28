using AT_Joao.BLL.Models.Entities;
using AT_Joao.DAL.Data;
using Microsoft.EntityFrameworkCore;

namespace AT_Joao.DAL.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly CountryDbContext countryDbContext;

        public CountryRepository(CountryDbContext countryDbContext)
        {
            this.countryDbContext = countryDbContext;
        }

        public async Task<Country> AddAsync(Country country)
        {
            await countryDbContext.AddAsync(country);
            await countryDbContext.SaveChangesAsync();
            return country;
        }

        public async Task<Country> DeleteAsync(int id)
        {
            var country = await countryDbContext.Countries.FindAsync(id);

            if (country == null)
            {
                return null;
            }

            countryDbContext.Countries.Remove(country);
            await countryDbContext.SaveChangesAsync();
            return country;
        }

        public async Task<IEnumerable<Country>> GetAllAsync()
        {
            return await countryDbContext.Countries.ToListAsync();
        }

        public async Task<Country> GetAsync(int id)
        {
            return await countryDbContext.Countries.FindAsync(id);
        }

        public async Task<Country> UpdateAsync(int id, Country country)
        {
            var existingCountry = await countryDbContext.Countries.FirstOrDefaultAsync(x => x.Id == id);

            if (existingCountry == null)
            {
                return null;
            }

            existingCountry.Name = country.Name;
            existingCountry.ImageUrl = country.ImageUrl;


            await countryDbContext.SaveChangesAsync();

            return existingCountry;
        }
    }
}
