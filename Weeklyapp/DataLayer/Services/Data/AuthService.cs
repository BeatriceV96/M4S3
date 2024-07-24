using Weeklyapp.DataLayer.Services.Interfaces;
using Weeklyapp.DataLayer.Entities;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Weeklyapp.DataLayer.Services.Data
{
    public class AuthService : IAuthService
    {
        private readonly string _connectionString;
        private const string LOGIN_COMMAND = "SELECT Username FROM Dipendenti WHERE Username = @user AND Password = @pass";

        public AuthService(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("AuthDb");
        }

        public ApplicationUser Login(string username, string password)
        {
            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            using var cmd = new SqlCommand(LOGIN_COMMAND, conn);
            cmd.Parameters.AddWithValue("@user", username);
            cmd.Parameters.AddWithValue("@pass", password);
            using var r = cmd.ExecuteReader();
            if (r.Read())
            {
                return new ApplicationUser { UserName = username, Password = password };
            }

            return null;
        }
    }
}
