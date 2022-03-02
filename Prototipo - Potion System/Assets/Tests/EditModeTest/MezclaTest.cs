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

    private class CambiarMultiplicarPrueba : ICambiar
    {
        private float _valorSumar;
        private IIdentificador _identificador;

        public CambiarMultiplicarPrueba(float valorSumar, IIdentificador identificador)
        {
            _valorSumar = valorSumar;
            _identificador = identificador;
        }

        public void Cambiar(ICambiante cambiante)
        {
            cambiante.AgregarModificador(this);
        }

        public float Modificar(IIdentificador identificador, float valor)
        {
            if (_identificador.EsIgual(identificador))
                return valor * _valorSumar;
            return valor;
        }
    }

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
        Mezcla mezcla = new Mezcla(atributosInicial);

        Atributos resultado = mezcla.CalcularEstado();

        Assert.AreEqual(valorVida, resultado.GetValor(_vida));
        Assert.AreEqual(valorTemp, resultado.GetValor(_temp));
        Assert.AreEqual(valorVel, resultado.GetValor(_vel));
    }

    [Test]
    public void Test02MezclaConUnIngredientesAlCalcularElEstadoEsIgualAlEstadoInicialMasElIngrediente()
    {
        float valorVida = 5f, valorTemp = 3f, valorVel = 4f;
        Atributos atributosInicial = new Atributos(new List<Par>
        {
            new Par(_vida, valorVida), new Par(_temp, valorTemp), new Par(_vel, valorVel)
        });
        Mezcla mezcla = new Mezcla(atributosInicial);


        float valorVidaIngre = 4f, valorTempIngre = 3f, valorVelIngre = 5f;
        IIngrediente ingrediente = new Ingrediente(new Atributos(new List<Par>
        {
            new Par(_vida, valorVidaIngre), new Par(_temp, valorTempIngre), 
            new Par(_vel, valorVelIngre)
        }));

        mezcla.Agregar(ingrediente);

        Atributos resultado = mezcla.CalcularEstado();

        Assert.AreEqual(valorVida + valorVidaIngre, resultado.GetValor(_vida));
        Assert.AreEqual(valorTemp + valorTempIngre, resultado.GetValor(_temp));
        Assert.AreEqual(valorVel + valorVelIngre, resultado.GetValor(_vel));
    }

    [Test]
    public void Test03MezclaConDosIngredientesYAlCalcularElEstadoEsIgaulEstadoInicialMasLosDosIngredientes()
    {
        float valorVida = 5f, valorTemp = 3f, valorVel = 4f;
        Atributos atributosInicial = new Atributos(new List<Par>
        {
            new Par(_vida, valorVida), new Par(_temp, valorTemp), new Par(_vel, valorVel)
        });
        Mezcla mezcla = new Mezcla(atributosInicial);

        float valorVidaIngre1 = 4f, valorTempIngre1 = 3f, valorVelIngre1 = 5f;
        IIngrediente ingrediente1 = new Ingrediente(new Atributos(new List<Par>
        {
            new Par(_vida, valorVidaIngre1), new Par(_temp, valorTempIngre1),
            new Par(_vel, valorVelIngre1)
        }));


        float valorVidaIngre2 = 4f, valorTempIngre2 = 3f, valorVelIngre2 = 5f;
        IIngrediente ingrediente2 = new Ingrediente(new Atributos(new List<Par>
        {
            new Par(_vida, valorVidaIngre2), new Par(_temp, valorTempIngre2),
            new Par(_vel, valorVelIngre2)
        }));


        mezcla.Agregar(ingrediente1);
        mezcla.Agregar(ingrediente2);
        Atributos resultado = mezcla.CalcularEstado();

        FloatEqualityComparer comparador = new FloatEqualityComparer(10e-3f);

        float resultadoEsperado = valorVida + valorVidaIngre1 + valorVidaIngre2;
        Assert.That(resultado.GetValor(_vida), Is.EqualTo(resultadoEsperado).Using(comparador));
        resultadoEsperado = valorTemp + valorTempIngre1 + valorTempIngre2;
        Assert.That(resultado.GetValor(_temp), Is.EqualTo(resultadoEsperado).Using(comparador));
        resultadoEsperado = valorVel + valorVelIngre1 + valorVelIngre2;
        Assert.That(resultado.GetValor(_vel), Is.EqualTo(resultadoEsperado).Using(comparador));
    }

    [Test]
    public void Test04MezclaConUnIngredienteDespuesDeFinalizarAlCalcularDeEstadoEsIgualAlEstadoInicial()
    {
        float valorVida = 5f, valorTemp = 3f, valorVel = 4f;
        Atributos atributosInicial = new Atributos(new List<Par>
        {
            new Par(_vida, valorVida), new Par(_temp, valorTemp), new Par(_vel, valorVel)
        });
        Mezcla mezcla = new Mezcla(atributosInicial);

        float valorVidaIngre = 4f, valorTempIngre = 3f, valorVelIngre = 5f;
        IIngrediente ingrediente = new Ingrediente(new Atributos(new List<Par>
        {
            new Par(_vida, valorVidaIngre), new Par(_temp, valorTempIngre),
            new Par(_vel, valorVelIngre)
        }));

        mezcla.Agregar(ingrediente);

        Atributos resultado = mezcla.CalcularEstado();

        Assert.AreEqual(valorVida + valorVidaIngre, resultado.GetValor(_vida));
        Assert.AreEqual(valorTemp + valorTempIngre, resultado.GetValor(_temp));
        Assert.AreEqual(valorVel + valorVelIngre, resultado.GetValor(_vel));

        mezcla.Finalizar();
        resultado = mezcla.CalcularEstado();

        Assert.AreEqual(valorVida, resultado.GetValor(_vida));
        Assert.AreEqual(valorTemp, resultado.GetValor(_temp));
        Assert.AreEqual(valorVel, resultado.GetValor(_vel));
    }

    [Test]
    public void Test05MezclaConDosIngredientesAlMezclarseElCalculaodDeEstadoEsIgualAlEstadoInicialMasElIngredienteCombinado()
    {
        float valorVida = 5f, valorTemp = 3f, valorVel = 4f;
        Atributos atributosInicial = new Atributos(new List<Par>
        {
            new Par(_vida, valorVida), new Par(_temp, valorTemp), new Par(_vel, valorVel)
        });
        Mezcla mezcla = new Mezcla(atributosInicial);

        float valorAMultiplicar = 2f;
        ICambiar cambiar = new CambiarMultiplicarPrueba(valorAMultiplicar, _vida);

        List<ICambiar> modificadores = new List<ICambiar> { cambiar };

        float valorVidaIngre1 = 5f, valorTempIngre1 = 3f, valorVelIngre1 = 4f;
        Atributos atributosBase1 = new Atributos(new List<Par>
        {
            new Par(_vida, valorVidaIngre1), new Par(_temp, valorTempIngre1), new Par(_vel, valorVelIngre1)
        });
        IIngrediente ingrediente1 = new Ingrediente(atributosBase1, modificadores);


        float valorVidaIngre2 = 4f, valorTempIngre2 = 3f, valorVelIngre2 = 5f;
        IIngrediente ingrediente2 = new Ingrediente(new Atributos(new List<Par>
        {
            new Par(_vida, valorVidaIngre2), new Par(_temp, valorTempIngre2),
            new Par(_vel, valorVelIngre2)
        }));

        mezcla.Agregar(ingrediente1);
        mezcla.Agregar(ingrediente2);

        mezcla.Mezclar();
        Atributos resultado = mezcla.CalcularEstado();

        FloatEqualityComparer comparador = new FloatEqualityComparer(10e-3f);

        float resultadoEsperado = valorVida + valorVidaIngre1 + valorVidaIngre2 * valorAMultiplicar;
        Assert.That(resultado.GetValor(_vida), Is.EqualTo(resultadoEsperado).Using(comparador));
        resultadoEsperado = valorTemp + valorTempIngre1 + valorTempIngre2;
        Assert.That(resultado.GetValor(_temp), Is.EqualTo(resultadoEsperado).Using(comparador));
        resultadoEsperado = valorVel + valorVelIngre1 + valorVelIngre2;
        Assert.That(resultado.GetValor(_vel), Is.EqualTo(resultadoEsperado).Using(comparador));
    }
}
