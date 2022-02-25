using UnityEngine;

namespace ItIsNotOnlyMe
{
    public class Concentrar : IDecoradorEtiqueta
    {
        [SerializeField] private Modificador[] _concentrables;
        [SerializeField] private float _factorDisminusion;

        public Concentrar(Modificador[] concentrables, float factorDisminusion, IEtiqueta etiqueta) : base(etiqueta)
        {
            _concentrables = concentrables;
            _factorDisminusion = factorDisminusion;
        }

        public override float ValorParaModificar(Eje eje)
        {
            float valorFinal = _etiqueta.ValorParaModificar(eje);

            Modificador concentrableActual = new Modificador(null, _factorDisminusion);

            foreach (Modificador concentrable in _concentrables)
                if (eje.Comparar(concentrable.Dimension))
                    concentrableActual = concentrable;

            return valorFinal * concentrableActual.Factor;
        }
    }
}
