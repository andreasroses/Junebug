using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndCheckpoint : MonoBehaviour
{
    [SerializeField] LevelManager lm;
    private GameObject rpgWindow;

    void Awake(){
        rpgWindow = GameObject.FindWithTag("RPGGame");
    }
    void OnTriggerEnter2D(Collider2D other){
        if(lm.numEnemiesRemaining == 0 && other.gameObject.tag == "Player"){
            rpgWindow.GetComponent<RPGManager>().RPGLevelCompleted();
        }
    }
}
