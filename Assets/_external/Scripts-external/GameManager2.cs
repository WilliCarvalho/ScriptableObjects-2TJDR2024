using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager2 : MonoBehaviour
{
    public static GameManager2 Instance;

    [SerializeField] private CoinCollection Coins;
    [SerializeField] private int resetLevelWhenCollect = 5;
    [SerializeField] private DisplayCoins coinsText;

    private void Awake()
    {
        Instance = this;
        coinsText.UpdateText(Coins.coinsCollected);
    }

    public void AddCoinsCollected()
    {
        Coins.Addcoins(1);
        coinsText.UpdateText(Coins.coinsCollected);
        if (Coins.coinsCollected >= resetLevelWhenCollect)
        {
            SceneManager.LoadScene("Persistência de dados");
        }
    }
}
