using System.Threading.Tasks;
using UnityEngine;

namespace At.Ac.FhStp.XRIDemo
{
    /// <summary>
    /// Repeatedly instantiates a prefab while enabled
    /// </summary>
    public class ContinuousSpawner : MonoBehaviour
    {
        /// <summary>
        /// The prefab to instantiate
        /// </summary>
        [SerializeField] private GameObject prefab;

        /// <summary>
        /// Prefabs will be spawned at the position of this transform
        /// </summary>
        [SerializeField] private Transform spawnLocationTransform;

        /// <summary>
        /// How many instances to spawn per second
        /// </summary>
        [SerializeField] private float spawnsPerSecond;


        /// <summary>
        /// Indicates whether new instances should be spawned
        /// </summary>
        private bool ShouldSpawn =>
            // We spawn when both
            // a. The game-object has not been destroyed
            // b. The script is enabled
            !destroyCancellationToken.IsCancellationRequested && enabled;


        /// <summary>
        /// Spawns one instance of the prefab
        /// </summary>
        private void Spawn()
        {
            // Instantiates the prefab at he location of the specified transform
            // We use the default rotation
            // We don't need the instance so we discard the reference using _
            _ = Instantiate(prefab, spawnLocationTransform.position, Quaternion.identity);
        }

        private void OnEnable()
        {
            // We implement this as an async method that can run parallel to
            // the regular update loop. We could also do the same using a
            // coroutine. 
            async void SpawnContinuously()
            {
                // Run forever, as long as we should spawn prefabs
                while (ShouldSpawn)
                {
                    Spawn();
                    
                    // After each spawn we wait. The wait-time for Task.Delay
                    // is given in whole milli-seconds. We convert the value
                    // given from "spawns per second" to milli-seconds by
                    // first dividing 1 by the spawn-rate, which gives us
                    // the wait-time in seconds. Next we multiply by 1000 to get
                    // milli-seconds and finally we round down to the nearest
                    // whole number.
                    var waitTimeMillis = Mathf.FloorToInt(1f / spawnsPerSecond * 1000);
                    // Tells Unity to continue the regular update loop and only
                    // continue here when the given time has passed
                    await Task.Delay(waitTimeMillis);
                }
            }

            // We start spawning when the script is enabled
            SpawnContinuously();
        }
    }
}