using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ItIsNotOnlyMe
{
    [RequireComponent(typeof(Rigidbody))]
    public class DragMe : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        [SerializeField] private float _velocidadMouse = 10;

        private Rigidbody _rigidbody;
        private Camera _camara;
        private float _distanciaInicial;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            _camara = eventData.enterEventCamera;
            _distanciaInicial = Vector3.Distance(_camara.transform.position, transform.position);
        }

        public void OnDrag(PointerEventData eventData)
        {
            Ray ray = _camara.ScreenPointToRay(eventData.position);
            Vector3 direccion = ray.GetPoint(_distanciaInicial) - transform.position;
            _rigidbody.velocity = direccion * _velocidadMouse;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
        }
    }
}
