using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Absract;
using Business.Concrete;
using Business.Rules;
using Business.Rules.Validation.FluentValidation;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.Extensions.DependencyInjection;

namespace Business.DependencyResolvers
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterBusinessService(this IServiceCollection services)
        {
            services.AddSingleton<IBrandDal, EfBrandDal>()
                    .AddSingleton<IBrandService, BrandManager>()
                    .AddSingleton<BrandBusinesRules>()
                    .AddSingleton<CarBusinessRules>()
                    .AddSingleton<ColorBusinessRules>()
                    .AddSingleton<BrandValidator>()
                    .AddSingleton<CarValidator>()
                    .AddSingleton<ColorValidator>()
                    .AddSingleton<ICarDal, EfCarDal>()
                    .AddSingleton<ICarService, CarManager>()
                    .AddSingleton<IColorDal, EfColorDal>()
                    .AddSingleton<IColorService, ColorManager>();
            return services;
        }
    }
}
