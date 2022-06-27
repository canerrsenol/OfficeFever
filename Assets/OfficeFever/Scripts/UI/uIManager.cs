using TMPro;
using UnityEngine;

namespace OfficeFever.UI
{
    public class uIManager : MonoBehaviour
    {
        [SerializeField] TMP_Text text;

        public void UpdateUI(float amount)
        {
            text.text = amount.ToString();
        }
    }
}
