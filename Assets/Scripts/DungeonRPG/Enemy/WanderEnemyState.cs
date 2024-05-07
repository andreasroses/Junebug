using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderEnemyState : EnemyState
{
    private Transform playerTransform;
    private float timer;
    private float speed;

    private Vector3 enterPosition;

    private Vector3 movePosition;
    public EnemyStateID GetID(){
        return EnemyStateID.Wander;
    }
    public void Enter(EnemyController enemy){
        playerTransform = enemy.playerTransform;
        timer = enemy.config.wanderTimer;
        speed = enemy.config.wanderSpeed;
        enterPosition = enemy.enemyTransform.position;
        movePosition = getWanderPosition(enterPosition,enemy);
        enemy.au.SwitchWalk();
    }
    public void Update(EnemyController enemy){
        Vector3 direction = playerTransform.position - movePosition;
        direction.z = 0;
        var enemyDistanceSqrd = direction.sqrMagnitude;
        var minDistanceSqrd = enemy.config.minDistanceFromPlayer * enemy.config.minDistanceFromPlayer;
        if(enemyDistanceSqrd < minDistanceSqrd){
            enemy.au.EnemyAttack();
            enemy.stateMachine.ChangeState(EnemyStateID.Attack);
        }
        timer -= Time.deltaTime;
        enemy.enemyTransform.position = Vector2.Lerp(enemy.enemyTransform.position,movePosition, speed * Time.deltaTime);
        if(timer < 0){
            enemy.au.SwitchWalk();
            movePosition = getWanderPosition(enterPosition, enemy);
            timer = enemy.config.wanderTimer;
            enemy.au.SwitchWalk();
        }
        
    }
    public void Exit(EnemyController enemy){

    }

    private Vector3 getWanderPosition(Vector3 originalPos, EnemyController enemy){
        int x = Random.Range(-1,1);
        int y = Random.Range(-1,1);
        Vector3 addPos = new(x,y,0);
        if(addPos.x != 0){
            enemy.au.UpdateDirFloats(addPos.x,0);
        }
        else if(addPos.y != 0){
            enemy.au.UpdateDirFloats(0,addPos.y);
        }
        return originalPos+addPos;
        
    }
}
