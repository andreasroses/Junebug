using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour,IInteractable
{
    [SerializeField] LevelManager lm;
    [SerializeField] GameObject openDoor;

    public void Interact(){
        if(lm.numEnemiesRemaining == 0){
            gameObject.SetActive(false);
            openDoor.SetActive(true);
        }
        
    }
}
