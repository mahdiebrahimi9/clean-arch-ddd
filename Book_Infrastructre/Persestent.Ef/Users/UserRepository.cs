using Book_Domain.Users;
using Book_Domain.UsersAgg.Repository;
using Microsoft.EntityFrameworkCore;

namespace Book_Infrastructre.Persestent.Ef.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly BookDbContext _context;
        public UserRepository(BookDbContext context)
        {
            _context = context;
        }
        public void Add(User user)
        {
            _context.Add(user);
        }

        public async Task<User> GetById(long id)
        {
            return await _context.Users.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(User user)
        {
            _context.Update(user);
        }
    }
}
