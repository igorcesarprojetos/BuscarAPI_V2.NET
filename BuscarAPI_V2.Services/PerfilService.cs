using BuscarAPI_V2.Domain.Interfaces;
using BuscarAPI_V2.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace BuscarAPI_V2.Services
{
    public class PerfilService : IPerfilService
    {
        private readonly HttpClient _httpClient;
        public PerfilService(HttpClient httpClient) => _httpClient = httpClient;


        public async Task<IList<Perfil>> GetPerfis() 
        { 
            var response = await _httpClient.GetFromJsonAsync<IList<Perfil>>($"{_httpClient.BaseAddress.Query}/perfil");
            return response;
        }
        public async Task<Perfil> GetPerfilId(int perfilId) 
        { 
            var response = await _httpClient.GetFromJsonAsync<Perfil>($"{_httpClient.BaseAddress.Query}/perfil/{perfilId}");
            return response;
        }
        public async Task<Perfil> UpdatePerfil(Perfil perfil)
        {
            var response = await _httpClient.PutAsJsonAsync<Perfil>($"{_httpClient.BaseAddress.Query}/perfil/{perfil.Id}", perfil);
            var content = await response.Content.ReadFromJsonAsync<Perfil>();
            return content;
        } 
        public async Task<Perfil> CreatePerfil(Perfil perfil) 
        {
           var response = await _httpClient.PostAsJsonAsync<Perfil>($"{_httpClient.BaseAddress.Query}/perfil", perfil);
           var content = await response.Content.ReadFromJsonAsync<Perfil>();
           return content;
        }
        public async Task DeletePerfil(int perfilId) {
            await _httpClient.DeleteAsync($"{_httpClient.BaseAddress.Query}/perfil/{perfilId}");           
        }
    }
}
