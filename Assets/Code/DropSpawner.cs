using System.Threading.Tasks;
using UnityEngine;

namespace At.Ac.FhStp.XRIDemo
{
    public class DropSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject dropPrefab;
        [SerializeField] private Transform spawnLocationTransform;
        [SerializeField] private float dropsPerSecond;


        private void SpawnDrop()
        {
            _ = Instantiate(dropPrefab, spawnLocationTransform.position, Quaternion.identity);
        }

        private void OnEnable()
        {
            async void SpawnDrops()
            {
                while (!destroyCancellationToken.IsCancellationRequested && enabled)
                {
                    SpawnDrop();
                    await Task.Delay(Mathf.FloorToInt(1f / dropsPerSecond * 1000));
                }
            }

            SpawnDrops();
        }
    }
}