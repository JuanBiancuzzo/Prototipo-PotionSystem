using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using ItIsNotOnlyMe;
using UnityEngine;
using UnityEngine.TestTools;

public class IngredienteTest
{
    private IIdentificador _vida, _temp, _vel;
    private Atributos atributosNulo;

    public IngredienteTest()
    {
        _vida = new IdentificadorPrueba();
        _temp = new IdentificadorPrueba();
        _vel = new IdentificadorPrueba();

        atributosNulo = new Atributos(new List<Par>
        {
            new Par(_vida, 0f), new Par(_temp, 0f), new Par(_vel, 0f)
        });
    }

    [Test]
    public void Test01IngredienteSinNingunRequisitoNecesarioEsEvaluadoPositivo()
    {
        float valorVida = 5f, valorTemp = 3f, valorVel = 4f;
        Atributos atributosBase = new Atributos(new List<Par>
        {
            new Par(_vida, valorVida), new Par(_temp, valorTemp), new Par(_vel, valorVel)
        });
        IIngrediente ingrediente = new Ingrediente(atributosBase);

        Assert.IsTrue(ingrediente.PermiteUnirse());
    }

    [Test]
    public void Test02IngredienteConLosRequisitosEsEvaluadoPositivo()
    {
        float valorMinimo = 4f;
        IRequisito requisito = new RequisitoMayorPrueba(valorMinimo, _vida);

        List<ICombinacionRequisitos> requisitos = new List<ICombinacionRequisitos> { new ParRequisito(requisito, new RequisitoValidoPrueba()) };

        float valorVida = 5f, valorTemp = 3f, valorVel = 4f;
        Atributos atributosBase = new Atributos(new List<Par>
        {
            new Par(_vida, valorVida), new Par(_temp, valorTemp), new Par(_vel, valorVel)
        });
        IIngrediente ingrediente = new Ingrediente(atributosBase, requisitos);

        Assert.IsTrue(ingrediente.PermiteUnirse());
    }

    [Test]
    public void Test03IngredienteSinLosRequisitosEsEvaluadoNegativo()
    {
        float valorMinimo = 4f;
        IRequisito requisito = new RequisitoMayorPrueba(valorMinimo, _temp);

        List<ICombinacionRequisitos> requisitos = new List<ICombinacionRequisitos> { new ParRequisito(requisito, new RequisitoValidoPrueba()) };

        float valorVida = 5f, valorTemp = 3f, valorVel = 4f;
        Atributos atributosBase = new Atributos(new List<Par>
        {
            new Par(_vida, valorVida), new Par(_temp, valorTemp), new Par(_vel, valorVel)
        });
        IIngrediente ingrediente = new Ingrediente(atributosBase, requisitos);

        Assert.IsFalse(ingrediente.PermiteUnirse());
    }

    [Test]
    public void Test04IngredienteEsModificadoSumandoleDosALaDimensionVida()
    {
        float valorVida = 5f, valorTemp = 3f, valorVel = 4f;
        Atributos atributosBase = new Atributos(new List<Par>
        {
            new Par(_vida, valorVida), new Par(_temp, valorTemp), new Par(_vel, valorVel)
        });
        IIngrediente ingrediente = new Ingrediente(atributosBase);

        float valorASumar = 2f;
        ICambiar cambiar = new CambiarSumarPrueba(valorASumar, _vida);

        cambiar.Cambiar(ingrediente);

        Atributos resultado = ingrediente.Agregar(atributosNulo);

        Assert.AreEqual(valorVida + valorASumar, resultado.GetValor(_vida));
        Assert.AreEqual(valorTemp, resultado.GetValor(_temp));
        Assert.AreEqual(valorVel, resultado.GetValor(_vel));
    }

    [Test]
    public void Test05IngredienteEsModificadoSumandoleDosALaDimensionVelocidadQueNoTiene()
    {
        float valorVida = 5f, valorTemp = 3f;
        Atributos atributosBase = new Atributos(new List<Par>
        {
            new Par(_vida, valorVida), new Par(_temp, valorTemp)
        });
        IIngrediente ingrediente = new Ingrediente(atributosBase);

        float valorASumar = 2f;
        ICambiar cambiar = new CambiarSumarPrueba(valorASumar, _vel);

        cambiar.Cambiar(ingrediente);

        Atributos resultado = ingrediente.Agregar(atributosNulo);

        Assert.AreEqual(valorVida, resultado.GetValor(_vida));
        Assert.AreEqual(valorTemp, resultado.GetValor(_temp));
        Assert.AreEqual(valorASumar, resultado.GetValor(_vel));
    }

