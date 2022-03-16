using System;

namespace ItIsNotOnlyMe.VectorDinamico
{
    public class ComponenteNulo : IComponente
    {
        private IComponente _componente;

        public ComponenteNulo(IComponente componente = null)
        {
            _componente = componente;
        }

        public bool EsIgual(IComponente componente)
        {
            return false;
        }

        public bool EsIgual(IIdentificador identificador, float valor)
        {
            return false;
        }

        public void Sumar(IComponente componente)
        {
            if (_componente == null)
                _componente = componente;
            else
                _componente.Sumar(componente);
        }

        public void Restar(IComponente componente)
        {
            if (_componente == null)
            {
                componente.Multiplicar(-1f);
                _componente = componente;
            }
            else
            {
                _componente.Restar(componente);
            }
        }

        public void Multiplicar(float escalar)
        {
            if (_componente != null)
                _componente.Multiplicar(escalar);
        }

        public void Multiplicar(float escalar, IIdentificador identificador)
        {
            if (_componente != null)
                _componente.Multiplicar(escalar, identificador);
        }

        public void Dividir(float escalar)
        {
            if (_componente != null)
                _componente.Dividir(escalar);
        }

        public float ProductoInterno(IComponente componente)
        {
            return (_componente == null) ? 0f : _componente.ProductoInterno(componente); ;
        }

        public float ProductoInterno(IIdentificador identificador, float valor)
        {
            return (_componente == null) ? 0f : _componente.ProductoInterno(identificador, valor); ;
        }

        public IComponente Copia()
        {
            return (_componente == null) ? this : _componente.Copia();
        }
    }
}
