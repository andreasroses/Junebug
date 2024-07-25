using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WanderEnemyState : EnemyState
{
    protected Transform playerTransform;
    protected float timer;
    protected float speed;

    protected float waypointRange;
    protected ContactFilter2D map;
    protected List<Vector2> wanderPoints = new List<Vector2>();
    protected int currPoint = -1;
    protected Vector2 movePosition;
    protected int numWaypoints;
    protected bool isWalking = true;
    protected Collider2D[] results = new Collider2D[10];
    private Vector2 moveDirection;
    public virtual EnemyStateID GetID(){
        return EnemyStateID.Wander;
    }
    public virtual void Enter(EnemyController enemy){
        playerTransform = enemy.playerTransform;
        timer = enemy.config.idleTimer;
        speed = enemy.config.wanderSpeed;
        waypointRange = enemy.config.WaypointRange;
        numWaypoints = enemy.config.NumWaypoints;
        map.SetLayerMask(enemy.config.mapMask);
        SetWaypoints(enemy);
        movePosition = GetNextPoint();
        moveDirection = movePosition - new Vector2(enemy.enemyTransform.position.x,enemy.enemyTransform.position.y);
        enemy.au.UpdateDirFloats(moveDirection.x,moveDirection.y);
        enemy.au.EnemyWalking();
    }
    public virtual void Update(EnemyController enemy){
        float distance = Vector3.Distance(enemy.enemyTransform.position, playerTransform.position);
        if(distance < enemy.config.minDistanceFromPlayer){
            enemy.au.EnemyAttack();
            enemy.stateMachine.ChangeState(EnemyStateID.Attack);
        }
        if(isWalking){
            Vector2 currPos = enemy.enemyTransform.position;
            Vector2 newPos = Vector2.MoveTowards(enemy.enemyTransform.position,movePosition, speed * Time.deltaTime);
            int numColliders = Physics2D.OverlapCircle(newPos,0.2f,map,results);
            if(numColliders > 0 || currPos == movePosition){
                enemy.au.EnemyStopWalking();
                isWalking = false;
            }else{
                enemy.enemyTransform.position = newPos;
            }
            // as lerping check if point collides, if it does get next waypoint
        }
        
        if(!isWalking){
            timer-=Time.deltaTime;
            if(timer < 0){
                timer = enemy.config.idleTimer;
                movePosition = GetNextPoint();
                moveDirection = movePosition - new Vector2(enemy.enemyTransform.position.x,enemy.enemyTransform.position.y);
                enemy.au.UpdateDirFloats(moveDirection.x,moveDirection.y);
                isWalking = true;
                enemy.au.EnemyWalking();
            }
        }
        
    }
    public virtual void Exit(EnemyController enemy){

    }

    protected bool GetWaypoint(Vector2 center, float range, out Vector2 result){
        Vector2 randomPoint = center + Random.insideUnitCircle * range;
        int numColliders = Physics2D.OverlapCircle(randomPoint,1f,map,results);
        if(numColliders > 0){
            result = randomPoint;
            return false;
        }
        result = randomPoint;
        return true;
    }

    protected void SetWaypoints(EnemyController enemy){
        int counter = 0;
        while (counter < numWaypoints - 1){
            if (GetWaypoint(enemy.enemyTransform.position, waypointRange, out Vector2 waypoint)){
                wanderPoints.Add(waypoint);
                counter++;
            }
        }
    }

    protected Vector2 GetNextPoint(){
        if (wanderPoints.Count == 0)
            return Vector2.zero;

        currPoint = (currPoint + 1) % wanderPoints.Count;
        return wanderPoints[currPoint];
        
    }
}
