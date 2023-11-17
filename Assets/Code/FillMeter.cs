using System;
using UnityEngine;
using UnityEngine.Events;

namespace At.Ac.FhStp.XRIDemo
{
    public class FillMeter : MonoBehaviour
    {
        [SerializeField] private float changeIncrement;
        [SerializeField] private UnityEvent<float> onFillChanged;
        [SerializeField] private UnityEvent onFull;


        private float fill;

        public void IncreaseFill()
        {
            var newFill = Mathf.Clamp01(fill + changeIncrement);
            if (Mathf.Approximately(newFill, fill)) return;

            fill = newFill;
            onFillChanged.Invoke(newFill);

            if (Mathf.Approximately(fill, 1)) onFull.Invoke();
        }

        private void Start()
        {
            onFillChanged.Invoke(0);
        }
    }
}