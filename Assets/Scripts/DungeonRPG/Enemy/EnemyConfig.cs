using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class EnemyConfig : ScriptableObject
{
    public LayerMask playerMask;
    public LayerMask mapMask;
    public float idleTimer = 5.0f;
    public float attackTimer = 1.0f;
    public float wanderSpeed = 0.5f;
    public float attackSpeed = 0.5f;
    public float minDistanceFromPlayer = 5.0f;
    public float maxDistanceFromPlayer = 5.0f;
    public float WaypointRange = 2f;
    public int NumWaypoints = 3;
    public float projSpeed;
}
