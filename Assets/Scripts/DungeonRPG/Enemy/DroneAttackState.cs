using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneAttackState : AttackEnemyState{
    public override void Update(EnemyController enemy)
    {
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
            enemy.au.DroneUpdateDirs(direction.x);
            enemy.au.SwitchAttacking();
            enemy.LaunchBall(playerTransform.position);
            timer = enemy.config.attackTimer;
            enemy.au.SwitchAttacking();
        }
    }

    public override void Exit(EnemyController enemy)
    {
        timer = enemy.config.attackTimer + 10;
    }
}
