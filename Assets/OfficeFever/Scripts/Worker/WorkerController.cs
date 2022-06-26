using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OfficeFever.Worker
{
    public class WorkerController : MonoBehaviour
    {
        [SerializeField] private GameObject moneyPrefab;
        [SerializeField] private float workTime;

        private float currentOwnedTime;
        public List<GameObject> paperList = new List<GameObject>();

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
                    
                    currentOwnedTime = workTime;
                }
                else
                {
                    currentOwnedTime -= Time.deltaTime;
                }
            }
        }

    }

}
