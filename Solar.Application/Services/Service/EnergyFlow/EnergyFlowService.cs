using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Solar.Application.DTOs.EnergyFlow;
using Solar.Application.Services.Interfaces.EnergyFlow;
using Solar.Domain.EnergyFlow;
using Solar.Infrastructure.Repository.Interface.EnergyFlow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Solar.Application.Services.Service.EnergyFlow
{

    public class EnergyFlowService : IEnergyFlowService
    {
        private readonly IEnergyFlowRepository _energyFlowRepository;
        private readonly IMapper _mapper;
        public EnergyFlowService(IMapper mapper, IEnergyFlowRepository energyFlowRepository)
        {
            _mapper = mapper;
            _energyFlowRepository = energyFlowRepository;
        }
        public async Task<ActionResult<EnergyFlowDTO>> GetFlowData()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, "https://api.solarweb.com/swqapi/pvsystems/8a5788a9-987a-4413-976d-691dd9c13aeb/flowdata");
            request.Headers.Add("AccessKeyId", "FKIA89D5AC35AF014EE5AED542CFA2DED97D");
            request.Headers.Add("AccessKeyValue", "1c0d5416-fcdc-4ff0-a974-7de953602dfb");
            request.Headers.Add("Cookie", "TS0153f740=015bdaa268f1faa4c5b5171877532276edce97fad153d47339a748434f492940804f0dd4e810c07c9d88d87e4e67939e02de3e984821cd2228d46df6d0dfec79c610a29634; lbc=!So3fDAe2tZ1yyFIrENFjkLE5nH6cEnkwif/hFmyPQc1+utizL9V9hY+nur80U3+bJt9t+4zCazItsvgMp6P12IAaoJLzOsTTsBV2ouKhku8=");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var result = response.Content.ReadFromJsonAsync<EnergyFlowDTO>().Result;
            var pvSystemId = result.PvSystemId;

            var energyFlowData = new EnergyFlowData();
            foreach (var item in result.Data.Channels)
            {
                if (string.Compare(item.ChannelName, "PowerFeedIn") == 0)
                {
                    energyFlowData.PowerFeedIn = item.Value;
                }
                else if (string.Compare(item.ChannelName, "PowerLoad") == 0)
                {
                    energyFlowData.PowerLoad = item.Value;
                }
                else if (string.Compare(item.ChannelName, "PowerBattCharge") == 0)
                {
                    energyFlowData.PowerBattCharge = item.Value;
                }
                else if (string.Compare(item.ChannelName, "PowerPV") == 0)
                {
                    energyFlowData.PowerPV = item.Value;
                }
                else if (string.Compare(item.ChannelName, "PowerOutput") == 0)
                {
                    energyFlowData.PowerOutput = item.Value;
                }
                else if (string.Compare(item.ChannelName, "BattSOC") == 0)
                {
                    energyFlowData.BattSOC = item.Value;
                }
                else if (string.Compare(item.ChannelName, "RateSelfConsumption") == 0)
                {
                    energyFlowData.RateSelfConsumption = item.Value;
                }
                else if (string.Compare(item.ChannelName, "RateSelfSufficiency") == 0)
                {
                    energyFlowData.RateSelfSufficiency = item.Value;
                }
                else if (string.Compare(item.ChannelName, "PowerEVCTotal") == 0)
                {
                    energyFlowData.PowerEVCTotal = item.Value;
                }
                else if (string.Compare(item.ChannelName, "PowerOhmpilot") == 0)
                {
                    energyFlowData.PowerOhmpilot = item.Value;
                }
            }
            _energyFlowRepository.Add(energyFlowData);
            _energyFlowRepository.SaveChanges();


            //foreach (var item in result.Data.Channels)
            //{
            //    var energyFlow = new EnergyFlowData();
            //    energyFlow.ChannelName = item.ChannelName;
            //    energyFlow.ChannelType = item.ChannelType;
            //    energyFlow.Value = item.Value;
            //    energyFlow.Unit = item.Unit;
            //    try
            //    {
            //        _energyFlowRepository.Add(energyFlow);

            //        _energyFlowRepository.SaveChanges();
            //    }
            //    catch (Exception e) { }
            //}

            return result;
        }
    }
}
