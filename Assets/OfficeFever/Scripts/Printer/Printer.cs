using UnityEngine;

namespace OfficeFever.PaperPrinter
{
    public class Printer : MonoBehaviour
    {
        [SerializeField] private GameObject paperModel;
        [SerializeField] private float paperSpawnSpeed;
        [SerializeField] private Transform desiredPosition;

        private float currentOwnedTime;

        private void Start()
        {
            currentOwnedTime = paperSpawnSpeed;
        }

        private void Update()
        {
            if (currentOwnedTime < 0)
            {
                SpawnPaper();
                currentOwnedTime = paperSpawnSpeed;
            }
            else
            {
                currentOwnedTime -= Time.deltaTime;
            }
        }

        private void SpawnPaper()
        {
            Instantiate(paperModel, desiredPosition.position, Quaternion.identity);
            desiredPosition.position += Vector3.up / 5;
        }
    }
}

