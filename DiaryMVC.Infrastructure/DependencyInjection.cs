using DiaryMVC.Domain.Interface;
using DiaryMVC.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiaryMVC.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<ITaskRepositories, TaskRepositories>();
            services.AddTransient<ISubjectRepositories, SubjectRepositories>();
            return services;
        }
    }
}
