using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using ItIsNotOnlyMe;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.TestTools.Utils;

public class ContenedorTest
{
    private class CapacidadInfinita : ICapacidad
    {
        public void Agregar()
        {
        }

        public void Reducir()
        {
        }

        public bool Vacio()
        {
            return false;
        }
    }

    private IIdentificador _vida, _temp, _vel;
    private ICapacidad _capacidadIlimitada, _capacidadDeDos;

    public ContenedorTest()
    {
        _capacidadIlimitada = new CapacidadInfinita();
        _capacidadDeDos = new Capacidad(2);
        _vida = new IdentificadorPrueba();
        _temp = new IdentificadorPrueba();
        _vel = new IdentificadorPrueba();
    }

    private Atributos CrearAtributos(float valorVida, float valorTemp, float valorVel)
    {
        Atributos atributo = new Atributos(new List<Par>
        {
            new Par(_vida, valorVida), new Par(_temp, valorTemp), new Par(_vel, valorVel)
        });
        return atributo;
    }

    [Test]
    public void Test01UnContenedorSinIngredientesDaUnaPosionIgualAlEstadoInicial()
    {
        IContenedor contenedor = new Contenedor(_capacidadIlimitada);
        Pocion pocionEsperada = new Pocion(Atributos.Nulo());

        Pocion pocionResultado = contenedor.ConsumirPocion();

        FloatEqualityComparer comparador = new FloatEqualityComparer(10e-3f);
        Assert.That(pocionEsperada.Similitud(pocionResultado), Is.EqualTo(0f).Using(comparador));
        Assert.That(pocionEsperada.Multiplicidad(pocionResultado), Is.EqualTo(0f).Using(comparador));
    }

    [Test]
    public void Test02UnContenedorConUnIngredienteDaUnaPosicionIgualAlEstadoInicialMasElEstadoDelIngrediente()
    {
        
        float valorVida = 4f, valorTemp = 3f, valorVel = 5f;
        Atributos atributo = CrearAtributos(valorVida, valorTemp, valorVel);
        IIngrediente ingrediente =  new Ingrediente(atributo);

        Pocion pocionEsperada = new Pocion(atributo);
        IContenedor contenedor = new Contenedor(_capacidadIlimitada);
        contenedor.AgregarIngrediente(ingrediente);

        Pocion pocionResultado = contenedor.ConsumirPocion();

        FloatEqualityComparer comparador = new FloatEqualityComparer(10e-3f);
        Assert.That(pocionEsperada.Similitud(pocionResultado), Is.EqualTo(1f).Using(comparador));
        Assert.That(pocionEsperada.Multiplicidad(pocionResultado), Is.EqualTo(1f).Using(comparador));
    }

    [Test]
    public void Test03UnContenedorConDosIngredientesNoVinculadosEsComoSumarSusEstados()
    {
        float valorVida1 = 4f, valorTemp1 = 3f, valorVel1 = 5f;
        Atributos atributo1 = CrearAtributos(valorVida1, valorTemp1, valorVel1);
        IIngrediente ingrediente1 = new Ingrediente(atributo1);

        float valorVida2 = 4f, valorTemp2 = 3f, valorVel2 = 5f;
        Atributos atributo2 = CrearAtributos(valorVida2, valorTemp2, valorVel2);
        IIngrediente ingrediente2 = new Ingrediente(atributo2);

        IContenedor contenedor = new Contenedor(_capacidadIlimitada);

        contenedor.AgregarIngrediente(ingrediente1);
        contenedor.AgregarIngrediente(ingrediente2);

        Pocion pocionEsperada = new Pocion(Atributos.Sumar(atributo1, atributo2));
        Pocion pocionResultado = contenedor.ConsumirPocion();

        FloatEqualityComparer comparador = new FloatEqualityComparer(10e-3f);
        Assert.That(pocionEsperada.Similitud(pocionResultado), Is.EqualTo(1f).Using(comparador));
        Assert.That(pocionEsperada.Multiplicidad(pocionResultado), Is.EqualTo(1f).Using(comparador));
    }

