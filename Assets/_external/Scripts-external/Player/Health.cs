using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int lives;

    public event Action OnDead;
    public event Action OnHurt;

    public void TakeDamage(int value)
    {
        lives -= value;
        HandleDamageTaken();
    }

    private void HandleDamageTaken()
    {
        if (lives <= 0)
        {
            OnDead?.Invoke();
        }
        else
        {
            OnHurt?.Invoke();
        }
    }

    public int GetLives()
    {
        return lives;
    }
}