    [Test]
    public void Test06CuandoSeJuntanDosIngredientesSinModificacionesYSinCondicionesElResultadoEsLaSumaDeAmbos()
    {
        float valorVida1 = 5f, valorTemp1 = 3f, valorVel1 = 4f;
        Atributos atributosBase1 = new Atributos(new List<Par>
        {
            new Par(_vida, valorVida1), new Par(_temp, valorTemp1), new Par(_vel, valorVel1)
        });
        IIngrediente ingrediente1 = new Ingrediente(atributosBase1);

        float valorVida2 = 3f, valorTemp2 = 1f, valorVel2 = 6f;
        Atributos atributosBase2 = new Atributos(new List<Par>
        {
            new Par(_vida, valorVida2), new Par(_temp, valorTemp2), new Par(_vel, valorVel2)
        });
        IIngrediente ingrediente2 = new Ingrediente(atributosBase2);

        IIngrediente compuesto = ingrediente1.Unirse(ingrediente2);

        Assert.AreNotEqual(null, compuesto);

        Atributos resultado = compuesto.Agregar(atributosNulo);

        Assert.AreEqual(valorVida1 + valorVida2, resultado.GetValor(_vida));
        Assert.AreEqual(valorTemp1 + valorTemp2, resultado.GetValor(_temp));
        Assert.AreEqual(valorVel1 + valorVel2, resultado.GetValor(_vel));
    }

    [Test]
    public void Test07ElPrimerIngredienteNoEstaEnCondicionesDeUnirse()
    {
        float valorMinimo = 4f;
        IRequisito requisito = new RequisitoMayorPrueba(valorMinimo, _temp);

        List<ICombinacionRequisitos> requisitos = new List<ICombinacionRequisitos> { new ParRequisito(requisito, new RequisitoValidoPrueba()) };

        float valorVida1 = 5f, valorTemp1 = 3f, valorVel1 = 4f;
        Atributos atributosBase1 = new Atributos(new List<Par>
        {
            new Par(_vida, valorVida1), new Par(_temp, valorTemp1), new Par(_vel, valorVel1)
        });
        IIngrediente ingrediente1 = new Ingrediente(atributosBase1, requisitos);

        float valorVida2 = 3f, valorTemp2 = 1f, valorVel2 = 6f;
        Atributos atributosBase2 = new Atributos(new List<Par>
        {
            new Par(_vida, valorVida2), new Par(_temp, valorTemp2), new Par(_vel, valorVel2)
        });
        IIngrediente ingrediente2 = new Ingrediente(atributosBase2);

        Assert.IsFalse(ingrediente1.PermiteUnirse());
        Assert.IsTrue(ingrediente2.PermiteUnirse());

        IIngrediente compuesto = ingrediente1.Unirse(ingrediente2);

        Assert.AreEqual(null, compuesto);
    }

    [Test]
    public void Test08ElSegundoIngredienteNoEstaEnCondicionesDeUnirse()
    {
        float valorVida1 = 5f, valorTemp1 = 3f, valorVel1 = 4f;
        Atributos atributosBase1 = new Atributos(new List<Par>
        {
            new Par(_vida, valorVida1), new Par(_temp, valorTemp1), new Par(_vel, valorVel1)
        });
        IIngrediente ingrediente1 = new Ingrediente(atributosBase1);

        float valorMinimo = 4f;
        IRequisito requisito = new RequisitoMayorPrueba(valorMinimo, _temp);

        List<ICombinacionRequisitos> requisitos = new List<ICombinacionRequisitos> { new ParRequisito(requisito, new RequisitoValidoPrueba()) };

        float valorVida2 = 3f, valorTemp2 = 1f, valorVel2 = 6f;
        Atributos atributosBase2 = new Atributos(new List<Par>
        {
            new Par(_vida, valorVida2), new Par(_temp, valorTemp2), new Par(_vel, valorVel2)
        });
        IIngrediente ingrediente2 = new Ingrediente(atributosBase2, requisitos);

        Assert.IsTrue(ingrediente1.PermiteUnirse());
        Assert.IsFalse(ingrediente2.PermiteUnirse());

        IIngrediente compuesto = ingrediente1.Unirse(ingrediente2);

        Assert.AreEqual(null, compuesto);
    }

