using UnityEngine;
using Cinemachine;

namespace ItIsNotOnlyMe
{
    public class CinemachinePOVExtention : CinemachineExtension
    {
        [SerializeField] private InputMovimientoLibreSO _inputPlayer;

        [SerializeField] private ValoresJugador _valores;

        private Vector3 _rotacionInicial;
        private Vector2 _deltaInput;

        protected override void Awake()
        {
            _rotacionInicial = transform.localRotation.eulerAngles;
            _inputPlayer.EventoRotar += ActualizarDetla;
            base.Awake();
        }

        private void ActualizarDetla(Vector2 rotacion)
        {
            _deltaInput = rotacion;
        }

        protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam, CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
        {
            if (!vcam.Follow)
                return;

            if (stage != CinemachineCore.Stage.Aim)
                return;

            _rotacionInicial.x += _deltaInput.x * _valores.VelocidadVertical * Time.deltaTime * _valores.MouseSensitivity;
            _rotacionInicial.y += _deltaInput.y * _valores.VelocidadHorizontal * Time.deltaTime * _valores.MouseSensitivity;
            _rotacionInicial.y = Mathf.Clamp(_rotacionInicial.y, -_valores.AnguloClamp, _valores.AnguloClamp);

            state.RawOrientation = Quaternion.Euler(-_rotacionInicial.y, _rotacionInicial.x, 0f);
        }
    }
}