using System;
using UnityEngine;

namespace ItIsNotOnlyMe.VectorDinamico
{
    public class Componente : IComponente
    {
        private IIdentificador _idetificador;
        private float _valor;

        private IComponente _componente;

        public Componente(IIdentificador identificador, float valor, IComponente componente)
        {
            _idetificador = identificador;
            _valor = valor;
            _componente = componente;
        }

        public Componente(IIdentificador identificador, float valor)
            : this(identificador, valor, null)
        {
        }

        public bool EsIgual(IComponente componente)
        {
            return componente.EsIgual(_idetificador, _valor);
        }

        public bool EsIgual(IIdentificador identificador, float valor)
        {
            if (!_idetificador.EsIgual(identificador))
                return false;
            return (float)Math.Round(_valor - valor, 4) == 0f;
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
            _valor *= escalar;
            if (_componente != null)
                _componente.Multiplicar(escalar);
        }

        public void Multiplicar(float escalar, IIdentificador identificador)
        {
            if (_idetificador.EsIgual(identificador))
                _valor *= escalar;
            if (_componente != null)
                _componente.Multiplicar(escalar, identificador);
        }

        public void Dividir(float escalar)
        {
            _valor /= escalar;
            if (_componente != null)
                _componente.Dividir(escalar);
        }

        public float ProductoInterno(IComponente componente)
        {
            float valorPropio = componente.ProductoInterno(_idetificador, _valor);
            float valorCadena = (_componente == null) ? 0f : _componente.ProductoInterno(componente);
            return valorPropio + valorCadena;
        }

        public float ProductoInterno(IIdentificador identificador, float valor)
        {
            float valorPropio = _idetificador.EsIgual(identificador) ? _valor * valor : 0f;
            float valorCadena = (_componente == null) ? 0f : _componente.ProductoInterno(identificador, valor);
            return valorPropio + valorCadena;
        }

        public IComponente Copia()
        {
            IComponente componenteCopia = (_componente != null) ? _componente.Copia() : null;
            return new Componente(_idetificador, _valor, componenteCopia);
        }
    }
}
