using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    void Start(){
        Destroy(gameObject,4);
    }
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Player"){
            other.GetComponent<PlayerCharacter>().TakeDamage(Random.Range(1,8));
            gameObject.SetActive(false);
        }
    }
}
