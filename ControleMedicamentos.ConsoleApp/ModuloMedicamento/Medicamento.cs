using ControleMedicamentos.ConsoleApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleMedicamentos.ConsoleApp.ModuloMedicamento
{
    public class Medicamento : EntidadeBase
    {
        private readonly string _nomeDoRemedio;
        private readonly string _descricaoDoRemedio;
        private readonly int _qtdDisponivel;

        public string Nome { get => _nomeDoRemedio; }
        public string DescricaoDoRemedio { get => _descricaoDoRemedio; }
        public int QtdDisponivel { get => _qtdDisponivel; }

        public Medicamento (string nomeDoRemedio, string descricaoDoRemedio, int qtdDisponivel)
        {
            _nomeDoRemedio = nomeDoRemedio;
            _descricaoDoRemedio = descricaoDoRemedio;
            _qtdDisponivel = qtdDisponivel;

        }
        public override string ToString()
        {
            return "-ID: " + id + Environment.NewLine +
                "-Nome do Remedio: " + Nome + Environment.NewLine + 
                "-Descrição do remedio: " + DescricaoDoRemedio + Environment.NewLine+
                "-Quantidade disponivel: " + QtdDisponivel + Environment.NewLine;
        }
    }
}
