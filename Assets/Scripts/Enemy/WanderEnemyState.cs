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
        playerTransform = enemy.config.playerTransform;
        timer = enemy.config.wanderTimer;
        speed = enemy.config.wanderSpeed;
        enterPosition = enemy.enemyTransform.position;
        movePosition = getWanderPosition(enterPosition);
    }
    public void Update(EnemyController enemy){
        Vector3 direction = playerTransform.position - movePosition;
        if(direction.sqrMagnitude > enemy.config.minDistanceFromPlayer *enemy.config.minDistanceFromPlayer){
            enemy.stateMachine.ChangeState(EnemyStateID.Attack);
            return;
        }
        timer -= Time.deltaTime;
        Debug.Log("Current position: " + enemy.enemyTransform.position);
        Debug.Log("WanderPosition: " + movePosition);
        enemy.enemyTransform.position = Vector2.Lerp(enemy.enemyTransform.position,movePosition, speed * Time.deltaTime);
        if(timer < 0){
            movePosition = getWanderPosition(enterPosition);
            timer = enemy.config.wanderTimer;
        }
        
    }
    public void Exit(EnemyController enemy){

    }

    private Vector3 getWanderPosition(Vector3 originalPos){
        int x = Random.Range(-1,1);
        int y = Random.Range(-1,1);
        Vector3 addPos = new Vector3(x,y,0);
        return originalPos+addPos;
        
    }
}
