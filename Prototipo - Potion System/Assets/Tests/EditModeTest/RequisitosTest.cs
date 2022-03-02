using NUnit.Framework;
using ItIsNotOnlyMe;

public partial class RequisitosTest
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

    private class DemandadoPrueba : IDemandado
    {
        private IIdentificador _identificador;
        private float _valor, _valorNulo;

        public DemandadoPrueba(IIdentificador identificador, float valor, float valorNulo)
        {
            _identificador = identificador;
            _valor = valor;
            _valorNulo = valorNulo;
        }

        public float ObtenerValor(IIdentificador identificador)
        {
            return _identificador.EsIgual(identificador) ? _valor : _valorNulo;
        }
    }

    private class RequisitoMayor : IRequisito
    {
        private float _valorMinimo;
        private IIdentificador _identificador;

        public RequisitoMayor(float valorMinimo, IIdentificador identificador)
        {
            _valorMinimo = valorMinimo;
            _identificador = identificador;
        }

        public float ConseguirValor(IDemandado ingrediente, IIdentificador identificador)
        {
            return ingrediente.ObtenerValor(identificador);
        }

        public bool Evaluar(IDemandado ingrediente)
        {
            float valor = ConseguirValor(ingrediente, _identificador);
            return valor > _valorMinimo;
        }
    }

    private IIdentificador _uno = new IdentificadorPrueba();
    private IIdentificador _dos = new IdentificadorPrueba();

    [Test]
    public void Test01RequisitoSeCumpleConUnIngredienteValido()
    {
        float valorDemandado = 5, valorNulo = 0, valorMinimo = 2;
        IDemandado ingredienteValido = new DemandadoPrueba(_uno, valorDemandado, valorNulo);
        IRequisito requisito = new RequisitoMayor(valorMinimo, _uno);

        Assert.IsTrue(requisito.Evaluar(ingredienteValido));
    }

    [Test]
    public void Test02RequisitoNoSeCumpleConUnIngredienteSinElIdentificador()
    {
        float valorDemandado = 5, valorNulo = 0, valorMinimo = 2;
        IDemandado ingredienteValido = new DemandadoPrueba(_dos, valorDemandado, valorNulo);
        IRequisito requisito = new RequisitoMayor(valorMinimo, _uno);

        Assert.IsFalse(requisito.Evaluar(ingredienteValido));
    }

    [Test]
    public void Test03RequisitoNoSeCumpleConUnIngredienteConIdentificadorPeroNoValorNecesario()
    {
        float valorDemandado = 2, valorNulo = 0, valorMinimo = 5;
        IDemandado ingredienteValido = new DemandadoPrueba(_uno, valorDemandado, valorNulo);
        IRequisito requisito = new RequisitoMayor(valorMinimo, _uno);

        Assert.IsFalse(requisito.Evaluar(ingredienteValido));
    }
}
