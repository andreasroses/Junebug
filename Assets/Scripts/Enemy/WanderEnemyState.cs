using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderEnemyState : EnemyState
{
    private float timer = 5.0f;
    private float speed = 0.5f;

    private Vector3 movePosition;
    private Vector3 originalPosition;
    public EnemyStateID GetID(){
        return EnemyStateID.Wander;
    }
    public void Enter(EnemyController enemy){
        movePosition = getWanderPosition();
        originalPosition = enemy.enemyTransform.position;
    }
    public void Update(EnemyController enemy){
        timer -= Time.deltaTime;
        enemy.enemyTransform.position = Vector2.MoveTowards(enemy.enemyTransform.position,enemy.enemyTransform.position + movePosition, speed * Time.deltaTime);
        if(timer < 0){
            movePosition = getWanderPosition();
            timer = 3.0f;
        }
        
    }
    public void Exit(EnemyController enemy){

    }

    private Vector2 getWanderPosition(){
        float x = Random.Range(-0.5f,0.5f);
        float y = Random.Range(-0.5f,0.5f);
        return new Vector3(x,y);
    }
}
