using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using ItIsNotOnlyMe;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.TestTools.Utils;

public class MezclaTest
{
    private class IdentificadorPrueba : IIdentificador
    {
        private static int _contador = 0;
        private int _id;

        public IdentificadorPrueba()
        {
            _id = _contador;
            _contador++;
        }

        public int GetID()
        {
            return _id;
        }

        public bool EsIgual(IIdentificador identificador)
        {
            return _id == identificador.GetID();
        }
    }

    private class FactoryPrueba : IFactoryContador
    {
        public IContadorDeProgreso CrearContador()
        {
            return new ProgresoPorcentual();
        }
    }

    private FactoryPrueba _factory = new FactoryPrueba();
    private IIdentificador _vida = new IdentificadorPrueba();
    private IIdentificador _temp = new IdentificadorPrueba();
    private IIdentificador _vel = new IdentificadorPrueba();

    [Test]
    public void Test01MezclaSinIngredientesAlCalcularElEstadoEsIgualAlEstadoInicial()
    {
        float valorVida = 5f, valorTemp = 3f, valorVel = 4f;
        Atributos atributosInicial = new Atributos(new List<Par>
        {
            new Par(_vida, valorVida), new Par(_temp, valorTemp), new Par(_vel, valorVel)
        });
        Mezcla mezcla = new Mezcla(atributosInicial, _factory);

        Atributos resultado = mezcla.CalcularEstado();

        Assert.AreEqual(valorVida, resultado.GetValor(_vida));
        Assert.AreEqual(valorTemp, resultado.GetValor(_temp));
        Assert.AreEqual(valorVel, resultado.GetValor(_vel));
    }

    [Test]
    public void Test02MezclaConUnIngredientesSinNingunAvanceAlCalcularElEstadoEsIgualAlEstadoInicial()
    {
        float valorVida = 5f, valorTemp = 3f, valorVel = 4f;
        Atributos atributosInicial = new Atributos(new List<Par>
        {
            new Par(_vida, valorVida), new Par(_temp, valorTemp), new Par(_vel, valorVel)
        });
        Mezcla mezcla = new Mezcla(atributosInicial, _factory);


        float _valorVidaIngre = 4f, _valorTempIngre = 3f, _valorVelIngre = 5f;
        IIngrediente ingrediente = new Ingrediente(new Atributos(new List<Par>
        {
            new Par(_vida, _valorVidaIngre), new Par(_temp, _valorTempIngre), 
            new Par(_vel, _valorVelIngre)
        }));

        mezcla.Agregar(ingrediente);

        Atributos resultado = mezcla.CalcularEstado();

        Assert.AreEqual(valorVida, resultado.GetValor(_vida));
        Assert.AreEqual(valorTemp, resultado.GetValor(_temp));
        Assert.AreEqual(valorVel, resultado.GetValor(_vel));
    }

    [Test]
    public void Test03MezclaConUnIngredientesCon10DeAvanceAlCalcularElEstadoEsElEstadoInicialMas10PorcientoDelIngrediente()
    {
        float valorVida = 5f, valorTemp = 3f, valorVel = 4f;
        Atributos atributosInicial = new Atributos(new List<Par>
        {
            new Par(_vida, valorVida), new Par(_temp, valorTemp), new Par(_vel, valorVel)
        });
        Mezcla mezcla = new Mezcla(atributosInicial, _factory);


        float valorVidaIngre = 4f, valorTempIngre = 3f, valorVelIngre = 5f;
        IIngrediente ingrediente = new Ingrediente(new Atributos(new List<Par>
        {
            new Par(_vida, valorVidaIngre), new Par(_temp, valorTempIngre),
            new Par(_vel, valorVelIngre)
        }));

        mezcla.Agregar(ingrediente);
        mezcla.Avanzar(10);

        Atributos resultado = mezcla.CalcularEstado();

        Assert.AreEqual(valorVida + 0.1f * valorVidaIngre, resultado.GetValor(_vida));
        Assert.AreEqual(valorTemp + 0.1f * valorTempIngre, resultado.GetValor(_temp));
        Assert.AreEqual(valorVel + 0.1f * valorVelIngre, resultado.GetValor(_vel));
    }

