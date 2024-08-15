using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public InputManager InputManager { get; private set; }

    [Header("Dynamic Game objects")]
    [SerializeField] private GameObject bossDoor;
    [SerializeField] private PlayerBehavior player;

    [Header("Managers")]
    public UIManager UIManager;
    public AudioManager AudioManager;

    private int totalKeys;
    private int keysLeftToCollect;

    private void Awake()
    {
        if (Instance != null) Destroy(this.gameObject);
        Instance = this;

        InputManager = new InputManager();

        totalKeys = FindObjectsOfType<CollectableKey>().Length;
        keysLeftToCollect = totalKeys;
        UIManager.UpdateKeysLeftText(totalKeys, keysLeftToCollect);
    }

    public void UpdateKeysLeft()
    {
        keysLeftToCollect--;
        UIManager.UpdateKeysLeftText(totalKeys, keysLeftToCollect);
        CheckAllKeysCollected();
    }

    private void CheckAllKeysCollected()
    {
        if(keysLeftToCollect <= 0)
        {
            Destroy(bossDoor);
        }
    }

    public void UpdateLives(int amount)
    {
        UIManager.UpdateLivesText(amount);
    }

    public PlayerBehavior GetPlayer()
    {
        return player;
    }
}
