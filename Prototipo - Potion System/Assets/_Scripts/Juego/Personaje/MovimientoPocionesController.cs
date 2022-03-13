using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ItIsNotOnlyMe
{
    public class MovimientoPocionesController : MonoBehaviour
    {
        [SerializeField] private InputMovimientoInterfazSO _inputPlayer;

        [Space]

        [SerializeField] private SceneManager _sceneManager;
        [SerializeField] private InputMovimientoLibreSO _nuevoInput;
        [SerializeField] private CamaraPrioridad _nuevaCamara;

        private void Update()
        {
            Salir();
        }

        private void Salir()
        {
            if (_inputPlayer.Salir)
                _sceneManager.Cambiar(_nuevoInput, _nuevaCamara);
        }
    }
}
