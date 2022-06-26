using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace OfficeFever.Worker
{
    public class WorkerController : MonoBehaviour
    {
        [SerializeField] private GameObject moneyPrefab;
        [SerializeField] private Transform paperPoolTransform;
        [SerializeField] private float workTime;

        private float currentOwnedTime;
        private List<GameObject> paperList = new List<GameObject>();

        private void Start()
        {
            currentOwnedTime = workTime;
        }

        private void Update()
        {
            if(paperList.Count > 0)
            {
                if(currentOwnedTime < 0)
                {
                    DeletePaper();
                    SpawnMoney();
                    currentOwnedTime = workTime;
                }
                else
                {
                    currentOwnedTime -= Time.deltaTime;
                }
            }
        }

        public void AddPaper(GameObject paper)
        {
            paperList.Add(paper);
        }

        private void DeletePaper()
        {
            paperList.Last().transform.parent = paperPoolTransform;
            paperList.RemoveAt(paperList.Count - 1);
        }

        private void SpawnMoney()
        {

        }

    }

}
