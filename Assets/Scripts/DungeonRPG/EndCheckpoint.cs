using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndCheckpoint : MonoBehaviour
{
    private GameObject rpgWindow;

    void Awake(){
        rpgWindow = GameObject.FindWithTag("RPGWindow");
    }
    void OnTriggerEnter2D(Collider2D other){
        if(GameDataManager.singleton.numEnemiesRemaining == 0){
            GameDataManager.singleton.RPGLevelCompleted();
            rpgWindow.SetActive(false);
        }
    }
}
