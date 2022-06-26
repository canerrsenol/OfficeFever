using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MoneyHolder : MonoBehaviour
{
    [SerializeField] private GameObject moneyPrefab;
    private List<GameObject> moneyList = new List<GameObject>();

    public void CreateMoney()
    {
        GameObject obj = Instantiate(moneyPrefab, CalculatePosition(), Quaternion.identity, transform);
        moneyList.Add(obj);
    }

    private Vector3 CalculatePosition()
        {
            Vector3 spawnPosition = Vector3.zero;
            if(moneyList.Count > 0)
            {
                spawnPosition = moneyList.Last().transform.position + Vector3.up / 15f;
            }
            else
            {
                spawnPosition = transform.position;
            }

            return spawnPosition;
        }
}
