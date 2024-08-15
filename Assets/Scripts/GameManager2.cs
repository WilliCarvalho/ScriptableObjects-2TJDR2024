using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager2 : MonoBehaviour
{
    public static GameManager2 Instance;

    private int coinsCollected = 0;
    [SerializeField] private int resetLevelWhenCollect = 5;

    private void Awake()
    {
        Instance = this;
    }

    public int GetCoinsCollected() => coinsCollected;

    public void AddCoinsCollected()
    {
        coinsCollected++;
        print($"Coins Collected: {coinsCollected} ");
        if (coinsCollected >= resetLevelWhenCollect)
        {
            SceneManager.LoadScene("Persistência de dados");
        }
    }
}
