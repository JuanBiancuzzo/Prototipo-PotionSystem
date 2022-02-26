using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace ItIsNotOnlyMe
{
    [CreateAssetMenuAttribute(fileName = "Atomo", menuName = "Elementos/Compuesto")]
    public class Compuesto : IAtomo
    {
        [SerializeField] private List<IAtomo> _atomos;
        private IElemento _compuesto;

        protected override IElemento _elemento
        {
            get
            {
                if (_compuesto == null)
                    _compuesto = Combinacion();

                return _compuesto;
            }
        }

        private IElemento Combinacion()
        {
            Energia energiaFinal = new Energia();
            IElemento elementoFinal = _atomos[0];
            for (int i = 1; i < _atomos.Count; i++)
            {
                List<IElemento> productos = elementoFinal.CrearEnlace(_atomos[i], ref energiaFinal);
                if (productos.Count > 1 || productos.Count == 0)
                {
                    Debug.LogWarning("No se creo un compuesto a partir de " + elementoFinal + " y " + _atomos[i]);
                    break;
                }
                elementoFinal = productos[0];
            }
            return elementoFinal;
        }
    }
}