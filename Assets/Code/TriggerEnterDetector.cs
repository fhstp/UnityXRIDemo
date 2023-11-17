using UnityEngine;
using UnityEngine.Events;

namespace At.Ac.FhStp.XRIDemo
{
    /// <summary>
    /// Helper component that sends an event when it receives a trigger-enter
    /// event
    /// </summary>
    public class TriggerEnterDetector : MonoBehaviour
    {
        /// <summary>
        /// Invoked when this script receives a trigger-enter event
        /// </summary>
        [SerializeField] private UnityEvent onTriggerEnter;


        private void OnTriggerEnter(Collider other)
        {
            onTriggerEnter.Invoke();
        }
    }
}