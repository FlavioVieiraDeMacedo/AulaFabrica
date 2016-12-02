using Fiap.Exemplo03.UI.Console.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Exemplo03.UI.Console.Repositories
{
    class AlunoRepositorie
    {
        public IEnumerable<AlunoDTO> Listar()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51030/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new
                MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync("api/aluno").Result;
                if (response.IsSuccessStatusCode)
                {
                    IEnumerable<AlunoDTO> aluno =
                    response.Content.ReadAsAsync<IEnumerable<AlunoDTO>>().Result;
                    return aluno;
                }
                else
                {
                    return null;
                }

            }
        }

        public void Cadastrar(AlunoDTO aluno)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51030/");
                HttpResponseMessage response = client.PostAsJsonAsync("api/aluno", aluno).Result;
                if (response.IsSuccessStatusCode)
                {
                    Uri uri = response.Headers.Location;
                }
            }
        }
        public void Deletar(int Id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51030/");
                HttpResponseMessage response = client.DeleteAsync("api/aluno/" + Id).Result;
                
            }
        }
        public void Alterar(AlunoDTO aluno, int Id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51030/");
                HttpResponseMessage response = client.PutAsJsonAsync("api/aluno/"+Id, aluno).Result;
                if (response.IsSuccessStatusCode)
                {
                    Uri uri = response.Headers.Location;
                }
            }
        }
        public AlunoDTO PegaUmAluno(int Id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51030/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new
                MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync("api/aluno/"+Id).Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<AlunoDTO>().Result;
                }
                else
                {
                    return null;
                }

            }
        }
    }
}
