using UnityEngine;

namespace At.Ac.FhStp.XRIDemo
{
    public class FillScaler : MonoBehaviour
    {
        [SerializeField] private float maxScale;

        private new Transform transform;
        private float baseY;


        public void ScaleFor(float fill)
        {
            var scale = maxScale * fill;
            var y = baseY + scale / 2;

            transform.localScale = transform.localScale.WithY(scale);
            transform.localPosition = transform.localPosition.WithY(y);
        }

        private void Awake()
        {
            transform = base.transform;
            baseY = transform.localPosition.y;
        }
    }
}