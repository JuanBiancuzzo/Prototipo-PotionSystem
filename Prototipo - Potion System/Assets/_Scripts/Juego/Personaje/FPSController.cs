using UnityEngine;
using Cinemachine;

namespace ItIsNotOnlyMe
{

    [RequireComponent(typeof(CharacterController))]
    public class FPSController : MonoBehaviour
    {
        [SerializeField] private InputMovimientoLibreSO _inputPlayer;
        [SerializeField] private ValoresJugador _valores;
        [SerializeField] private Camera _camara;
        [SerializeField] private bool _lockCursor;

        private CharacterController _controller;

        private float _verticalVelocity;
        
        private Vector3 _velocidad;
        private Vector3 _smoothV;

        void Awake()
        {
            if (_lockCursor)
                LockMouse();

            _controller = GetComponent<CharacterController>();
        }

        private void OnApplicationFocus(bool focus)
        {
            if (focus && _lockCursor)
                LockMouse();
        }

        private void LockMouse()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        private void Update()
        {
            Mover();
        }

        private void Mover()
        {
            Vector2 movimiento = _inputPlayer.Movimiento;
            Vector3 inputDireccion = new Vector3(movimiento.x, 0, movimiento.y);
            Vector3 worldInputDir = transform.TransformDirection(inputDireccion);
            Vector3 targetVelocity = worldInputDir * _valores.WalkSpeed;
            _velocidad = Vector3.SmoothDamp(_velocidad, targetVelocity, ref _smoothV, _valores.SmoothMoveTime);

            _verticalVelocity -= _valores.Gravity * Time.deltaTime;
            _velocidad = new Vector3(_velocidad.x, _verticalVelocity, _velocidad.z);

            var flags = _controller.Move(_velocidad * Time.deltaTime);
            if (flags == CollisionFlags.Below)
                _verticalVelocity = 0;

            float forwardX = _camara.transform.forward.x;
            float forwardY = transform.forward.y;
            float forwardZ = _camara.transform.forward.z;
            transform.forward = new Vector3(forwardX, forwardY, forwardZ);
        }
    }
}
