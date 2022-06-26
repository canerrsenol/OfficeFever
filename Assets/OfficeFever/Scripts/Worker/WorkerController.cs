using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace OfficeFever.Worker
{
    public class WorkerController : MonoBehaviour
    {
        [SerializeField] private float workTime;
        [SerializeField] private Transform papersSpawnTransform;
        [SerializeField] private MoneyHolder moneyHolder;

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
        
        public void GetPaper(GameObject paper)
        {
            paper.transform.parent = papersSpawnTransform;
            paper.transform.position = CalculatePosition();
            paper.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
            paperList.Add(paper);
        }

        private Vector3 CalculatePosition()
        {
            Vector3 spawnPosition = Vector3.zero;
            if(paperList.Count > 0)
            {
                spawnPosition = paperList.Last().transform.position + Vector3.up / 15f;
            }
            else
            {
                spawnPosition = papersSpawnTransform.position;
            }

            return spawnPosition;
        }

        private void DeletePaper()
        {
            //paperList.Last().transform.parent = paperPoolTransform;
            paperList.RemoveAt(paperList.Count - 1);
            
        }

        private void SpawnMoney()
        {
            moneyHolder.CreateMoney();
        }

    }

}
