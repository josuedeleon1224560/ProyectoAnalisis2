using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Data;
using ProyectoFinal.Interfaces;
using ProyectoFinal.Models;

namespace ProyectoFinal.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AplicationDbContext _context;

        public UserRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(AppUser user)
        {
            _context.Add(user);
            return Save();
        }

        public bool Delete(AppUser user)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<AppUser>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<AppUser> GetUserById(string id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<AppUser> GetByIdAsyncNoTracking(string id)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(AppUser user)
        {
            _context.Update(user);
            return Save();
        }
    }
}
