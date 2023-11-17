using UnityEngine;

namespace At.Ac.FhStp.XRIDemo
{
    /// <summary>
    /// Helper extensions for Vector3s
    /// </summary>
    public static class Vector3Ext
    {
        /// <summary>
        /// Creates a copy of this vector with a different y coordinate
        /// </summary>
        /// <param name="v">The original vector</param>
        /// <param name="y">The replacement y</param>
        /// <returns>A new vector with the y replaced</returns>
        public static Vector3 WithY(this Vector3 v, float y) =>
            new Vector3(v.x, y, v.z);
    }
}