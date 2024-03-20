using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class AttackEvent : UnityEvent<float> {}
public class EnemyController : MonoBehaviour
{
    public EnemyStateMachine stateMachine;
    public Transform playerTransform;
    public EnemyStateID initialState;
    public EnemyConfig config;
    public Transform enemyTransform;
    public AttackEvent OnAttack;
    void Awake()
    {
        enemyTransform = GetComponent<Transform>();
        stateMachine = new EnemyStateMachine(this);
        stateMachine.RegisterState(new WanderEnemyState());
        stateMachine.RegisterState(new AttackEnemyState());
        stateMachine.ChangeState(initialState);
    }

    void Update()
    {
        Debug.Log("Current state: " + stateMachine.currentState);
        stateMachine.Update();
    }
}
