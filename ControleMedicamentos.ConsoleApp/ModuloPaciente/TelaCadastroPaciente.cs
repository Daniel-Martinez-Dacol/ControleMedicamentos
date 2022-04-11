using ControleMedicamentos.ConsoleApp.Compartilhado;
using System;
using System.Collections.Generic;
namespace ControleMedicamentos.ConsoleApp.ModuloPaciente
{
    public class TelaCadastroPaciente : TelaBase, ITelaCadastravel
    {
        private readonly RepositorioPaciente _repositorioPaciente;
        private readonly Notificador _notificador;

        public TelaCadastroPaciente(RepositorioPaciente repositorioPaciente, Notificador notificador)
           : base("Cadastro de Pacientes")
        {
            _repositorioPaciente = repositorioPaciente;
            _notificador = notificador;
        }
        public void Inserir()
        {
            MostrarTitulo("Cadastro de Pacientes");

            Paciente novoPaciente = ObterPaciente();

            _repositorioPaciente.Inserir(novoPaciente);

            _notificador.ApresentarMensagem("Paciente cadastrado com sucesso!", TipoMensagem.Sucesso);

        }
        public void Editar()
        {
            MostrarTitulo("Editando Paciente ");

            bool temPacienteCadastrados = VisualizarRegistros("Pesquisando");

            if (temPacienteCadastrados == false)
            {
                _notificador.ApresentarMensagem("Nenhum paciente cadastrado para editar!", TipoMensagem.Atencao);
            }
            int numeroPaciente = ObterNumeroRegistro();

            Paciente pacienteAtualizado = ObterPaciente();

            bool conseguiuEditar = _repositorioPaciente.Editar(numeroPaciente, pacienteAtualizado);

            if (!conseguiuEditar)
                _notificador.ApresentarMensagem("Não foi posssivel editar o paciente", TipoMensagem.Erro);
            else
                _notificador.ApresentarMensagem("Paciente editado com sucesso!", TipoMensagem.Sucesso);
        }

        public void Excluir()
        {

            MostrarTitulo("Excluindo Paciente");

            bool temPacienteCadastrados = VisualizarRegistros("Pesquisando");

            if (temPacienteCadastrados == false)
            {
                _notificador.ApresentarMensagem("Nenhum paciente cadastrado para excluir!", TipoMensagem.Atencao);
                return;
            }
            int numeroPaciente = ObterNumeroRegistro();

            bool conseguiuExcluir = _repositorioPaciente.Excluir(numeroPaciente);

            if (!conseguiuExcluir)
                _notificador.ApresentarMensagem("Não foi posssivel excluir o paciente", TipoMensagem.Erro);
            else
                _notificador.ApresentarMensagem("Paciente excluido com sucesso!", TipoMensagem.Sucesso);
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

                numeroRegistroEncontrado = _repositorioPaciente.ExisteRegistro(numeroRegistro);

                if (numeroRegistroEncontrado == false)
                    _notificador.ApresentarMensagem("ID do Paciente não foi encontrado, digite novamente", TipoMensagem.Atencao);

            } while (numeroRegistroEncontrado == false);

            return numeroRegistro;
        }
        #region Metodos Privados 
        private Paciente ObterPaciente()
        {
            Console.WriteLine("-Digite o nome do paciente: ");
            string nomeDoPaciente = Console.ReadLine();

            Console.WriteLine("-Digite a idade do paciente: ");
            int idadeDoPaciente = int.Parse(Console.ReadLine());

            Console.WriteLine("-Digite o endereço do paciente: ");
            string enderecoDoPaciente = Console.ReadLine();

            
            return new Paciente(nomeDoPaciente, idadeDoPaciente, enderecoDoPaciente);
        }

        #endregion

    }
}
