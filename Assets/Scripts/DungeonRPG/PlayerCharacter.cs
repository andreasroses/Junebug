using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class PlayerCharacter : MonoBehaviour
{
    [SerializeField] public float speed = 0.5f;
    [SerializeField] public float health = 100f;
    [SerializeField] float maxHealth = 100f;
    [SerializeField] float armorDef = 0;
    [SerializeField] float interactRadius = 5f;
    [SerializeField] LayerMask interactLayer;
    [SerializeField] LayerMask attackLayer;
    [SerializeField] Transform swordTransform;
    [SerializeField] Transform bladeTransform;
    [SerializeField] public AnimationUpdater au;
    [SerializeField] private HealthTracker healthTracker;
    public RPGEvent PlayerDeath;
    Rigidbody2D rb;
    void Awake(){
        rb = GetComponent<Rigidbody2D>();
    }
    public void MovePlayer(Vector3 direction){
        direction = direction.normalized;
        
        rb.MovePosition(transform.position + (direction * speed));
    }

    public void TakeDamage(float damage){
        if(health > 0){
            health-=damage;
            health+=armorDef;
        }
        if(health <= 0){
            PlayerDeath.Invoke();
        }
        healthTracker.UpdateHealth();
    }

    public void Heal(float healingAmount){
        if(health < maxHealth){
            var calcHeal = health + healingAmount;
            if(calcHeal > maxHealth){
                health = maxHealth;
            }
            else{
                health = calcHeal;
            }
        }
        healthTracker.UpdateHealth();
    }

    public void CheckInteract(){
        Collider2D[] results = Physics2D.OverlapCircleAll(transform.position, interactRadius,interactLayer);
        if(results.Length > 0){
            results[0].GetComponent<IInteractable>().Interact();
        }
    }

    public void Attack(){
        Collider2D[] results = Physics2D.OverlapCircleAll(bladeTransform.position, interactRadius,attackLayer);
        if(results.Length > 0){
            results[0].GetComponent<IDamageable>().Damage();
        }
    }

    public void PlayerReveal(){
        au.SwitchModern();
    }

    public void GainedArmor(){
        armorDef = 10;
        au.SwitchArmored();
    }

}
