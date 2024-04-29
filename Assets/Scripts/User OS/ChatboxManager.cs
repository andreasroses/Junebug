using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class ChatboxManager : MonoBehaviour
{
    [SerializeField] private GameObject playerMsg;
    [SerializeField] private GameObject friendMsg;
    [SerializeField] private RectTransform MsgBox;
    [SerializeField] private Scrollbar scroll;
    public void SpawnNewPlayerMessage(string dialogueTxt){
        GameObject newMsg = Instantiate(playerMsg,Vector3.zero,Quaternion.identity);
        TextMeshProUGUI msgTxt = newMsg.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        msgTxt.text = dialogueTxt;
        newMsg.transform.SetParent(MsgBox,false);
        scroll.value = 0f;
    }

    public void SpawnNewFriendMessage(string dialogueTxt){
        GameObject newMsg = Instantiate(friendMsg,Vector3.zero,Quaternion.identity);
        TextMeshProUGUI msgTxt = newMsg.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        msgTxt.text = dialogueTxt;
        newMsg.transform.SetParent(MsgBox,false);
        scroll.value = 0f;
    }
}