    [Test] 
    public void Test04UnContenedorConDosIngredientesVinculadosEsLaSumaDeSusEstadosModificados()
    {
        float multiplicador = 2f;
        ICambiar modificador = new CambiarMultiplicarPrueba(multiplicador, _vida);

        IRequisito requisito = new RequisitoValidoPrueba();

        List<ICondicionDeVinculo> condiciones = new List<ICondicionDeVinculo>
            { new CondicionDeVinculoPrueba(requisito, modificador) };

        float valorVida1 = 5f, valorTemp1 = 3f, valorVel1 = 4f;
        Atributos atributo1 = CrearAtributos(valorVida1, valorTemp1, valorVel1);
        IIngrediente ingrediente1 = new Ingrediente(atributo1, condiciones);

        float valorVida2 = 4f, valorTemp2 = 3f, valorVel2 = 5f;
        Atributos atributo2 = CrearAtributos(valorVida2, valorTemp2, valorVel2);
        IIngrediente ingrediente2 = new Ingrediente(atributo2);

        IContenedor contenedor = new Contenedor(_capacidadIlimitada);

        contenedor.AgregarIngrediente(ingrediente1);
        contenedor.AgregarIngrediente(ingrediente2);

        Atributos atributoEsperado = ingrediente1.Agregar(Atributos.Nulo());
        atributoEsperado = ingrediente2.Agregar(atributoEsperado);

        Pocion pocionEsperada = new Pocion(atributoEsperado);
        Pocion pocionResultado = contenedor.ConsumirPocion();

        FloatEqualityComparer comparador = new FloatEqualityComparer(10e-3f);
        Assert.That(pocionEsperada.Similitud(pocionResultado), Is.EqualTo(1f).Using(comparador));
        Assert.That(pocionEsperada.Multiplicidad(pocionResultado), Is.EqualTo(1f).Using(comparador));
    }

    [Test]
    public void Test05UnContenedorConCapacidadDeDosPuedeSacarDosPocionesIguales()
    {
        float valorVida1 = 4f, valorTemp1 = 3f, valorVel1 = 5f;
        Atributos atributo1 = CrearAtributos(valorVida1, valorTemp1, valorVel1);
        IIngrediente ingrediente1 = new Ingrediente(atributo1);

        float valorVida2 = 4f, valorTemp2 = 3f, valorVel2 = 5f;
        Atributos atributo2 = CrearAtributos(valorVida2, valorTemp2, valorVel2);
        IIngrediente ingrediente2 = new Ingrediente(atributo2);

        Pocion pocionEsperada = new Pocion(Atributos.Sumar(atributo1, atributo2));

        IContenedor contenedor = new Contenedor(_capacidadDeDos);
        contenedor.AgregarIngrediente(ingrediente1);
        contenedor.AgregarIngrediente(ingrediente2);

        Pocion pocionResultado = contenedor.ConsumirPocion();

        FloatEqualityComparer comparador = new FloatEqualityComparer(10e-3f);
        Assert.That(pocionEsperada.Similitud(pocionResultado), Is.EqualTo(1f).Using(comparador));
        Assert.That(pocionEsperada.Multiplicidad(pocionResultado), Is.EqualTo(1f).Using(comparador));

        Pocion segundaPocion = contenedor.ConsumirPocion();

        Assert.That(pocionEsperada.Similitud(segundaPocion), Is.EqualTo(1f).Using(comparador));
        Assert.That(pocionEsperada.Multiplicidad(segundaPocion), Is.EqualTo(1f).Using(comparador));
    }

    [Test]
    public void Test06UnContenedorModificaLosIngredientesQueSeAgregan()
    {
        float valorVida = 4f, valorTemp = 3f, valorVel = 5f;
        Atributos atributo = CrearAtributos(valorVida, valorTemp, valorVel);
        IIngrediente ingrediente = new Ingrediente(atributo);

        float factoDeMultiplicacion = 4f;
        ICambiar modificador = new CambiarMultiplicarPrueba(factoDeMultiplicacion, _vida);

        List<ICambiar> modificadores = new List<ICambiar> { modificador };

        Pocion pocionEsperada = new Pocion(modificador.Modificar(atributo));
        IContenedor contenedor = new Contenedor(_capacidadIlimitada, modificadores);
        contenedor.AgregarIngrediente(ingrediente);

        Pocion pocionResultado = contenedor.ConsumirPocion();

        FloatEqualityComparer comparador = new FloatEqualityComparer(10e-3f);
        Assert.That(pocionEsperada.Similitud(pocionResultado), Is.EqualTo(1f).Using(comparador));
        Assert.That(pocionEsperada.Multiplicidad(pocionResultado), Is.EqualTo(1f).Using(comparador));
    }
}
