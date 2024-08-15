using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private ScriptableTest identity;

    private void Start()
    {
        print(identity.name);
        print(identity.age);
    }
}
