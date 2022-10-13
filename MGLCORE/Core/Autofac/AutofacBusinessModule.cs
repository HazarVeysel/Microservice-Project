using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Core.Services;

namespace Core.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AuthApiService>().As<IAuthApiService>().SingleInstance();
            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<CompanyService>().As<ICompanyService>();


            //builder.RegisterType<EmailParameterManager>().As<IEmailParameterService>();
            //builder.RegisterType<EFEmailParameterDal>().As<IEmailParameterDal>();

            //builder.RegisterType<UserManager>().As<IUserService>();
            //builder.RegisterType<EFUserDal>().As<IUserDal>();

            //builder.RegisterType<AuthManager>().As<IAuthService>();
            //builder.RegisterType<JwtHelper>().As<ITokenHelper>();
        }
    }
}
