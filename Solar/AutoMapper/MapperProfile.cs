﻿using AutoMapper;
using Solar.Application.DTOs;
using Solar.Domain.Agg;
using Solar.Domain.Equipment;
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
            CreateMap<EquipmentDTO, Equipment>();
            CreateMap<Equipment, EquipmentDTO>();

            CreateMap<AggregateSubmitDTO, Aggregate>();
            CreateMap<Aggregate, AggregateSubmitDTO>();
        }
    }
}
