using OnlineStore.Models.Entities;
using ServiceReference1;

namespace OnlineStore.Utilities.Mernis
{
    public class KpsServiceAdapter : IUserService
    {
        public bool CheckUser(ApplicationUser applicationUser)
        {
            var kpsPublicSoap = new KPSPublicSoapClient(KPSPublicSoapClient.EndpointConfiguration.KPSPublicSoap);

            var result = kpsPublicSoap.TCKimlikNoDogrulaAsync(Convert.ToInt64(applicationUser.IdentityNumber),
                applicationUser.Name, applicationUser.LastName, applicationUser.Birthday.Year
                ).Result;
            return result.Body.TCKimlikNoDogrulaResult;
        }
    }
}
