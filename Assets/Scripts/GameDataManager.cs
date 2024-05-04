using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataManager : MonoBehaviour
{
    public static GameDataManager singleton;
    [SerializeField]private DialogueDatabase storyTexts;
    private int currMsgEvent = -1;
    private int currRPGLevelNum = 0;
    private int CorrectInfoFound = 0;
    void Awake()
    {
        if(singleton != null){
            Destroy(this.gameObject);
        }
        singleton = this;
    }

    public void StoryInfoTracker(){
        CorrectInfoFound++;
    }

    public DialogueEvent GetNextMsgEvent(){
        currMsgEvent++;
        return storyTexts.DialogueEvents[currMsgEvent];
    }

    public int GetCurrentRPGLevel(){
        return currRPGLevelNum;
    }

    public void SetCurrentRPGLevel(int numLevel){
        currRPGLevelNum = numLevel;
    }
}
