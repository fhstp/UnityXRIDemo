using System.Threading.Tasks;
using UnityEngine;

namespace At.Ac.FhStp.XRIDemo
{
    public class ContinuousSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject prefab;
        [SerializeField] private Transform spawnLocationTransform;
        [SerializeField] private float spawnsPerSecond;


        private bool ShouldSpawn =>
            !destroyCancellationToken.IsCancellationRequested && enabled;


        private void Spawn()
        {
            _ = Instantiate(prefab, spawnLocationTransform.position, Quaternion.identity);
        }

        private void OnEnable()
        {
            async void SpawnContinuously()
            {
                while (ShouldSpawn)
                {
                    Spawn();
                    await Task.Delay(Mathf.FloorToInt(1f / spawnsPerSecond * 1000));
                }
            }

            SpawnContinuously();
        }
    }
}