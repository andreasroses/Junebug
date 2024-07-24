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
    //two event types or however many needed
    public bool IsEventDone(){
        return eventDone;
    }

    public void MarkEventDone(EventType type){
        if(eventTypes.Contains(type)){
            eventTypes.Remove(type);
        }
        if(eventTypes.Count == 0){
            eventDone = true;
        }
    }
}

public enum EventType{
    Text,
    Feed,
    Browser,
    DataSort,
    RPGStart,
    RPGEnd,
    RPGReveal
}

public enum EventResult{
    None,
    Message,
    RPGIcon,
    DataIcon,
    FeedUpdate
}
