using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

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
    private Quaternion[] dirRotates = new Quaternion[4];
    private int[] angles = {0,-90,-180,90};
    Rigidbody2D rb;
    void Awake(){
        rb = GetComponent<Rigidbody2D>();
        dirRotates[0] = swordTransform.rotation;
        for(int i = 1;i<4;i++){
            dirRotates[i] = Quaternion.AngleAxis(angles[i],swordTransform.forward);
        }
    }
    public void MovePlayer(Vector3 direction){
        if(direction.x == 1){
            swordTransform.rotation = dirRotates[1];
        }
        else if(direction.x == -1){
            swordTransform.rotation = dirRotates[2];
        }
        if(direction.y == -1){
            swordTransform.rotation = dirRotates[3];
        }
        else if(direction.y == 1){
            swordTransform.rotation = dirRotates[0];
        }
        direction = direction.normalized;
        
        rb.MovePosition(transform.position + (direction * speed));
    }

    public void TakeDamage(float damage){
        if(health > 0){
            health-=damage;
            health+=armorDef;
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
            Debug.Log("Object found: "+ results[0].gameObject.name);
            results[0].GetComponent<IInteractable>().Interact();
        }
    }

    public void Attack(){
        Collider2D[] results = Physics2D.OverlapCircleAll(bladeTransform.position, interactRadius,attackLayer);
        if(results.Length > 0){
            Debug.Log("Object found: "+ results[0].gameObject.name);
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
