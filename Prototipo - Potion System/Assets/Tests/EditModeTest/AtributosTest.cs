using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using ItIsNotOnlyMe;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.TestTools.Utils;

public class AtributosTest
{
    private IdentificadorPrueba _vida = new IdentificadorPrueba();
    private IdentificadorPrueba _temperatura = new IdentificadorPrueba();
    private IdentificadorPrueba _visibilidad = new IdentificadorPrueba();
    private IdentificadorPrueba _velocidad = new IdentificadorPrueba();
    private IdentificadorPrueba _estado = new IdentificadorPrueba();
    private IdentificadorPrueba _densidad = new IdentificadorPrueba();

    [Test]
    public void Test01DistanciaEntreDosAtributosConParesIgualesYEnElMismoOrden()
    {
        List<Par> paresPropio = new List<Par>
        {
            new Par(_vida, 4f), new Par(_temperatura, 3.5f), new Par(_visibilidad, 0.5f),
            new Par(_velocidad, -3f), new Par(_estado, -5f), new Par(_densidad, 1.5f)
        };
        Atributos propio = new Atributos(paresPropio);

        List<Par> paresOtro = new List<Par>
        {
            new Par(_vida, 3.8f), new Par(_temperatura, 2f), new Par(_visibilidad, 1f),
            new Par(_velocidad, -3f), new Par(_estado, -5f), new Par(_densidad, 1.5f)
        };
        Atributos otro = new Atributos(paresOtro);

        float diffVida = Mathf.Pow(4f - 3.8f, 2);
        float diffTemperatura = Mathf.Pow(3.5f - 2f, 2);
        float diffVisibilidad = Mathf.Pow(0.5f - 1f, 2);

        float distancia = Mathf.Sqrt(diffVida + diffTemperatura + diffVisibilidad);

        Assert.AreEqual(distancia, Atributos.Comparacion(propio, otro));
    }

    [Test]
    public void Test02DistanciaEntreDosAtributosConParesIgualesYEnElDiferenteOrden()
    {
        List<Par> paresPropio = new List<Par>
        {
            new Par(_vida, 4f), new Par(_temperatura, 3.5f), new Par(_visibilidad, 0.5f),
            new Par(_velocidad, -3f), new Par(_estado, -5f), new Par(_densidad, 1.5f)
        };
        Atributos propio = new Atributos(paresPropio);

        List<Par> paresOtro = new List<Par>
        {
            new Par(_vida, 3.8f), new Par(_visibilidad, 1f), new Par(_temperatura, 2f),
            new Par(_velocidad, -3f), new Par(_densidad, 1.5f), new Par(_estado, -5f)
        };
        Atributos otro = new Atributos(paresOtro);

        float diffVida = Mathf.Pow(4f - 3.8f, 2);
        float diffTemperatura = Mathf.Pow(3.5f - 2f, 2);
        float diffVisibilidad = Mathf.Pow(0.5f - 1f, 2);

        float distancia = Mathf.Sqrt(diffVida + diffTemperatura + diffVisibilidad);

        Assert.AreEqual(distancia, Atributos.Comparacion(propio, otro));
    }

    [Test]
    public void Test03DistanciaEntreDosAtributosConParesDiferentes()
    {
        List<Par> paresPropio = new List<Par>
        {
            new Par(_vida, 4f), new Par(_temperatura, 3.5f),
            new Par(_velocidad, -3f), new Par(_estado, -5f), new Par(_densidad, 1.5f)
        };
        Atributos propio = new Atributos(paresPropio);

        List<Par> paresOtro = new List<Par>
        {
            new Par(_vida, 3.8f), new Par(_visibilidad, 1f),
            new Par(_velocidad, -3f), new Par(_estado, -5f), new Par(_densidad, 1.5f)
        };
        Atributos otro = new Atributos(paresOtro);

        float diffVida = Mathf.Pow(4f - 3.8f, 2);
        float diffTemperatura = Mathf.Pow(3.5f - 0f, 2);
        float diffVisibilidad = Mathf.Pow(0f - 1f, 2);

        float distancia = Mathf.Sqrt(diffVida + diffTemperatura + diffVisibilidad);

        Assert.AreEqual(distancia, Atributos.Comparacion(propio, otro));
    }

