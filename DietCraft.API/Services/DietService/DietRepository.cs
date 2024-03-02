using DietCraft.API.DbContexts;
using DietCraft.API.Entities;
using DietCraft.API.Models.Diet;
using DietCraft.API.Services.UserService;
using Microsoft.EntityFrameworkCore;

namespace DietCraft.API.Services.DietService
{
    public class DietRepository : IDietRepository
    {
        private readonly DietCraftContext _context;
        private readonly IUserRepository _userRepository;

        public DietRepository(DietCraftContext context, IUserRepository userRepository)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public async Task<(IEnumerable<Diet>, PaginationMetadata)> GetDietsAsync(int pageNumber, int pageSize)
        {
            var collection = _context.Diets as IQueryable<Diet>;
            var totalItemCount = await collection.CountAsync();

            var paginationMetaData = new PaginationMetadata(totalItemCount, pageSize, pageNumber);
            var collectionToReturn = await collection
                .OrderBy(x => x.Id)
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize)
                .ToListAsync();

            return (collectionToReturn, paginationMetaData);

        }

        public async Task<Diet?> GetDietByIdAsync(int dietId)
        {
            var dietExists = await DietExistsAsync(dietId);
            if (!dietExists)
                return null;

            var diet = await _context.Diets.Where(d => d.Id == dietId).FirstOrDefaultAsync();
            return diet;
        }

        public async Task<bool> DietExistsAsync(int dietId)
        {
            return await _context.Diets.AnyAsync(d => d.Id == dietId);
        }

        public async Task<bool> DietTypeExistsAsync(int dietTypeId)
        {
            return await _context.DietTypes.AnyAsync(d => d.Id == dietTypeId);
        }

        public void AddDiet(Diet diet)
        {
            _context.Diets.Add(diet);
        }

        public void DeleteDiet(Diet diet)
        {
            _context.Diets.Remove(diet);
        }

        
        public async Task<(IEnumerable<DietType>, PaginationMetadata)> GetDietTypesAsync(int pageNumber, int pageSize)
        {
            var collection = _context.DietTypes as IQueryable<DietType>;
            var totalItemCount = await collection.CountAsync();

            var paginationMetaData = new PaginationMetadata(totalItemCount, pageSize, pageNumber);
            var collectionToReturn = await collection
                .OrderBy(x => x.Id)
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize)
                .ToListAsync();

            return (collectionToReturn, paginationMetaData);

        }

        public async Task<DietType?> GetDietTypeByIdAsync(int dietTypeId)
        {
            var dietTypeExists = await DietTypeExistsAsync(dietTypeId);
            if (!dietTypeExists)
                return null;

            var dietType = await _context.DietTypes.Where(d => d.Id == dietTypeId).FirstOrDefaultAsync();
            return dietType;
        }

        public void AddDietType(DietType dietType)
        {
            _context.DietTypes.Add(dietType);
        }

        public void DeleteDietType(DietType dietType)
        {
            _context.DietTypes.Remove(dietType);
        }

        public async Task<UserDiet?> GetDietForUserAsync(string userName, int dietId)
        {
            var userExists = await _userRepository.UserExistsAsync(userName);
            var dietExists = await DietExistsAsync(dietId);
            if (! (dietExists || userExists) )
                return null;

            var user = await _userRepository.GetUserByNameAsync(userName);

            return await _context.UserDiets.Where(d => d.UserId == user.Id && d.DietId == dietId).FirstOrDefaultAsync();
        }

        public async Task<(List<UserDiet?>, PaginationMetadata)> GetDietsForUserAsync(string userName, int pageNumber, int pageSize)
        {
            if(await _userRepository.UserExistsAsync(userName))
            {
                var user = await _userRepository.GetUserByNameAsync(userName);
                var collection = _context.UserDiets as IQueryable<UserDiet>;
                var totalItemCount = await collection.CountAsync();
                var paginationMetaData = new PaginationMetadata(totalItemCount, pageSize, pageNumber);

                var collectionToReturn = await collection
                .Where(d => d.UserId == user.Id)
                .OrderBy(x => x.DietId)
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize)
                .ToListAsync();

            return (collectionToReturn, paginationMetaData);

            }

            return (null,null);
            
        }

        public void DeleteDietForUser(UserDiet userDiet)
        {
            _context.UserDiets.Remove(userDiet);
        }

        public async Task ClearDietsForUserAsync(string userName)
        {
           var user = await _userRepository.GetUserByNameAsync(userName);
           await _context.UserDiets.Where(d => d.UserId == user.Id).ExecuteDeleteAsync();
        }

        public void AddUserDiet(UserDiet diet)
        {
            _context.UserDiets.Add(diet);
        }
    }
}
