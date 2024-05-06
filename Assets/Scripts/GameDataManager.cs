using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameDataManager : MonoBehaviour
{
    public static GameDataManager singleton;
    [SerializeField]private DialogueDatabase storyTexts;
    [SerializeField]private FeedsDatabase storyFeed;
    private int currMsgEvent = -1;
    private int currFeedEvent = -1;
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
        if(currMsgEvent < storyTexts.DialogueEvents.Count()){
            currMsgEvent++;
            return storyTexts.DialogueEvents[currMsgEvent];
        }
        return null;
    }

    public FeedEvent GetNextFeedEvent(){
        if(currFeedEvent < storyFeed.allFeeds.Count()){
            currFeedEvent++;
            return storyFeed.allFeeds[currFeedEvent];
        }
        return null;
    }

    public int GetCurrentRPGLevel(){
        return currRPGLevelNum;
    }

    public void SetCurrentRPGLevel(int numLevel){
        currRPGLevelNum = numLevel;
    }

    public void TimerPenalty(){
        CorrectInfoFound-=5;
    }
}
