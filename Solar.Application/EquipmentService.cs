using Solar.Application.DTOs;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Solar.Infrastructure.Repository.Interface;
using AutoMapper;

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
        public IEnumerable<EquipmentDTO> GetAll()
        {
            return _mapper.Map<List<EquipmentDTO>>(_equipmentRepository.GetAll());
        }
    }
}
