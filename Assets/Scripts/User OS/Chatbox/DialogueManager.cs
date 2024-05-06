using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using UnityEditor.VersionControl;
using UnityEngine;

[System.Serializable]
public class DialogueManager
{
    public Sprite friendImg;
    private Queue<MessageData> currTexts = new();
    private Queue<string> msgOptions = new Queue<string>();
    public string linkMsg;
    private List<string> dialogueDesc;

    public void StartDialogue(DialogueEvent d){
        friendImg = d.friendIcon;
        List<MessageData> tmpTxts = d.msgDialogue;
        queueTexts(tmpTxts);
        dialogueDesc = d.DialogueDesc;
        queueOptions(dialogueDesc);
    }


    private void queueTexts(List<MessageData> msgTxts){
        foreach(MessageData msg in msgTxts){
            currTexts.Enqueue(msg);
        }
    }

    private void queueOptions(List<string> options){
        foreach(string msg in options){
            msgOptions.Enqueue(msg);
        }
    }

    public MessageData GetNextMessage(){
        if(!IsDialogueQueueEmpty()){
            return currTexts.Dequeue();
        }
        return null;
    }

    public string GetNextOptions(){
        if(!IsOptionsQueueEmpty()){
            return msgOptions.Dequeue();
        }
        return null;
    }

    public bool IsDialogueQueueEmpty(){
        if(currTexts.Any()){
            return false;
        }
        return true;
    }

    public bool IsOptionsQueueEmpty(){
        if(msgOptions.Any()){
            return false;
        }
        return true;
    }
}
