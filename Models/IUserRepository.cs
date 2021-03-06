using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace share_login_api.Models
{
    public interface IUserRepository
    {
        User Create(User user);

        User GetByEmail(string email);

        User GetById(int id);
    }
}
