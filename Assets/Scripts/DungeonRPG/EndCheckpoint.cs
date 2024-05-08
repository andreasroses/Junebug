using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

public class EndCheckpoint : MonoBehaviour
{
    private GameObject rpgWindow;

    void Awake(){
        rpgWindow = GameObject.FindWithTag("RPGWindow");
    }
    void OnTriggerEnter2D(Collider2D other){
        if(GameDataManager.singleton.numEnemiesRemaining == 0){
            Destroy(rpgWindow);
        }
    }
}
