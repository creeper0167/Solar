using Solar.Application.DTOs.EnergyFlow;
using Solar.Application.Services.Interfaces.EnergyFlow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solar.Application.Services.Service.EnergyFlow
{
    public class EnergyFlowService : IEnergyFlowService
    {
        public async Task<EnergyFlowDataDTO> GetFlowData()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, "https://api.solarweb.com/swqapi/pvsystems/8a5788a9-987a-4413-976d-691dd9c13aeb/flowdata");
            request.Headers.Add("AccessKeyId", "FKIA89D5AC35AF014EE5AED542CFA2DED97D");
            request.Headers.Add("AccessKeyValue", "1c0d5416-fcdc-4ff0-a974-7de953602dfb");
            request.Headers.Add("Cookie", "TS0153f740=015bdaa268f1faa4c5b5171877532276edce97fad153d47339a748434f492940804f0dd4e810c07c9d88d87e4e67939e02de3e984821cd2228d46df6d0dfec79c610a29634; lbc=!So3fDAe2tZ1yyFIrENFjkLE5nH6cEnkwif/hFmyPQc1+utizL9V9hY+nur80U3+bJt9t+4zCazItsvgMp6P12IAaoJLzOsTTsBV2ouKhku8=");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            Console.WriteLine(await response.Content.ReadAsStringAsync());

            var result = await response.Content.ReadAsStringAsync();
            return result;
        }
    }
}
