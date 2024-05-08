using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class GameDataManager : MonoBehaviour
{
    public static GameDataManager singleton;
    [SerializeField]private DialogueDatabase storyTexts;
    [SerializeField]private FeedsDatabase storyFeed;
    private int currMsgEvent = -1;
    private int currFeedEvent = -1;
    [SerializeField] private int currRPGLevelNum = 0;
    public int numEnemiesRemaining = 0;
    public bool beatLevel = false;
    private int CorrectInfoFound = 0;

    private PlayerCharacter RPGplayer = null;
    void Awake()
    {
        if(singleton != null){
            Destroy(this.gameObject);
        }
        singleton = this;
    }

    void Update(){

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

    public void RPGLevelCompleted(){
        currRPGLevelNum++;
    }

    public void TimerPenalty(){
        CorrectInfoFound-=5;
    }

    public PlayerCharacter GetPlayer(){
        return RPGplayer;
    }

    public void LoadPlayer(){
        if(RPGplayer == null){
            RPGplayer = GameObject.FindWithTag("Player").GetComponent<PlayerCharacter>();
        }
        
    }
}
