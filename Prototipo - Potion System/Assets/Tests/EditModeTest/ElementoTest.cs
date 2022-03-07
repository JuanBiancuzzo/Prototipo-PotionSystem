using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using ItIsNotOnlyMe;
using UnityEngine;
using UnityEngine.TestTools;

public class ElementoTest
{
    

    private IIdentificador _vida, _temp, _vel;
    private Atributos _atributosNulo;

    public ElementoTest()
    {
        _vida = new IdentificadorPrueba();
        _temp = new IdentificadorPrueba();
        _vel = new IdentificadorPrueba();

        _atributosNulo = Atributos.Nulo();
    }

    private Atributos HacerAtributos(float vida, float temp, float vel)
    {
        return new Atributos(new List<Par>
        {
            new Par(_vida, vida), new Par(_temp, temp), new Par(_vel, vel)
        });
    }

    [Test]
    public void Test01IngredienteSinNingunVinculoAlAgregaEsSuEstadoInicial()
    {
        float valorVida = 5f, valorTemp = 3f, valorVel = 4f;
        Atributos atributosBase = HacerAtributos(valorVida, valorTemp, valorVel);
        IElemento elemento = new Elemento(atributosBase);

        Atributos resultado = elemento.Agregar(_atributosNulo);

        Assert.AreEqual(valorVida, resultado.GetValor(_vida));
        Assert.AreEqual(valorTemp, resultado.GetValor(_temp));
        Assert.AreEqual(valorVel, resultado.GetValor(_vel));
    }

    [Test]
    public void Test02IngredienteNoSePuedeVincularSiNoTieneCondicionesParaUnirse()
    {
        float valorVida1 = 5f, valorTemp1 = 3f, valorVel1 = 4f;
        Atributos atributosBase1 = HacerAtributos(valorVida1, valorTemp1, valorVel1);
        IElemento elemento1 = new Elemento(atributosBase1);

        float valorVida2 = 5f, valorTemp2 = 3f, valorVel2 = 4f;
        Atributos atributosBase2 = HacerAtributos(valorVida2, valorTemp2, valorVel2);
        IElemento elemento2 = new Elemento(atributosBase2);

        bool pudoUnirse = IElemento.Unirse(elemento1, elemento2);
        Assert.IsFalse(pudoUnirse);
    }

    [Test]
    public void Test03IngredienteConUnVinculoAlAgregarEsSuEstadoInicialConLaModificacion()
    {
        float multiplicador = 2f;
        ICambiar modificador = new CambiarMultiplicarPrueba(multiplicador, _vida);

        IRequisito requisito = new RequisitoValidoPrueba();

        List<ICondicionDeVinculo> condiciones = new List<ICondicionDeVinculo>
            { new CondicionDeVinculoPrueba(requisito, modificador) };

        float valorVida1 = 5f, valorTemp1 = 3f, valorVel1 = 4f;
        Atributos atributosBase1 = HacerAtributos(valorVida1, valorTemp1, valorVel1);
        IElemento elemento1 = new Elemento(atributosBase1, condiciones);

        float valorVida2 = 5f, valorTemp2 = 3f, valorVel2 = 4f;
        Atributos atributosBase2 = HacerAtributos(valorVida2, valorTemp2, valorVel2);
        IElemento elemento2 = new Elemento(atributosBase2);

        bool pudoUnirse = IElemento.Unirse(elemento1, elemento2);

        Assert.IsTrue(pudoUnirse);

        Atributos resultado = elemento1.Agregar(_atributosNulo);

        Assert.AreEqual(valorVida1 * multiplicador, resultado.GetValor(_vida));
        Assert.AreEqual(valorTemp1, resultado.GetValor(_temp));
        Assert.AreEqual(valorVel1, resultado.GetValor(_vel));
    }

    [Test]
    public void Test04IngredienteNoSePuedeUnirDosVecesConUnIngrediente()
    {
        float multiplicador = 2f;
        ICambiar modificador = new CambiarMultiplicarPrueba(multiplicador, _vida);

        IRequisito requisito = new RequisitoValidoPrueba();

        List<ICondicionDeVinculo> condiciones = new List<ICondicionDeVinculo>
            { new CondicionDeVinculoPrueba(requisito, modificador) };

        float valorVida1 = 5f, valorTemp1 = 3f, valorVel1 = 4f;
        Atributos atributosBase1 = HacerAtributos(valorVida1, valorTemp1, valorVel1);
        IElemento elemento1 = new Elemento(atributosBase1, condiciones);

        float valorVida2 = 5f, valorTemp2 = 3f, valorVel2 = 4f;
        Atributos atributosBase2 = HacerAtributos(valorVida2, valorTemp2, valorVel2);
        IElemento elemento2 = new Elemento(atributosBase2);

        bool pudoUnirse = IElemento.Unirse(elemento1, elemento2);
        Assert.IsTrue(pudoUnirse);

        pudoUnirse = IElemento.Unirse(elemento1, elemento2);
        Assert.IsFalse(pudoUnirse);
    }

