using System;
using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEngine;

[System.Serializable]
public class DialogueManager
{
    [SerializeField]private DialogueDatabase storyTexts;
    private Queue<string> currTexts;
    private List<string> dialogueDesc;

    public DialogueManager(string eventName){
        Predicate<DialogueEvent> matchEvent = (DialogueEvent d) => {return d.EventName.Equals(eventName);};
        DialogueEvent d = storyTexts.DialogueEvents.Find(matchEvent);
        List<string> tmpTxts = d.Dialogue;
        queueTexts(tmpTxts);
        dialogueDesc = d.DialogueDesc;
    }


    private void queueTexts(List<string> msgTxts){
        foreach(string msg in msgTxts){
            currTexts.Enqueue(msg);
        }
    }
}
