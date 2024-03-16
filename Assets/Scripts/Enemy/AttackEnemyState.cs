using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEnemyState : EnemyState
{
    private Transform playerTransform;
    private LayerMask playerMask;
    private float timer;
    private float speed;
    private Vector3 attackPosition;

    private Vector3 enterPosition;
    public EnemyStateID GetID(){
        return EnemyStateID.Attack;
    }
    public void Enter(EnemyController enemy){
        playerTransform = enemy.config.playerTransform;
        playerMask = enemy.config.playerMask;
        timer = enemy.config.attackTimer;
        speed = enemy.config.attackSpeed;
        enterPosition = enemy.transform.position;
        attackPosition = enemy.transform.position + new Vector3(0,-0.2f,0);

    }
    
    public void Update(EnemyController enemy){
        timer -= Time.deltaTime;
        if(timer < 0){
            enemy.OnAttack.Invoke(swordAttack(enemy));
            timer = enemy.config.attackTimer;
        }
    }

    public void Exit(EnemyController enemy){

    }

    private float swordAttack(EnemyController enemy){
        // enemy.enemyTransform.position = Vector2.Lerp(enterPosition,attackPosition, speed);
        // enemy.enemyTransform.position = Vector2.Lerp(attackPosition,enterPosition, speed);
        //add animator to show attack movement, will work with state machine
        if(doesLand()){
            return Random.Range(5,20);
        }
        return 0f;
    }

    private bool doesLand(){
        var check = Random.Range(0,10);
        Collider2D[] collisions = Physics2D.OverlapCircleAll(enterPosition,2f,playerMask);
        if(check > 5 && collisions.Length > 0){
            return true;
        }
        return false;
    }
}
