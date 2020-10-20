using LoginApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginApi.Repository
{
   public interface ITokenRepository
    {
        public Usercheck AuthenticateUser(Usercheck user);
        public string GenerateJSONWebToken(Usercheck userInfo);
    }
}
