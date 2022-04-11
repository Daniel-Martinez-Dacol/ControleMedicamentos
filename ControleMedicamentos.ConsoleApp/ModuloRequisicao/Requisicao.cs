using ControleMedicamentos.ConsoleApp.Compartilhado;
using ControleMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleMedicamentos.ConsoleApp.ModuloPaciente;
using System;

namespace ControleMedicamentos.ConsoleApp.ModuloRequisicao
{
    public class Requisicao : EntidadeBase
    {
        private readonly Paciente _paciente;
        private readonly Medicamento _medicamento;
        private readonly bool _aprovado;
        private readonly DateTime _data;
        private readonly DateTime _hora;

        public Paciente PacienteDaRequisicao { get => _paciente; }
        
        public Medicamento MedicamentoRequisitado { get => _medicamento; }
        
        public bool Aprovado { get => _aprovado; }
        
        public DateTime Data { get => _data; }
        
        public DateTime Hora { get => _hora; }

        public Requisicao(Paciente paciente, Medicamento medicamento, bool aprovado, DateTime data, DateTime hora)
        {
            _paciente = paciente;
            _medicamento = medicamento;
            _aprovado = aprovado;
            _data = data;
            _hora = hora;
        }

        public override string ToString()
        {
            return "-ID: " + id + Environment.NewLine +
                "-Nome do paciente da requisição: " + PacienteDaRequisicao.Nome + Environment.NewLine +
                "-Nome do Medicamento requisitado: " + MedicamentoRequisitado.Nome + Environment.NewLine +
                "-Situação da requisição: " + Aprovado + Environment.NewLine +
                "-Data da requisição: " + Data + Environment.NewLine + 
                "-Hora da requisição: " + Hora + Environment.NewLine;
        }
    }
}
