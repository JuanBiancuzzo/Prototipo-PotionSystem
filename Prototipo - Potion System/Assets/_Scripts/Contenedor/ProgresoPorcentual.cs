using UnityEngine;

namespace ItIsNotOnlyMe
{
    public class ProgresoPorcentual : IContadorDeProgreso
    {
        private static float _minimo = 0f, _maximo = 100f;
        private float _porcentaje;

        public ProgresoPorcentual(float porcentajeInicial = 0)
        {
            _porcentaje = Mathf.Min(_maximo, Mathf.Max(_minimo, porcentajeInicial));
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

        public float Porcentaje()
        {
            return _porcentaje / 100f;
        }
    }
}
