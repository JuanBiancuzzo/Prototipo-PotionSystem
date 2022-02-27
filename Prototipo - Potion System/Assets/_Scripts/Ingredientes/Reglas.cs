

using System.Collections.Generic;

namespace ItIsNotOnlyMe
{
    public abstract class Requisito : IRequisito
    {
        private static int _contador = 0;
        private int _id;

        public Requisito()
        {
            _id = _contador;
            _contador++;
        }

        public int GetID()
        {
            return _id;
        }

        public IRequisito CombinacionNueva(IRequisito requisito)
        {
            throw new System.NotImplementedException();
        }

        public abstract bool Permitido(IIngrediente principal, IIngrediente otro);
    }

    public class Reglas : IRequisito
    {
        private static int _contador = -1;
        private int _id;

        private List<IRequisito> _requisitos;

        public Reglas(List<IRequisito> requisitos)
        {
            _requisitos = requisitos;
            _id = _contador;
            _contador--;
        }

        public int GetID()
        {
            return _id;
        }

        public bool Permitido(IIngrediente principal, IIngrediente otro)
        {
            return _requisitos.TrueForAll(r => r.Permitido(principal, otro));
        }

        public IRequisito CombinacionNueva(IRequisito requisito)
        {
            throw new System.NotImplementedException();
        }
    }
}