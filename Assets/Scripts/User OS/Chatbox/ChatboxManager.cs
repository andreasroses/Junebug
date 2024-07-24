using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class ChatboxManager : MonoBehaviour
{
    //add flag to load new messages or not
    [SerializeField] GameDataManager gm;
    public static ChatboxManager singleton;
    [SerializeField] private GameObject nomsgTxt;
    [SerializeField] private GameObject playerMsg;
    [SerializeField] private GameObject msgOption;
    [SerializeField] private GameObject friendMsg;
    [SerializeField] private GameObject linkMsg;
    [SerializeField] private RectTransform MsgBox;
    [SerializeField] private RectTransform optionBox;
    [SerializeField] private DialogueManager dialogueManager;
    private GameObject newMsg;
    private GameObject lastOption;
    private MessageData currMsg;
    private Sprite profPic;

    void Awake(){
        if(singleton != null){
            Destroy(this.gameObject);
        }
        singleton = this;
    }
    // void Start(){
    //     dialogueManager.StartDialogue(gm.DebugEvent());
    //     profPic = dialogueManager.friendImg;
    //     currMsg = dialogueManager.GetNextMessage();
    //     StartCoroutine(SpawnMessagesWithDelay());
    //     SpawnNewOption(dialogueManager.GetNextOptions());
    // }

    public void NewMessageEvent(){
        gameObject.SetActive(true);
        nomsgTxt.SetActive(false);
        foreach(Transform child in MsgBox.transform){
            Destroy(child.gameObject);
        }
        foreach(Transform child in optionBox.transform){
            Destroy(child.gameObject);
        }
        dialogueManager.StartDialogue(gm.GetNextMsgEvent());
        profPic = dialogueManager.friendImg;
        currMsg = dialogueManager.GetNextMessage();
        StartCoroutine(SpawnMessagesWithDelay());
        SpawnNewOption(dialogueManager.GetNextOptions());
    }
    public void SpawnMessage(){
        if(!currMsg.charName.Equals("June")){
            if(!currMsg.linkText.Equals("")){
                SpawnNewFriendMessage(linkMsg);
                SetLink();
            }
            else{
                SpawnNewFriendMessage(friendMsg);
            }
        }
        else{
            SpawnNewPlayerMessage();
        }
        
    }

    public void SpawnNewPlayerMessage(){
        newMsg = Instantiate(playerMsg,Vector3.zero,Quaternion.identity);
        MessageHandler msgHandler = newMsg.GetComponent<MessageHandler>();
        msgHandler.SetTexts(currMsg.messageText);
        newMsg.transform.SetParent(MsgBox,false);
    }
    public void SpawnNewOption(string dialogueTxt){
        GameObject newOption = Instantiate(msgOption,optionBox);
        lastOption = newOption;
        OptionHandler optHandler = newOption.GetComponent<OptionHandler>();
        optHandler.SetText(dialogueTxt);
        //newOption.transform.SetParent(optionBox,false);
    }

    public void SpawnNewFriendMessage(GameObject chatMsg){
        newMsg = Instantiate(chatMsg,Vector3.zero,Quaternion.identity);
        MessageHandler msgHandler = newMsg.GetComponent<MessageHandler>();
        msgHandler.SetTexts(currMsg.messageText, currMsg.charName);
        msgHandler.SetProfPic(profPic);
        newMsg.transform.SetParent(MsgBox,false);

    }

    public void SetLink(){
        LinkHandler linkHandler = newMsg.GetComponent<LinkHandler>();
        linkHandler.SetLink(currMsg.linkText);
    }

    public void PlayerReply(){
        Destroy(lastOption);
        if(!dialogueManager.IsOptionsQueueEmpty()){
            SpawnNewOption(dialogueManager.GetNextOptions());
        }
        StartCoroutine(SpawnPlayerMessagesWithDelay());
    }

    private IEnumerator SpawnMessagesWithDelay(){
        while(currMsg!=null && !currMsg.charName.Equals("June")){
            SpawnMessage();
            currMsg = dialogueManager.GetNextMessage();
        }
        yield return new WaitForSeconds(2);
        StopCoroutine(SpawnMessagesWithDelay());
        
    }

    private IEnumerator SpawnPlayerMessagesWithDelay(){
        while(currMsg!=null && currMsg.charName.Equals("June")){
            SpawnMessage();
            currMsg = dialogueManager.GetNextMessage();
            yield return new WaitForSeconds(1);
            
        }
        StartCoroutine(SpawnMessagesWithDelay());
    }
}
