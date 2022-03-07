using System;
using System.Collections.Generic;
using UnityEngine;

namespace ItIsNotOnlyMe
{
    [RequireComponent(typeof(CharacterController))]
    public class FPSController : MonoBehaviour
    {
        [SerializeField] private InputEntreAccionesSO _inputPlayer;

        [Space]

        [SerializeField] private Camera _cam;

        [Space]

        [SerializeField] private float _walkSpeed = 3;
        [SerializeField] private float _smoothMoveTime = 0f;
        [SerializeField] private float _gravity = 18;

        [SerializeField] private bool _lockCursor;
        [SerializeField] private float _mouseSensitivity = 10;
        [SerializeField] private Vector2 _pitchMinMax = new Vector2(-40, 85);
        [SerializeField] private float _rotationSmoothTime = 0f;

        private CharacterController _controller;
        [SerializeField] private float _yaw;
        [SerializeField] private float _pitch;
        private float _smoothYaw;
        private float _smoothPitch;

        private float _yawSmoothV;
        private float _pitchSmoothV;
        private float _verticalVelocity;
        private Vector3 _velocity;
        private Vector3 _smoothV;
        private Vector3 _inputDireccion;

        private void OnEnable()
        {
            _inputPlayer.EventoMover += ActualizarInput;
            _inputPlayer.EventoRotar += Rotar;
        }

        private void OnDisable()
        {
            _inputPlayer.EventoMover -= ActualizarInput;
            _inputPlayer.EventoRotar -= Rotar;
        }

        void Start()
        {
            if (_lockCursor)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }

            _controller = GetComponent<CharacterController>();

            _yaw = transform.eulerAngles.y;
            _pitch = _cam.transform.localEulerAngles.x;
            _smoothYaw = _yaw;
            _smoothPitch = _pitch;
        }

        void Update()
        {
            Mover();
        }

        void ActualizarInput(Vector2 movimiento)
        {
            _inputDireccion = new Vector3(movimiento.x, 0, movimiento.y).normalized;
        }

        void Mover()
        {
            Vector3 worldInputDir = transform.TransformDirection(_inputDireccion);
            Vector3 targetVelocity = worldInputDir * _walkSpeed;
            _velocity = Vector3.SmoothDamp(_velocity, targetVelocity, ref _smoothV, _smoothMoveTime);

            _verticalVelocity -= _gravity * Time.deltaTime;
            _velocity = new Vector3(_velocity.x, _verticalVelocity, _velocity.z);

            var flags = _controller.Move(_velocity * Time.deltaTime);
            if (flags == CollisionFlags.Below)
                _verticalVelocity = 0;
        }

        void Rotar(Vector2 rotacion)
        {
            _yaw += rotacion.x * _mouseSensitivity / 10;
            _pitch -= rotacion.y * _mouseSensitivity / 10;
            _pitch = Mathf.Clamp(_pitch, _pitchMinMax.x, _pitchMinMax.y);
            _smoothPitch = Mathf.SmoothDampAngle(_smoothPitch, _pitch, ref _pitchSmoothV, _rotationSmoothTime);
            _smoothYaw = Mathf.SmoothDampAngle(_smoothYaw, _yaw, ref _yawSmoothV, _rotationSmoothTime);

            transform.eulerAngles = Vector3.up * _smoothYaw;
            _cam.transform.localEulerAngles = Vector3.right * _smoothPitch;
        }
    }
}
