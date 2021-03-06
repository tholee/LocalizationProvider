﻿using EPiServer.Core;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using InitializationModule = EPiServer.Web.InitializationModule;

namespace DbLocalizationProvider.EPiServer.Sample
{
    [InitializableModule]
    [ModuleDependency(typeof(InitializationModule))]
    public class InitLocalization : IInitializableModule
    {
        public void Initialize(InitializationEngine context)
        {
            ConfigurationContext.Setup(cfg =>
            {
                cfg.DiagnosticsEnabled = true;
                cfg.ModelMetadataProviders.EnableLegacyMode = () => true;
                cfg.CustomAttributes = new[]
                {
                    new CustomAttributeDescriptor(typeof(HelpTextAttribute), false)
                };

                cfg.ForeignResources.Add(typeof(VersionStatus));
            });
        }

        public void Uninitialize(InitializationEngine context) { }
    }
}
