using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zeroconf;

namespace NanoleafHome.Helpers
{
    public static class AuroraHelper
    {
        public static async Task<IZeroconfHost> ProbeForAuroras()
        {
            IReadOnlyList<IZeroconfHost> results = await ZeroconfResolver.ResolveAsync("_nanoleafapi._tcp.local.").ConfigureAwait(false);

            return results.FirstOrDefault();
        }
    }
}
