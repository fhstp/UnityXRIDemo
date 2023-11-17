using UnityEngine;
using UnityEngine.Events;

namespace At.Ac.FhStp.XRIDemo
{
    /// <summary>
    /// Detects if the transform on this game-object is pointing a certain
    /// direction
    /// </summary>
    public class TiltDetector : MonoBehaviour
    {
        /// <summary>
        /// The target direction to check for
        /// </summary>
        [SerializeField] private Vector3 targetUp;

        /// <summary>
        /// How much dot deviation still counts as pointing at the correct
        /// direction
        /// </summary>
        [SerializeField] private float maxDotDeviation;

        /// <summary>
        /// Invoked when the script goes from tilted to not-tilted or vice-versa.
        /// Carries a bool indicating the current tilted state
        /// </summary>
        [SerializeField] private UnityEvent<bool> isTiltedChanged;

        /// <summary>
        /// Whether the transform was tilted the previous frame
        /// </summary>
        private bool wasTilted;

        /// <summary>
        /// The current up-vector of this transform
        /// </summary>
        private Vector3 Up => transform.up;

        /// <summary>
        /// Dot-deviation from the current up-direction to the target direction.
        /// Ranges from 0 to 2, where 0 means no deviation, 1 means right angle
        /// and 2 means opposite direction
        /// </summary>
        private float DotDeviation => 1 - Vector3.Dot(targetUp, Up);

        /// <summary>
        /// Indicates whether the transform is currently tilted
        /// </summary>
        private bool IsTilted => DotDeviation <= maxDotDeviation;


        private void Update()
        {
            // If no change has occured then there is nothing to do this frame
            if (IsTilted == wasTilted) return;

            // Store the new tilt-state and invoke the event
            wasTilted = IsTilted;
            isTiltedChanged.Invoke(wasTilted);
        }

        private void Awake()
        {
            // Store initial tilt-state and invoke event
            wasTilted = IsTilted;
            isTiltedChanged.Invoke(wasTilted);
        }
    }
}