using DevOne.Security.Cryptography.BCrypt;
using FlexiFlow.Exception;
using FlexiFlow.Infrastructure.Jwt;
using FlexiFlow.Model.Request;
using FlexiFlow.Model.Response;
using FlexiFlow.Repository.Interface;

namespace FlexiFlow.Service.Implementation;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IOrganizationRepository _organizationRepository;
    private readonly IJwtUtils _jwtUtils;

    public AuthService(IUserRepository repository,
        IOrganizationRepository organizationRepository,
        IJwtUtils jwtUtils)
    {
        _userRepository = repository;
        _organizationRepository = organizationRepository;
        _jwtUtils = jwtUtils;
    }

    public UserLoginResponse LoginUser(UserLoginRequest request)
    {
        User? user = _userRepository.GetByEmail(request.email);
        
        if (user is null || !BCryptHelper.CheckPassword(request.password, user.Password))
            throw new InvalidCredentialsException("Invalid credentials");
        
        var token = _jwtUtils.GenerateUserToken(user);

        return new UserLoginResponse(
            user.Id,
            token,
            user.Email,
            user.Password,
            user.Address,
            user.FirstName,
            user.LastName);
    }

    public UserRegisterResponse RegisterUser(UserRegisterRequest request) //logs in user after registration
    {
        if(_userRepository.GetAll().Any(x => x.Email == request.email))
            throw new DuplicateEmailException("Email already taken");
        
        User user = new User(
            request.email,
            BCryptHelper.HashPassword(request.password, BCryptHelper.GenerateSalt()),
            request.address,
            request.firstName,
            request.lastName);

        _userRepository.Add(user);
        
        var token = _jwtUtils.GenerateUserToken(user);
        
        return new UserRegisterResponse(
            user.Id,
            token,
            user.Email,
            user.Password,
            user.Address,
            user.FirstName,
            user.LastName);
    }

    public OrganizationRegisterResponse RegisterOrganization(OrganizationRegisterRequest request)
    {
        if(_organizationRepository.GetAll().Any(x => x.Email == request.email))
            throw new DuplicateEmailException("Email already taken");

        var organization = new Organization(
            request.email,
            BCryptHelper.HashPassword(request.password, BCryptHelper.GenerateSalt()),
            request.address,
            request.organizationName,
            null
            );
        
        _organizationRepository.Add(organization);
        
        var token = _jwtUtils.GenerateOrganizationToken(organization);
        
        return new OrganizationRegisterResponse(
            organization.Id,
            token,
            organization.Email,
            organization.Password,
            organization.Address,
            organization.OrganizationName,
            organization.Users
            );
    }

    public OrganizationLoginResponse LoginOrganization(OrganizationLoginRequest request)
    {
        Organization? organization = _organizationRepository.GetByEmail(request.email);
        
        if (organization is null || !BCryptHelper.CheckPassword(request.password, organization.Password))
            throw new InvalidCredentialsException("Invalid credentials");
        
        var token = _jwtUtils.GenerateOrganizationToken(organization);

        return new OrganizationLoginResponse(
            organization.Id,
            token,
            organization.Email,
            organization.Password,
            organization.Address,
            organization.OrganizationName,
            organization.Users
            );
    }

    public User? CheckToken(string token)
    {
        throw new NotImplementedException();
    }
}