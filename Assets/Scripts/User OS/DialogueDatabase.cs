using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class DialogueDatabase : ScriptableObject
{
    public List<DialogueEvent> DialogueEvents;
}
