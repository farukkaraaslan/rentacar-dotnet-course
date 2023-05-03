using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Concrete;
using Business.Rules;
using Business.Rules.Validation.FluentValidation;
using Core.Helpers.FileHelper;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.Extensions.DependencyInjection;

namespace Business.DependencyResolvers
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterBusinessService(this IServiceCollection services)
        {
            services
                .AddSingleton<IBrandDal, EfBrandDal>()
                .AddSingleton<IBrandService, BrandManager>()
                .AddSingleton<BrandBusinesRules>()
                .AddSingleton<BrandValidator>()

                .AddSingleton<ICarDal, EfCarDal>()
                .AddSingleton<ICarService, CarManager>()
                .AddSingleton<CarBusinessRules>()
                .AddSingleton<CarValidator>()

                .AddSingleton<IColorDal, EfColorDal>()
                .AddSingleton<IColorService, ColorManager>()
                .AddSingleton<ColorBusinessRules>()
                .AddSingleton<ColorValidator>()

                .AddSingleton<IRentalDal, EfRentalDal>()
                .AddSingleton<IRentalService, RentalManager>()
                .AddSingleton<RentalBusinessRules>()

                .AddSingleton<ICarImageDal, EfCarImageDal>()
                .AddSingleton<ICarImageService, CarImageManager>()
                .AddSingleton<IFileHelper, FileHelper>()

                .AddSingleton<IPaymentDal, EfPaymentDal>()


                .AddSingleton<IPaymentService, PaymentManager>()
                .AddSingleton<PaymentBusinessRules>()
                .AddSingleton<PaymentValidator>()
                .AddSingleton<PaymentDtoValidator>()
                
                .AddSingleton<IInvoiceDal, EfInvoiceDal>()
                .AddSingleton<IInvoiceService, InvoiceManager>()
                
                ;

               
                    
            return services;
        }
    }
}
