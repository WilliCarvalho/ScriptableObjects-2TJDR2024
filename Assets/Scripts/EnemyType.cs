using UnityEngine;


[CreateAssetMenu(fileName = "new Enemy type", 
                 menuName = "ScriptableObjects/New Enemy type")]
public class EnemyType : ScriptableObject
{
    public Color Color;
    public int Damage;
}
