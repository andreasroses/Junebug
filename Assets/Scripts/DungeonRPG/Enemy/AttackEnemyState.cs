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
    private EnemyController e;
    public EnemyStateID GetID(){
        return EnemyStateID.Attack;
    }
    public virtual void Enter(EnemyController enemy){
        playerTransform = enemy.playerTransform;
        playerMask.SetLayerMask(enemy.config.playerMask);
        timer = enemy.config.attackTimer;
        enterPosition = enemy.transform.position;
        enemy.EnableSpearCollider();
        e = enemy;
    }
    
    public virtual void Update(EnemyController enemy){
        enemy.StopAttacking();
        Vector3 direction = playerTransform.position - enterPosition;
        direction.z = 0;
        UpdateSpearDirs(direction,enemy);
        float distance = Vector3.Distance(enterPosition, playerTransform.position);
        if(distance > enemy.config.maxDistanceFromPlayer){
            enemy.au.EnemyWander();
            enemy.stateMachine.ChangeState(EnemyStateID.Wander);
        }
        timer -= Time.deltaTime;
        if(timer < 0){
            enemy.au.UpdateDirFloats(direction.x,direction.y);
            enemy.au.EnemyAttack();
            timer = enemy.config.attackTimer;
            enemy.au.SwitchAttacking();
            enemy.IsAttacking();
            timer = enemy.config.attackTimer;
        }
    }

    public virtual void Exit(EnemyController enemy){
        enemy.DisableSpearCollider();
    }


    private void UpdateSpearDirs(Vector3 input, EnemyController enemy){
        if(input.x != 0){
            if(input.x < 0){
            enemy.RotateSpearCollider(Direction.Left);
            }
            else{
                enemy.RotateSpearCollider(Direction.Right);
            }
        }
        else if(input.y != 0){
            if(input.y < 0){
                enemy.RotateSpearCollider(Direction.Down);
            }
            else{
                enemy.RotateSpearCollider(Direction.Up);
            }
        }
    }
}
