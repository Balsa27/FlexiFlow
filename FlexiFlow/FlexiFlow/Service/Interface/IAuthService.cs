using FlexiFlow.Model.Request;
using FlexiFlow.Model.Response;

namespace FlexiFlow.Service;

public interface IAuthService
{
    UserLoginResponse LoginUser(UserLoginRequest request);
    UserRegisterResponse RegisterUser(UserRegisterRequest request);
    OrganizationRegisterResponse RegisterOrganization(OrganizationRegisterRequest request); //should be mapped on controller lvl but is ok :)
    OrganizationLoginResponse LoginOrganization(OrganizationLoginRequest request); //should be mapped on controller lvl but is ok :)
    User? CheckToken(string token);
}