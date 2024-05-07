using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyController : MonoBehaviour, IDamageable{
    private int HitsLanded = 0;
    public EnemyStateMachine stateMachine;
    public Transform playerTransform;
    public EnemyStateID initialState;
    public EnemyConfig config;
    public Transform enemyTransform;
    public Transform swordTransform;
    private PlayerCharacter playerCharacter;
    [SerializeField] public Animator enemyAttack;
    void Awake(){
        enemyTransform = GetComponent<Transform>();
        stateMachine = new EnemyStateMachine(this);
        stateMachine.RegisterState(new WanderEnemyState());
        stateMachine.RegisterState(new AttackEnemyState());
        stateMachine.ChangeState(initialState);
        playerCharacter = GameObject.FindWithTag("Player").GetComponent<PlayerCharacter>();
    }

    void Update(){
        stateMachine.Update();
    }

    public void Damage(){
        HitsLanded++;
        if(HitsLanded == 4){
            Destroy(gameObject);
        }
    }

    public void Attack(float dmg){
        playerCharacter.TakeDamage(dmg);
    }
}
