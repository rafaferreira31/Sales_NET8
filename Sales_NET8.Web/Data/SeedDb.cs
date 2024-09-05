using Microsoft.EntityFrameworkCore;
using Sales_NET8.Web.Data.Entities;

namespace Sales_NET8.Web.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;

        public SeedDb(DataContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();

            
            await SeedCountryAsync();
            await SeedCategoryAsync();

        }
        private async Task SeedCountryAsync()
        {
            if (!_context.Countries.Any())
            {
                AddCountry("Portugal");
                AddCountry("Espanha");
                AddCountry("Argentina");
                await _context.SaveChangesAsync();
            }
        }


        private void AddCountry(string countryName)
        {
            _context.Countries.Add(new Country
            {
                Name = countryName
            });
        }
        private async Task SeedCategoryAsync()
        {
            if (!_context.Categories.Any())
            {
                AddCategory("Categoria X");
                AddCategory("Categoria Y");
                AddCategory("Categoria W");
                AddCategory("Categoria Z");
                await _context.SaveChangesAsync();
            }
        }

        private void AddCategory(string categoryName)
        {
            _context.Categories.Add(new Category
            {
                Name = categoryName
            });
        }
    }
}
