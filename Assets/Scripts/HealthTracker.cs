using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthTracker : MonoBehaviour
{
    [SerializeField] PlayerCharacter player;
    private TextMeshProUGUI healthTrackerTxt;
    
    void Awake(){
        healthTrackerTxt = GetComponent<TextMeshProUGUI>();
    }

    void Start(){
        healthTrackerTxt.text = player.health.ToString();
    }
    public void UpdateHealth(){
        Debug.Log("Interact called in HealthTracker");
        healthTrackerTxt.text = player.health.ToString();
    }

}
