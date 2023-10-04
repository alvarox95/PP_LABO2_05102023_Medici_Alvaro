namespace Entidades
{
    public class Operacion
    {
        private Numeracion primerOperando;
        private Numeracion segundoOperando;

        public Operacion(Numeracion primerOperando, Numeracion segundoOperando)
        {
            this.primerOperando = primerOperando;
            this.segundoOperando = segundoOperando;
        }

        public Numeracion Operar(char operador)
        {
            Numeracion resultadoOperacion;

            switch (operador)
            {
                case '+':
                    resultadoOperacion = primerOperando + segundoOperando;
                    break;
                case '-':
                    resultadoOperacion = primerOperando - segundoOperando;
                    break;
                case '/':
                    resultadoOperacion = segundoOperando.ValorNumerico != "0"
                        ? primerOperando / segundoOperando
                        : primerOperando;
                    break;
                case '*':
                    resultadoOperacion = primerOperando * segundoOperando;
                    break;
                default:
                    resultadoOperacion = primerOperando;
                    break;
            }
            return resultadoOperacion;
        }
    }
}
