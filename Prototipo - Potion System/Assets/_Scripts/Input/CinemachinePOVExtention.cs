using UnityEngine;
using Cinemachine;

namespace ItIsNotOnlyMe
{
    public class CinemachinePOVExtention : CinemachineExtension
    {
        [SerializeField] private InputMovimientoLibreSO _inputPlayer;

        [SerializeField] private ValoresJugador _valores;

        private Vector3 _rotacionInicial;

        protected override void Awake()
        {
            _rotacionInicial = transform.localRotation.eulerAngles;
            base.Awake();
        }

        protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam, CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
        {
            if (!vcam.Follow)
                return;

            if (stage != CinemachineCore.Stage.Aim)
                return;

            Vector2 deltaInput = _inputPlayer.DeltaMouse;

            _rotacionInicial.x += deltaInput.x * _valores.VelocidadVertical * Time.deltaTime * _valores.MouseSensitivity;
            _rotacionInicial.y += deltaInput.y * _valores.VelocidadHorizontal * Time.deltaTime * _valores.MouseSensitivity;
            _rotacionInicial.y = Mathf.Clamp(_rotacionInicial.y, -_valores.AnguloClamp, _valores.AnguloClamp);

            state.RawOrientation = Quaternion.Euler(-_rotacionInicial.y, _rotacionInicial.x, 0f);
        }
    }
}
