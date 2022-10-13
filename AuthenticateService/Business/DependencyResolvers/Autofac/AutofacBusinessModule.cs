using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.DataAccess.EntityFramework;
using Core.Utilities.Interceptors;
using Core.Utilities.JWT;

namespace Business.DependencyResolvers.Autofac
{
    /// <summary>
    /// Burada;
    /// -Service ile Manager'ı,
    /// -IEntryTypeDal ile de EFEntryTypeDal'ı eşleştireceğiz
    /// </summary>
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EntryTypeManager>().As<IEntryTypeService>();
            builder.RegisterType<EFEntryTypeDal>().As<IEntryTypeDal>();

      
            builder.RegisterType<EmailParameterManager>().As<IEmailParameterService>();
            builder.RegisterType<EFEmailParameterDal>().As<IEmailParameterDal>();

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EFUserDal>().As<IUserDal>();

            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces().EnableInterfaceInterceptors(new ProxyGenerationOptions()
            {
                Selector = new AspectInterceptorSelector()
            }).SingleInstance();
        }
    }
}