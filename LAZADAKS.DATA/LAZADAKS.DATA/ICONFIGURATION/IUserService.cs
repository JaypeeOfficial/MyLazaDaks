
using LAZADAKS.DATA.JWT.AUTHENTICATION;

namespace LAZADAKS.DATA.ICONFIGURATION
{
    public  interface IUserService
    {

        AuthenticateResponse Authenticate(AuthenticationRequest request);


    }
}
