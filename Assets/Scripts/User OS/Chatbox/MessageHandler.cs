using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class MessageHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI msgTxt;
    [SerializeField] private TextMeshProUGUI nameTxt;
    [SerializeField] private Image userImg;

    public void SetTexts(string msg, string charName){
        msgTxt.text = msg;
        nameTxt.text = charName;
    }

    public void SetTexts(string msg){
        msgTxt.text = msg;
    }

    public void SetProfPic(Sprite userPic){
        userImg.sprite = userPic;
    }
}
