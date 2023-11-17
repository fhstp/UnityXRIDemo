using UnityEngine;

namespace At.Ac.FhStp.XRIDemo
{
    
    /// <summary>
    /// Helper component to allow destroying a game-object via UnityEvent
    /// </summary>
    public class Destroyer : MonoBehaviour
    {
        /// <summary>
        /// Destroys the game-object this component is attached to
        /// </summary>
        public void DestroyGameObject()
        {
            Destroy(gameObject);
        }
    }
}