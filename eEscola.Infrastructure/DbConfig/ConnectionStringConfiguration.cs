using eEscola.Domain.Interfaces;
using Microsoft.Extensions.Configuration;

namespace eEscola.Infrastructure.DbConfig
{
    public class ConnectionStringConfiguration : IConnectionStringConfiguration
    {
        private readonly IConfiguration _configuration;

        public ConnectionStringConfiguration(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string? GetConnectionString()
        {
            return _configuration.GetConnectionString("PostgreSQL");
        }
    }
}
