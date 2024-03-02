using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    [SerializeField] float speed = 0.5f;
    [SerializeField] public float health = 100f;
    [SerializeField] float maxHealth = 100f;

    [SerializeField] float interactRadius = 5f;
    [SerializeField] LayerMask layerMask;
    Rigidbody2D rb;

    void Awake(){
        rb = GetComponent<Rigidbody2D>();
    }
    public void MovePlayer(Vector3 direction){
        rb.MovePosition(transform.position + (direction * speed));
    }

    public void TakeDamage(float damage){
        if(health > 0){
            health-=damage;
        }
        
    }

    public void Heal(float healingAmount){
        if(health < maxHealth){
            health+=healingAmount;
        }
    }

    public void CheckInteract(){
        Collider2D[] results = Physics2D.OverlapCircleAll(transform.position, interactRadius,layerMask);
        if(results.Length > 0){
            Debug.Log("Object found: "+ results[0].gameObject.name);
            results[0].GetComponent<Interactable>().Interact();
        }
    }
}
