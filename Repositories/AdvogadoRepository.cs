using Domains;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repositories
{
    public class AdvogadoRepository: IAdvogadoRepository
    {
        public AdvogadoRepository()
        {
            if (Advogados == null)
            {
                Advogados = new List<Advogado>();

                Adicionar(new Advogado
                {
                    Id = 1,
                    Nome = "Pedro Valente",
                    Senioridade = 3,
                    Endereco = new Endereco
                    {
                        Logradouro = "Rua Barata Ribeiro",
                        Numero = 283,
                        Complemento = "703"
                    }
                });
            }
        }

        private static List<Advogado> Advogados;

        public List<Advogado> Listar()
        {
            return Advogados;
        }

        public bool Adicionar(Advogado advogado)
        {
            Advogados.Add(advogado);
            return true;
        }

        public bool Editar(Advogado advogado)
        {
            Advogados.Remove(Advogados.Where(x => x.Id == advogado.Id).FirstOrDefault());
            Advogados.Add(advogado);
            return true;
        }

        public bool Deletar(int id)
        {
            Advogados.Remove(Advogados.Where(x =>x.Id == id).FirstOrDefault());
            return true;
        }
    }
}
