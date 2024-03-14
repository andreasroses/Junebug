using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class EnemyConfig : ScriptableObject
{
    public Transform playerTransform;
    public float wanderTimer = 5.0f;
    public float attackTimer = 2.0f;
    public float wanderSpeed = 0.5f;
    public float attackSpeed = 0.5f;
    public float minDistanceFromPlayer = 5.0f;
}
