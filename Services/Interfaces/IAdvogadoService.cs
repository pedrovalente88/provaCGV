using Domains;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface IAdvogadoService
    {
        bool Adicionar(Advogado advogado);

        bool Editar(Advogado advogado);

        List<Advogado> Listar();

        bool Deletar(int id);
    }
}
