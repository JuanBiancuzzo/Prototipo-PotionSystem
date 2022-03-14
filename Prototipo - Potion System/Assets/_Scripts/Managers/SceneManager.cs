using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

namespace ItIsNotOnlyMe
{
    [CreateAssetMenu(fileName = "Scene Manager", menuName = "Manager/Scene Manager")]
    public class SceneManager : ScriptableObject
    {
        private MovimientoInput _inputActual;
        private CamaraPrioridad _camaraActual;

        public void Init(MovimientoInput input, CamaraPrioridad camara)
        {
            _camaraActual = camara;
            _inputActual = input;
        }

        public void Cambiar(MovimientoInput input, CamaraPrioridad camara)
        {
            if (_inputActual != null)
                _inputActual.Desactivar();
            if (_camaraActual != null)
                _camaraActual.Desactivar();

            _camaraActual = camara;
            _inputActual = input;

            _camaraActual.Activar();
            _inputActual.Activar();
        }
    }
}
