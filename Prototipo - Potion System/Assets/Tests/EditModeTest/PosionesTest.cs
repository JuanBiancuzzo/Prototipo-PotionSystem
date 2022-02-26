using NUnit.Framework;
using ItIsNotOnlyMe;
using UnityEngine;
using UnityEngine.TestTools.Utils;

public class PosionesTest
{
    [Test]
    public void DistanciaEntreUnaRecetaYUnaPosion()
    {
        Propiedades atributosReceta = new Propiedades(4f, 3.5f, 0f, -3f, -5f, 1.5f);
        Posion receta = new Posion(atributosReceta);

        Propiedades atributos = new Propiedades(3.8f, 3.5f, 1f, -3f, -5f, 1.5f);
        Posion posion = new Posion(atributos);

        float distancia = Mathf.Sqrt(Mathf.Pow(3.8f - 4f, 2) + Mathf.Pow(1f - 0f, 2));

        Assert.AreEqual(distancia, posion.Distancia(receta));
    }

    [Test]
    public void LaSimilitudEntreUnaRecetaYUnaPosionEsPerfecta()
    {
        Propiedades atributosReceta = new Propiedades(4f, 3.5f, 0f, -3f, -5f, 1.5f);
        Posion receta = new Posion(atributosReceta);

        Propiedades atributos = new Propiedades(8f, 7f, 0f, -6f, -10f, 3f);
        Posion posion = new Posion(atributos);

        FloatEqualityComparer comparador = new FloatEqualityComparer(10e-3f);
        Assert.That(receta.Similitud(posion), Is.EqualTo(1f).Using(comparador));
    }

    [Test]
    public void LaSimilitudEntreUnaRecetaYUnaPosionEsOpuesta()
    {
        Propiedades atributosReceta = new Propiedades(4f, 3.5f, 0f, -3f, -5f, 1.5f);
        Posion receta = new Posion(atributosReceta);

        Propiedades atributos = new Propiedades(-8f, -7f, 0f, 6f, 10f, -3f);
        Posion posion = new Posion(atributos);

        FloatEqualityComparer comparador = new FloatEqualityComparer(10e-3f);
        Assert.That(receta.Similitud(posion), Is.EqualTo(-1f).Using(comparador));
    }

    [Test]
    public void LaMultiplicidadEntreUnaRecetaYUnaPosionEsElDoble()
    {
        Propiedades atributosReceta = new Propiedades(4f, 3.5f, 0f, -3f, -5f, 1.5f);
        Posion receta = new Posion(atributosReceta);

        Propiedades atributos = new Propiedades(8f, 7f, 0f, -6f, -10f, 3f);
        Posion posion = new Posion(atributos);

        Assert.AreEqual(2, posion.Multiplicidad(receta));
    }
}
