namespace Solar.Infrastructure.Repository.Interface.User;

public interface IUserRepository
{
    Domain.User.User GetById(int id);
    ICollection<Domain.User.User> GetAll();
    Domain.User.User GetByUserEmail(string userEmail);
}