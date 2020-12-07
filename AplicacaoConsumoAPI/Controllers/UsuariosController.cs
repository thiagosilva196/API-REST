using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AplicacaoConsumoAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AplicacaoConsumoAPI.Controllers
{
    public class UsuariosController : Controller
    {
        HttpClientHandler _clientHandler = new HttpClientHandler();

        Usuario _oUsuario = new Usuario();
        List<Usuario> _oUsuarios = new List<Usuario>();

        public UsuariosController()
        {
            _clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<List<Usuario>> GetAllUsers()
        {
            _oUsuarios = new List<Usuario>();

            using (var httpClient = new HttpClient(_clientHandler))
            {
                using (var response = await httpClient.GetAsync("https://localhost:44393/api/Usuarios"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    _oUsuarios = JsonConvert.DeserializeObject<List<Usuario>>(apiResponse);
                }
            }

            return _oUsuarios;
        }

        [HttpGet]
        public async Task<Usuario> GetById(int usuarioId)
        {
            _oUsuario = new Usuario();

            using (var httpClient = new HttpClient(_clientHandler))
            {
                using (var response = await httpClient.GetAsync("https://localhost:44393/api/Usuarios/" + usuarioId))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    _oUsuario = JsonConvert.DeserializeObject<Usuario>(apiResponse);
                }
            }

            return _oUsuario;
        }

        [HttpPost]
        public async Task<Usuario> AddUpdateUser(Usuario usuario)
        {
             _oUsuario = new Usuario();

            using (var httpClient = new HttpClient(_clientHandler))
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(usuario), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync("https://localhost:44393/api/Usuarios", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    _oUsuario = JsonConvert.DeserializeObject<Usuario>(apiResponse);
                }
            }

            return _oUsuario;
        }

        [HttpDelete]
        public async Task<string> Delete(int usuarioId)
        {
            string message = "";

            using (var httpClient = new HttpClient(_clientHandler))
            {
                using (var response = await httpClient.DeleteAsync("https://localhost:44393/api/Usuarios/" + usuarioId))
                {
                    message = await response.Content.ReadAsStringAsync();
                }
            }

            return message;
        }
    }
}