﻿using System.Collections.Generic;
using ConfigurationReader.Interfaces;

namespace ConfigurationReader.ConfigurationProviders
{
    public class CloudConfigurationProvider<T> : ConfigurationProvider<T>
    {
        public CloudConfigurationProvider(IConfigurationManager configurationManager) : base(configurationManager)
        {
        }

        protected override Dictionary<string, T> GetConfigurationFromStorage()
        {
            throw new System.NotImplementedException();
        }
    }
}