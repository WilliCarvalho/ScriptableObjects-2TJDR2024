using System;
using StarterAssets;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private Vector3 rotation;

    private void Update() => transform.Rotate(rotation * Time.deltaTime);

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<ThirdPersonController>(out var player))
        {
            GameManager.Instance.AddCoinsCollected();
            Destroy(this.gameObject);
        }
    }
}
