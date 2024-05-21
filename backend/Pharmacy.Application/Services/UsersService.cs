using PharmacyStore.Core.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using PharmacyStore.DataAccess.Repositories;

namespace Pharmacy.Application.Services
{
    public class UserService(IUsersRepository userRepository) : IUsersService
    {
        private readonly IUsersRepository _userRepository = userRepository;
        private readonly string secretKey = "zhendoszhendoszhendoszhendoszhendoszhendoszhendoszhendoszhendoszhendoszhendoszhendoszhendoszhendos";

        public string Generate(string password) =>
            BCrypt.Net.BCrypt.EnhancedHashPassword(password);

        public string GenerateToken(User user)
        {
            ArgumentNullException.ThrowIfNull(user);

            var singningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
                SecurityAlgorithms.HmacSha256
                );

            var token = new JwtSecurityToken(
 
                signingCredentials: singningCredentials
                );
            var tokenValue = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenValue;
        }

        public async Task<Guid> Register(User user)
        {
            user.Password = Generate(user.Password);

            return await _userRepository.Create(user);
        }

        public async Task<string> Login(User userLogin)
        {
            var userPassword = await _userRepository.Get(userLogin.Login);

            var result = Verify(userLogin.Password, userPassword);
            if (result == false)
            {
                throw new Exception("Неверный пароль");
            }
            var token = GenerateToken(userLogin);

            return token;
        }

        public bool Verify(string password, string passwordHash)
        {
            return BCrypt.Net.BCrypt.EnhancedVerify(password, passwordHash);
        }
    }
}
