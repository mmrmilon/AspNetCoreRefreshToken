using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Repositories
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
