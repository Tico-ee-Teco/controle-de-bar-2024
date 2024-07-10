using ControleDeBar.Dominio.Compartilhar;
using ControleDeBar.Dominio.ModuloConta;

namespace ControleDeBar.Dominio.ModuloProduto
{
    public class Produto : EntidadeBase
    {
        public string Nome { get; set;}        

        public decimal Valor { get; set; }  
        
        public List<Pedido> Pedidos { get; set; }

        public Produto() 
        {
            Pedidos = new List<Pedido>();
        }

        public Produto(string nome, decimal valor) : this()
        {
            Nome = nome;
            Valor = valor;            
        }

        public override List<string> Validar()
        {
            List<string> erros = new List<string>();

            if(string.IsNullOrEmpty(Nome))
                erros.Add("Nome do produto é obrigatório");

            if(Valor <= 0)
                erros.Add("Valor do produto deve ser maior do zero");            

            return erros;
        }

        public override void AtualizarRegistro(EntidadeBase novoRegistro)
        {
            Produto novoProduto = (Produto)novoRegistro;

            Nome = novoProduto.Nome;
            Valor = novoProduto.Valor;           
        }        

        public override string ToString()
        {
            return $"Nome: {Nome}, Valor: {Valor}";
        }

        public bool AdiconarPedido(Pedido pedido)
        {
            if(Pedidos.Contains(pedido))
                return false;

            Pedidos.Add(pedido);

            return true;
        }
    }
}