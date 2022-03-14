using UnityEngine;
using UnityEngine.UI;

namespace ItIsNotOnlyMe
{
    public class Menu : MonoBehaviour
    {
        [SerializeField] private InputMenuSO _inputPlayer;
        [SerializeField] private InputMovimientoLibreSO _movimiento;
        [SerializeField] private GameObject _tablero;

        [SerializeReference] private Slider _seleccionDefault;

        private bool _estadoMenu;

        private void Awake()
        {
            _estadoMenu = false;
            _tablero.SetActive(_estadoMenu);
            _movimiento.SetActive(!_estadoMenu);
        }

        private void OnEnable() => _inputPlayer.EventoMenu += Cambiar;
        private void OnDisable() => _inputPlayer.EventoMenu -= Cambiar;

        private void Cambiar()
        {
            _estadoMenu = !_estadoMenu;
            _tablero.SetActive(_estadoMenu);
            _movimiento.SetActive(!_estadoMenu);
            _seleccionDefault.Select();
        }
    }
}
