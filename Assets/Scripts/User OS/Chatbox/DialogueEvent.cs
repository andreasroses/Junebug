using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class DialogueEvent : ScriptableObject
{
    public string EventName;
    public string FriendName;
    public Sprite friendIcon;
    public List<MessageData> msgDialogue;
    public List<string> DialogueDesc;

    public List<string> DialogueMultChoices;
    public List<string> DialogueResults;
}
