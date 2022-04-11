using ControleMedicamentos.ConsoleApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleMedicamentos.ConsoleApp.ModuloPaciente
{
    public class Paciente : EntidadeBase
    {
        private readonly string _nomeDoPaciente;
        private readonly int _idadeDoPaciente;
        private readonly string _endereco;

        public string Nome { get => _nomeDoPaciente; }

        public int Idade { get => _idadeDoPaciente; }

        public string Endereco { get => _endereco; }

        public Paciente(string nomeDoPaciente, int idadeDoPaciente, string endereco)
        {
            _nomeDoPaciente = nomeDoPaciente;
            _idadeDoPaciente = idadeDoPaciente;
            _endereco = endereco;
        }
        
        public override string ToString()
        {
            return "-ID: " + id + Environment.NewLine +
                "-Nome do paciente: " + Nome + Environment.NewLine +
                "-Idade do paciente: " + Idade + Environment.NewLine +
                "-Endereço do paciente: " + Endereco + Environment.NewLine;
        }
    }
}
