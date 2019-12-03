using System;
using System.Globalization;

namespace ProjetoDemo
{
    public class Credito
    {
        #region Variaveis
        public bool status { get; set; }
        public double valorTotal { get; set; }
        public double valorJuros { get; set; }
        #endregion

        #region Contrutor
        public Credito()
        {
            status = false;
            valorTotal = 0;
            valorJuros = 0;
        }
        #endregion

        #region ValidarCredito
        private bool Validar(VariaveisEntrada variaveisEntrada)
        {
            DateTime dataVenctoMinimo = DateTime.Now.AddDays(15);
            DateTime dataVenctoMaximo = DateTime.Now.AddDays(40);

            if (variaveisEntrada.TipoCredito < 1 || variaveisEntrada.TipoCredito > 5)
                return false;

            if (variaveisEntrada.ValorCredito > 1000000 || (variaveisEntrada.TipoCredito.Equals(3) && variaveisEntrada.ValorCredito < 15000))
                return false;

            if (variaveisEntrada.QtdeParcelas < 5 || variaveisEntrada.QtdeParcelas > 72)
                return false;

            if (variaveisEntrada.DataVenctoInicial < dataVenctoMinimo || variaveisEntrada.DataVenctoInicial > dataVenctoMaximo)
                return false;

            return true;
        }
        #endregion

        #region CalcularCredito
        public void Calcular(VariaveisEntrada variaveisEntrada)
        {
            if (Validar(variaveisEntrada))
            {
                status = true;

                double taxaJuros = 0;

                switch (variaveisEntrada.TipoCredito)
                {
                    case 1:
                        taxaJuros = 2;
                        break;
                    case 2:
                        taxaJuros = 1;
                        break;
                    case 3:
                        taxaJuros = 5;
                        break;
                    case 4:
                        taxaJuros = 3;
                        break;
                    case 5:
                        taxaJuros = (9 / 12);
                        break;
                }
                valorJuros = Convert.ToDouble((variaveisEntrada.ValorCredito * (variaveisEntrada.QtdeParcelas * taxaJuros) / 100), CultureInfo.CurrentCulture);
                valorTotal = variaveisEntrada.ValorCredito + valorJuros;
            }
        }
        #endregion
    }
}
