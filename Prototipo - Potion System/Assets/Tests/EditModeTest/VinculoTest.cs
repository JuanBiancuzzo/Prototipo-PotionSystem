using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using ItIsNotOnlyMe;
using UnityEngine;
using UnityEngine.TestTools;

public class VinculoTest
{
    private class VinculadoPrueba : IVinculado
    {
        private Atributos _estado;
        private ICondicionDeVinculo _condicion;
        private List<IVinculo> _vinculos;
        private List<ICambiar> _modificadores;

        public VinculadoPrueba(Atributos estadoInicial, ICondicionDeVinculo condicion = null)
        {
            _estado = estadoInicial;
            _condicion = condicion;

            _vinculos = new List<IVinculo>();
            _modificadores = new List<ICambiar>();
        }

        public void AgregarModificador(ICambiar modificador)
        {
            _modificadores.Add(modificador);
        }

        public void SacarModificador(ICambiar modificador)
        {
            _modificadores.Remove(modificador);
        }

        public void CrearVinculo(IVinculo vinculo)
        {
            _vinculos.Add(vinculo);
        }

        public void RomperVinculo(IVinculo vinculo)
        {
            _vinculos.Remove(vinculo);
        }

        public float ObtenerValor(IIdentificador identificador)
        {
            return EstadoModificado().GetValor(identificador);
        }

        public bool PermiteVinculoCon(IVinculado vinculado)
        {
            return (_condicion == null) ? false : _condicion.Evaluar(this, vinculado);
        }

        private Atributos EstadoModificado()
        {
            Atributos nuevo = _estado;
            _modificadores.ForEach(modificador => nuevo = modificador.Modificar(nuevo));
            return nuevo;
        }
    }

    private IIdentificador _vida, _temp, _vel;

    public VinculoTest()
    {
        _vida = new IdentificadorPrueba();
        _temp = new IdentificadorPrueba();
        _vel = new IdentificadorPrueba();
    }

    Atributos CrearAtributos(float vida, float temp, float vel)
    {
        return new Atributos(new List<Par>
        {
            new Par(_vida, vida), new Par(_temp, temp), new Par(_vel, vel)
        });
    }

    [Test]
    public void Test01UnVinculoDondeLosVinculadosNoTienenNingunModificacionEsEstable()
    {
        ICondicionDeVinculo condicion = new CondicionDeVinculoPrueba(new RequisitoValidoPrueba(),
                                                                     new CambiarNadaPrueba());

        IVinculado vinculado1 = new VinculadoPrueba(Atributos.Nulo(), condicion);
        IVinculado vinculado2 = new VinculadoPrueba(Atributos.Nulo());

        IVinculo vinculo = new Vinculo(vinculado1, vinculado2, condicion);

        Assert.IsTrue(vinculo.Estable());
    }

    [Test]
    public void Test02UnVinculoDondeLosVinculadosEstanModificadoHaciendoQueYaNoSeanEstable()
    {
        ICondicionDeVinculo condicion = new CondicionDeVinculoPrueba(new RequisitoMayorPrueba(7f, _vida),
                                                                     new CambiarNadaPrueba());

        Atributos estado1 = CrearAtributos(10f, 0f, 0f);
        IVinculado vinculado1 = new VinculadoPrueba(estado1, condicion);

        Atributos estado2 = CrearAtributos(20f, 0f, 0f);
        IVinculado vinculado2 = new VinculadoPrueba(estado2);

        IVinculo vinculo = new Vinculo(vinculado1, vinculado2, condicion);

        Assert.IsTrue(vinculo.Estable());

        float factorModificacion = 0.5f;
        ICambiar modificador = new CambiarMultiplicarPrueba(factorModificacion, _vida);

        vinculado1.AgregarModificador(modificador);
        vinculado2.AgregarModificador(modificador);

        Assert.IsFalse(vinculo.Estable());
    }

    [Test]
    public void Test03DosVinculadosCuandoHayUnVinculoSuEstadoEsModificado()
    {
        float factorModificacion = 2f;
        ICambiar modificador = new CambiarMultiplicarPrueba(factorModificacion, _vida);

        ICondicionDeVinculo condicion = new CondicionDeVinculoPrueba(new RequisitoValidoPrueba(),
                                                                     modificador);
        float valorVida1 = 10f;
        Atributos estado1 = CrearAtributos(valorVida1, 0f, 0f);
        IVinculado vinculado1 = new VinculadoPrueba(estado1, condicion);

        float valorVida2 = 20f;
        Atributos estado2 = CrearAtributos(valorVida2, 0f, 0f);
        IVinculado vinculado2 = new VinculadoPrueba(estado2);

        IVinculo vinculo = new Vinculo(vinculado1, vinculado2, condicion);

        Assert.AreEqual(valorVida1 * factorModificacion, vinculado1.ObtenerValor(_vida));
        Assert.AreEqual(valorVida2 * factorModificacion, vinculado2.ObtenerValor(_vida));
    }

    [Test]
    public void Test04DosVinculadosCuandoSeRompeElVinculoYaSuEstadoNoEstaModificado()
    {
        float factorModificacion = 2f;
        ICambiar modificador = new CambiarMultiplicarPrueba(factorModificacion, _vida);

        ICondicionDeVinculo condicion = new CondicionDeVinculoPrueba(new RequisitoValidoPrueba(),
                                                                     modificador);
        float valorVida1 = 10f;
        Atributos estado1 = CrearAtributos(valorVida1, 0f, 0f);
        IVinculado vinculado1 = new VinculadoPrueba(estado1, condicion);

        float valorVida2 = 20f;
        Atributos estado2 = CrearAtributos(valorVida2, 0f, 0f);
        IVinculado vinculado2 = new VinculadoPrueba(estado2);

        IVinculo vinculo = new Vinculo(vinculado1, vinculado2, condicion);

        Assert.AreEqual(valorVida1 * factorModificacion, vinculado1.ObtenerValor(_vida));
        Assert.AreEqual(valorVida2 * factorModificacion, vinculado2.ObtenerValor(_vida));

        vinculo.RomperVinculo();

        Assert.AreEqual(valorVida1, vinculado1.ObtenerValor(_vida));
        Assert.AreEqual(valorVida2, vinculado2.ObtenerValor(_vida));
    }
}
