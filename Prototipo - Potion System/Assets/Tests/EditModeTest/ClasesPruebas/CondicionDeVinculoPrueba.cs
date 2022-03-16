using ItIsNotOnlyMe.PotionSystem;

public class CondicionDeVinculoPrueba : ICondicionDeVinculo
{
    private IRequisito _requisito, _requisitoOtro;
    private ICambiar _modificador, _modificadorOtro;

    public CondicionDeVinculoPrueba(IRequisito requisito,
                                    ICambiar modificador,
                                    IRequisito requisitoOtro = null,
                                    ICambiar modificadorOtro = null)
    {
        _requisito = requisito;
        _modificador = modificador;
        _requisitoOtro = (requisitoOtro == null) ? requisito : requisitoOtro;
        _modificadorOtro = (modificadorOtro == null) ? modificador : modificadorOtro;
    }

    public void AgregarModificadores(ICambiante propio, ICambiante otro)
    {
        propio.AgregarModificador(_modificador);
        otro.AgregarModificador(_modificadorOtro);
    }

    public bool Evaluar(IDemandado propio, IDemandado otro)
    {
        return _requisito.Evaluar(propio) && _requisitoOtro.Evaluar(otro);
    }

    public void SacarModificadores(ICambiante propio, ICambiante otro)
    {
        propio.SacarModificador(_modificador);
        otro.SacarModificador(_modificadorOtro);
    }
}
