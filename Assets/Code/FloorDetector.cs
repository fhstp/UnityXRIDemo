using System;
using System.Collections;
using System.Collections.Generic;
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
                var dotDeviation = Vector3.Dot(Vector3.up, normal);
                var isCollidingWithFloor = 1 - dotDeviation <= maxDotDeviation;
                if (!isCollidingWithFloor) continue;

                onTouchingFloor.Invoke();
                return;
            }
        }
    }
}