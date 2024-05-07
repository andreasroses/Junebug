using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class AttackEnemyState : EnemyState
{
    private Transform playerTransform;
    private LayerMask playerMask;
    private float timer;
    private Vector3 enterPosition;
    public EnemyStateID GetID(){
        return EnemyStateID.Attack;
    }
    public void Enter(EnemyController enemy){
        playerTransform = enemy.playerTransform;
        playerMask = enemy.config.playerMask;
        timer = enemy.config.attackTimer;
        enterPosition = enemy.transform.position;
    }
    
    public void Update(EnemyController enemy){
        Vector3 direction = playerTransform.position - enterPosition;
        direction.z = 0;
        var enemyDistanceSqrd = direction.sqrMagnitude;
        var maxDistanceSqrd = enemy.config.maxDistanceFromPlayer * enemy.config.maxDistanceFromPlayer;
        if(enemyDistanceSqrd > maxDistanceSqrd){
            enemy.stateMachine.ChangeState(EnemyStateID.Wander);
        }
        timer -= Time.deltaTime;
        if(timer < 0){
            enemy.Attack(swordAttack(enemy));
            timer = enemy.config.attackTimer;
        }
    }

    public void Exit(EnemyController enemy){

    }

    private float swordAttack(EnemyController enemy){
        //add animator to show attack movement, will work with state machine
        if(doesLand()){
            Debug.Log("AttackState: swordAttack(): hit landed!");
            return Random.Range(5,20);
        }
        Debug.Log("AttackState: swordAttack(): hit did not land,,,");
        return 0f;
    }

    private bool doesLand(){
        Debug.Log("AttackState: checking if lands...");
        var check = Random.Range(0,10);
        Collider2D[] collisions = Physics2D.OverlapCircleAll(enterPosition,2f,playerMask);
        if(check > 3 && collisions.Length > 0){          
            return true;
        }
        return false;
    }
}
