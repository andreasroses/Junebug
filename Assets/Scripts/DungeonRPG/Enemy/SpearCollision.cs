using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpearCollision : MonoBehaviour
{
    public RPGEvent SpearAttack;
    void OnTriggerStay2D(Collider2D other){
        if(other.gameObject.tag == "Player"){
            SpearAttack.Invoke();
        }
    }
}
