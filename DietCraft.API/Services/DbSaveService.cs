using DietCraft.API.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace DietCraft.API.Services
{
    public class DbSaveService
    {
        public DietCraftContext _context;

        public DbSaveService(DietCraftContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }
    }
}
