using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public EnemyStateMachine stateMachine;
    public EnemyStateID initialState;

    public Transform enemyTransform;
    void Awake()
    {
        enemyTransform = GetComponent<Transform>();
        stateMachine = new EnemyStateMachine(this);
        stateMachine.RegisterState(new WanderEnemyState());
        stateMachine.ChangeState(initialState);
    }

    void Update()
    {
        stateMachine.Update();
    }
}
