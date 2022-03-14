using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ItIsNotOnlyMe
{
    public class Menu : MonoBehaviour
    {
        [SerializeField] private InputMovimientoLibreSO _inputPlayer;
        [SerializeField] private GameObject _tablero;

        private bool _estadoMenu;

        private void Awake()
        {
            _tablero.SetActive(false);
            _estadoMenu = false;
        }

        private void OnEnable() => _inputPlayer.EventoMenu += Cambiar;
        private void OnDisable() => _inputPlayer.EventoMenu -= Cambiar;

        private void Cambiar()
        {
            _estadoMenu = !_estadoMenu;
            _tablero.SetActive(_estadoMenu);
        }
    }
}
