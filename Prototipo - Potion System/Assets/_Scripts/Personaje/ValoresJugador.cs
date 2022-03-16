using UnityEngine;

namespace ItIsNotOnlyMe
{
    [CreateAssetMenu(fileName = "Valores de movimiento", menuName = "Valores/Valores de movimiento")]
    public class ValoresJugador : ScriptableObject
    {
        public float WalkSpeed = 8;
        public float SmoothMoveTime = 0;
        public float Gravity = 18;

        public float RotationSmoothTime = 0;
        public float MouseSensitivity = 3;
        public float VelocidadHorizontal = 10f;
        public float VelocidadVertical = 10f;
        public float AnguloClamp = 80f;
    }
}
