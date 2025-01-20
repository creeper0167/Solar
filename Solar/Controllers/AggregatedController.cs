using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using Solar.Application.DTOs;
using Solar.Application.Services.Interface;
using System.Text.Json;

namespace Solar.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AggregatedController : Controller
    {
        IAggregateService _aggregateService;
        public AggregatedController(IAggregateService aggregateService)
        {
            _aggregateService = aggregateService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, "https://api.solarweb.com/swqapi/pvsystems/8a5788a9-987a-4413-976d-691dd9c13aeb/aggdata?pvSystemId=8a5788a9-987a-4413-976d-691dd9c13aeb");
            request.Headers.Add("AccessKeyId", "FKIA89D5AC35AF014EE5AED542CFA2DED97D");
            request.Headers.Add("AccessKeyValue", "1c0d5416-fcdc-4ff0-a974-7de953602dfb");
            request.Headers.Add("Cookie", "TS0153f740=015bdaa2681a68d1b91a5d15f2a7f4927a288e719e05f04c36c10e6431d8fdccc855122fe1c2c8a94cf84a1f2787644b3428d9fc973317674d6539b7de0224ad99efa9b98e; lbc=!A+UCnHkEx0yLlYzhmGaVQc9UUUixhFP+b7c8O7O135zly11uKiBZVqS8tE3XvEmET8RWGyq46LSHRotE5Mk0qGhWsMNiW+tOTwmsk72AWnM=");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var result = response.Content.ReadFromJsonAsync<AggregateDTO>().Result;
            var pvSystemId = result.PvSystemId;

            result.PvSystemId = pvSystemId;
            AggregateSubmitDTO aggregateSubmitDTO = new AggregateSubmitDTO();
            aggregateSubmitDTO.LogDateTime = DateTime.Now;
            aggregateSubmitDTO.PvSystemId = pvSystemId;
            foreach (var item in result.Data.Channels)
            {
                if (string.Compare(item.ChannelName, "EnergyOutput") == 0)
                {
                    aggregateSubmitDTO.EnergyOutput = item.Values.Total;
                }
                else if (string.Compare(item.ChannelName, "EnergyDirectConsumption") == 0)
                {
                    aggregateSubmitDTO.EnergyDirectConsumption = item.Values.Total;
                }
                else if (string.Compare(item.ChannelName, "EnergyProductionTotal") == 0)
                {
                    aggregateSubmitDTO.EnergyProductionTotal = item.Values.Total;
                }
                else if (string.Compare(item.ChannelName, "EnergySelfConsumptionTotal") == 0)
                {
                    aggregateSubmitDTO.EnergySelfConsumptionTotal = item.Values.Total;
                }
                else if (string.Compare(item.ChannelName, "EnergyConsumptionTotal") == 0)
                {
                    aggregateSubmitDTO.EnergyConsumptionTotal = item.Values.Total;
                }
                else if (string.Compare(item.ChannelName, "SavingsCO2") == 0)
                {
                    aggregateSubmitDTO.SavingsCO2 = item.Values.Total;
                }
                else if (string.Compare(item.ChannelName, "SavingsTrees") == 0)
                {
                    aggregateSubmitDTO.SavingsTrees = item.Values.Total;
                }
                else if (string.Compare(item.ChannelName, "SavingsTravelCar") == 0)
                {
                    aggregateSubmitDTO.SavingsTravelCar = item.Values.Total;
                }
                else if (string.Compare(item.ChannelName, "SavingsTravelPlane") == 0)
                {
                    aggregateSubmitDTO.SavingsTravelPlane = item.Values.Total;
                }
                else if (string.Compare(item.ChannelName, "Profits") == 0)
                {
                    aggregateSubmitDTO.Profits = item.Values.Total;
                }
                else if (string.Compare(item.ChannelName, "Earnings") == 0)
                {
                    aggregateSubmitDTO.Earnings = item.Values.Total;
                }
                else if (string.Compare(item.ChannelName, "Savings") == 0)
                {
                    aggregateSubmitDTO.Savings = item.Values.Total;
                }
            }
            _aggregateService.AddAggregate(aggregateSubmitDTO);
            _aggregateService.SaveChanges();

            return Ok(result);
        }

        [HttpGet("/years")]
        public async Task<IActionResult> GetAggregateYear()
        {
            //request
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, "https://api.solarweb.com/swqapi/pvsystems/8a5788a9-987a-4413-976d-691dd9c13aeb/aggdata/years");
            request.Headers.Add("AccessKeyId", "FKIA89D5AC35AF014EE5AED542CFA2DED97D");
            request.Headers.Add("AccessKeyValue", "1c0d5416-fcdc-4ff0-a974-7de953602dfb");
            request.Headers.Add("Cookie", "TS0153f740=015bdaa268480e92fd2da9a5f0b51e5522c95f0f666dc2f8077afbd10122c3e42e678fef2460304919f51f4e1b84ac2d63dbcbc1fe61c4e9c46dde11aacfa5146d00b667c1; lbc=!S1YGjYObxrF4zgADh2dzVc1rNXSSvYcwl6zjovsciljLXzqmDJGvw23WUX5JAF2/m3TxuBIs5GkAKfJFfU8+U5TEJ3Z+DkeZSbuOFb0TeAA=");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var result = response.Content.ReadFromJsonAsync<Object>().Result;

            //--
            return Ok(result);
        }

        [HttpGet("/years/{year}")]
        public async Task<IActionResult> GetYearByYearValue(string year)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, "https://api.solarweb.com/swqapi/pvsystems/8a5788a9-987a-4413-976d-691dd9c13aeb/aggdata/years/2020");
            request.Headers.Add("AccessKeyId", "FKIA89D5AC35AF014EE5AED542CFA2DED97D");
            request.Headers.Add("AccessKeyValue", "1c0d5416-fcdc-4ff0-a974-7de953602dfb");
            request.Headers.Add("Cookie", "TS0153f740=015bdaa268f94af99a76ebef428c151b24ca8dd252d8e872c0ea6be830d27e11890d535cc0e6f2bdfcf8a06338cd05b75f84d3a6bbad1d08aa66d5a4bee66c7ceadbd8b480; lbc=!vGxddraY18B8jX3FcUwMb3JmQn6jD5PwTX2TChMvC/MAEoL5+CVC8lv9/797wE8jFDLOFNxVh5kW7f9NgYLtOv5seSOmVKSpCAm0k/wi6Qk=");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var result = response.Content.ReadFromJsonAsync<Object>().Result;

            return Ok(result);
        }
        [HttpGet("/years/{year}/months")]
        public async Task<IActionResult> GetMonthsByYearValue(string year)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, "https://api.solarweb.com/swqapi/pvsystems/8a5788a9-987a-4413-976d-691dd9c13aeb/aggdata/years/"+year+"/months");
            request.Headers.Add("AccessKeyId", "FKIA89D5AC35AF014EE5AED542CFA2DED97D");
            request.Headers.Add("AccessKeyValue", "1c0d5416-fcdc-4ff0-a974-7de953602dfb");
            request.Headers.Add("Cookie", "TS0153f740=015bdaa268f94af99a76ebef428c151b24ca8dd252d8e872c0ea6be830d27e11890d535cc0e6f2bdfcf8a06338cd05b75f84d3a6bbad1d08aa66d5a4bee66c7ceadbd8b480; lbc=!vGxddraY18B8jX3FcUwMb3JmQn6jD5PwTX2TChMvC/MAEoL5+CVC8lv9/797wE8jFDLOFNxVh5kW7f9NgYLtOv5seSOmVKSpCAm0k/wi6Qk=");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var result = response.Content.ReadFromJsonAsync<Object>().Result;

            return Ok(result);
        }

        [HttpGet("/years/{year}/months/{month}")]
        public async Task<IActionResult> GetMonthByMonthValue(string year, string month)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, "https://api.solarweb.com/swqapi/pvsystems/8a5788a9-987a-4413-976d-691dd9c13aeb/aggdata/years/"+year+"/months/"+month);
            request.Headers.Add("AccessKeyId", "FKIA89D5AC35AF014EE5AED542CFA2DED97D");
            request.Headers.Add("AccessKeyValue", "1c0d5416-fcdc-4ff0-a974-7de953602dfb");
            request.Headers.Add("Cookie", "TS0153f740=015bdaa268f94af99a76ebef428c151b24ca8dd252d8e872c0ea6be830d27e11890d535cc0e6f2bdfcf8a06338cd05b75f84d3a6bbad1d08aa66d5a4bee66c7ceadbd8b480; lbc=!vGxddraY18B8jX3FcUwMb3JmQn6jD5PwTX2TChMvC/MAEoL5+CVC8lv9/797wE8jFDLOFNxVh5kW7f9NgYLtOv5seSOmVKSpCAm0k/wi6Qk=");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var result = response.Content.ReadFromJsonAsync<Object>().Result;
            return Ok(result);
        }

        [HttpGet("/years/{year}/months/{month}/days")]
        public async Task<IActionResult> GetDaysByMonthValue(string year, string month)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, "https://api.solarweb.com/swqapi/pvsystems/8a5788a9-987a-4413-976d-691dd9c13aeb/aggdata/years/"+year+"/months/"+month+"/days");
            request.Headers.Add("AccessKeyId", "FKIA89D5AC35AF014EE5AED542CFA2DED97D");
            request.Headers.Add("AccessKeyValue", "1c0d5416-fcdc-4ff0-a974-7de953602dfb");
            request.Headers.Add("Cookie", "TS0153f740=015bdaa2683808cdf745dc1810ac91b500f1607f2992bd37dae4437a0ca15801a790510ce5b4a0f8137bddf8d97ee47ed283083884b846aec9aecd857849948d9ab0d3e0fb; lbc=!vGxddraY18B8jX3FcUwMb3JmQn6jD5PwTX2TChMvC/MAEoL5+CVC8lv9/797wE8jFDLOFNxVh5kW7f9NgYLtOv5seSOmVKSpCAm0k/wi6Qk=");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var result = response.Content.ReadFromJsonAsync<Object>().Result;
            return Ok(result);
        }

        [HttpGet("/years/{year}/months/{month}/days/{day}")]
        public async Task<IActionResult> GetDayByDayValue(string year,string month, string day)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, "https://api.solarweb.com/swqapi/pvsystems/8a5788a9-987a-4413-976d-691dd9c13aeb/aggdata/years/2020/months/12/days/1");
            request.Headers.Add("AccessKeyId", "FKIA89D5AC35AF014EE5AED542CFA2DED97D");
            request.Headers.Add("AccessKeyValue", "1c0d5416-fcdc-4ff0-a974-7de953602dfb");
            request.Headers.Add("Cookie", "TS0153f740=015bdaa2683808cdf745dc1810ac91b500f1607f2992bd37dae4437a0ca15801a790510ce5b4a0f8137bddf8d97ee47ed283083884b846aec9aecd857849948d9ab0d3e0fb; lbc=!vGxddraY18B8jX3FcUwMb3JmQn6jD5PwTX2TChMvC/MAEoL5+CVC8lv9/797wE8jFDLOFNxVh5kW7f9NgYLtOv5seSOmVKSpCAm0k/wi6Qk=");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var result = response.Content.ReadFromJsonAsync<Object>().Result;
            return Ok(result);
        }
    }
}
