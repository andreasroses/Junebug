using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using UnityEngine;

[System.Serializable]
public class DialogueManager
{
    
    private Queue<string> currTexts = new Queue<string>();
    private Queue<string> msgOptions = new Queue<string>();
    public string linkMsg;
    private List<string> dialogueDesc;

    public void StartDialogue(DialogueEvent d){
        List<string> tmpTxts = d.Dialogue;
        queueTexts(tmpTxts);
        dialogueDesc = d.DialogueDesc;
        queueOptions(dialogueDesc);
        linkMsg = d.LinkDialogue[0];
    }


    private void queueTexts(List<string> msgTxts){
        foreach(string msg in msgTxts){
            currTexts.Enqueue(msg);
        }
    }

    private void queueOptions(List<string> options){
        foreach(string msg in options){
            msgOptions.Enqueue(msg);
        }
    }

    public string GetNextMessage(){
        return currTexts.Dequeue();
    }

    public string GetNextOptions(){
        return msgOptions.Dequeue();
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