    [Test]
    public void Test05IngredienteSeVinculaConDosIngredientesYSuEstadoEsElInicialYDosVecesLaModificacion()
    {
        float multiplicador = 2f;
        ICambiar modificador = new CambiarMultiplicarPrueba(multiplicador, _vida);

        IRequisito requisito = new RequisitoValidoPrueba();

        List<ICondicionDeVinculo> condiciones = new List<ICondicionDeVinculo>
            { new CondicionDeVinculoPrueba(requisito, modificador) };

        float valorVida1 = 5f, valorTemp1 = 3f, valorVel1 = 4f;
        Atributos atributosBase1 = HacerAtributos(valorVida1, valorTemp1, valorVel1);
        IElemento elemento1 = new Elemento(atributosBase1, condiciones);

        float valorVida2 = 5f, valorTemp2 = 3f, valorVel2 = 4f;
        Atributos atributosBase2 = HacerAtributos(valorVida2, valorTemp2, valorVel2);
        IElemento elemento2 = new Elemento(atributosBase2);

        float valorVida3 = 5f, valorTemp3 = 3f, valorVel3 = 4f;
        Atributos atributosBase3 = HacerAtributos(valorVida3, valorTemp3, valorVel3);
        IElemento elemento3 = new Elemento(atributosBase3);

        bool pudoUnirse = IElemento.Unirse(elemento1, elemento2);
        Assert.IsTrue(pudoUnirse);

        pudoUnirse = IElemento.Unirse(elemento3, elemento1);
        Assert.IsTrue(pudoUnirse);

        Atributos resultado = elemento1.Agregar(_atributosNulo);

        Assert.AreEqual(valorVida1 * multiplicador * multiplicador, resultado.GetValor(_vida));
        Assert.AreEqual(valorTemp1, resultado.GetValor(_temp));
        Assert.AreEqual(valorVel1, resultado.GetValor(_vel));
    }

    [Test]
    public void Test06IngredienteSeVinculaConOtroYAlVincularseConElTerceroRompeElPrimerVinculo()
    {
        float multiplicador1 = 2f;
        ICambiar modificador1 = new CambiarMultiplicarPrueba(multiplicador1, _vida);

        IRequisito requisito1 = new RequisitoMayorPrueba(7f, _vida);

        List<ICondicionDeVinculo> condiciones1 = new List<ICondicionDeVinculo>
            { new CondicionDeVinculoPrueba(requisito1, modificador1) };

        float valorVida1 = 10f, valorTemp1 = 3f, valorVel1 = 4f;
        Atributos atributosBase1 = HacerAtributos(valorVida1, valorTemp1, valorVel1);
        IElemento elemento1 = new Elemento(atributosBase1, condiciones1);

        float valorVida2 = 50f, valorTemp2 = 3f, valorVel2 = 4f;
        Atributos atributosBase2 = HacerAtributos(valorVida2, valorTemp2, valorVel2);
        IElemento elemento2 = new Elemento(atributosBase2);

        float multiplicador3 = .25f;
        ICambiar modificador3 = new CambiarMultiplicarPrueba(multiplicador3, _vida);

        IRequisito requisito3 = new RequisitoValidoPrueba();

        List<ICondicionDeVinculo> condiciones3 = new List<ICondicionDeVinculo>
            { new CondicionDeVinculoPrueba(requisito3, modificador3) };

        float valorVida3 = 5f, valorTemp3 = 3f, valorVel3 = 4f;
        Atributos atributosBase3 = HacerAtributos(valorVida3, valorTemp3, valorVel3);
        IElemento elemento3 = new Elemento(atributosBase3, condiciones3);

        bool pudoUnirse = IElemento.Unirse(elemento1, elemento2);
        Assert.IsTrue(pudoUnirse);

        pudoUnirse = IElemento.Unirse(elemento1, elemento3);
        Assert.IsTrue(pudoUnirse);

        Atributos resultado = elemento1.Agregar(_atributosNulo);

        Assert.AreEqual(valorVida1 * multiplicador3, resultado.GetValor(_vida));
        Assert.AreEqual(valorTemp1, resultado.GetValor(_temp));
        Assert.AreEqual(valorVel1, resultado.GetValor(_vel));
    }
}