    [Test]
    public void Test09ElPrimeroYElSegundoPuedenUnirseYPuedenUnirseEntreSi()
    {

        float valorMinimo = 1f;
        IRequisito requisito = new RequisitoMayorPrueba(valorMinimo, _temp);

        List<ICombinacionRequisitos> requisitos = new List<ICombinacionRequisitos> { new ParRequisito(requisito, new RequisitoValidoPrueba()) };

        float valorVida1 = 5f, valorTemp1 = 3f, valorVel1 = 4f;
        Atributos atributosBase1 = new Atributos(new List<Par>
        {
            new Par(_vida, valorVida1), new Par(_temp, valorTemp1), new Par(_vel, valorVel1)
        });
        IIngrediente ingrediente1 = new Ingrediente(atributosBase1, requisitos);

        float valorVida2 = 3f, valorTemp2 = 1f, valorVel2 = 6f;
        Atributos atributosBase2 = new Atributos(new List<Par>
        {
            new Par(_vida, valorVida2), new Par(_temp, valorTemp2), new Par(_vel, valorVel2)
        });
        IIngrediente ingrediente2 = new Ingrediente(atributosBase2);

        Assert.IsTrue(ingrediente1.PermiteUnirse());
        Assert.IsTrue(ingrediente2.PermiteUnirse());

        Assert.IsTrue(ingrediente1.PermiteUnirseCon(ingrediente2));

        IIngrediente compuesto = ingrediente1.Unirse(ingrediente2);

        Assert.AreNotEqual(null, compuesto);
    }

    [Test]
    public void Test10ElPrimeroYElSegundoPuedenUnirsePeroNoEntreSi()
    {

        float valorMinimo = 1f;
        IRequisito requisito = new RequisitoMayorPrueba(valorMinimo, _temp);

        List<ICombinacionRequisitos> requisitos = new List<ICombinacionRequisitos> { new ParRequisito(requisito, new RequisitoInvalidoPrueba()) };

        float valorVida1 = 5f, valorTemp1 = 3f, valorVel1 = 4f;
        Atributos atributosBase1 = new Atributos(new List<Par>
        {
            new Par(_vida, valorVida1), new Par(_temp, valorTemp1), new Par(_vel, valorVel1)
        });
        IIngrediente ingrediente1 = new Ingrediente(atributosBase1, requisitos);

        float valorVida2 = 3f, valorTemp2 = 1f, valorVel2 = 6f;
        Atributos atributosBase2 = new Atributos(new List<Par>
        {
            new Par(_vida, valorVida2), new Par(_temp, valorTemp2), new Par(_vel, valorVel2)
        });
        IIngrediente ingrediente2 = new Ingrediente(atributosBase2);

        Assert.IsTrue(ingrediente1.PermiteUnirse());
        Assert.IsTrue(ingrediente2.PermiteUnirse());

        Assert.IsFalse(ingrediente1.PermiteUnirseCon(ingrediente2)); 
        
        IIngrediente compuesto = ingrediente1.Unirse(ingrediente2);

        Assert.AreEqual(null, compuesto);
    }

