using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Rafael.AcessoDados.Entity.Context;
using Rafael.LocalizaAmigos.BLL;
using Rafael.LocalizaAmigos.Dominio;
using Rafael.LocalizaAmigos.Repositorio.Entity;
using Rafael.LocalizaAmigos.Api.DTOs;

namespace Rafael.LocalizaAmigos.Api.Controllers
{
    [Authorize]
    [RoutePrefix("api/Amigos")]
    public class AmigosController : ApiController    {
        
        private RepositorioAmigos _repositorio = new RepositorioAmigos(new AcessoDadosDbContext());

        // GET: api/Amigos
        public IHttpActionResult Get()
        {
            List<Amigo> lista = _repositorio.Selecionar();
            return Ok(lista);
        }

        // GET: api/Amigos/5        
        [ResponseType(typeof(AmigoDTO))]        
        public IHttpActionResult Get(int id)
        {            
            List<Amigo> amigo = CalculaDistancia.ListaAmigosProximo(id);
            if (amigo == null)
            {
                return NotFound();
            }

            return Ok(amigo);
        }
    }
}