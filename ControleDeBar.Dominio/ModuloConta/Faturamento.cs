namespace ControleDeBar.Dominio.ModuloConta
{
    public class Faturamento
    {
        public TipoFaturamentoEnum TipoFaturamento { get; set; }
        public List<Conta> contasFechadas { get; private set; }

        public Faturamento(TipoFaturamentoEnum tipoFaturamento, List<Conta> contasFechadas)
        {
            TipoFaturamento = tipoFaturamento;
            this.contasFechadas = contasFechadas;
        }

        public decimal CalcularTotal(out List<Conta> contasFiltradas)
        {
            decimal total = 0;

            DateTime dataAtual = DateTime.Now;

            DateTime inicioSemana = dataAtual.AddDays(-(int)dataAtual.DayOfWeek);
            DateTime fimSemana = inicioSemana.AddDays(7).AddSeconds(-1);

            DateTime inicioMes = new DateTime(dataAtual.Year, dataAtual.Month, 1);
            DateTime fimMes = inicioMes.AddMonths(1).AddSeconds(-1);

            contasFiltradas = new List<Conta>();

            if (TipoFaturamento == TipoFaturamentoEnum.Diario)
                contasFiltradas = obterContasPorDia(dataAtual);

            else if (TipoFaturamento == TipoFaturamentoEnum.Semanal)
                contasFiltradas = obterContasPorSemana(inicioSemana, fimSemana);

            else if (TipoFaturamento == TipoFaturamentoEnum.Mensal)
                contasFiltradas = obterContasPorMes(inicioMes, fimMes);

            foreach (Conta conta in contasFiltradas)
                total += conta.CalcularValorTotal();

            return total;
        }

        public decimal calcularTotalPeriodo(DateTime inicioPeriodo, DateTime finalPeriodo, out List<Conta> contasFiltradas)
        {
            decimal total = 0;

            contasFiltradas = ObterContasPorPeriodo(inicioPeriodo, finalPeriodo);

            foreach (Conta conta in contasFiltradas)
                total += conta.CalcularValorTotal();

            return total;
        }        

        private List<Conta> obterContasPorDia(DateTime dataAtual)
        {
            return contasFechadas
                .Where(c => c.Fechamento.Date == dataAtual.Date)
                .ToList();
        }
        private List<Conta> obterContasPorSemana(DateTime inicioSemana, DateTime fimSemana)
        {
            return contasFechadas
                .Where(c =>
                {
                    return c.Fechamento.Date >= inicioSemana &&
                        c.Fechamento.Date <= fimSemana;
                })
                .ToList();
        }
        private List<Conta> obterContasPorMes(DateTime inicioMes, DateTime fimMes)
        {
            return contasFechadas
                .Where(c =>
                {
                    return c.Fechamento.Date >=inicioMes &&
                        c.Fechamento.Date <= fimMes;
                })
                .ToList();
        }

        private List<Conta> ObterContasPorPeriodo(DateTime inicioPeriodo, DateTime finalPeriodo)
        {
            return contasFechadas
                .Where(c => c.Fechamento >= inicioPeriodo &&
                    c.Fechamento <= finalPeriodo)
                .ToList();
        }
    }
}
