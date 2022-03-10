using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using ItIsNotOnlyMe;
using UnityEngine;
using UnityEngine.TestTools;

public class VectorTest
{
    private IIdentificador _x = new IdentificadorPrueba();
    private IIdentificador _y = new IdentificadorPrueba();
    private IIdentificador _z = new IdentificadorPrueba();

    private Vector CrearVector(float x, float y)
    {
        return new Vector(new List<IComponente> {
            new Componente(_x, x), new Componente(_y, y)
        });
    }

    private Vector CrearVector(float x, float y, float z)
    {
        return new Vector(new List<IComponente> {
            new Componente(_x, x), new Componente(_y, y), new Componente(_z, z)
        });
    }

    private Vector CrearVector(float y)
    {
        return new Vector(new List<IComponente> {
            new Componente(_y, y)
        });
    }

    [Test]
    public void Test01SeSumaDosVectores()
    {
        Vector vector1 = CrearVector(8, 0);
        Vector vector2 = CrearVector(0, -3, 3);

        Vector resultado = vector1.Sumar(vector2);
        Vector vectorEsperado = CrearVector(8, -3, 3);

        Assert.IsTrue(resultado.EsIgual(vectorEsperado));
    }

    [Test]
    public void Test02SeRestanDosVectores()
    {
        Vector vector1 = CrearVector(8, 0);
        Vector vector2 = CrearVector(0, -3, 3);

        Vector resultado = vector1.Restar(vector2);
        Vector vectorEsperado = CrearVector(8, 3, -3);

        Assert.IsTrue(resultado.EsIgual(vectorEsperado));
    }

    [Test]
    public void Test03SeSumaDosVectoresYLuegoSeRestaUnTercero()
    {
        Vector vector1 = CrearVector(8, 0);
        Vector vector2 = CrearVector(-5);
        Vector vector3 = CrearVector(0, -3, 3);

        Vector resultado = vector1.Sumar(vector2).Restar(vector3);
        Vector vectorEsperado = CrearVector(8, -2, -3);

        Assert.IsTrue(resultado.EsIgual(vectorEsperado));
    }

    [Test]
    public void Test04SeMultiplicaUnVector()
    {
        Vector vector = CrearVector(0, -3, 3);

        Vector resultado = vector.Multiplicar(4f);
        Vector vectorEsperado = CrearVector(0, -12f, 12f);

        Assert.IsTrue(resultado.EsIgual(vectorEsperado));
    }

    [Test]
    public void Test05SeDivideUnVector()
    {
        Vector vector = CrearVector(0, -3, 3);

        Vector resultado = vector.Dividir(3f);
        Vector vectorEsperado = CrearVector(0, -1f, 1f);

        Assert.IsTrue(resultado.EsIgual(vectorEsperado));
    }

    [Test]
    public void Test06SeCalculaElProductoInternoEntreElMismoVector()
    {
        Vector vector = CrearVector(8, -2, 3);
        float productoInterno = 8 * 8 + 2 * 2 + 3 * 3;

        Assert.AreEqual(productoInterno, vector.ProductoInterno(vector));
    }

    [Test]
    public void Test06SeCalculaElProductoInternoEntreLaSumaDeDosVectores()
    {
        Vector vector1 = CrearVector(8, 0);
        Vector vector2 = CrearVector(2, -3, 3);

        Vector resultado = vector1.Sumar(vector2);
        float productoInterno = 10 * 10 + 3 * 3 + 3 * 3;

        Assert.AreEqual(productoInterno, resultado.ProductoInterno(resultado));
    }

    [Test]
    public void Test07SeCalculaElProductoInternoEntreLaDiferenciaDeDosVectores()
    {
        Vector vector1 = CrearVector(8, 0);
        Vector vector2 = CrearVector(2, -3, 3);

        Vector resultado = vector1.Restar(vector2);
        float productoInterno = 6 * 6 + 3 * 3 + 3 * 3;

        Assert.AreEqual(productoInterno, resultado.ProductoInterno(resultado));
    }
}
