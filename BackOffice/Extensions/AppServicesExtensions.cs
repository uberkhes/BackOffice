using BackOffice.Domain.Interfaces.Users;
using BackOffice.Application.Users;
using Microsoft.AspNetCore.Mvc;
using BackOffice.Infrastructure.Repositories.Users;

namespace BackOffice.Extensions;

public static class AppServicesExtensions
{
    public static IServiceCollection AddAppServices(this IServiceCollection services)
    {
        services.AddScoped<IUsersService, UsersService>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.Configure<ApiBehaviorOptions>(options =>
          options.InvalidModelStateResponseFactory = ActionContext =>
          {
              var error = ActionContext.ModelState
                          .Where(e => e.Value.Errors.Count > 0)
                          .SelectMany(e => e.Value.Errors)
                          .Select(e => e.ErrorMessage).ToArray();
              return new BadRequestObjectResult(error);
          }
        );
        return services;
    }
}
