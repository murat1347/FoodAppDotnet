using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TilkiWeb.Application.Abstractions
{
    public interface IInternalAuthentication
    {
        Task<Dtos.Token> LoginAsync(string usernameOrEmail, string password, int accessTokenLifeTime);
        Task<Dtos.Token> RefreshTokenLoginAsync(string refreshToken);
    }
}
