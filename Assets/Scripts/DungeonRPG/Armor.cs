using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : MonoBehaviour, IInteractable
{
    private PlayerCharacter playerCharacter;
    void Start(){
        playerCharacter = playerCharacter = GameDataManager.singleton.GetPlayer();
    }
    public void Interact(){
        playerCharacter.au.SwitchArmored();
        Destroy(gameObject);
    }
}
