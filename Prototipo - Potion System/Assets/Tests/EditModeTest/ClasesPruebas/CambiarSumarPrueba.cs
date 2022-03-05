using ItIsNotOnlyMe;
using System.Collections.Generic;

public class CambiarSumarPrueba : ICambiar
{
    private float _valorSumar;
    private IIdentificador _identificador;

    public CambiarSumarPrueba(float valorSumar, IIdentificador identificador)
    {
        _valorSumar = valorSumar;
        _identificador = identificador;
    }

    public void Cambiar(ICambiante cambiante)
    {
        cambiante.AgregarModificador(this);
    }

    public Atributos Modificar(Atributos atributos)
    {
        return Atributos.Sumar(atributos, new Atributos(new List<Par> { new Par(_identificador, _valorSumar) }));
    }
}
