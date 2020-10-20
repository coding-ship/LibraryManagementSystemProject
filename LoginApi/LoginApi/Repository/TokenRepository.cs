using LoginApi.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginApi.Repository
{
    public class TokenRepository:ITokenRepository
    {
        private IConfiguration _config;
        private DatabaseDbContext _context;
        public TokenRepository(IConfiguration config, DatabaseDbContext context)
        {
            _config = config;
            _context = context;

        }

        public Usercheck AuthenticateUser(Usercheck users)
        {
            Usercheck user = null;

            List<Usercheck> alluser = _context.Usercheck.ToList();
            foreach (var v in alluser)
            {
                if (v.Id == users.Id && v.Password == users.Password)
                {
                    user = new Usercheck { Id = users.Id, Password = users.Password };
                    return user;
                }
            }
            return user;
        }
        public string GenerateJSONWebToken(Usercheck userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                null,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

