using Core.Entities;
using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
    public class UserRepository : Repository<Entity>, IUserRepository
    {
        public UserRepository(DatabaseContext context) : base (context)
        {
        }
    }
}