    [Test]
    public void Test11ElPrimeroTieneModificacionesParaElSegundoEntoncesElCompuestoEsElPrimeroMasElSegundoModificado()
    {
        float valorAMultiplicar = 2f;
        ICambiar cambiar = new CambiarMultiplicarPrueba(valorAMultiplicar, _vida);

        List<ICambiar> modificadores = new List<ICambiar> { cambiar };

        float valorVida1 = 5f, valorTemp1 = 3f, valorVel1 = 4f;
        Atributos atributosBase1 = new Atributos(new List<Par>
        {
            new Par(_vida, valorVida1), new Par(_temp, valorTemp1), new Par(_vel, valorVel1)
        });
        IIngrediente ingrediente1 = new Ingrediente(atributosBase1, modificadores);

        float valorVida2 = 3f, valorTemp2 = 1f, valorVel2 = 6f;
        Atributos atributosBase2 = new Atributos(new List<Par>
        {
            new Par(_vida, valorVida2), new Par(_temp, valorTemp2), new Par(_vel, valorVel2)
        });
        IIngrediente ingrediente2 = new Ingrediente(atributosBase2);

        IIngrediente compuesto = ingrediente1.Unirse(ingrediente2);

        Atributos resultado = compuesto.Agregar(atributosNulo);

        Assert.AreEqual(valorVida1 + valorVida2 * valorAMultiplicar, resultado.GetValor(_vida));
        Assert.AreEqual(valorTemp1 + valorTemp2, resultado.GetValor(_temp));
        Assert.AreEqual(valorVel1 + valorVel2, resultado.GetValor(_vel));
    }

    [Test]
    public void Test12ElSegundoTieneModificacionesParaElPrimeroEntoncesElCompuestoEsElPrimeroModificadoMasElSegundo()
    {
        float valorVida1 = 5f, valorTemp1 = 3f, valorVel1 = 4f;
        Atributos atributosBase1 = new Atributos(new List<Par>
        {
            new Par(_vida, valorVida1), new Par(_temp, valorTemp1), new Par(_vel, valorVel1)
        });
        IIngrediente ingrediente1 = new Ingrediente(atributosBase1);

        float valorAMultiplicar = 2f;
        ICambiar cambiar = new CambiarMultiplicarPrueba(valorAMultiplicar, _vida);

        List<ICambiar> modificadores = new List<ICambiar> { cambiar };

        float valorVida2 = 3f, valorTemp2 = 1f, valorVel2 = 6f;
        Atributos atributosBase2 = new Atributos(new List<Par>
        {
            new Par(_vida, valorVida2), new Par(_temp, valorTemp2), new Par(_vel, valorVel2)
        });
        IIngrediente ingrediente2 = new Ingrediente(atributosBase2, modificadores);

        IIngrediente compuesto = ingrediente1.Unirse(ingrediente2);

        Atributos resultado = compuesto.Agregar(atributosNulo);

        Assert.AreEqual(valorVida1 * valorAMultiplicar + valorVida2, resultado.GetValor(_vida));
        Assert.AreEqual(valorTemp1 + valorTemp2, resultado.GetValor(_temp));
        Assert.AreEqual(valorVel1 + valorVel2, resultado.GetValor(_vel));
    }

    [Test]
    public void Test13LosDosIngredientesTieneModificadoresEntoncesElCompuestoEsLaSumaModificada()
    {
        float valorAMultiplicar1 = 3f;
        List<ICambiar> modificadores1 = new List<ICambiar> { new CambiarMultiplicarPrueba(valorAMultiplicar1, _vida) };

        float valorVida1 = 5f, valorTemp1 = 3f, valorVel1 = 4f;
        Atributos atributosBase1 = new Atributos(new List<Par>
        {
            new Par(_vida, valorVida1), new Par(_temp, valorTemp1), new Par(_vel, valorVel1)
        });
        IIngrediente ingrediente1 = new Ingrediente(atributosBase1, modificadores1);

        float valorAMultiplicar2 = 4f;
        List<ICambiar> modificadores2 = new List<ICambiar> { new CambiarMultiplicarPrueba(valorAMultiplicar2, _temp) };

        float valorVida2 = 3f, valorTemp2 = 1f, valorVel2 = 6f;
        Atributos atributosBase2 = new Atributos(new List<Par>
        {
            new Par(_vida, valorVida2), new Par(_temp, valorTemp2), new Par(_vel, valorVel2)
        });
        IIngrediente ingrediente2 = new Ingrediente(atributosBase2, modificadores2);

        IIngrediente compuesto = ingrediente1.Unirse(ingrediente2);

        Atributos resultado = compuesto.Agregar(atributosNulo);

        Assert.AreEqual(valorVida1 + valorVida2 * valorAMultiplicar1, resultado.GetValor(_vida));
        Assert.AreEqual(valorTemp1 * valorAMultiplicar2 + valorTemp2, resultado.GetValor(_temp));
        Assert.AreEqual(valorVel1 + valorVel2, resultado.GetValor(_vel));
    }
}
