using System.Linq;
using Microsoft.Build.Locator;

namespace Amazon.Common.DotNetCli.Tools
{
    public static class MSBuildInitializer
    {
        /// <summary>
        /// This is required to bind to the latest SDK owned MSBuild assembly. It must be ran before any MSBuild code is JITted.
        /// </summary>
        public static void Initialize()
        {
            var instance = MSBuildLocator.QueryVisualStudioInstances(new VisualStudioInstanceQueryOptions()
                {
                    DiscoveryTypes = DiscoveryType.DotNetSdk
                })
                .FirstOrDefault();
            
            MSBuildLocator.RegisterInstance(instance);
        }
    }
}