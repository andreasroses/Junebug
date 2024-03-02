using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class HealEvent : UnityEvent<float> {}

public class Potion : MonoBehaviour, Interactable
{
    [SerializeField] float healAmount = 10f;
    public HealEvent OnHeal;
    
    public void Interact(){
        Debug.Log("Interact called in Potion");
        OnHeal.Invoke(healAmount);
        Destroy(this.gameObject);
    }

}
