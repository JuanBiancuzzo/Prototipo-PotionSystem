using UnityEngine;

namespace ItIsNotOnlyMe
{
    [CreateAssetMenu(fileName = "Receta para posion", menuName = "Receta de posion")]
    public class Receta : ScriptableObject, IPosion
    {
        [SerializeField] [Range(-20f, 20f)]
        private float _vida, _temperatura, _visivilidad, _velocidad, _estado, _peso;

        private Posion _posionBase = null;
        public Posion Posion
        {
            get
            {
                if (_posionBase == null)
                {
                    Atributos atributos = new Atributos(_vida, _temperatura, _visivilidad, _velocidad, _estado, _peso);
                    _posionBase = new Posion(atributos);
                }
                return _posionBase;
            }
        }

        public Atributos GetAtributos()
        {
            return Posion.GetAtributos();
        }

        public float Distancia(IPosion posion)
        {
            return Posion.Distancia(posion);
        }

        public float Similitud(IPosion posion)
        {
            return Posion.Similitud(posion);
        }

        public float Multiplicidad(IPosion posion)
        {
            return Posion.Multiplicidad(posion);
        }
    }
}
