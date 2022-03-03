using System.Collections.Generic;

namespace ItIsNotOnlyMe
{
    public struct Par
    {
        private static float _valorNulo = 0f;
        private IIdentificador _identificador;
        private float _valor;

        public Par(IIdentificador identificador, float valor)
        {
            _identificador = identificador;
            _valor = valor;
        }

        public bool Comparar(IIdentificador identificador)
        {
            return _identificador.EsIgual(identificador);
        }

        public bool Comparar(Par par)
        {
            return par.Comparar(_identificador);
        }

        public float GetValor()
        {
            return _valor;
        }

        public IIdentificador GetIdentificador()
        {
            return _identificador;
        }

        public static Par Sumar(Par propio, Par otro)
        {
            float nuevoValor = propio.Comparar(otro) ? propio._valor + otro._valor : _valorNulo;
            return new Par(propio._identificador, nuevoValor);
        }

        public static Par Restar(Par propio, Par otro)
        {
            float nuevoValor = propio.Comparar(otro) ? propio._valor - otro._valor : _valorNulo;
            return new Par(propio._identificador, nuevoValor);
        }

        public static Par Multiplicar(Par par, float valor)
        {
            return new Par(par._identificador, par._valor * valor);
        }

        public static float Multiplicar(Par propio, Par otro)
        {
            return propio.Comparar(otro) ? propio._valor * otro._valor : _valorNulo;
        }

        public static Par Dividir(Par par, float valor)
        {
            float valorResultante = (valor == 0f) ? 0f : par._valor / valor;
            return new Par(par._identificador, valorResultante);
        }

        public static Par CopiaNula(Par par)
        {
            return new Par(par._identificador, 0);
        }

        public static bool Existe(Par parActual, List<Par> pares)
        {
            foreach (Par par in pares)
                if (par.Comparar(parActual))
                    return true;
            return false;
        }
    }
}
