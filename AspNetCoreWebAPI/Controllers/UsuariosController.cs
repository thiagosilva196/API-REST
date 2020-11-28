using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreWebAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace AspNetCoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        List<Usuario> _oUsuarios = new List<Usuario>()
        {
            new Usuario() { Id = 1, Nome = "Pedro", Email = "pedro@gmail.com" },
            new Usuario() { Id = 2, Nome = "Cirilo", Email = "cirilo@gmail.com" },
            new Usuario() { Id = 3, Nome = "Maria Joaquina", Email = "maria.joaquina@gmail.com" },
        };

        [HttpGet]
        public IActionResult Gets()
        {
            if(_oUsuarios.Count == 0)
            {
                return NotFound("Nenhuma lista encontrada.");
            }
            return Ok(_oUsuarios);
        }

        [HttpGet("GetUsuario")]
        public IActionResult Get(int id)
        {
            var oUsuario = _oUsuarios.SingleOrDefault(x => x.Id == id);
            if(oUsuario == null)
            {
                return NotFound("Nenhum usuário encontrado.");
            }
            return Ok(oUsuario);
        }

        [HttpPost]
        public IActionResult Save(Usuario oUsuario) 
        {
            _oUsuarios.Add(oUsuario);
            if(_oUsuarios.Count == 0)
            {
                return NotFound("Nenhuma lista encontrada.");
            }
            return Ok(_oUsuarios);
        }

        [HttpDelete]
        public IActionResult DeleteUsuario(int id)
        {
            var oUsuario = _oUsuarios.SingleOrDefault(x => x.Id == id);
            if (oUsuario == null)
            {
                return NotFound("Nenhum usuário encontrado.");
            }
            _oUsuarios.Remove(oUsuario);

            if (_oUsuarios.Count == 0)
            {
                return NotFound("Nenhuma lista encontrada");
            }
            return Ok(_oUsuarios);
        }
    }
}