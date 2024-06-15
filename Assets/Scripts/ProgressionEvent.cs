using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[System.Serializable]
public class ProgressionEvent{
    public List<EventType> eventTypes;
    public List<EventResult> results;
    public bool eventDone = false;
    public int rpgLvlReq;
    public int currRPGLvl;
    private int numReqs;
    private int reqsDone = 0;
    //two event types or however many needed
    public bool IsEventDone(){
        if(currRPGLvl == rpgLvlReq){
            return eventDone;
        }
        return false;
    }

    public void MarkEventDone(EventType type){
        if(eventTypes.Contains(type)){
            eventTypes.Remove(type);
            reqsDone++;
        }
        if(reqsDone == numReqs){
            eventDone = true;
        }
    }

    public void SetEventReqs(){
        numReqs = eventTypes.Count;
    }
}

public enum EventType{
    Text,
    Feed,
    Browser,
    DataSort,
    RPGStart,
    RPGEnd
}

public enum EventResult{
    None,
    Message,
    RPGIcon,
    DataIcon,
    FeedUpdate
}
