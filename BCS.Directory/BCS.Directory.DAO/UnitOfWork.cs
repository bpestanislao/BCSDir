using BCS.Directory.CORE.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BCS.Directory.DAO
{
    public class UnitOfWork : IUnitOfWork
    {
        private BCSContext _context;
        public UnitOfWork(BCSContext context)
        {
            if (context == null)
                throw new ArgumentNullException("BCSContext");
            _context = context;
        }
        private bool disposed = false;

        public DbContext Context
        {
            get { return _context; }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
