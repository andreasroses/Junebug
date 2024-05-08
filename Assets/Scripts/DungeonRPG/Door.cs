using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour,IInteractable
{
    [SerializeField] GameObject openDoor;
    [SerializeField] int numEnemies;

    void Start(){
        GameDataManager.singleton.numEnemiesRemaining = numEnemies;
    }
    public void Interact(){
        if(GameDataManager.singleton.numEnemiesRemaining == 0){
            gameObject.SetActive(false);
            openDoor.SetActive(true);
            GameDataManager.singleton.RPGLevelCompleted();
        }
        
    }
}
