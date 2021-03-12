using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly DatabaseContext context;
        private bool disposed = false;

        public UnitOfWork(DatabaseContext context)
        {
            this.context = context;
        }

        public void Commit()
        {
            context.SaveChanges();
        }

        //Implement IDisposable
        public void Dispose() 
        {
            Dispose(true);

            //SuppressFinalize should only be called by a class that has a finalizer.
            //It's informing the Garbage Collector (GC) that this object was cleaned up fully.
            //So call GC.SuppressFinalize(this) remove reference in finalization queue.
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool isDisposed)
        {
            // Release unmanaged resources.
            if (!disposed && !isDisposed)
                context.Dispose();

            disposed = true;
        }
    }
}
