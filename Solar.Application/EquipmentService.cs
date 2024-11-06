using Solar.Application.DTOs;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Solar.Infrastructure.Repository.Interface;
using AutoMapper;
using Solar.Domain.Equipment;
using System.Net.Http.Json;

namespace Solar.Application
{
    public class EquipmentService : IEquipmentService
    {
        private readonly IEquipmentRepository _equipmentRepository;
        private IMapper _mapper;
        public EquipmentService(IEquipmentRepository equipmentRepository, IMapper mapper)
        {
            _equipmentRepository = equipmentRepository;
            _mapper = mapper;
        }

        public void Add(EquipmentDTO equipmentDTO)
        {
            var equipment = _mapper.Map<Equipment>(equipmentDTO);
            _equipmentRepository.InsertAsync(equipment);

        }

        public async Task<object> FetchData()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, "https://api.solarweb.com/swqapi/pvsystems/8a5788a9-987a-4413-976d-691dd9c13aeb/aggdata");
            request.Headers.Add("AccessKeyId", "FKIA89D5AC35AF014EE5AED542CFA2DED97D");
            request.Headers.Add("AccessKeyValue", "1c0d5416-fcdc-4ff0-a974-7de953602dfb");
            request.Headers.Add("Cookie", "TS0153f740=015bdaa26869c6ce9d33bfac922a2622bc16cb9eda7c00f51341b3410a6d6cd388ae1a0fe46c8623913080babf7a0e52969c3fd5e7d8b8a8b09a093bcb180b2f9b5d7b55ec; lbc=!yVdQFTLooaHbvVaB4Da2EMou4rkJbyyfgfwAB7naiQCjXbeQ5Gq3L3bIURY2Fz+KL1DabTdeDT42sFBaYrzzlcEa9k8Z4Yh7AWJzeHpMuDc=");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            return response.Content.ReadFromJsonAsync<object>();

        }

        public IEnumerable<EquipmentDTO> GetAll()
        {
            return _mapper.Map<List<EquipmentDTO>>(_equipmentRepository.GetAll());
        }

        public void SaveChanges()
        {
            _equipmentRepository.SaveChanges();
        }
    }
}
