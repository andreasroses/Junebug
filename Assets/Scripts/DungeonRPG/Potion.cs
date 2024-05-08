using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Potion : MonoBehaviour, IInteractable
{
    [SerializeField] float healAmount = 10f;
    private PlayerCharacter playerCharacter;

    void Start(){
        playerCharacter = playerCharacter = GameDataManager.singleton.GetPlayer();
    }
    public void Interact(){
        playerCharacter.Heal(healAmount);
        gameObject.SetActive(false);
        Destroy(gameObject);
    }

}
