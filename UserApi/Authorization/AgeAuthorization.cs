using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace UserApi.Authorization
{
    public class AgeAuthorization : AuthorizationHandler<MinimunAge>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MinimunAge requirement)
        {
            //var birthDateClaim = context.User.FindFirst(c => c.Type == "BirthDate");
            var birthDateClaim = context.User.FindFirst(c => c.Type == ClaimTypes.DateOfBirth);

            if (birthDateClaim == null)
            {
                return Task.CompletedTask;
            }
            var birthDate = DateTime.Parse(birthDateClaim.Value);

            var age = DateTime.Today.Year - birthDate.Year;

            if (birthDate > DateTime.Today.AddYears(-age))
            {
                age--;
            }

            if (age >= requirement.Age)
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}
