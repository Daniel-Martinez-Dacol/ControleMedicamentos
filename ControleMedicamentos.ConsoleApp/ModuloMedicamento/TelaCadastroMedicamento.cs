using ControleMedicamentos.ConsoleApp.Compartilhado;
using System;
using System.Collections.Generic;

namespace ControleMedicamentos.ConsoleApp.ModuloMedicamento
{
    public class TelaCadastroMedicamento : TelaBase, ITelaCadastravel
    {
        private readonly RepositorioMedicamento _repositorioMedicamento;
        private readonly Notificador _notificador;

        public TelaCadastroMedicamento(RepositorioMedicamento repositorioMedicamento, Notificador notificador)
            : base("Cadastro de Medicamentos")
        {
            _repositorioMedicamento = repositorioMedicamento;
            _notificador = notificador;
        }
        public void Inserir()
        {
            MostrarTitulo("Cadastro de Medicamentos");

            Medicamento novoMedicamento = ObterMedicamento();

            _repositorioMedicamento.Inserir(novoMedicamento);

            _notificador.ApresentarMensagem("Medicamento cadastrado com sucesso!", TipoMensagem.Sucesso);

        }
        public void Editar()
        {
            MostrarTitulo("Editando Medicamento ");

            bool temMedicamentosCadastrados = VisualizarRegistros("Pesquisando");

            if (temMedicamentosCadastrados == false)
            {
                _notificador.ApresentarMensagem("Nenhum medicamento cadastrado para editar!", TipoMensagem.Atencao);
            }
            int numeroMedicamento = ObterNumeroRegistro();

            Medicamento medicamentoAtualizado = ObterMedicamento();

            bool conseguiuEditar = _repositorioMedicamento.Editar(numeroMedicamento, medicamentoAtualizado);

            if (!conseguiuEditar)
                _notificador.ApresentarMensagem("Não foi posssivel editar o medicamento", TipoMensagem.Erro);
            else
                _notificador.ApresentarMensagem("Medicamento editado com sucesso!", TipoMensagem.Sucesso);
        }

        public void Excluir() {
            
            MostrarTitulo("Excluindo Medicamento");

            bool temMedicamentosCadastrados = VisualizarRegistros("Pesquisando");

            if (temMedicamentosCadastrados == false)
            {
                _notificador.ApresentarMensagem("Nenhum medicamento cadastrado para excluir!", TipoMensagem.Atencao);
                return;
            }
            int numeroMedicamento = ObterNumeroRegistro();
            
            bool conseguiuExcluir = _repositorioMedicamento.Excluir(numeroMedicamento);

            if (!conseguiuExcluir)
                _notificador.ApresentarMensagem("Não foi posssivel excluir o medicamento", TipoMensagem.Erro);
            else
                _notificador.ApresentarMensagem("Medicamento excluido com sucesso!", TipoMensagem.Sucesso);
        }

        public bool VisualizarRegistros(string tipoVisualizacao)
        {
            if (tipoVisualizacao == "Tela")
                MostrarTitulo("Visualização de Medicamentos");

            List<Medicamento> medicamentos = _repositorioMedicamento.SelecionarTodos();

            if (medicamentos.Count == 0)
            {
                _notificador.ApresentarMensagem("Nenhum medicamento disponviel", TipoMensagem.Atencao);
            }

            foreach (Medicamento medicamento in medicamentos)
                Console.WriteLine(medicamento.ToString());
            Console.ReadLine();

            return true;
        }
        public bool VisualizarRegistrosEmFalta(string tipoVisualizacao)
        {
            if (tipoVisualizacao == "Tela")
                MostrarTitulo("Visualização de Medicamentos");

            List<Medicamento> medicamentos = _repositorioMedicamento.SelecionarTodos();

            if (medicamentos.Count == 0)
            {
                _notificador.ApresentarMensagem("Nenhum medicamento disponviel", TipoMensagem.Atencao);
            }

            foreach (Medicamento medicamento in medicamentos)
                if (medicamento.QtdDisponivel == 0)
                {
                    Console.WriteLine(medicamento.ToString());
                }

            Console.ReadLine();

            return true;
        }
        public int ObterNumeroRegistro()
        {
            int numeroRegistro;
            bool numeroRegistroEncontrado;

            do
            {
                Console.Write("Digite o ID do Medicamento que deseja editar: ");
                numeroRegistro = int.Parse(Console.ReadLine());

                numeroRegistroEncontrado = _repositorioMedicamento.ExisteRegistro(numeroRegistro);
                
                if (numeroRegistroEncontrado == false)
                    _notificador.ApresentarMensagem("ID do Medicamento não foi encontrado, digite novamente", TipoMensagem.Atencao);

            } while (numeroRegistroEncontrado == false);

            return numeroRegistro;
        }

        #region Metodos Privados 
        private Medicamento ObterMedicamento()
        {
            Console.WriteLine("-Digite o nome do Remedio: ");
            string nomeDoRemedio = Console.ReadLine();

            Console.WriteLine("-Digite a descrição do Remedio: ");
            string descricaoDoRemedio = Console.ReadLine();

            Console.WriteLine("-Digite a qtd disponviel do Remedio: ");
            int qtdDisponivel = int.Parse(Console.ReadLine());

            return new Medicamento(nomeDoRemedio, descricaoDoRemedio, qtdDisponivel);
        }

        #endregion
    }
}
