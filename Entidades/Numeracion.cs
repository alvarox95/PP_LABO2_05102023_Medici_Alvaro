using System;

namespace Entidades
{
    public class Numeracion
    {
        private ESistema sistema;
        private double valorNumerico;

        public ESistema Sistema => sistema;
        public string ValorNumerico => valorNumerico.ToString();

        public Numeracion(ESistema sistema, double valorNumerico)
        {
            this.sistema = sistema;
            this.valorNumerico = valorNumerico;
        }

        public Numeracion(string valor, ESistema sistema)
        {
            InicializarValores(valor, sistema);
        }

        private void InicializarValores(string valor, ESistema sistema)
        {
            if (sistema == ESistema.Binario || sistema == ESistema.Decimal)
            {
                if (double.TryParse(valor, out double valorParsed))
                {
                    valorNumerico = valorParsed;
                    this.sistema = sistema;
                }
                else
                {
                    valorNumerico = double.MinValue;
                }
            }
        }

        public string ConvertirA(ESistema sistema)
        {
            if (sistema == ESistema.Decimal)
            {
                double valorDecimal = Convert.ToInt32(ValorNumerico, 2);
                return valorDecimal.ToString();
            }
            else if (sistema == ESistema.Binario)
            {
                if (double.TryParse(ValorNumerico, out double valorDecimal))
                {
                    return DecimalABinario((int)valorDecimal);
                }
                else
                {
                    return "Numero invalido";
                }
            }
            else
            {
                return "Sistema invalido";
            }
        }

        private string DecimalABinario(int valor)
        {
            if (valor < 0)
            {
                return "Numero invalido";
            }
            return Convert.ToString(valor, 2);
        }

        public bool EsBinario(string valor)
        {
            foreach (char caracter in valor)
            {
                if (caracter != '0' && caracter != '1')
                {
                    return false;
                }
            }
            return true;
        }

        public static bool operator ==(ESistema sistema, Numeracion numeracion)
        {
            return sistema == numeracion.sistema;
        }

        public static bool operator ==(Numeracion n1, Numeracion n2)
        {
            return n1.sistema == n2.sistema;
        }

        public static bool operator !=(ESistema sistema, Numeracion numeracion)
        {
            return sistema != numeracion.sistema;
        }

        public static bool operator !=(Numeracion n1, Numeracion n2)
        {
            return n1.sistema != n2.sistema;
        }

        public static Numeracion operator +(Numeracion n1, Numeracion n2)
        {
            double.TryParse(n1.ValorNumerico, out double aux1);
            double.TryParse(n2.ValorNumerico, out double aux2);
            return new Numeracion(ESistema.Decimal, aux1 + aux2);
        }

        public static Numeracion operator -(Numeracion n1, Numeracion n2)
        {
            double.TryParse(n1.ValorNumerico, out double aux1);
            double.TryParse(n2.ValorNumerico, out double aux2);
            return new Numeracion(ESistema.Decimal, aux1 - aux2);
        }

        public static Numeracion operator *(Numeracion n1, Numeracion n2)
        {
            double.TryParse(n1.ValorNumerico, out double aux1);
            double.TryParse(n2.ValorNumerico, out double aux2);
            return new Numeracion(ESistema.Decimal, aux1 * aux2);
        }

        public static Numeracion operator /(Numeracion n1, Numeracion n2)
        {
            double.TryParse(n1.ValorNumerico, out double aux1);
            double.TryParse(n2.ValorNumerico, out double aux2);
            return new Numeracion(ESistema.Decimal, aux1 / aux2);
        }
    }

    public enum ESistema
    {
        Decimal = 10,
        Binario
    }
}
