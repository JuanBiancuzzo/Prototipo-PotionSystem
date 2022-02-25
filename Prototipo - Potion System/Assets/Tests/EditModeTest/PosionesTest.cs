using NUnit.Framework;
using ItIsNotOnlyMe;
using UnityEngine;

public class PosionesTest
{
    [Test]
    public void DistanciaEntreUnaRecetaYUnaPosicion()
    {
        Atributos atributosReceta = new Atributos(4f, 3.5f, 0f, -3f, -5f, 1.5f);
        Posion receta = new Posion(atributosReceta);

        Atributos atributos = new Atributos(3.8f, 3.5f, 1f, -3f, -5f, 1.5f);
        Posion posicion = new Posion(atributos);

        float distancia = Mathf.Sqrt(Mathf.Pow(3.8f - 4f, 2) + Mathf.Pow(1f - 0f, 2));

        Assert.AreEqual(distancia, posicion.Distancia(receta));
    }
}
