using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModernPotion : MonoBehaviour, IInteractable
{
    [SerializeField] int healAmt;
    [SerializeField] int cooldownTime;
    private PlayerCharacter playerCharacter;
    private bool healCooldown;
    void Start(){
        playerCharacter = GameDataManager.singleton.GetPlayer();
    }
    public void Interact(){
        if(healCooldown == false){
            playerCharacter.Heal(healAmt);
            healCooldown = true;
            StartCoroutine(delayHeal());
        }
        
    }

    private IEnumerator delayHeal(){
        yield return new WaitForSeconds(cooldownTime);
        healCooldown = false;

    }
}
