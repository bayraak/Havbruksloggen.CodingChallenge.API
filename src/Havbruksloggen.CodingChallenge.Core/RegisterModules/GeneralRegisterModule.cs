using Autofac;
using Havbruksloggen.CodingChallenge.Core.Repositories;
using Havbruksloggen.CodingChallenge.Core.Services;

namespace Havbruksloggen.CodingChallenge.Core.RegisterModules
{
    public class GeneralRegisterModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserRepository>().As<IUserRepository>();
            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<BoatService>().As<IBoatService>();
            builder.RegisterType<BoatRepository>().As<IBoatRepository>();
        }
    }
}
