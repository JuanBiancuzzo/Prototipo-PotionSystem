using ItIsNotOnlyMe.PotionSystem;
using ItIsNotOnlyMe.VectorDinamico;

public class RequisitoInvalidoPrueba : IRequisito
{
    public float ConseguirValor(IDemandado demandado, IIdentificador identificador)
    {
        return demandado.ObtenerValor(identificador);
    }

    public bool Evaluar(IDemandado demandado)
    {
        return false;
    }
}