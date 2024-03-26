using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryData
{
    public int CorrectInfoFound = 0;
    public bool HasGoodEnding = false;

    public void UpdateInfoCount(){
        CorrectInfoFound++;
    }
}
