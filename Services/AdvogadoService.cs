using Domains;
using Repositories.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;

namespace Services
{
    public class AdvogadoService : IAdvogadoService
    {
        private IAdvogadoRepository _advogadoRepository;

        public AdvogadoService(IAdvogadoRepository advogadoRepository)
        {
            _advogadoRepository = advogadoRepository;
        }

        public bool Adicionar(Advogado advogado)
        {
            try
            {
                return _advogadoRepository.Adicionar(advogado);                 
            }
            catch
            {
                return false;
            }

        }

        public bool Editar(Advogado advogado)
        {
            try
            {
                return _advogadoRepository.Editar(advogado);
            }
            catch
            {
                return false;
            }

        }

        public List<Advogado> Listar()
        {
            return _advogadoRepository.Listar();
        }

        public bool Deletar(int id)
        {
            try
            {
                return _advogadoRepository.Deletar(id);
            }
            catch
            {
                return false;
            }
        }
    }
}
