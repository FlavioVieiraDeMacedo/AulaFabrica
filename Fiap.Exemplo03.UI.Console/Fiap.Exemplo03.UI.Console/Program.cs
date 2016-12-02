using Fiap.Exemplo03.UI.Console.DTOs;
using Fiap.Exemplo03.UI.Console.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Exemplo03.UI.Console
{
    class Program
    {
        static void Main(string[] args)
        {

            int a = 5;
            while (a != 0)
            {
                AlunoRepositorie aluno = new AlunoRepositorie();
                System.Console.WriteLine("Digite 1 para listar");
                System.Console.WriteLine("Digite 2 para cadastrar");
                System.Console.WriteLine("Digite 3 para alterar");
                System.Console.WriteLine("Digite 4 para deletar");
                System.Console.WriteLine("Digite 0 para sair");
                a = Int32.Parse(System.Console.ReadLine());
                
                switch (a)
                {
                    case 1:
                        foreach (var item in aluno.Listar())
                        {
                            System.Console.WriteLine("Id: " + item.Id);
                            System.Console.WriteLine("Nome: " + item.Nome + "\n");
                        }
                        break;
                    case 2:
                        System.Console.WriteLine("Digite o nome");
                        string nome = System.Console.ReadLine();
                        System.Console.WriteLine("Digite o Data De Nascimento");
                        System.DateTime dataNascimento = DateTime.Parse(System.Console.ReadLine());
                        System.Console.WriteLine("Digite se tem ou nao bolsa");
                        bool bolsa = bool.Parse(System.Console.ReadLine());
                        System.Console.WriteLine("Digite o Desconto");
                        double desconto = double.Parse(System.Console.ReadLine());
                        System.Console.WriteLine("Digite o Id do Grupo");
                        int grupoId = Int32.Parse(System.Console.ReadLine());
                        AlunoDTO alunoDto = new AlunoDTO()
                        {
                            Nome = nome,
                            DataNascimento = dataNascimento,
                            Bolsa=bolsa,
                            Desconto=desconto,
                            GrupoId=grupoId
                        };
                        aluno.Cadastrar(alunoDto);
                        break;
                    case 3:
                        System.Console.WriteLine("Digite o Id");
                        AlunoDTO alunoDtoo = aluno.PegaUmAluno(Int32.Parse(System.Console.ReadLine()));
                        System.Console.WriteLine("Id:"+alunoDtoo.Id+"  Nome:"+alunoDtoo.Nome);
                        System.Console.WriteLine("Digite o Nome a ser alterado");
                        alunoDtoo.Nome = System.Console.ReadLine();
                        aluno.Alterar(alunoDtoo, alunoDtoo.Id);
                        break;
                    case 4:
                        System.Console.WriteLine("Digite o Id");
                        aluno.Deletar(Int32.Parse(System.Console.ReadLine()));
                        break;
                }

            }
        }
    }
}
