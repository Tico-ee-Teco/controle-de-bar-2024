using ControleDeBar.Dominio.Compartilhar;
using ControleDeBar.Dominio.ModuloGarçon;

namespace ControleDeBar.Dominio.ModuloConta
{
    public class Conta : EntidadeBase
    {
        public Mesa Mesa { get; set; }        

        public decimal ValorTotal { get; }
       
        public Garcom Garcom { get; set; }         

        public bool ContaPaga { get; set; } = false;       
       
        public List<Pedido> Pedidos { get; set; }

        public DateTime Abertura { get; set; }

        public DateTime? Fechamento { get; set; }

        public Conta() { }

        public Conta(Mesa mesa, Garcom garcom, List<Pedido> pedidos)
        {
            Mesa = mesa;
            Garcom = garcom;
            Pedidos = pedidos;
            Abertura = DateTime.Now;            
        }

        public override List<string> Validar()
        {
            List<string> erros = new List<string>();
           
           if (Mesa == null)
                erros.Add($"O campo Mesa é obrigatório!");           

           if (Garcom == null)
                erros.Add($"O campo Garçom é obrigatório!"); 
           
           if (Pedidos == null || Pedidos.Count == 0)
                erros.Add($"A conta deve ter pelo menos um pedido!");

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

        public void AdicionarPedido(Pedido pedido)
        {
            if(Pedidos == null)
                Pedidos = new List<Pedido>();

            Pedidos.Add(pedido);
        }

        public void RemoverPedido(Pedido pedido)
        {
            if (pedido == null)
                return;

            Pedidos.Remove(pedido);
        }

        public override string ToString()
        {
            return $"Mesa: {Mesa.Numero} - Garçom: {Garcom.Nome} - Valor Total: {ValorTotal}";
        }
    }
}