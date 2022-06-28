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
        GameObject obj = Instantiate(moneyPrefab, ExtensionMethods.CalculatePosition(transform.position, moneyList), 
        Quaternion.identity, transform);
        moneyList.Add(obj);
    }

    public int ReturnMoneyListLength()
    {
        return moneyList.Count;
    }

    public void ResetList()
    {
        foreach (GameObject obj in moneyList)
        {
            Destroy(obj);
        }
        moneyList = new List<GameObject>();
    }
}
