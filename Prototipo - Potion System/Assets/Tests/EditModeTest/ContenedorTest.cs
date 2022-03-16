using System.Collections.Generic;
using NUnit.Framework;
using ItIsNotOnlyMe.PotionSystem;
using ItIsNotOnlyMe.VectorDinamico;
using UnityEngine;
using UnityEngine.TestTools.Utils;

public class ContenedorTest
{
    private class CapacidadInfinita : ICapacidad
    {
        private int _cantidad;

        public CapacidadInfinita()
        {
            _cantidad = 0;
        }

        public void Agregar()
        {
            _cantidad++;
        }

        public void Reducir()
        {
            _cantidad = Mathf.Max(0, _cantidad - 1);
        }

        public bool Vacio()
        {
            return _cantidad == 0;
        }

        public bool Lleno()
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

    private Vector CrearVector(float valorVida, float valorTemp, float valorVel)
    {
        Vector atributo = new Vector(new List<IComponente>
        {
            new Componente(_vida, valorVida), new Componente(_temp, valorTemp), new Componente(_vel, valorVel)
        });
        return atributo;
    }

    [Test]
    public void Test01UnContenedorSinIngredientesDaUnaPosionIgualAlEstadoInicial()
    {
        IContenedor contenedor = new Contenedor(_capacidadIlimitada);
        ResultadoPrueba pocionEsperada = new ResultadoPrueba(Vector.VectorNulo());

        Vector pocionResultado = contenedor.CalcularEstado();

        FloatEqualityComparer comparador = new FloatEqualityComparer(10e-3f);
        Assert.That(pocionEsperada.Similitud(pocionResultado), Is.EqualTo(0f).Using(comparador));
        Assert.That(pocionEsperada.Multiplicidad(pocionResultado), Is.EqualTo(0f).Using(comparador));
    }

    [Test]
    public void Test02UnContenedorConUnIngredienteDaUnaPosicionIgualAlEstadoInicialMasElEstadoDelIngrediente()
    {
        
        float valorVida = 4f, valorTemp = 3f, valorVel = 5f;
        Vector atributo = CrearVector(valorVida, valorTemp, valorVel);
        IElemento ingrediente =  new Elemento(atributo);

        ResultadoPrueba pocionEsperada = new ResultadoPrueba(atributo);
        IContenedor contenedor = new Contenedor(_capacidadIlimitada);
        contenedor.AgregarElemento(ingrediente);

        Vector pocionResultado = contenedor.CalcularEstado();

        FloatEqualityComparer comparador = new FloatEqualityComparer(10e-3f);
        Assert.That(pocionEsperada.Similitud(pocionResultado), Is.EqualTo(1f).Using(comparador));
        Assert.That(pocionEsperada.Multiplicidad(pocionResultado), Is.EqualTo(1f).Using(comparador));
    }

    [Test]
    public void Test03UnContenedorConDosIngredientesNoVinculadosEsComoSumarSusEstados()
    {
        float valorVida1 = 4f, valorTemp1 = 3f, valorVel1 = 5f;
        Vector atributo1 = CrearVector(valorVida1, valorTemp1, valorVel1);
        IElemento ingrediente1 = new Elemento(atributo1);

        float valorVida2 = 4f, valorTemp2 = 3f, valorVel2 = 5f;
        Vector atributo2 = CrearVector(valorVida2, valorTemp2, valorVel2);
        IElemento ingrediente2 = new Elemento(atributo2);

        IContenedor contenedor = new Contenedor(_capacidadIlimitada);

        contenedor.AgregarElemento(ingrediente1);
        contenedor.AgregarElemento(ingrediente2);

        ResultadoPrueba pocionEsperada = new ResultadoPrueba(atributo1.Sumar(atributo2));
        Vector pocionResultado = contenedor.CalcularEstado();

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
        Vector atributo1 = CrearVector(valorVida1, valorTemp1, valorVel1);
        IElemento ingrediente1 = new Elemento(atributo1, condiciones);

        float valorVida2 = 4f, valorTemp2 = 3f, valorVel2 = 5f;
        Vector atributo2 = CrearVector(valorVida2, valorTemp2, valorVel2);
        IElemento ingrediente2 = new Elemento(atributo2);

        IContenedor contenedor = new Contenedor(_capacidadIlimitada);

        contenedor.AgregarElemento(ingrediente1);
        contenedor.AgregarElemento(ingrediente2);

        Vector atributoEsperado = ingrediente1.Agregar(Vector.VectorNulo());
        atributoEsperado = ingrediente2.Agregar(atributoEsperado);

        ResultadoPrueba pocionEsperada = new ResultadoPrueba(atributoEsperado);
        Vector pocionResultado = contenedor.CalcularEstado();

        FloatEqualityComparer comparador = new FloatEqualityComparer(10e-3f);
        Assert.That(pocionEsperada.Similitud(pocionResultado), Is.EqualTo(1f).Using(comparador));
        Assert.That(pocionEsperada.Multiplicidad(pocionResultado), Is.EqualTo(1f).Using(comparador));
    }

