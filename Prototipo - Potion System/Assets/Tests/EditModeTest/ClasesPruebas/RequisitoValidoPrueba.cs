using ItIsNotOnlyMe;

public class RequisitoValidoPrueba : IRequisito
{
    public float ConseguirValor(IDemandado demandado, IIdentificador identificador)
    {
        return demandado.ObtenerValor(identificador);
    }

    public bool Evaluar(IDemandado demandado)
    {
        return true;
    }
}
