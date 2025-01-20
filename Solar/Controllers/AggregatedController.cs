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

            foreach (var item in result.Data.Channels)
            {
                AggregateSubmitDTO aggregateDTO = new AggregateSubmitDTO();
                aggregateDTO.PvSystemId = pvSystemId;
                aggregateDTO.ChannelName = item.ChannelName;
                aggregateDTO.ChannelType = item.ChannelType;
                aggregateDTO.Unit = item.Unit;
                aggregateDTO.Total = item.Values.Total;

                _aggregateService.AddAggregate(aggregateDTO);
                _aggregateService.SaveChanges();
            }

            return Ok(result);
        }

        [HttpGet("/years")]
        public async Task<IActionResult> GetYears()
        {
            //1.call api
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, "https://api.solarweb.com/swqapi/pvsystems/8a5788a9-987a-4413-976d-691dd9c13aeb/aggdata/years");
            request.Headers.Add("AccessKeyId", "FKIA89D5AC35AF014EE5AED542CFA2DED97D");
            request.Headers.Add("AccessKeyValue", "1c0d5416-fcdc-4ff0-a974-7de953602dfb");
            request.Headers.Add("Cookie", "TS0153f740=015bdaa268aac7a7a90f5c34e1424a6ced216096a086e738ddc80e2ba0aa85e75d384957d80eb9bfe636a0f49156e64ba7b4b63f1da3c899bdb56cd52582d2289f599d183e; lbc=!SrMZl+dcE+kH87jFcUwMb3JmQn6jD4eHVN+kIolWPnnBK7Yx6EELuSuotjInjNqakJbxt3GF8bnKJAiZWoZ7qU1uwqwwlA0JrPKNt6fmn80=");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var result = response.Content.ReadFromJsonAsync<Object>().Result;
            //var result = response.Content.ReadFromJsonAsync<AggregateDTO>().Result;
            //Console.WriteLine(response.Content);
            //2.store in db
            //foreach (var item in result.Data.Channels)
            //{
            //AggregateYearDTO aggregateYearDTO = new AggregateYearDTO();
            //_aggregateService.AddAggregateYears(aggregateYearDTO);

            //}
            //3.return data as json
            return Ok(result);
        }

        [HttpGet("/years/{year}")]
        public async Task<IActionResult> GetByYearValue(string year)
        {
            //1.call api
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, "https://api.solarweb.com/swqapi/pvsystems/8a5788a9-987a-4413-976d-691dd9c13aeb/aggdata/years/"+year);
            request.Headers.Add("AccessKeyId", "FKIA89D5AC35AF014EE5AED542CFA2DED97D");
            request.Headers.Add("AccessKeyValue", "1c0d5416-fcdc-4ff0-a974-7de953602dfb");
            request.Headers.Add("Cookie", "TS0153f740=015bdaa2687198e55be10aef74d578191e6f6234eba71db5df4880d98c5f3ea01ea8a6ae2323662a1c83365f5c418596ad468cf2d55529e87df2969c4a06f3bd4692f00d62; lbc=!vGxddraY18B8jX3FcUwMb3JmQn6jD5PwTX2TChMvC/MAEoL5+CVC8lv9/797wE8jFDLOFNxVh5kW7f9NgYLtOv5seSOmVKSpCAm0k/wi6Qk=");
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
            request.Headers.Add("Cookie", "TS0153f740=015bdaa2687198e55be10aef74d578191e6f6234eba71db5df4880d98c5f3ea01ea8a6ae2323662a1c83365f5c418596ad468cf2d55529e87df2969c4a06f3bd4692f00d62; lbc=!vGxddraY18B8jX3FcUwMb3JmQn6jD5PwTX2TChMvC/MAEoL5+CVC8lv9/797wE8jFDLOFNxVh5kW7f9NgYLtOv5seSOmVKSpCAm0k/wi6Qk=");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var result = response.Content.ReadFromJsonAsync<Object>().Result;


            return Ok(result);
        }

        [HttpGet("/years/{year}/months/{month}")]
        public async Task<IActionResult> GetMonthValueByMonth(string year, string month)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, "https://api.solarweb.com/swqapi/pvsystems/8a5788a9-987a-4413-976d-691dd9c13aeb/aggdata/years/"+year+"/months/"+month);
            request.Headers.Add("AccessKeyId", "FKIA89D5AC35AF014EE5AED542CFA2DED97D");
            request.Headers.Add("AccessKeyValue", "1c0d5416-fcdc-4ff0-a974-7de953602dfb");
            request.Headers.Add("Cookie", "TS0153f740=015bdaa2687c27bc615adbd85954ef8dc624f40bdbffe83e467cd8e5febc94d4b951f55eca21fcda09a848eac53ff204abd0cce0deeaab3b543855a6246ebac4826be1edda; lbc=!vGxddraY18B8jX3FcUwMb3JmQn6jD5PwTX2TChMvC/MAEoL5+CVC8lv9/797wE8jFDLOFNxVh5kW7f9NgYLtOv5seSOmVKSpCAm0k/wi6Qk=");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var result = response.Content.ReadFromJsonAsync<Object>().Result;

            return Ok(result);
        }

        [HttpGet("/years/{year}/months/{month}/days")]
        public async Task<IActionResult> GetDaysByMonth(string year, string month)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, "https://api.solarweb.com/swqapi/pvsystems/8a5788a9-987a-4413-976d-691dd9c13aeb/aggdata/years/"+year+"/months/"+month+"/days");
            request.Headers.Add("AccessKeyId", "FKIA89D5AC35AF014EE5AED542CFA2DED97D");
            request.Headers.Add("AccessKeyValue", "1c0d5416-fcdc-4ff0-a974-7de953602dfb");
            request.Headers.Add("Cookie", "TS0153f740=015bdaa268029a3517843c824d4d1a19a4e348c71e0b796b972ab87ea00799e870b733f0f24f71f41625a3ba138c59b5d9c3df3bcf9dec59901a7ba0763d8188b6a0bbc2ce; lbc=!vGxddraY18B8jX3FcUwMb3JmQn6jD5PwTX2TChMvC/MAEoL5+CVC8lv9/797wE8jFDLOFNxVh5kW7f9NgYLtOv5seSOmVKSpCAm0k/wi6Qk=");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var result = response.Content.ReadFromJsonAsync<Object>().Result;
            
            return Ok(result);
        }
        [HttpGet("/years/{year}/months/{month}/days/{day}")]
        public async Task<IActionResult> GetDayByDayValue(string year, string month, string day)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, "https://api.solarweb.com/swqapi/pvsystems/8a5788a9-987a-4413-976d-691dd9c13aeb/aggdata/years/"+year+"/months/"+month+"/days/"+day);
            request.Headers.Add("AccessKeyId", "FKIA89D5AC35AF014EE5AED542CFA2DED97D");
            request.Headers.Add("AccessKeyValue", "1c0d5416-fcdc-4ff0-a974-7de953602dfb");
            request.Headers.Add("Cookie", "TS0153f740=015bdaa268029a3517843c824d4d1a19a4e348c71e0b796b972ab87ea00799e870b733f0f24f71f41625a3ba138c59b5d9c3df3bcf9dec59901a7ba0763d8188b6a0bbc2ce; lbc=!vGxddraY18B8jX3FcUwMb3JmQn6jD5PwTX2TChMvC/MAEoL5+CVC8lv9/797wE8jFDLOFNxVh5kW7f9NgYLtOv5seSOmVKSpCAm0k/wi6Qk=");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var result = response.Content.ReadFromJsonAsync<Object>().Result;

            return Ok(result);
        }
    }
}
