using TMPro;
using UnityEngine;

public class DisplayCoins : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI collectedCoinsText;

    public void UpdateText(int value)
    {
        collectedCoinsText.text = $"Coins collected: {value.ToString()}";
    }
}
