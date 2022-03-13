using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ItIsNotOnlyMe
{
    public class CambioAEstacion : MonoBehaviour
    {
        [SerializeField] private InputMovimientoLibreSO _inputPlayer;

        [Space]

        [SerializeField] private SceneManager _sceneManager;
        [SerializeField] private InputMovimientoInterfazSO _nuevoInput;
        [SerializeField] private CamaraPrioridad _nuevaCamara;

        private void OnTriggerStay(Collider other)
        {
            if (_inputPlayer.Interactuar)
                _sceneManager.Cambiar(_nuevoInput, _nuevaCamara);
        }
    }
}