    [Test]
    public void Test04LaSimilitudEntreDosAtributosEsUnoCuandoEsUnMultiplico()
    {
        List<Par> paresPropio = new List<Par>
        {
            new Par(_vida, 4f), new Par(_temperatura, 3.5f),
            new Par(_velocidad, -3f), new Par(_estado, -5f), new Par(_densidad, 1.5f)
        };
        Atributos propio = new Atributos(paresPropio);

        List<Par> paresOtro = new List<Par>
        {
            new Par(_vida, 8f), new Par(_temperatura, 7f),
            new Par(_velocidad, -6f), new Par(_estado, -10f), new Par(_densidad, 3f)
        };
        Atributos otro = new Atributos(paresOtro);

        FloatEqualityComparer comparador = new FloatEqualityComparer(10e-3f);
        Assert.That(Atributos.Similitud(propio, otro), Is.EqualTo(1f).Using(comparador));
    }

    [Test]
    public void Test05LaSimilitudEntreDosAtributosEsMenosUnoCuandoEsElInverso()
    {
        List<Par> paresPropio = new List<Par>
        {
            new Par(_vida, 4f), new Par(_temperatura, 3.5f),
            new Par(_velocidad, -3f), new Par(_estado, -5f), new Par(_densidad, 1.5f)
        };
        Atributos propio = new Atributos(paresPropio);

        List<Par> paresOtro = new List<Par>
        {
            new Par(_vida, -4f), new Par(_temperatura, -3.5f),
            new Par(_velocidad, 3f), new Par(_estado, 5f), new Par(_densidad, -1.5f)
        };
        Atributos otro = new Atributos(paresOtro);

        FloatEqualityComparer comparador = new FloatEqualityComparer(10e-3f);
        Assert.That(Atributos.Similitud(propio, otro), Is.EqualTo(-1f).Using(comparador));
    }

    [Test]
    public void Test06LaSimilitudEntreDosAtributosEsCeroCuandoEsOrtogonal()
    {
        List<Par> paresPropio = new List<Par>
        {
            new Par(_velocidad, -3f), new Par(_estado, -5f), new Par(_densidad, 1.5f)
        };
        Atributos propio = new Atributos(paresPropio);

        List<Par> paresOtro = new List<Par>
        {
            new Par(_vida, -4f), new Par(_temperatura, -3.5f), new Par(_visibilidad, 5f)
        };
        Atributos otro = new Atributos(paresOtro);

        FloatEqualityComparer comparador = new FloatEqualityComparer(10e-3f);
        Assert.That(Atributos.Similitud(propio, otro), Is.EqualTo(0f).Using(comparador));
    }

    [Test]
    public void Test07LaMultiplicidadEntreDosAtributosEsDosCuandoEsElDoble()
    {
        List<Par> paresPropio = new List<Par>
        {
            new Par(_vida, 4f), new Par(_temperatura, 3.5f),
            new Par(_velocidad, -3f), new Par(_estado, -5f), new Par(_densidad, 1.5f)
        };
        Atributos propio = new Atributos(paresPropio);

        List<Par> paresOtro = new List<Par>
        {
            new Par(_vida, 8f), new Par(_temperatura, 7f),
            new Par(_velocidad, -6f), new Par(_estado, -10f), new Par(_densidad, 3f)
        };
        Atributos otro = new Atributos(paresOtro);

        Assert.AreEqual(2f, Atributos.Multiplicidad(propio, otro));
    }

    [Test]
    public void Test08LaMultiplicidadEntreDosAtributosEsMenosDosCuandoEsElDobleEInverso()
    {
        List<Par> paresPropio = new List<Par>
        {
            new Par(_vida, 4f), new Par(_temperatura, 3.5f),
            new Par(_velocidad, -3f), new Par(_estado, -5f), new Par(_densidad, 1.5f)
        };
        Atributos propio = new Atributos(paresPropio);

        List<Par> paresOtro = new List<Par>
        {
            new Par(_vida, -8f), new Par(_temperatura, -7f),
            new Par(_velocidad, 6f), new Par(_estado, 10f), new Par(_densidad, -3f)
        };
        Atributos otro = new Atributos(paresOtro);

        Assert.AreEqual(-2f, Atributos.Multiplicidad(propio, otro));
    }
}
