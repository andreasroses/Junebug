using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class DialogueEvent : ScriptableObject
{
    public string EventName;
    public string FriendName;
    public List<String> Dialogue;
    public List<String> DialogueDesc;

    public List<String> DialogueMultChoices;
    public List<String> DialogueResults;
}
