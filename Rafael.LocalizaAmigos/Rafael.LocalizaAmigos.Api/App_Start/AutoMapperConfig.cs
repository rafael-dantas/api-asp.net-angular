using Rafael.LocalizaAmigos.Api.AutoMapper;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rafael.LocalizaAmigos.Api.App_Start
{
    public static class AutoMapperConfig
    {
        public static void Configurar()
        {
            Mapper.AddProfile<DominioParaViewModelProfile>();
        }
    }
}