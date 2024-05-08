using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneWanderState : WanderEnemyState{

    private Vector2 moveDirection;
    public override void Enter(EnemyController enemy){
        playerTransform = enemy.playerTransform;
        timer = enemy.config.idleTimer;
        speed = enemy.config.wanderSpeed;
        waypointRange = enemy.config.WaypointRange;
        numWaypoints = enemy.config.NumWaypoints;
        map.SetLayerMask(enemy.config.mapMask);
        SetWaypoints(enemy);
        movePosition = GetNextPoint();
        moveDirection = movePosition - new Vector2(enemy.enemyTransform.position.x,enemy.enemyTransform.position.y);
        enemy.au.DroneUpdateDirs(moveDirection.x);
    }

    public override void Update(EnemyController enemy){
        Vector2 direction = new Vector2(playerTransform.position.x,playerTransform.position.y) - movePosition;
        var enemyDistanceSqrd = direction.sqrMagnitude;
        var minDistanceSqrd = enemy.config.minDistanceFromPlayer * enemy.config.minDistanceFromPlayer;
        if(enemyDistanceSqrd < minDistanceSqrd){
            enemy.au.SwitchAttacking();
            enemy.stateMachine.ChangeState(EnemyStateID.Attack);
        }
        if(isWalking){
            Vector2 currPos = enemy.enemyTransform.position;
            Vector2 newPos = Vector2.MoveTowards(enemy.enemyTransform.position,movePosition, speed * Time.deltaTime);
            int numColliders = Physics2D.OverlapCircle(newPos,1,map,results);
            if(numColliders > 0 || currPos == movePosition){
                isWalking = false;
            }
            else{
                enemy.enemyTransform.position = newPos;
            }
        }
        
        if(!isWalking){
            timer-=Time.deltaTime;
            if(timer < 0){
                timer = enemy.config.idleTimer;
                movePosition = GetNextPoint();
                moveDirection = movePosition - new Vector2(enemy.enemyTransform.position.x,enemy.enemyTransform.position.y);
                enemy.au.DroneUpdateDirs(moveDirection.x);
                isWalking = true;
            }
        }
    }
}
