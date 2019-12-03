using System;

namespace ProjetoDemo
{
    public class VariaveisEntrada
    {
        public double ValorCredito { get; set; }
        public int TipoCredito { get; set; }
        public int QtdeParcelas { get; set; }
        public DateTime? DataVenctoInicial { get; set; }
        public VariaveisEntrada()
        {
            ValorCredito = 0;
            TipoCredito = 0;
            QtdeParcelas = 0;
        }
    }
}
