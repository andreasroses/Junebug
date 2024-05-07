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
        healthTrackerTxt.text = "Player Health: " +  player.health.ToString();
    }
    public void UpdateHealth(){
        healthTrackerTxt.text = "Player Health: " + player.health.ToString();
    }

}
