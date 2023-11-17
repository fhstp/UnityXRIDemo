using UnityEngine;
using UnityEngine.Events;

namespace At.Ac.FhStp.XRIDemo
{
    /// <summary>
    /// Detects when this game-object collides with a horizontal surface
    /// </summary>
    public class FloorDetector : MonoBehaviour
    {
        /// <summary>
        /// Event for then the floor is touched
        /// </summary>
        [SerializeField] private UnityEvent onTouchingFloor;

        /// <summary>
        /// The maximum dot-deviation before a surface does not count as
        /// horizontal anymore
        /// </summary>
        [SerializeField] private float maxDotDeviation;


        private void OnCollisionStay(Collision collision)
        {
            // We loop over all contacts
            for (var i = 0; i < collision.contactCount; i++)
            {
                // Get the normal for the current contact and calculate
                // dot deviation to a vector pointing straight up
                var normal = collision.GetContact(i).normal;
                var dotDeviation = 1 - Vector3.Dot(Vector3.up, normal);
                // If the deviation is small then the surface is horizontal
                var isCollidingWithFloor = dotDeviation <= maxDotDeviation;
                // If we are not touching the floor on this contact we can skip
                // it and check the next one
                if (!isCollidingWithFloor) continue;

                // If the get here then the contact is horizontal. We can
                // invoke the event and then cancel out of the method since
                // we already found what we were looking for
                onTouchingFloor.Invoke();
                return;
            }
        }
    }
}