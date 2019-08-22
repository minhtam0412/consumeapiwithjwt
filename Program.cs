using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thinktecture.IdentityModel.Client;

namespace ConsumeWebAPIOauth2
{
    class Program
    {
        private static string URL = @"http://localhost:17298";
        static void Main(string[] args)
        {
            var token = GetToken();
            Console.WriteLine("Token type: {0}", token.TokenType);
            Console.WriteLine("Token: {0}", token.AccessToken);
            Console.WriteLine("Refresh token: {0}", token.RefreshToken);
            Console.WriteLine("--------------------REFRESH-------------------------");
            var refreshToken = RefreshToken(token.RefreshToken);
            Console.WriteLine("Token type: {0}", refreshToken.TokenType);
            Console.WriteLine("Token: {0}", refreshToken.AccessToken);
            Console.WriteLine("Refresh token: {0}", refreshToken.RefreshToken);
            Console.ReadKey();
        }

        private static TokenResponse GetToken()
        {
            var client = new OAuth2Client(new Uri(URL + "/token"), "74AAF591-0A89-4C5C-8E73-47C0C54036FF", "E90E5C0C-EACA-4A25-8CF6-AEAC1A897E2C");
            var response = client.RequestResourceOwnerPasswordAsync("admin", "admin").Result;
            return response;
        }

        private static TokenResponse RefreshToken(string refreshToken)
        {
            var client = new OAuth2Client(new Uri(URL + "/token"), "74AAF591-0A89-4C5C-8E73-47C0C54036FF", "E90E5C0C-EACA-4A25-8CF6-AEAC1A897E2C");
            var response = client.RequestRefreshTokenAsync(refreshToken).Result;
            return response;
        }
    }
}
