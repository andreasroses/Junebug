using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class EnemyConfig : ScriptableObject
{
    public LayerMask playerMask;
    public float wanderTimer = 5.0f;
    public float attackTimer = 1.0f;
    public float wanderSpeed = 0.5f;
    public float attackSpeed = 0.5f;
    public float minDistanceFromPlayer = 5.0f;
    public float maxDistanceFromPlayer = 5.0f;
}
