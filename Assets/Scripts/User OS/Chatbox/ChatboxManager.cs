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

    void Start(){
        dialogueManager.StartDialogue(GameDataManager.singleton.GetNextMsgEvent());
        profPic = dialogueManager.friendImg;
        currMsg = dialogueManager.GetNextMessage();
        StartCoroutine(SpawnMessagesWithDelay());
        SpawnNewOption(dialogueManager.GetNextOptions());
    }

    public void SpawnMessage(){
        if(currMsg.notPlayer){
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
        TextMeshProUGUI msgTxt = newMsg.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        msgTxt.text = currMsg.messageText;
        newMsg.transform.SetParent(MsgBox,false);
    }
    public void SpawnNewOption(string dialogueTxt){
        GameObject newOption = Instantiate(msgOption,Vector3.zero,Quaternion.identity);
        lastOption = newOption;
        TextMeshProUGUI msgTxt = newOption.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        msgTxt.text = dialogueTxt;
        newOption.transform.SetParent(optionBox,false);
    }

    public void SpawnNewFriendMessage(GameObject chatMsg){
        newMsg = Instantiate(chatMsg,Vector3.zero,Quaternion.identity);
        TextMeshProUGUI msgTxt = newMsg.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        Image userImg = newMsg.transform.GetChild(1).GetComponent<Image>();
        msgTxt.text = currMsg.messageText;
        userImg.sprite = profPic;
        newMsg.transform.SetParent(MsgBox,false);

    }

    public void SetLink(){
        TextMeshProUGUI linkTxt = newMsg.transform.GetChild(2).GetComponent<TextMeshProUGUI>();
        linkTxt.text = currMsg.linkText;
    }

    public void PlayerReply(){
        StartCoroutine(SpawnPlayerMessagesWithDelay());
        Destroy(lastOption);
    }

    private IEnumerator SpawnMessagesWithDelay(){
        while(currMsg!=null && currMsg.notPlayer){
            SpawnMessage();
            currMsg = dialogueManager.GetNextMessage();
            yield return new WaitForSeconds(1);
        }
        yield return new WaitForSeconds(2);
        StopCoroutine(SpawnMessagesWithDelay());
        if(!dialogueManager.IsOptionsQueueEmpty()){
            SpawnNewOption(dialogueManager.GetNextOptions());
        }
    }

    private IEnumerator SpawnPlayerMessagesWithDelay(){
        while(currMsg!=null &&!currMsg.notPlayer){
            SpawnMessage();
            currMsg = dialogueManager.GetNextMessage();
            yield return new WaitForSeconds(1);
            
        }
        StartCoroutine(SpawnMessagesWithDelay());
    }
}
