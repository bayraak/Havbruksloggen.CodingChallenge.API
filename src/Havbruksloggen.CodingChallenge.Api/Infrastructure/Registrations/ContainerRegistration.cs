using Autofac;
using Havbruksloggen.CodingChallenge.Core.RegisterModules;

namespace Havbruksloggen.CodingChallenge.Api.Infrastructure.Registrations
{
    public static class ContainerRegistration
    {
        public static void RegisterModules(ContainerBuilder builder)
        {
            builder.RegisterModule<GeneralRegisterModule>();
        }
    }
}