    [Test]
    public void Test04MezclaConDosIngredientesUnoCon10DeAvanceYElOtroCon20DeAvanceYElEstadoEsEstadoInicialMas10PorcienteMas20Porciente()
    {
        float valorVida = 5f, valorTemp = 3f, valorVel = 4f;
        Atributos atributosInicial = new Atributos(new List<Par>
        {
            new Par(_vida, valorVida), new Par(_temp, valorTemp), new Par(_vel, valorVel)
        });
        Mezcla mezcla = new Mezcla(atributosInicial, _factory);

        float valorVidaIngre1 = 4f, valorTempIngre1 = 3f, valorVelIngre1 = 5f;
        IIngrediente ingrediente1 = new Ingrediente(new Atributos(new List<Par>
        {
            new Par(_vida, valorVidaIngre1), new Par(_temp, valorTempIngre1),
            new Par(_vel, valorVelIngre1)
        }));

        mezcla.Agregar(ingrediente1);
        mezcla.Avanzar(10);

        float valorVidaIngre2 = 4f, valorTempIngre2 = 3f, valorVelIngre2 = 5f;
        IIngrediente ingrediente2 = new Ingrediente(new Atributos(new List<Par>
        {
            new Par(_vida, valorVidaIngre2), new Par(_temp, valorTempIngre2),
            new Par(_vel, valorVelIngre2)
        }));

        mezcla.Agregar(ingrediente2);
        mezcla.Avanzar(10);

        Atributos resultado = mezcla.CalcularEstado();

        FloatEqualityComparer comparador = new FloatEqualityComparer(10e-3f);

        float resultadoEsperado = valorVida + 0.2f * valorVidaIngre1 + 0.1f * valorVidaIngre2;
        Assert.That(resultado.GetValor(_vida), Is.EqualTo(resultadoEsperado).Using(comparador));
        resultadoEsperado = valorTemp + 0.2f * valorTempIngre1 + 0.1f * valorTempIngre2;
        Assert.That(resultado.GetValor(_temp), Is.EqualTo(resultadoEsperado).Using(comparador));
        resultadoEsperado = valorVel + 0.2f * valorVelIngre1 + 0.1f * valorVelIngre2;
        Assert.That(resultado.GetValor(_vel), Is.EqualTo(resultadoEsperado).Using(comparador));
    }

    [Test]
    public void Test05MezclaConUnIngredienteDespuesDeFinalizarAlCalcularElEstadoEsIgualAlEstadoBase()
    {
        float valorVida = 5f, valorTemp = 3f, valorVel = 4f;
        Atributos atributosInicial = new Atributos(new List<Par>
        {
            new Par(_vida, valorVida), new Par(_temp, valorTemp), new Par(_vel, valorVel)
        });
        Mezcla mezcla = new Mezcla(atributosInicial, _factory);

        float valorVidaIngre = 4f, valorTempIngre = 3f, valorVelIngre = 5f;
        IIngrediente ingrediente = new Ingrediente(new Atributos(new List<Par>
        {
            new Par(_vida, valorVidaIngre), new Par(_temp, valorTempIngre),
            new Par(_vel, valorVelIngre)
        }));

        mezcla.Agregar(ingrediente);
        mezcla.Avanzar(10); 

        Atributos resultado = mezcla.CalcularEstado();

        Assert.AreEqual(valorVida + 0.1f * valorVidaIngre, resultado.GetValor(_vida));
        Assert.AreEqual(valorTemp + 0.1f * valorTempIngre, resultado.GetValor(_temp));
        Assert.AreEqual(valorVel + 0.1f * valorVelIngre, resultado.GetValor(_vel));

        mezcla.Finalizar();
        resultado = mezcla.CalcularEstado();

        Assert.AreEqual(valorVida, resultado.GetValor(_vida));
        Assert.AreEqual(valorTemp, resultado.GetValor(_temp));
        Assert.AreEqual(valorVel, resultado.GetValor(_vel));
    }
}
