using UnityEngine;

namespace ItIsNotOnlyMe
{
    public struct Atributos
    {
        public float Vida, Temperatura, Visivilidad, Velocidad, Estado, Peso;

        public Atributos(float vida, float temperatura, float visivilidad, 
                         float velocidad, float estado, float peso)
        {
            Vida = vida;
            Temperatura = temperatura;
            Visivilidad = visivilidad;
            Velocidad = velocidad;
            Estado = estado;
            Peso = peso;
        }

        public static float Comparacion(Atributos propio, Atributos otro)
        {
            float[] valoresPropios = new float[6]
                { propio.Vida, propio.Temperatura, propio.Visivilidad, propio.Velocidad, propio.Estado, propio.Peso };
            float[] valoresOtro = new float[6] 
                { otro.Vida, otro.Temperatura, otro.Visivilidad, otro.Velocidad, otro.Estado, otro.Peso };

            float distancia = 0f;

            for (int i = 0; i < valoresPropios.Length; i++)
                distancia += Mathf.Pow(valoresPropios[i] - valoresOtro[i], 2);

            return Mathf.Sqrt(distancia);
        }
    }
}
