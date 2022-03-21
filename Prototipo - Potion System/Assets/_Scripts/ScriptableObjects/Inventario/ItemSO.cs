using System.Collections.Generic;
using UnityEngine;

namespace ItIsNotOnlyMe.Inventario
{
    [CreateAssetMenu(fileName = "Item", menuName = "Inventario System/Item")]
    public class ItemSO : ScriptableObject, IItem
    {
        [SerializeField] private Sprite _sprite;
        [SerializeField] private string _nombre;

        public bool EsIgual(IItem item)
        {
            return item.EsIgual(GetInstanceID());
        }

        public bool EsIgual(int id)
        {
            return GetInstanceID() == id;
        }

        public Sprite GetSprite()
        {
            return _sprite;
        }
    }
}
