﻿using Autofac;
using Microsoft.Extensions.Configuration;
using Server.Infrastructure.EF;
using Server.Infrastructure.Extensions;
using Server.Infrastructure.Settings;
namespace Server.Infrastructure.IoC.Modules
{
    public class SettingsModule : Autofac.Module
    {
        private readonly IConfiguration _configuration;

        public SettingsModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(_configuration.GetSettings<GeneralSettings>())
                   .SingleInstance();
            builder.RegisterInstance(_configuration.GetSettings<JwtSettings>())
                   .SingleInstance();
            //builder.RegisterInstance(_configuration.GetSettings<MongoSettings>())
            //       .SingleInstance();
            builder.RegisterInstance(_configuration.GetSettings<SqlSettings>())
                   .SingleInstance();
            builder.RegisterInstance(_configuration.GetSettings<ImageStorageSettings>())
                  .SingleInstance();
        }
    }
}
