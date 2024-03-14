using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyStateID{
    Wander,Attack
}
public interface EnemyState
{
    EnemyStateID GetID();
    void Enter(EnemyController enemy);
    void Update(EnemyController enemy);
    void Exit(EnemyController enemy);
}
