using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndCheckpoint : MonoBehaviour
{
    [SerializeField] LevelManager lm;
    private GameObject rpgWindow;

    void Awake(){
        rpgWindow = GameObject.FindWithTag("RPGWindow");
    }
    void OnTriggerEnter2D(Collider2D other){
        if(lm.numEnemiesRemaining == 0){
            rpgWindow.GetComponent<RPGManager>().RPGLevelCompleted();
            rpgWindow.SetActive(false);
        }
    }
}
