using UnityEngine;
using UnityEngine.Events;

namespace At.Ac.FhStp.XRIDemo
{
    public class TriggerEnterDetector : MonoBehaviour
    {
        [SerializeField] private UnityEvent onTriggerEnter;


        private void OnTriggerEnter(Collider other)
        {
            onTriggerEnter.Invoke();
        }
    }
}