using BCS.Directory.CORE.Entity;
using BCS.Directory.DAO;
using BCS.Directory.DAO.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BCS.Directory.Service
{
    public static class Startup
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IEmployeeService, EmployeeService>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient(typeof(IGenericRepository<EntityBase<int>, int>), typeof(GenericRepository<EntityBase<int>, int>));
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
        }

    }
}
