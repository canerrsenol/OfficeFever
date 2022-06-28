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
        [SerializeField] private Transform paperPoolTransform;
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
            paper.transform.position = ExtensionMethods.CalculatePosition(papersSpawnTransform.position, paperList);
            paper.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
            paperList.Add(paper);
        }

        private void DeletePaper()
        {
            Transform lastPaper = paperList.Last().transform;
            lastPaper.parent = paperPoolTransform;
            lastPaper.gameObject.SetActive(false);
            paperList.RemoveAt(paperList.Count - 1);
        }

        private void SpawnMoney()
        {
            moneyHolder.CreateMoney();
        }

    }

}
