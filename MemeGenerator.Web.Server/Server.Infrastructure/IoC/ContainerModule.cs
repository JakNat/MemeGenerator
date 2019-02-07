using Autofac;
using AutoMapper.Configuration;
using Server.Infrastructure.IoC.Modules;
using Server.Infrastructure.Mappers;

namespace Server.Infrastructure.IoC
{
    public class ContainerModule : Autofac.Module
    {
        private readonly IConfiguration _configuration;

        public ContainerModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(AutoMapperConfig.Initialize())
                .SingleInstance();
            builder.RegisterModule<CommandModule>();
            builder.RegisterModule<RepositoryModule>();
            //builder.RegisterModule<MongoModule>();
            //builder.RegisterModule<SqlModule>();
            builder.RegisterModule<ServiceModule>();
            //builder.RegisterModule(new SettingsModule(_configuration));
        }
    }
}
