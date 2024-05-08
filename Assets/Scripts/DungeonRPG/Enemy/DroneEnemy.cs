using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DroneEnemy : EnemyController
{
    protected override void RegisterStates()
    {
        stateMachine.RegisterState(new DroneWanderState());
        stateMachine.RegisterState(new DroneAttackState());
    }

    public override void Damage(){
        HitsLanded++;
        if(HitsLanded == 4){
            GameDataManager.singleton.numEnemiesRemaining--;
            stateMachine.GetState(stateMachine.currentState)?.Exit(this);
            au.EnemyDeath();
            Destroy(gameObject,1);
        }
    }
}
