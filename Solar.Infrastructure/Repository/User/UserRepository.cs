using Solar.Infrastructure.Context;
using Solar.Infrastructure.Repository.Interface.User;

namespace Solar.Infrastructure.Repository.User;

public class UserRepository : IUserRepository
{
    private SolarDbContext _context;

    public UserRepository(SolarDbContext solarDbContext)
    {
        _context = solarDbContext;
    }
    public Domain.User.User GetById(int id)
    {
        return _context.Users.Find(id);
    }

    public ICollection<Domain.User.User> GetAll()
    {
        return _context.Users.ToList();
    }

    public Domain.User.User GetByUserEmail(string userEmail)
    {
        return _context.Users.Where(i => string.Compare(i.Email, userEmail) == 0).FirstOrDefault();
    }

    public void InsertAsync(Domain.User.User user)
    {
        _context.Users.AddAsync(user);
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }
}