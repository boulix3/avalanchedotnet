﻿using AvalancheDotNet;
using AvalancheDotNet.Apis;
using AvalancheDotNet.Common.Records;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(new AvalancheCore("https://api.avax-test.network"));
            services.AddSingleton(new HttpClient());
            services.AddTransient<AvalancheDotNet.Apis.InfoApi>();            
        }
    }
}
