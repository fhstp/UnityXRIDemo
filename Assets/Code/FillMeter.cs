using UnityEngine;
using UnityEngine.Events;

namespace At.Ac.FhStp.XRIDemo
{
    /// <summary>
    /// Keeps track of a fill value which is always between 0 and 1, where 0
    /// means empty and 1 means full.
    /// </summary>
    public class FillMeter : MonoBehaviour
    {
        /// <summary>
        /// By how much to increase the fill for each call to <see cref="IncreaseFill"/>
        /// </summary>
        [SerializeField] private float changeIncrement;

        /// <summary>
        /// Event for the fill in this meter has changed
        /// </summary>
        [SerializeField] private UnityEvent<float> onFillChanged;

        /// <summary>
        /// Event for when the meter is full
        /// </summary>
        [SerializeField] private UnityEvent onFull;

        /// <summary>
        /// The current fill value
        /// </summary>
        private float fill;


        /// <summary>
        /// Increments the fill value for this meter
        /// </summary>
        public void IncreaseFill()
        {
            // We calculate the new fill value by adding the increment to
            // the current value. We also make sure that the value is clamped
            // between 0 and 1.
            var newFill = Mathf.Clamp01(fill + changeIncrement);
            // If the value is not different to the old one then nothing has
            // changed and we can cancel out of the method
            if (Mathf.Approximately(newFill, fill)) return;

            // Store the new value and send out the change event
            fill = newFill;
            onFillChanged.Invoke(newFill);

            // If the value is now 1 then the meter is full and we can send out
            // the full event
            if (Mathf.Approximately(fill, 1)) onFull.Invoke();
        }

        private void Start()
        {
            // We send out the initial value when the script starts
            onFillChanged.Invoke(0);
        }
    }
}