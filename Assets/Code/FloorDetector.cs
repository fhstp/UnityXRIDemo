using UnityEngine;
using UnityEngine.Events;

namespace At.Ac.FhStp.XRIDemo
{
    public class FloorDetector : MonoBehaviour
    {
        [SerializeField] private UnityEvent onTouchingFloor;
        [SerializeField] private float maxDotDeviation;


        private void OnCollisionStay(Collision other)
        {
            for (var i = 0; i < other.contactCount; i++)
            {
                var normal = other.GetContact(i).normal;
                var dotDeviation = 1 - Vector3.Dot(Vector3.up, normal);
                var isCollidingWithFloor = dotDeviation <= maxDotDeviation;
                if (!isCollidingWithFloor) continue;

                onTouchingFloor.Invoke();
                return;
            }
        }
    }
}