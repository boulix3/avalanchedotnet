using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<AvalancheDotNet.Dto.AvalancheConfig> (new AvalancheDotNet.Dto.AvalancheConfig("http://box:9650/ext/info"));
        }
    }
}
