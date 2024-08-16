using UnityEngine;

[CreateAssetMenu(fileName = "NewCollection", menuName ="ScriptableObjects/New Collection")]
public class CoinCollection : ScriptableObject
{
    public int coinsCollected { get; private set; } = 0;

    //private void OnEnable()
    //{
    //    coinsCollected = 0;
    //}

    public void Addcoins(int value)
    {
        coinsCollected += value;
    }

    private void OnEnable() => Debug.Log("OnEnable");
    private void OnDisable() => Debug.Log("OnDisable");
}
