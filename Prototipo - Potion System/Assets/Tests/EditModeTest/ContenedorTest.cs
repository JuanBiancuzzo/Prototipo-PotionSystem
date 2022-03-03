using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using ItIsNotOnlyMe;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.TestTools.Utils;

public class ContenedorTest
{
    private Mezcla _mezcla; 
    private Atributos _estadoInicial;
    private IIdentificador _vida, _temp, _vel;

    public ContenedorTest()
    {

        _vida = new IdentificadorPrueba();
        _temp = new IdentificadorPrueba();
        _vel = new IdentificadorPrueba();

        _estadoInicial = new Atributos(new List<Par>
        {
            new Par(_vida, 1f), new Par(_temp, 1f), new Par(_vel, 1f)
        });
        _mezcla = new Mezcla(_estadoInicial);
    }

    private IIngrediente CrearIngrediente(float valorVida, float valorTemp, float valorVel)
    {
        Atributos atributo = new Atributos(new List<Par>
        {
            new Par(_vida, valorVida), new Par(_temp, valorTemp), new Par(_vel, valorVel)
        });
        return new Ingrediente(atributo);
    }

    [Test]
    public void Test01UnContenedorSinIngredientesDaUnaPosionIgualAlEstadoInicial()
    {
        IContenedor contenedor = new Contenedor(_mezcla);
        Pocion pocionEsperada = new Pocion(_estadoInicial);

        Pocion pocionResultado = contenedor.Finalizar();

        FloatEqualityComparer comparador = new FloatEqualityComparer(10e-3f);
        Assert.That(pocionEsperada.Similitud(pocionResultado), Is.EqualTo(1f).Using(comparador));
        Assert.That(pocionEsperada.Multiplicidad(pocionResultado), Is.EqualTo(1f).Using(comparador));
    }

    [Test]
    public void Test02UnContenedorConUnIngredienteDaUnaPosicionIgualAlEstadoInicialMasElEstadoDelIngrediente()
    {
        
        float valorVida = 4f, valorTemp = 3f, valorVel = 5f;
        Atributos atributo = new Atributos(new List<Par>
        {
            new Par(_vida, valorVida), new Par(_temp, valorTemp), new Par(_vel, valorVel)
        });
        IIngrediente ingrediente =  new Ingrediente(atributo);

        Pocion pocionEsperada = new Pocion(Atributos.Sumar(_estadoInicial, atributo));
        IContenedor contenedor = new Contenedor(_mezcla);
        contenedor.AgregarIngrediente(ingrediente);

        Pocion pocionResultado = contenedor.Finalizar();

        FloatEqualityComparer comparador = new FloatEqualityComparer(10e-3f);
        Assert.That(pocionEsperada.Similitud(pocionResultado), Is.EqualTo(1f).Using(comparador));
        Assert.That(pocionEsperada.Multiplicidad(pocionResultado), Is.EqualTo(1f).Using(comparador));
    }
}
