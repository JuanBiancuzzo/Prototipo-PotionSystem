using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using ItIsNotOnlyMe;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.TestTools.Utils;

public class MezclaTest
{
    private IIdentificador _vida = new IdentificadorPrueba();
    private IIdentificador _temp = new IdentificadorPrueba();
    private IIdentificador _vel = new IdentificadorPrueba();
    /*
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

    [Test]
    public void Test06MezclaConDosIngredientesAlMezclarseNoSeUnenElCalculaodDeEstadoEsIgualAlEstadoInicialMasLosDosIngredientes()
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

        float valorMinimo = 4f;
        IRequisito requisito = new RequisitoMayorPrueba(valorMinimo, _temp);

        List<ICombinacionRequisitos> requisitos = new List<ICombinacionRequisitos>
            { new ParRequisito(requisito, new RequisitoInvalidoPrueba()) };

        float valorVidaIngre2 = 4f, valorTempIngre2 = 3f, valorVelIngre2 = 5f;
        IIngrediente ingrediente2 = new Ingrediente(new Atributos(new List<Par>
        {
            new Par(_vida, valorVidaIngre2), new Par(_temp, valorTempIngre2),
            new Par(_vel, valorVelIngre2)
        }), requisitos);

        mezcla.Agregar(ingrediente1);
        mezcla.Agregar(ingrediente2);

        mezcla.Mezclar();
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
    public void Test07MezclaConTresIngredientesYAlMezclarUnaVezSoloSeCombinanDosHaciendoQueElEstadoSeaElEstadoInicialLaCombinacionYElTercerIngrediente()
    {
        // primer ingrediente

        float valorVida = 5f, valorTemp = 3f, valorVel = 4f;
        Atributos atributosInicial = new Atributos(new List<Par>
        {
            new Par(_vida, valorVida), new Par(_temp, valorTemp), new Par(_vel, valorVel)
        });
        Mezcla mezcla = new Mezcla(atributosInicial);

        float valorAMultiplicar1 = 2f;
        ICambiar cambiar1 = new CambiarMultiplicarPrueba(valorAMultiplicar1, _vida);

        List<ICambiar> modificadores1 = new List<ICambiar> { cambiar1 };

        float valorVidaIngre1 = 5f, valorTempIngre1 = 3f, valorVelIngre1 = 4f;
        Atributos atributosBase1 = new Atributos(new List<Par>
        {
            new Par(_vida, valorVidaIngre1), new Par(_temp, valorTempIngre1), new Par(_vel, valorVelIngre1)
        });
        IIngrediente ingrediente1 = new Ingrediente(atributosBase1, modificadores1);

        // segundo ingrediente

        float valorAMultiplicar2 = 3f;
        ICambiar cambiar2 = new CambiarMultiplicarPrueba(valorAMultiplicar2, _temp);

        List<ICambiar> modificadores2 = new List<ICambiar> { cambiar2 };

        float valorVidaIngre2 = 4f, valorTempIngre2 = 3f, valorVelIngre2 = 5f;
        Atributos atributosBase2 = new Atributos(new List<Par>
        {
            new Par(_vida, valorVidaIngre2), new Par(_temp, valorTempIngre2), new Par(_vel, valorVelIngre2)
        });
        IIngrediente ingrediente2 = new Ingrediente(atributosBase2, modificadores2);

        // tercer ingrediente

        float valorAMultiplicar3 = 4f;
        ICambiar cambiar3 = new CambiarMultiplicarPrueba(valorAMultiplicar3, _vel);

        List<ICambiar> modificadores3 = new List<ICambiar> { cambiar3 };

        float valorVidaIngre3 = 4f, valorTempIngre3 = 3f, valorVelIngre3 = 5f;
        Atributos atributosBase3 = new Atributos(new List<Par>
        {
            new Par(_vida, valorVidaIngre3), new Par(_temp, valorTempIngre3), new Par(_vel, valorVelIngre3)
        });
        IIngrediente ingrediente3 = new Ingrediente(atributosBase3, modificadores3);

        mezcla.Agregar(ingrediente1);
        mezcla.Agregar(ingrediente2);
        mezcla.Agregar(ingrediente3);

        mezcla.Mezclar();

        Atributos resultado = mezcla.CalcularEstado();

        FloatEqualityComparer comparador = new FloatEqualityComparer(10e-3f);

        float resultadoEsperado = valorVida + valorVidaIngre1 + valorVidaIngre2 * valorAMultiplicar1 + valorVidaIngre3;
        Assert.That(resultado.GetValor(_vida), Is.EqualTo(resultadoEsperado).Using(comparador));
        resultadoEsperado = valorTemp + valorTempIngre1 * valorAMultiplicar2 + valorTempIngre2 + valorTempIngre3;
        Assert.That(resultado.GetValor(_temp), Is.EqualTo(resultadoEsperado).Using(comparador));
        resultadoEsperado = valorVel + valorVelIngre1 + valorVelIngre2 + valorVelIngre3;
        Assert.That(resultado.GetValor(_vel), Is.EqualTo(resultadoEsperado).Using(comparador));
    }

    [Test]
    public void Test08MezclaConTresIngredientesYAlMezclarDosVecesSeCombinanHaciendoQueElEstadoSeaElEstadoInicialLaCombinacion()
    {
        // primer ingrediente

        float valorVida = 5f, valorTemp = 3f, valorVel = 4f;
        Atributos atributosInicial = new Atributos(new List<Par>
        {
            new Par(_vida, valorVida), new Par(_temp, valorTemp), new Par(_vel, valorVel)
        });
        Mezcla mezcla = new Mezcla(atributosInicial);

        float valorAMultiplicar1 = 2f;
        ICambiar cambiar1 = new CambiarMultiplicarPrueba(valorAMultiplicar1, _vida);

        List<ICambiar> modificadores1 = new List<ICambiar> { cambiar1 };

        float valorVidaIngre1 = 5f, valorTempIngre1 = 3f, valorVelIngre1 = 4f;
        Atributos atributosBase1 = new Atributos(new List<Par>
        {
            new Par(_vida, valorVidaIngre1), new Par(_temp, valorTempIngre1), new Par(_vel, valorVelIngre1)
        });
        IIngrediente ingrediente1 = new Ingrediente(atributosBase1, modificadores1);

        // segundo ingrediente

        float valorAMultiplicar2 = 3f;
        ICambiar cambiar2 = new CambiarMultiplicarPrueba(valorAMultiplicar2, _temp);

        List<ICambiar> modificadores2 = new List<ICambiar> { cambiar2 };

        float valorVidaIngre2 = 4f, valorTempIngre2 = 3f, valorVelIngre2 = 5f;
        Atributos atributosBase2 = new Atributos(new List<Par>
        {
            new Par(_vida, valorVidaIngre2), new Par(_temp, valorTempIngre2), new Par(_vel, valorVelIngre2)
        });
        IIngrediente ingrediente2 = new Ingrediente(atributosBase2, modificadores2);

        // tercer ingrediente

        float valorAMultiplicar3 = 4f;
        ICambiar cambiar3 = new CambiarMultiplicarPrueba(valorAMultiplicar3, _vel);

        List<ICambiar> modificadores3 = new List<ICambiar> { cambiar3 };

        float valorVidaIngre3 = 4f, valorTempIngre3 = 3f, valorVelIngre3 = 5f;
        Atributos atributosBase3 = new Atributos(new List<Par>
        {
            new Par(_vida, valorVidaIngre3), new Par(_temp, valorTempIngre3), new Par(_vel, valorVelIngre3)
        });
        IIngrediente ingrediente3 = new Ingrediente(atributosBase3, modificadores3);

        mezcla.Agregar(ingrediente1);
        mezcla.Agregar(ingrediente2);
        mezcla.Agregar(ingrediente3);

        mezcla.Mezclar();
        mezcla.Mezclar();

        Atributos resultado = mezcla.CalcularEstado();

        FloatEqualityComparer comparador = new FloatEqualityComparer(10e-3f);

        float resultadoEsperado = valorVida + valorVidaIngre1 + valorVidaIngre2 * valorAMultiplicar1 + valorVidaIngre3 * valorAMultiplicar1;
        Assert.That(resultado.GetValor(_vida), Is.EqualTo(resultadoEsperado).Using(comparador));
        resultadoEsperado = valorTemp + valorTempIngre1 * valorAMultiplicar2 + valorTempIngre2 + valorTempIngre3 * valorAMultiplicar2;
        Assert.That(resultado.GetValor(_temp), Is.EqualTo(resultadoEsperado).Using(comparador));
        resultadoEsperado = valorVel + valorVelIngre1 * valorAMultiplicar3 + valorVelIngre2 * valorAMultiplicar3 + valorVelIngre3;
        Assert.That(resultado.GetValor(_vel), Is.EqualTo(resultadoEsperado).Using(comparador));
    } */
}
