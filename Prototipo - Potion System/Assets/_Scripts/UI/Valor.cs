using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace ItIsNotOnlyMe
{
    public class Valor : MonoBehaviour
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private TextMeshProUGUI _texto;

        private void OnEnable() => _slider.onValueChanged.AddListener(ActualizarNumero);
        private void OnDisable() => _slider.onValueChanged.RemoveListener(ActualizarNumero);

        private void Awake()
        {
            ActualizarNumero(_slider.value);
        }

        private void ActualizarNumero(float nuevoValor)
        {
            _texto.SetText(nuevoValor.ToString());
        }
    }
}
