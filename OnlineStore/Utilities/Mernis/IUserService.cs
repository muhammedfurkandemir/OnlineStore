using OnlineStore.Models.Entities;

namespace OnlineStore.Utilities.Mernis
{
    public interface IUserService
    {
        bool CheckUser(ApplicationUser applicationUser);
    }
}
