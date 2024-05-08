using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class AttackEnemyState : EnemyState
{
    protected Transform playerTransform;
    protected Collider2D[] results = new Collider2D[10];
    protected ContactFilter2D playerMask;
    protected float timer;
    protected Vector3 enterPosition;
    public EnemyStateID GetID(){
        return EnemyStateID.Attack;
    }
    public virtual void Enter(EnemyController enemy){
        playerTransform = enemy.playerTransform;
        playerMask.SetLayerMask(enemy.config.playerMask);
        timer = enemy.config.attackTimer;
        enterPosition = enemy.transform.position;
    }
    
    public virtual void Update(EnemyController enemy){
        Vector3 direction = playerTransform.position - enterPosition;
        direction.z = 0;
        var enemyDistanceSqrd = direction.sqrMagnitude;
        var maxDistanceSqrd = enemy.config.maxDistanceFromPlayer * enemy.config.maxDistanceFromPlayer;
        if(enemyDistanceSqrd > maxDistanceSqrd){
            enemy.au.EnemyWander();
            enemy.stateMachine.ChangeState(EnemyStateID.Wander);
        }
        timer -= Time.deltaTime;
        if(timer < 0){
            enemy.au.UpdateDirFloats(direction.x,direction.y);
            enemy.au.EnemyAttack();
            enemy.Attack(swordAttack(enemy));
            timer = enemy.config.attackTimer;
            enemy.au.SwitchAttacking();
        }
    }

    public virtual void Exit(EnemyController enemy){

    }

    protected float swordAttack(EnemyController enemy){
        //add animator to show attack movement, will work with state machine
        if(doesLand()){
            return Random.Range(5,20);
        }
        return 0f;
    }

    protected bool doesLand(){
        var check = Random.Range(0,10);
        int numColliders = Physics2D.OverlapCircle(enterPosition,2f,playerMask,results);
        if(check > 3 && numColliders > 0){          
            return true;
        }
        return false;
    }
}
