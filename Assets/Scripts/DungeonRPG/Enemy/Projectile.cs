using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private PlayerCharacter playerCharacter;
    void Start(){
        playerCharacter = GameDataManager.singleton.GetPlayer();
        Destroy(gameObject,4);
    }
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Player"){
            playerCharacter.TakeDamage(Random.Range(1,8));
            gameObject.SetActive(false);
        }
    }
}