    [Test]
    public void Test05UnContenedorConCapacidadDeDosPuedeSacarDosPocionesIguales()
    {
        float valorVida1 = 4f, valorTemp1 = 3f, valorVel1 = 5f;
        Vector atributo1 = CrearVector(valorVida1, valorTemp1, valorVel1);
        IElemento ingrediente1 = new Elemento(atributo1);

        float valorVida2 = 4f, valorTemp2 = 3f, valorVel2 = 5f;
        Vector atributo2 = CrearVector(valorVida2, valorTemp2, valorVel2);
        IElemento ingrediente2 = new Elemento(atributo2);

        ResultadoPrueba pocionEsperada = new ResultadoPrueba(atributo1.Sumar(atributo2));

        IContenedor contenedor = new Contenedor(_capacidadDeDos);
        contenedor.AgregarElemento(ingrediente1);
        contenedor.AgregarElemento(ingrediente2);

        Vector pocionResultado = contenedor.CalcularEstado();

        FloatEqualityComparer comparador = new FloatEqualityComparer(10e-3f);
        Assert.That(pocionEsperada.Similitud(pocionResultado), Is.EqualTo(1f).Using(comparador));
        Assert.That(pocionEsperada.Multiplicidad(pocionResultado), Is.EqualTo(1f).Using(comparador));

        Vector segundaPocion = contenedor.CalcularEstado();

        Assert.That(pocionEsperada.Similitud(segundaPocion), Is.EqualTo(1f).Using(comparador));
        Assert.That(pocionEsperada.Multiplicidad(segundaPocion), Is.EqualTo(1f).Using(comparador));
    }

    [Test]
    public void Test06UnContenedorModificaLosIngredientesQueSeAgregan()
    {
        float valorVida = 4f, valorTemp = 3f, valorVel = 5f;
        Vector atributo = CrearVector(valorVida, valorTemp, valorVel);
        IElemento ingrediente = new Elemento(atributo);

        float factoDeMultiplicacion = 4f;
        ICambiar modificador = new CambiarMultiplicarPrueba(factoDeMultiplicacion, _vida);

        List<ICambiar> modificadores = new List<ICambiar> { modificador };

        ResultadoPrueba pocionEsperada = new ResultadoPrueba(modificador.Modificar(atributo));
        IContenedor contenedor = new Contenedor(_capacidadIlimitada, modificadores);
        contenedor.AgregarElemento(ingrediente);

        Vector pocionResultado = contenedor.CalcularEstado();

        FloatEqualityComparer comparador = new FloatEqualityComparer(10e-3f);
        Assert.That(pocionEsperada.Similitud(pocionResultado), Is.EqualTo(1f).Using(comparador));
        Assert.That(pocionEsperada.Multiplicidad(pocionResultado), Is.EqualTo(1f).Using(comparador));
    }
}
