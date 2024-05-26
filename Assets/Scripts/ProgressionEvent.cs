using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ProgressionEvent{
    public EventType eventType;
    public bool eventReq;
    public bool eventDone;
    public int rpgLvlReq;
    public int currRPGLvl;

    public bool IsEventDone(){
        if(currRPGLvl == rpgLvlReq){
            return eventDone;
        }
        return false;
    }

    public void MarkEventDone(EventType type){
        if(type == eventType){
            eventDone = true;
        }
    }
}

public enum EventType{
    Text,
    Feed,
    Browser
}
