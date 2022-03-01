using System.Collections.Generic;
using UnityEngine;

namespace ItIsNotOnlyMe
{
    [CreateAssetMenu(fileName = "Ingrediente compuesto", menuName = "Ingredientes/Compuesto")]
    public class CompuestoSO : ScriptableObject, IIngrediente
    {
        [SerializeField]
        private List<IngredienteSO> _ingredientes;

        private IIngrediente _compuestoBase;
        public IIngrediente Compuesto
        {
            get
            {
                if (_ingredientes.Count == 0)
                {
                    Debug.LogError("Lista de ingrediente vacia, no se puede crear un compuesto");
                    return null;
                }

                if (_compuestoBase == null)
                {
                    _compuestoBase = Instantiate(_ingredientes[0]);                    
                    for (int i = 1; i < _ingredientes.Count; i++)
                    {
                        IngredienteSO ingrediente = Instantiate(_ingredientes[i]);

                        IIngrediente nuevo = _compuestoBase.Unirse(ingrediente);
                        if (nuevo == null)
                        {
                            Debug.LogWarning("No se creo el compuesto completo, pero se puede seguir usando");
                            break;
                        }

                        _compuestoBase = nuevo;
                    }
                }

                return _compuestoBase;
            }
        }

        public Atributos Agregar(Atributos atributos, float multiplicador = 1)
        {
            return Compuesto.Agregar(atributos, multiplicador);
        }

        public void AgregarModificador(ICambiar modificador)
        {
            Compuesto.AgregarModificador(modificador);
        }

        public void ModificarOtro(IIngrediente ingrediente)
        {
            Compuesto.ModificarOtro(ingrediente);
        }

        public float ObtenerValor(IIdentificador identificador)
        {
            return Compuesto.ObtenerValor(identificador);
        }

        public bool PermiteUnirse()
        {
            return Compuesto.PermiteUnirse();
        }

        public IIngrediente Unirse(IIngrediente ingrediente)
        {
            return Compuesto.Unirse(ingrediente);
        }
    }
}
