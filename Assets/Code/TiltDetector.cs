using UnityEngine;
using UnityEngine.Events;

namespace At.Ac.FhStp.XRIDemo
{
    public class TiltDetector : MonoBehaviour
    {
        [SerializeField] private Vector3 targetUp;
        [SerializeField] private float maxDotDeviation;
        [SerializeField] private UnityEvent<bool> isTiltedChanged;

        private bool wasTilted;

        private Vector3 Up => transform.up;

        private float DotDeviation => 1 - Vector3.Dot(targetUp, Up);

        private bool IsTilted => DotDeviation <= maxDotDeviation;


        private void Update()
        {
            if (IsTilted == wasTilted) return;

            wasTilted = IsTilted;
            isTiltedChanged.Invoke(wasTilted);
        }

        private void Awake()
        {
            isTiltedChanged.Invoke(IsTilted);
        }
    }
}