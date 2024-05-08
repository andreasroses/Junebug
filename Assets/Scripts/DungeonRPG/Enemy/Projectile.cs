using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private PlayerCharacter playerCharacter;
    private Collider2D[] results = new Collider2D[10];
    [SerializeField] LayerMask playerMask;
    private ContactFilter2D player;
    void Start(){
        player.SetLayerMask(playerMask);
        playerCharacter = GameDataManager.singleton.GetPlayer();
        Destroy(gameObject,4);
    }
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Player"){
            playerCharacter.TakeDamage(Random.Range(1,8));
            gameObject.SetActive(false);
        }
    }

    void OnDrawGizmosSelected(){
        Gizmos.DrawWireSphere(transform.position,0.1f);
    }
}
