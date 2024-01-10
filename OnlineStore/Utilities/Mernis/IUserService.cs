using OnlineStore.Models.Concrete;

namespace OnlineStore.Utilities.Mernis
{
    public interface IUserService
    {
        bool CheckUser(ApplicationUser applicationUser);
    }
}
