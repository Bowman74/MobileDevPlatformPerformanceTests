using System.Collections.Generic;
using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;

namespace PerfTest1Xamarin
{
    public static class AzureTable
    {
        private static MobileServiceClient mobileService = new MobileServiceClient(
            "https://malor2014jsmobileservice.azure-mobile.net/",
			"pdFskoBXcwzaDNTpuRWdVRhUIRYcFF14");

        public static async Task<IList<Registration>> GetRegistrationsAsync()
        {
            return await mobileService.GetTable<Registration>().Take(1000).ToListAsync();
        }
    }
}