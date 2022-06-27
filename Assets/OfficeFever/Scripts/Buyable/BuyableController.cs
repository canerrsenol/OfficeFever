using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace OfficeFever.Buyable
{
    public class BuyableController : MonoBehaviour
    {
        [SerializeField] private Transform spawnTransform;
        [SerializeField] private float spawnCost = 800f;
        [SerializeField] private Image progressImage;
        [SerializeField] private TMP_Text costText;

        private float payedCost = 0f;

        public void Pay()
        {
            payedCost += 100f;
            UpdateProgressImage();
            CheckIsUnlocked();
        }

        private void UpdateProgressImage()
        {
            progressImage.fillAmount = payedCost / spawnCost;
            costText.text = (spawnCost - payedCost).ToString();
        }

        private void CheckIsUnlocked()
        {
            if(payedCost == spawnCost)
            {
                transform.tag = "Untagged";
                spawnTransform.parent = null;
                spawnTransform.gameObject.SetActive(true);
                Destroy(this.gameObject);
            }
        }

    }
}

