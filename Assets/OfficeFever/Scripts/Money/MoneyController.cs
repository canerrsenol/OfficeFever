using System.Collections;
using System.Collections.Generic;
using OfficeFever.Buyable;
using OfficeFever.UI;
using UnityEngine;

namespace OfficeFever.Money
{
    public class MoneyController : MonoBehaviour
    {
        [SerializeField] private uIManager uiManager;
        [SerializeField] private float buyTime;

        private float currentOwnedTime;


        private float money;
        private BuyableController buyableController;

        private void Start()
        {
            currentOwnedTime = buyTime;
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.CompareTag("Money"))
            {
                MoneyHolder moneyHolder = other.GetComponent<MoneyHolder>();
                CalculateMoney(moneyHolder.ReturnMoneyListLength() * 100);
                moneyHolder.ResetList();
            }
            else if(other.CompareTag("Buyable"))
            {
                buyableController = other.GetComponent<BuyableController>();
            }
        }

        private void CalculateMoney(float amount)
        {
            money += amount;
            UpdateUI();
        }

        private void UpdateUI()
        {
            uiManager.UpdateUI(money);
        }

        private void OnTriggerStay(Collider other)
        {
            if(money < 100) return;
            if(other.CompareTag("Buyable"))
            {
                if(currentOwnedTime < 0 )
                {
                    money -= 100;
                    buyableController.Pay();
                    currentOwnedTime = buyTime;
                    UpdateUI();
                }
                else
                {
                    currentOwnedTime -= Time.deltaTime;
                }
            }
        }
    }
}

