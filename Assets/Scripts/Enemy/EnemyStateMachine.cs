using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine
{
    public EnemyState[] states;
    public EnemyController enemy;
    public EnemyStateID currentState;

    public EnemyStateMachine(EnemyController enemy){
        this.enemy = enemy;
        int numStates = System.Enum.GetNames(typeof(EnemyStateID)).Length;
        states = new EnemyState[numStates];
    }

    public void RegisterState(EnemyState state){
        int index = (int)state.GetID();
        states[index] = state;
    }

    public EnemyState GetState(EnemyStateID stateID){
        int index = (int) stateID;
        return states[index];
    }
    public void Update(){
        GetState(currentState)?.Update(enemy);
    }

    public void ChangeState(EnemyStateID newState){
        GetState(currentState)?.Exit(enemy);
        currentState = newState;
        GetState(currentState)?.Enter(enemy);
    }
}
