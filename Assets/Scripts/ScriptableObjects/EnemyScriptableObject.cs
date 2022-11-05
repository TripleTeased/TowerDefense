using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/EnemyScriptableObject", order = 2)]
public class EnemyScriptableObject : ScriptableObject
{
    public string enemyName;

    public EnemyTowerType type;

    public int health;

    public float moveSpeed;
}
