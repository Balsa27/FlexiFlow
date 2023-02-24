namespace FlexiFlow.Infrastructure.Jwt;

public interface IJwtUtils
{
    string GenerateUserToken(User account);
    string GenerateOrganizationToken(Organization account);
    Guid? ValidateToken(string token);
}