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
            if (Math.Abs(newFill - fill) < Mathf.Epsilon) return;

            fill = newFill;
            onFillChanged.Invoke(newFill);

            if (Math.Abs(fill - 1) < Mathf.Epsilon) onFull.Invoke();
        }

        private void Awake()
        {
            onFillChanged.Invoke(0);
        }
    }
}