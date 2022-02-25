using UnityEngine;

namespace ItIsNotOnlyMe
{
    public class Invertir : IDecoradorEtiqueta
    {
        public Invertir(IEtiqueta etiqueta) : base(etiqueta)
        {
        }

        public override float ValorParaModificar(Eje eje)
        {
            return _etiqueta.ValorParaModificar(eje) * (-1f);
        }
    }
}
