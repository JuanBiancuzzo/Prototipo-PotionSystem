using ItIsNotOnlyMe;

public class CambiarMultiplicarPrueba : ICambiar
{
    private float _valorMultiplicar;
    private IIdentificador _identificador;

    public CambiarMultiplicarPrueba(float valorMultiplicar, IIdentificador identificador)
    {
        _valorMultiplicar = valorMultiplicar;
        _identificador = identificador;
    }

    public void Cambiar(ICambiante cambiante)
    {
        cambiante.AgregarModificador(this);
    }

    public Atributos Modificar(Atributos atributos)
    {
        return Atributos.Multiplicar(atributos, new Par(_identificador, _valorMultiplicar));
    }
}
