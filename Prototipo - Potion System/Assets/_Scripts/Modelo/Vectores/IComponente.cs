using System.Collections.Generic;

namespace ItIsNotOnlyMe.VectorDinamico
{
    public interface IComponente
    {
        public bool EsIgual(IComponente componente);

        public bool EsIgual(IIdentificador identificador, float valor);

        public void Sumar(IComponente componente);

        public void Restar(IComponente componente);

        public void Multiplicar(float escalar);

        public void Multiplicar(float escalar, IIdentificador identificador);

        public void Dividir(float escalar);

        public float ProductoInterno(IComponente componente);

        public float ProductoInterno(IIdentificador identificador, float valor);

        public IComponente Copia();
    }
}
