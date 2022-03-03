namespace ItIsNotOnlyMe
{
    public interface ICombinacionRequisitos
    {
        public bool EvaluarPropio(IDemandado propio);

        public bool EvaluarOtro(IDemandado otro);
    }
}