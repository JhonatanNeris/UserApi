using Microsoft.AspNetCore.Authorization;

namespace UserApi.Authorization
{
    public class MinimunAge : IAuthorizationRequirement
    {
        public int Age { get; }
        public MinimunAge(int age)
        {
            Age = age;
        }
    }
}
