using UnityEngine;

namespace ItIsNotOnlyMe
{
    public class Aumentar : IEtiqueta
    {
        [SerializeField] private Modificador[] _modificadores;
        [SerializeField] private float _valorDefault;

        public Aumentar(Modificador[] modificadores, float valorDefault)
        {
            _modificadores = modificadores;
            _valorDefault = valorDefault;
        }

        public override float ValorParaModificar(Eje eje)
        {
            float valorFinal = _valorDefault;

            foreach (Modificador modificador in _modificadores)
                if (eje.Comparar(modificador.Dimension))
                    valorFinal = modificador.Factor;

            return valorFinal;
        }
    }
}
