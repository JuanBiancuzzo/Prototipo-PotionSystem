namespace ItIsNotOnlyMe.PotionSystem
{
    public interface ICondicionDeVinculo
    {
        public bool Evaluar(IDemandado propio, IDemandado otro);

        public void AgregarModificadores(ICambiante propio, ICambiante otro);

        public void SacarModificadores(ICambiante propio, ICambiante otro);
    }
}