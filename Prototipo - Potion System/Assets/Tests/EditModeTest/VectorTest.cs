using System.Collections.Generic;
using NUnit.Framework;
using ItIsNotOnlyMe.VectorDinamico;
using UnityEngine;

public class VectorTest
{
    private IIdentificador _x, _y, _z;

    public VectorTest()
    {
        _x = new IdentificadorPrueba();
        _y = new IdentificadorPrueba();
        _z = new IdentificadorPrueba();
    }

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

    [Test]
    public void Test08DistanciaEntreDosVectoresIguales()
    {
        float valorX1 = 4f, valorY1 = 3.5f, valorZ1 = 0.5f;
        Vector vector1 = CrearVector(valorX1, valorY1, valorZ1);

        Assert.AreEqual(0f, MathfVectores.Distancia(vector1, vector1));
    }

    [Test]
    public void Test09DistanciaEntreDosVectoresDistintos()
    {
        float valorX1 = 4f, valorY1 = 3.5f, valorZ1 = 0.5f;
        Vector vector1 = CrearVector(valorX1, valorY1, valorZ1);

        float valorX2 = 3.8f, valorY2 = 4f, valorZ2 = -0.5f;
        Vector vector2 = CrearVector(valorX2, valorY2, valorZ2);

        float diffX = valorX1 - valorX2;
        float diffY = valorY1 - valorY2;
        float diffZ = valorZ1 - valorZ2;

        float distancia = Mathf.Sqrt(diffX * diffX + diffY * diffY + diffZ * diffZ);

        Assert.AreEqual(distancia, MathfVectores.Distancia(vector1, vector2));
    }

    [Test]
    public void Test10LaSimilitudEntreDosVectoresMultiplosEsUno()
    {
        float valorX1 = 4f, valorY1 = 3.5f, valorZ1 = 0.5f;
        Vector vector1 = CrearVector(valorX1, valorY1, valorZ1);

        float valorX2 = 8f, valorY2 = 7f, valorZ2 = 1f;
        Vector vector2 = CrearVector(valorX2, valorY2, valorZ2);

        Assert.AreEqual(1f, MathfVectores.Similitud(vector1, vector2));
    }

    [Test]
    public void Test11LaSimilitudEntreDosVectoresOrtogonalesEsCero()
    {
        float valorX1 = 4f, valorY1 = 3.5f, valorZ1 = 0.5f;
        Vector vector1 = CrearVector(valorX1, valorY1, valorZ1);

        float valorX2 = -0.5f, valorY2 = 0f, valorZ2 = 4f;
        Vector vector2 = CrearVector(valorX2, valorY2, valorZ2);

        Assert.AreEqual(0f, MathfVectores.Similitud(vector1, vector2));
    }

    [Test]
    public void Test12LaSimilitudEntreUnVectorYSuInversoEsMenosUno()
    {
        float valorX1 = 4f, valorY1 = 3.5f, valorZ1 = 0.5f;
        Vector vector1 = CrearVector(valorX1, valorY1, valorZ1);

        float valorX2 = -4f, valorY2 = -3.5f, valorZ2 = -0.5f;
        Vector vector2 = CrearVector(valorX2, valorY2, valorZ2);

        Assert.AreEqual(-1f, MathfVectores.Similitud(vector1, vector2));
    }

    [Test]
    public void Test13LaMultiplicidadEntreElMismoVectorEsUno()
    {
        float valorX1 = 4f, valorY1 = 3.5f, valorZ1 = 0.5f;
        Vector vector1 = CrearVector(valorX1, valorY1, valorZ1);

        Assert.AreEqual(1f, MathfVectores.Multiplicdad(vector1, vector1));
    }

    [Test]
    public void Test14LaMultiplicidadEntreUnVectorYElDobleEsDos()
    {
        float valorX1 = 4f, valorY1 = 3.5f, valorZ1 = 0.5f;
        Vector vector1 = CrearVector(valorX1, valorY1, valorZ1);

        float valorX2 = 8f, valorY2 = 7f, valorZ2 = 1f;
        Vector vector2 = CrearVector(valorX2, valorY2, valorZ2);

        Assert.AreEqual(2f, MathfVectores.Multiplicdad(vector1, vector2));
    }

    [Test]
    public void Test15LaMultiplicidadEntreUnVectorYElInversoEsMenosUno()
    { 
        float valorX1 = 4f, valorY1 = 3.5f, valorZ1 = 0.5f;
        Vector vector1 = CrearVector(valorX1, valorY1, valorZ1);

        float valorX2 = -4f, valorY2 = -3.5f, valorZ2 = -0.5f;
        Vector vector2 = CrearVector(valorX2, valorY2, valorZ2);

        Assert.AreEqual(-1f, MathfVectores.Multiplicdad(vector1, vector2));
    }

    [Test]
    public void Test16UnVectorMultiplicadoPorUnIdentificadorEspecifico()
    {
        float valorX = 4f, valorY = 3.5f, valorZ = 0.5f;
        Vector vector = CrearVector(valorX, valorY, valorZ);

        float multiplicador = 2f;
        Vector resultado = vector.Multiplicar(multiplicador, _x);
        Vector vectorEsperado = CrearVector(valorX * multiplicador, valorY, valorZ);

        Assert.IsTrue(resultado.EsIgual(vectorEsperado));
    }

    [Test]
    public void Test17UnaSumaDeVectoresMultiplicadoPorUnIdentificadorEspecifico()
    {
        float valorX1 = 4f, valorY1 = 3.5f, valorZ1 = 0.5f;
        Vector vector1 = CrearVector(valorX1, valorY1, valorZ1);

        float valorX2 = 5f, valorY2 = -2f, valorZ2 = 6.25f;
        Vector vector2 = CrearVector(valorX2, valorY2, valorZ2);

        float multiplicador = 2f;
        Vector resultado = (vector1.Sumar(vector2)).Multiplicar(multiplicador, _x);
        Vector vectorEsperado = CrearVector((valorX1 + valorX2) * multiplicador, valorY1 + valorY2, valorZ1 + valorZ2);

        Assert.IsTrue(resultado.EsIgual(vectorEsperado));
    }
}
