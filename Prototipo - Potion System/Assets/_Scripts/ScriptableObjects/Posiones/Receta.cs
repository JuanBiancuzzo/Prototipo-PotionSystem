using UnityEngine;

namespace ItIsNotOnlyMe
{
    [CreateAssetMenu(fileName = "Receta para posion", menuName = "Receta de posion")]
    public class Receta : ScriptableObject, IPosion
    {
        [SerializeField] [Range(-20f, 20f)]
        private float _vida, _temperatura, _visivilidad, _velocidad, _estado, _peso;

        private Posion _posionBase = null;
        private Posion _posion
        {
            get
            {
                if (_posionBase == null)
                {
                    Propiedades atributos = new Propiedades(_vida, _temperatura, _visivilidad, _velocidad, _estado, _peso);
                    _posionBase = new Posion(atributos);
                }
                return _posionBase;
            }
        }

        public Propiedades GetPropiedades()
        {
            return _posion.GetPropiedades();
        }

        public float Distancia(IPosion posion)
        {
            return _posion.Distancia(posion);
        }

        public float Similitud(IPosion posion)
        {
            return _posion.Similitud(posion);
        }

        public float Multiplicidad(IPosion posion)
        {
            return _posion.Multiplicidad(posion);
        }
    }
}
