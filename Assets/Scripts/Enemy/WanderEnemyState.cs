using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderEnemyState : EnemyState
{
    private float timer = 5.0f;
    private float speed = 0.5f;

    private Vector3 movePosition;
    public EnemyStateID GetID(){
        return EnemyStateID.Wander;
    }
    public void Enter(EnemyController enemy){
        movePosition = getWanderPosition(enemy.enemyTransform.position);
    }
    public void Update(EnemyController enemy){
        timer -= Time.deltaTime;
        Debug.Log("Current position: " + enemy.enemyTransform.position);
        Debug.Log("WanderPosition: " + movePosition);
        enemy.enemyTransform.position = Vector2.Lerp(enemy.enemyTransform.position,movePosition, speed * Time.deltaTime);
        if(timer < 0){
            movePosition = getWanderPosition(enemy.enemyTransform.position);
            timer = 5.0f;
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
