using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

namespace At.Ac.FhStp.XRIDemo
{
    public class FillMeter : MonoBehaviour
    {
        [SerializeField] private UnityEvent<float> onFillChanged;
        [SerializeField] private UnityEvent onFull;
        [SerializeField] private float changeIncrement;

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