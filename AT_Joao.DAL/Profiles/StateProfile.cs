using AT_Joao.BLL.Models.DTO;
using AT_Joao.BLL.Models.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AT_Joao.DAL.Profiles
{
    internal class StateProfile : Profile
    {
        public StateProfile()
        {
            CreateMap<State, StateDTO>()
               .ReverseMap();
        }       
    }
}
