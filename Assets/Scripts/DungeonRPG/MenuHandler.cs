using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MenuHandler : MonoBehaviour
{
    [SerializeField] Image img;
    [SerializeField] RectTransform imgTransform;
    [SerializeField] Sprite selectSprite;
    [SerializeField] Sprite defaultSprite;
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
}
