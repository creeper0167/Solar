using AutoMapper;
using Solar.Application.DTOs;
using Solar.Application.Services.Interface;
using Solar.Domain.Agg;
using Solar.Infrastructure.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solar.Application.Services.Service
{
    public class AggregateService : IAggregateService
    {
        IAggregateRepository _aggregateRepository;
        IMapper _mapper;
        public AggregateService(IAggregateRepository aggregateRepository, IMapper mapper)
        {
            _aggregateRepository = aggregateRepository;
            _mapper = mapper;
        }
        public void AddAggregate(AggregateSubmitDTO aggregate)
        {
            var result = _mapper.Map<Aggregate>(aggregate);
            result.RequestDate = DateTime.Now;
            _aggregateRepository.Add(result);
        }

        public void SaveChanges()
        {
            _aggregateRepository.SaveChanges();
        }
    }
}
