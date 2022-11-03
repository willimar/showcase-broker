using AutoMapper;
using DataCore.Mapper;
using Showcase.Broker.Application.Commands.Authenticate;
using Showcase.Broker.Navigator.Dtos.Authenticate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Showcase.Broker.Application.Mappers.Authenticate
{
    public class LoginMapper : MapperProfile<AuthenticateCommand, LoginDto>, IMapperProfile<AuthenticateCommand, LoginDto>
    {
        protected override void ForMemberMapper(IMappingExpression<AuthenticateCommand, LoginDto> mapping)
        {
            mapping
                .ForMember(dest => dest.Login, map => map.MapFrom(source => source.Login))
                .ForMember(dest => dest.Password, map => map.MapFrom(source => source.Password))
                ;
        }
    }
}
