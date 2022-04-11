using ControleMedicamentos.ConsoleApp.Compartilhado;
using ControleMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleMedicamentos.ConsoleApp.ModuloPaciente;
using System;
using System.Collections.Generic;

namespace ControleMedicamentos.ConsoleApp.ModuloRequisicao
{
    public class TelaCadastroRequisicao : TelaBase, ITelaCadastravel
    {
        private readonly IRepositorio<Paciente> _repositorioPaciente;
        private readonly TelaCadastroPaciente _telaCadastroRevista;
        private readonly IRepositorio<Medicamento> _repositorioMedicamento;
        private readonly TelaCadastroMedicamento _telaCadastroMedicamento;
        private readonly IRepositorio<Requisicao> _repositorioRequisicao;
        private readonly Notificador _notificador;

        public TelaCadastroRequisicao(IRepositorio<Paciente> repositorioPaciente, TelaCadastroPaciente telaCadastroRevista, IRepositorio<Medicamento> repositorioMedicamento, TelaCadastroMedicamento telaCadastroMedicamento, IRepositorio<Requisicao> repositorioRequisicao, Notificador notificador)
            : base("Cadastro de requisições")
        {
            _repositorioPaciente = repositorioPaciente;
            _telaCadastroRevista = telaCadastroRevista;
            _repositorioMedicamento = repositorioMedicamento;
            _telaCadastroMedicamento = telaCadastroMedicamento;
            _repositorioRequisicao = repositorioRequisicao;
            _notificador = notificador;
        }

        public void Inserir()
        {
            MostrarTitulo("Cadastro de requisição");

            Requisicao novaRequisicao= ObterRequisicao();

            _repositorioRequisicao.Inserir(novaRequisicao);

            _notificador.ApresentarMensagem("Requiscao cadastrado com sucesso!", TipoMensagem.Sucesso);

        }
        
      

        public bool VisualizarRegistros(string tipoVisualizacao)
        {
            if (tipoVisualizacao == "Tela")
                MostrarTitulo("Visualização de Paciente");

            List<Paciente> pacientes = _repositorioPaciente.SelecionarTodos();

            if (pacientes.Count == 0)
            {
                _notificador.ApresentarMensagem("Nenhum medicamento disponviel", TipoMensagem.Atencao);
            }

            foreach (Paciente paciente in pacientes)
                Console.WriteLine(paciente.ToString());
            Console.ReadLine();

            return true;
        }
        public int ObterNumeroRegistro()
        {
            int numeroRegistro;
            bool numeroRegistroEncontrado;

            do
            {
                Console.Write("Digite o ID do Paciente que deseja editar: ");
                numeroRegistro = int.Parse(Console.ReadLine());

                numeroRegistroEncontrado = _repositorioRequiscao.ExisteRegistro(numeroRegistro);

                if (numeroRegistroEncontrado == false)
                    _notificador.ApresentarMensagem("ID do Paciente não foi encontrado, digite novamente", TipoMensagem.Atencao);

            } while (numeroRegistroEncontrado == false);

            return numeroRegistro;
        }
        #region Metodos Privados 
        private Requisicao ObterRequisicao()
        {

            Requisicao novaRequisicao = new Requisicao(paciente, medicamento, aprovado, data, hora);

            return new Requisicao(paciente, medicamento, aprovado, data, hora);
        }

        public void Editar()
        {
            throw new NotImplementedException();
        }

        public void Excluir()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
