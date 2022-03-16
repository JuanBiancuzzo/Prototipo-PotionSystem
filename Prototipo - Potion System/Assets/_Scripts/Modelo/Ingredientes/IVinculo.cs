namespace ItIsNotOnlyMe.PotionSystem
{
    public interface IVinculo
    {
        public bool Estable();

        public void RomperVinculo();

        public bool HayVinculo(IVinculado vinculado);
    }

    public interface IVinculado : IDemandado, ICambiante
    {
        public void CrearVinculo(IVinculo vinculo);

        public void RomperVinculo(IVinculo vinculo);

        public bool PermiteVinculoCon(IVinculado vinculado);
    }
}