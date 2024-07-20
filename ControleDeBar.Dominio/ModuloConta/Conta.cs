using ControleDeBar.Dominio.Compartilhar;
using ControleDeBar.Dominio.ModuloGarçon;
using ControleDeBar.Dominio.ModuloMesa;
using ControleDeBar.Dominio.ModuloProduto;

namespace ControleDeBar.Dominio.ModuloConta
{
    public class Conta : EntidadeBase
    {
        public Mesa Mesa { get; set; }        
       
        public Garcom Garcom { get; set; }         

        public bool ContaPaga { get; set; }     

        public DateTime Abertura { get; set; }

        public DateTime Fechamento { get; set; }        

        public List<Pedido> Pedidos { get; set; }
        public Conta()
        {
            Pedidos = new List<Pedido>();
        }

        public Conta(Mesa mesa, Garcom garcom) : this()
        {
            Mesa = mesa;
            Garcom = garcom;
            abrirConta();
        }

        public decimal CalcularValorTotal()
        {
            return Pedidos.Sum(p => p.CalcularTotalParcial());
        }

        public override List<string> Validar()
        {
            List<string> erros = new List<string>();
           
           if (Mesa == null)
                erros.Add($"O campo Mesa é obrigatório!");           

           if (Garcom == null)
                erros.Add($"O campo Garçom é obrigatório!");            
          

            return erros;
        }

        public override void AtualizarRegistro(EntidadeBase novoRegistro)
        {
            Conta contaEditado = (Conta)novoRegistro;
            
            Mesa = contaEditado.Mesa;
            Garcom = contaEditado.Garcom;
            Pedidos = contaEditado.Pedidos;

            ContaPaga = contaEditado.ContaPaga;     
        }

        public Pedido AdicionarPedido(Produto produto, int quantidadeEscolhida)
        {
            Pedido novoPedido = new Pedido(produto, quantidadeEscolhida);

            Pedidos.Add(novoPedido);

            return novoPedido;
            
        }

        public void abrirConta()
        {
            ContaPaga = true;
            Abertura = DateTime.Now;

            if (Mesa != null)
                Mesa.Ocupar();
        }

        public void Fechar()
        {
            ContaPaga = false;
            Fechamento = DateTime.Now;

            Mesa.Desocupar();
        }

        public void RemoverPedido(Pedido pedido)
        {
            if (pedido == null)
                return;

            Pedidos.Remove(pedido);
        }

        public override string ToString()
        {
            return $"Mesa: {Mesa.Numero} - Garçom: {Garcom.Nome}";
        }
    }
}