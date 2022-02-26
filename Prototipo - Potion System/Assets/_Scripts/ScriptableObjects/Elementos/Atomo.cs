using UnityEngine;

namespace ItIsNotOnlyMe
{
    [CreateAssetMenuAttribute(fileName = "Atomo", menuName = "Elementos/Atomo")]
    public class Atomo : IAtomo
    {
        [SerializeField] [Range(1, 28)]
        private int _numeroAtomico;
        private IElemento _elementoBase = null;

        protected override IElemento _elemento
        {
            get
            {
                if (_elementoBase == null)
                    _elementoBase = new Elemento(_numeroAtomico);
                return _elementoBase;
            }
        }
    }
}