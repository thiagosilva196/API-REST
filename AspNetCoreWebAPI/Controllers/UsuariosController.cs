using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreWebAPI.Data;
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
        private readonly APIContext _context;

        public UsuariosController(APIContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Gets()
        {
            List<Usuario> _oUsuarios = new List<Usuario>();
            _oUsuarios = _context.Usuario.ToList();

            if (_oUsuarios.Count == 0)
            {
                return NotFound("Nenhuma lista encontrada.");
            }
            return Ok(_oUsuarios);
        }

        [HttpGet("GetUsuario")]
        public IActionResult GetById(int id)
        {
            

            var oUsuario = _context.Usuario.SingleOrDefault(x => x.Id == id);
            if (oUsuario == null)
            {
                return NotFound("Nenhum usuário encontrado.");
            }
            return Ok(oUsuario);
        }

        [HttpPost]
        public IActionResult Save(Usuario oUsuario)
        {
            List<Usuario> _oUsuarios = new List<Usuario>();
            
            _context.Update(oUsuario);
            _context.SaveChanges();
            _oUsuarios = _context.Usuario.ToList();
            if (_oUsuarios.Count == 0)
            {
                return NotFound("Nenhuma lista encontrada.");
            }
            return Ok(_oUsuarios);
        }

        [HttpDelete]
        public IActionResult DeleteUsuario(int id)
        {
            var oUsuario = _context.Usuario.SingleOrDefault(x => x.Id == id);
            if (oUsuario == null)
            {
                return NotFound("Nenhum usuário encontrado.");
            }
            _context.Remove(oUsuario);
            _context.SaveChanges();
            List<Usuario> _oUsuarios = new List<Usuario>();
            _oUsuarios = _context.Usuario.ToList();
            if (_oUsuarios.Count == 0)
            {
                return NotFound("Nenhuma lista encontrada");
            }
            return Ok(_oUsuarios);
        }
    }
}