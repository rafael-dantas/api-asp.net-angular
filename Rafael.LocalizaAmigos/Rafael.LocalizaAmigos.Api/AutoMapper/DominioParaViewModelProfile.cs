using Rafael.LocalizaAmigos.Api.DTOs;
using Rafael.LocalizaAmigos.Dominio;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rafael.LocalizaAmigos.Api.AutoMapper
{
    public class DominioParaViewModelProfile : Profile
    {
        protected override void Configure()
        {            
            Mapper.CreateMap<Amigo, AmigoDTO>();
        }
    }
}