using CustomerManagementAPI.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CustomerManagementAPI
{
    public static class MigrationDatabase
    {
        public static async Task Run(WebApplication webHost)
        {
            var logger = webHost.Services.GetService<ILogger<Program>>();

            try
            {
                logger.LogInformation($"MigrationDatabase.Run is running");

                var dbContext = webHost.Services.GetService<CustomerContext>();
                if (dbContext?.Database != null)
                {
                    await dbContext.Database.MigrateAsync();
                }

                logger.LogInformation($"MigrationDatabase.Run is finished successfully");
                return;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"MigrationDatabase.Run is failed");
                return;
            }
        }
    }
}
