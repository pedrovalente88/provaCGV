using Domains;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.Interfaces
{
    public interface IAdvogadoRepository
    {
        bool Adicionar(Advogado advogado);

        bool Editar(Advogado advogado);

        List<Advogado> Listar();

        bool Deletar(int id);
    }
}
