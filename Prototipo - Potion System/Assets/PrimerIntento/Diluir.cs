namespace ItIsNotOnlyMe
{
    public class Diluir : IDecoradorEtiqueta
    {
        private float _factorDisminuir;

        public Diluir(float factorDisminuir, IEtiqueta etiqueta) : base(etiqueta)
        {
            _factorDisminuir = factorDisminuir;
        }

        public override float ValorParaModificar(Eje eje)
        {
            return _etiqueta.ValorParaModificar(eje) * _factorDisminuir;
        }
    }
}
