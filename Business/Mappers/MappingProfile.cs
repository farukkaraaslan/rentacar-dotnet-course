using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Entities;
using Entities.Dto;

namespace Business.Mappers
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<RentalDto, Rental>();
        }
    }
}
