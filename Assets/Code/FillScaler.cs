using UnityEngine;

namespace At.Ac.FhStp.XRIDemo
{
    /// <summary>
    /// Scales the transform on this game-object in accordance with a [0;1]
    /// value
    /// </summary>
    public class FillScaler : MonoBehaviour
    {
        /// <summary>
        /// The maximum scale the transform should reach when it is scaled for
        /// 1. By this we mean the scale on the y-axis.
        /// </summary>
        [SerializeField] private float maxScale;

        /// <summary>
        /// The transform on this game-object. We cache it to increase
        /// performance.
        /// </summary>
        private new Transform transform;

        /// <summary>
        /// The initial y coordinate of the transform before any scaling has
        /// happened.
        /// </summary>
        private float baseY;


        /// <summary>
        /// Rescales the transform to fit the given value
        /// </summary>
        /// <param name="fill">
        /// The value to scale for. Must be between 0 and 1
        /// </param>
        public void ScaleFor(float fill)
        {
            // The new scale and y coordinate for the transform
            var scale = maxScale * fill;
            var y = baseY + scale / 2;

            // Update y-scale and position without affecting x and z
            transform.localScale = transform.localScale.WithY(scale);
            transform.localPosition = transform.localPosition.WithY(y);
        }

        private void Awake()
        {
            // Cache the transform
            transform = base.transform;
            // Remember the initial y coordinate
            baseY = transform.localPosition.y;
        }
    }
}