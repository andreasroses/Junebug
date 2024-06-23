using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuHandler : MonoBehaviour
{
    [SerializeField] Image img;
    [SerializeField] RectTransform imgTransform;
    [SerializeField] Sprite selectSprite;
    [SerializeField] Sprite defaultSprite;
    [SerializeField] private TextMeshProUGUI nameTxt;
    [SerializeField] private TextMeshProUGUI statusTxt;
    [SerializeField] private GameObject button;
    bool isSelected = false;

    public void Play(){
        UserManager.singleton.LoadRPGGame();
        gameObject.SetActive(false);
    }

    public void SelectPlayer(){
        isSelected = !isSelected;
        if(isSelected){
            imgTransform.sizeDelta = new Vector3(6,6);
            img.sprite = selectSprite;
            
        }
        else{
            imgTransform.sizeDelta = new Vector3(2,2);
            img.sprite = defaultSprite;
        }
        
    }

    public void PlayerUnavailable(){
        img.gameObject.SetActive(false);
        nameTxt.gameObject.SetActive(false);
        button.SetActive(false);
        statusTxt.text = "No Player Available";
    }
}
