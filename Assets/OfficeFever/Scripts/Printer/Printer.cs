using System.Collections.Generic;
using System.Linq;
using OfficeFever.PoolSystem;
using UnityEngine;

namespace OfficeFever.PaperPrinter
{
    public class Printer : MonoBehaviour
    {
        [SerializeField] private GameObject paperModel;
        [SerializeField] private float paperSpawnSpeed;
        [SerializeField] private Transform desiredPosition;
        [SerializeField] private float maxPaperCount;
        [SerializeField] private PaperPoolController paperPoolController;

        private float currentOwnedTime;
        private List<GameObject> paperList = new List<GameObject>();

        public List<GameObject> PaperList { get { return paperList;}}

        private void Start()
        {
            currentOwnedTime = paperSpawnSpeed;
        }

        private void Update()
        {
            if(paperList.Count >= maxPaperCount) return;
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

        public GameObject GetLastPaper()
        {
            GameObject paper = paperList.Last();
            if(paper != null)
            {
                paperList.RemoveAt(paperList.Count-1);
                return paper;
            }
            return null;
        }

        private void SpawnPaper()
        {
            Vector3 spawnPosition = Vector3.zero;
            if(paperList.Count < 1)
            {
                spawnPosition = desiredPosition.position;
            } 
            else
            {
               spawnPosition = paperList.Last().transform.position + Vector3.up / 15; 
            } 
            GameObject paper = paperPoolController.GetPaperFromPool();
            paper.transform.position = spawnPosition;
            paper.gameObject.SetActive(true);
            paperList.Add(paper);
        }
    }
}

