using System;
using System.Globalization;

namespace ProjetoDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string strMsgTemp;
            VariaveisEntrada variaveisEntrada = new VariaveisEntrada();

            #region TipoCredito
            while (true)
            {
                strMsgTemp = "Informe o código do tipo de crédito desejado:" + Environment.NewLine +
                             "Cód - Tipo" + Environment.NewLine +
                             "1 - Crédito Direto." + Environment.NewLine +
                             "2 - Crédito Consignado." + Environment.NewLine +
                             "3 - Crédito Pessoa Jurídica." + Environment.NewLine +
                             "4 - Crédito Pessoa Física." + Environment.NewLine +
                             "5 - Crédito Imobiliário." + Environment.NewLine;

                Console.WriteLine(strMsgTemp);
                try
                {
                    int nTipoCreditoTemp = int.Parse(Console.ReadLine());
                    variaveisEntrada.TipoCredito = nTipoCreditoTemp;
                    break;
                }
                catch
                {
                    Console.WriteLine("Tipo de Crédito inválido, verifique." + Environment.NewLine);
                }
            }
            #endregion

            #region ValorCredito
            while (true)
            {
                strMsgTemp = Environment.NewLine + "O valor máximo que pode ser solicitado é de R$ 1.000.000,00" +
                             (variaveisEntrada.TipoCredito.Equals(3) ? Environment.NewLine + "Para o crédito de pessoa jurídica, o valor mínimo a ser liberado é de R$ 15.000,00." : string.Empty) +
                             Environment.NewLine + "Informe o valor do crédito:" + Environment.NewLine;

                Console.WriteLine(strMsgTemp);
                try
                {
                    double nValorSolicitadoTemp = double.Parse(Console.ReadLine(), CultureInfo.CurrentCulture);
                    variaveisEntrada.ValorCredito = nValorSolicitadoTemp;
                    break;
                }
                catch
                {
                    Console.WriteLine("Valor do crédito inválido, verifique." + Environment.NewLine);
                }
            }
            #endregion

            #region QtdeParc
            while (true)
            {
                strMsgTemp = Environment.NewLine + "Informe quantidade de parcelas" +
                             Environment.NewLine + "Deve ser no mínimo 5 e no máximo 72" + Environment.NewLine;

                Console.WriteLine(strMsgTemp);
                try
                {
                    int nQtdeParcTemp = int.Parse(Console.ReadLine());
                    variaveisEntrada.QtdeParcelas = nQtdeParcTemp;
                    break;
                }
                catch
                {
                    Console.WriteLine("Número de parcelas inválido, verifique." + Environment.NewLine);
                }
            }
            #endregion

            #region DataVenctoInicial
            while (true)
            {
                strMsgTemp = Environment.NewLine + "Informe o primeiro vencimento" +
                             Environment.NewLine + "Deve ser entre " + DateTime.Now.AddDays(15).ToString("dd/MM/yyyy") + " e " + DateTime.Now.AddDays(40).ToString("dd/MM/yyyy") + Environment.NewLine;

                Console.WriteLine(strMsgTemp);
                try
                {
                    DateTime dDataTemp = DateTime.Parse(Console.ReadLine());
                    variaveisEntrada.DataVenctoInicial = dDataTemp;
                    break;
                }
                catch
                {
                    Console.WriteLine("Data do primeiro vencimento inválida, verifique." + Environment.NewLine);
                }
            }
            #endregion

            #region Credito
            Credito credito = new Credito();
            credito.Calcular(variaveisEntrada);

            if (credito.status)
            {
                strMsgTemp = Environment.NewLine + "Status do crédito 'APROVADO'" +
                             Environment.NewLine + string.Format("Valor total com juros R$ {0}", credito.valorTotal.ToString("F2", CultureInfo.CurrentCulture)) +
                             Environment.NewLine + string.Format("Valor do juros R$ {0}", credito.valorJuros.ToString("F2", CultureInfo.CurrentCulture));
            }
            else
                strMsgTemp = Environment.NewLine + "Status do crédito 'REPROVADO'";

            Console.WriteLine(strMsgTemp);
            #endregion

            Console.ReadKey();
        }
    }
}
