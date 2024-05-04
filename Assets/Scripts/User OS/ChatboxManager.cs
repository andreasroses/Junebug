using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class ChatboxManager : MonoBehaviour
{
    public static ChatboxManager singleton;
    [SerializeField] private GameObject playerMsg;
    [SerializeField] private GameObject msgOption;
    [SerializeField] private GameObject friendMsg;
    [SerializeField] private GameObject linkMsg;
    [SerializeField] private RectTransform MsgBox;
    [SerializeField] private RectTransform optionBox;
    [SerializeField] private DialogueManager dialogueManager;
    private GameObject lastOption;

    void Awake(){
        if(singleton != null){
            Destroy(this.gameObject);
        }
        singleton = this;
    }

    void Start(){
        dialogueManager.StartDialogue(GameDataManager.singleton.GetNextMsgEvent());
        SpawnNewFriendMessage(dialogueManager.GetNextMessage());
        SpawnNewOption(dialogueManager.GetNextOptions());
    }
    public void SpawnNewPlayerMessage(string dialogueTxt){
        GameObject newMsg = Instantiate(playerMsg,Vector3.zero,Quaternion.identity);
        TextMeshProUGUI msgTxt = newMsg.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        msgTxt.text = dialogueTxt;
        newMsg.transform.SetParent(MsgBox,false);
    }
    public void SpawnNewOption(string dialogueTxt){
        GameObject newMsg = Instantiate(msgOption,Vector3.zero,Quaternion.identity);
        lastOption = newMsg;
        TextMeshProUGUI msgTxt = newMsg.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        msgTxt.text = dialogueTxt;
        newMsg.transform.SetParent(optionBox,false);
    }

    public void SpawnNewFriendMessage(string dialogueTxt){
        GameObject newMsg = Instantiate(friendMsg,Vector3.zero,Quaternion.identity);
        TextMeshProUGUI msgTxt = newMsg.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        msgTxt.text = dialogueTxt;
        newMsg.transform.SetParent(MsgBox,false);
    }

    public void SpawnNewLinkMessage(string dialogueTxt){
        GameObject newMsg = Instantiate(linkMsg,Vector3.zero,Quaternion.identity);
        TextMeshProUGUI msgTxt = newMsg.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        msgTxt.text = dialogueTxt;
        newMsg.transform.SetParent(MsgBox,false);
    }

    public void PlayerReply(){
        if(dialogueManager.IsDialogueQueueEmpty()){
            return;
        }
        Destroy(lastOption);
        StartCoroutine(SpawnMessagesWithDelay());
    }

    private IEnumerator SpawnMessagesWithDelay(){
        SpawnNewPlayerMessage(dialogueManager.GetNextMessage());
        yield return new WaitForSeconds(1);
        SpawnNewFriendMessage(dialogueManager.GetNextMessage());
        if(!dialogueManager.IsOptionsQueueEmpty()){
            SpawnNewOption(dialogueManager.GetNextOptions());
        }
        else{
            SpawnNewLinkMessage(dialogueManager.linkMsg);
        }
        StopCoroutine(SpawnMessagesWithDelay());
    }
}
