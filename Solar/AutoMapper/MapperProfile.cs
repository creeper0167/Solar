using AutoMapper;
using Solar.Application.DTOs;
using Solar.Application.DTOs.EnergyFlow;
using Solar.Application.DTOs.User;

using Solar.Domain.Agg;
using Solar.Domain.EnergyFlow;
using Solar.Domain.Equipment;
using Solar.Domain.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solar.Application.AutoMapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<EquipmentDTO, Equipment>().ReverseMap();

            CreateMap<AggregateSubmitDTO, Aggregate>().ReverseMap();

            CreateMap<User, RegisterRequestDTO>().ReverseMap();

            CreateMap<Aggregate, AggregateDTO>().ReverseMap();

            CreateMap<EnergyFlowData, EnergyFlowDTO>().ReverseMap();
        }
    }
}
