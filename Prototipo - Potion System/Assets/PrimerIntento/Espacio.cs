using UnityEngine;

namespace ItIsNotOnlyMe
{
    [CreateAssetMenu(fileName = "Espacio", menuName = "Espacio/EspacioManager")]
    public class Espacio : ScriptableObject
    {
        [SerializeField]
        private float _valorInicial;
        [SerializeField]
        private Eje[] _ejes;

        public void Awake()
        {
            if (_ejes != null)
                for (int i = 0; i < _ejes.Length; i++)
                    _ejes[i].SetValor(_valorInicial);
        }

        public void Init(Eje[] ejes, float valorInicial)
        {
            _ejes = ejes;
            _valorInicial = valorInicial;
            Awake();
        }

        public void ModificarEspacio(IEtiqueta etiqueta)
        {
            for (int i = 0; i < _ejes.Length; i++)
            {
                float valor = etiqueta.ValorParaModificar(_ejes[i]);
                _ejes[i].Agregar(valor);
            }
        }

        public float ValorPorDimension(Dimension dimension, out bool encontrado)
        {
            encontrado = false;
            foreach (Eje eje in _ejes)
                if (eje.Comparar(dimension))
                {
                    encontrado = true;
                    return eje.GetValor();
                }
            return 0f;
        }
    }
}
