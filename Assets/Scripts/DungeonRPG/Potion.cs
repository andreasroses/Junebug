using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;



public class Potion : MonoBehaviour, IInteractable
{
    [SerializeField] float healAmount = 10f;
    private PlayerCharacter playerCharacter;

    void Awake(){
        playerCharacter = GameObject.FindWithTag("Player").GetComponent<PlayerCharacter>();
    }
    public void Interact(){
        Debug.Log("Interact called in Potion");
        playerCharacter.Heal(healAmount);
        gameObject.SetActive(false);
        Destroy(gameObject);
    }

}
