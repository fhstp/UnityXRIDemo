using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace At.Ac.FhStp.XRIDemo
{
    public static class Vector3Ext
    {
        public static Vector3 WithY(this Vector3 v, float y) =>
            new Vector3(v.x, y, v.z);
    }
}