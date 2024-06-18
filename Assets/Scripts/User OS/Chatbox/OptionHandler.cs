using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class OptionHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI optionTxt;
    public void ChooseOption(){
        ChatboxManager.singleton.PlayerReply();
    }

    public void SetText(string txt){
        optionTxt.text = txt;
    }

}
