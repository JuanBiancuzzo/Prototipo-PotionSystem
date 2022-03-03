using ItIsNotOnlyMe;

public class CambiarMultiplicarPrueba : ICambiar
{
    private float _valorSumar;
    private IIdentificador _identificador;

    public CambiarMultiplicarPrueba(float valorSumar, IIdentificador identificador)
    {
        _valorSumar = valorSumar;
        _identificador = identificador;
    }

    public void Cambiar(ICambiante cambiante)
    {
        cambiante.AgregarModificador(this);
    }

    public float Modificar(IIdentificador identificador, float valor)
    {
        if (_identificador.EsIgual(identificador))
            return valor * _valorSumar;
        return valor;
    }
}
