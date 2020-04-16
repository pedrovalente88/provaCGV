using System;

namespace Domains
{
    public class Advogado
    {
        public int Id { get; set; }
        
        public string Nome { get; set; }

        public int Senioridade { get; set; }

        public Endereco Endereco { get; set; }
    }
}
