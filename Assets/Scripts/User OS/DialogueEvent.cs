using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class DialogueEvent : ScriptableObject
{
    public string EventName;
    public string FriendName;
    public List<string> Dialogue;
    public List<string> LinkDialogue;
    public List<string> DialogueDesc;

    public List<string> DialogueMultChoices;
    public List<string> DialogueResults;
}
