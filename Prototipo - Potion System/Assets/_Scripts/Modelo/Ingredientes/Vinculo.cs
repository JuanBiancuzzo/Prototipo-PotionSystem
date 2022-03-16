namespace ItIsNotOnlyMe.PotionSystem
{
    public class Vinculo : IVinculo
    {
        private IVinculado _vinculado1, _vinculado2;
        private ICondicionDeVinculo _condicion;

        public Vinculo(IVinculado vinculado1, IVinculado vinculado2, ICondicionDeVinculo condicion)
        {
            _vinculado1 = vinculado1;
            _vinculado2 = vinculado2;
            _condicion = condicion;
            _condicion.AgregarModificadores(_vinculado1, _vinculado2);
        }

        public bool Estable()
        {
            _condicion.SacarModificadores(_vinculado1, _vinculado2);
            bool evaluar = _condicion.Evaluar(_vinculado1, _vinculado2);
            _condicion.AgregarModificadores(_vinculado1, _vinculado2);

            return evaluar;
        }

        public bool HayVinculo(IVinculado vinculado)
        {
            return vinculado == _vinculado1 || vinculado == _vinculado2;
        }

        public void RomperVinculo()
        {
            _condicion.SacarModificadores(_vinculado1, _vinculado2);
            _vinculado1.RomperVinculo(this);
            _vinculado2.RomperVinculo(this);
        }
    }
}