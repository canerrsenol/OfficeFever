using System.Collections.Generic;
using System.Linq;
using OfficeFever.PaperPrinter;
using OfficeFever.PlayerAnimation;
using OfficeFever.Worker;
using UnityEngine;

namespace OfficeFever.Carry
{
    public class CarryController : MonoBehaviour
    {
        [SerializeField] private Transform carryTransform;
        [SerializeField] private int maxCarry;
        [SerializeField] private float takeDropTime = 1f;

        private List<GameObject> carryList = new List<GameObject>();
        private bool isCarrying = false;
        private Printer printer;
        private WorkerController workerController;
        private float currentOwnedTime;

        private void Start()
        {
            currentOwnedTime = takeDropTime;
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.CompareTag("Print"))
            {
                printer = other.GetComponent<Printer>();
            }
            else if(other.CompareTag("Pc"))
            {
                workerController = other.GetComponent<WorkerController>();
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if(other.CompareTag("Print"))
            {
                if(currentOwnedTime < 0 && carryList.Count < maxCarry && printer.PaperList.Count > 0)
                {
                    TakePaper();
                    currentOwnedTime = takeDropTime;
                }
                else
                {
                    currentOwnedTime -= Time.deltaTime;
                }
            }
            else if(other.CompareTag("Pc"))
            {
                if(currentOwnedTime < 0 && carryList.Count > 0)
                {
                    PutPaper();
                    currentOwnedTime = takeDropTime;
                }
                else
                {
                    currentOwnedTime -= Time.deltaTime;
                }
            }
        }

        private void PutPaper()
        {
            workerController.GetPaper(carryList.Last());
            carryList.RemoveAt(carryList.Count - 1);
        }

        private void TakePaper()
        {
            GameObject paper = printer.GetLastPaper();
            paper.transform.parent = carryTransform;
            paper.transform.position = CalculatePosition();
            paper.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);

            carryList.Add(paper);

            if(!isCarrying)
            {
                isCarrying = true;
                GetComponent<AnimationController>().AnimationOverride();
            }
        }

        private Vector3 CalculatePosition()
        {
            Vector3 spawnPosition;
            if(carryList.Count > 0)
            {
                spawnPosition = carryList.Last().transform.position + Vector3.up / 15f;
            }
            else
            {
                spawnPosition = carryTransform.position;
            }

            return spawnPosition;
        }
    }
}

