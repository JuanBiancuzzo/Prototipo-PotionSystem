using UnityEngine;

namespace ItIsNotOnlyMe
{
    public class ProgresoPorcentual : IContadorDeProgreso
    {
        private static float _minimo = 0f, _maximo = 100f;
        private float _porcentaje, _porcentajeAnterior;

        public ProgresoPorcentual(float porcentajeInicial = 0)
        {
            _porcentaje = Mathf.Min(_maximo, Mathf.Max(_minimo, porcentajeInicial));
            _porcentajeAnterior = _porcentaje;
        }

        public void Avanzar(float valor)
        {
            if (valor < 0)
                return;

            _porcentaje += valor;

            if (_porcentaje >= _maximo)
                _porcentaje = _maximo;
        }

        public bool Finalizado()
        {
            return _porcentaje == _maximo;
        }

        public IContadorDeProgreso Maximo()
        {
            return new ProgresoPorcentual(_maximo);
        }

        public float Porcentaje()
        {
            float porcentaje = (_porcentaje - _porcentajeAnterior) / 100f;
            _porcentajeAnterior = _porcentaje;
            return porcentaje;
        }

        public void Restar(IContadorDeProgreso contadorDeProgreso)
        {
            throw new System.NotImplementedException();
        }

        public void Sumar(IContadorDeProgreso contadorDeProgreso)
        {
            throw new System.NotImplementedException();
        }
    }
}
