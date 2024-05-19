using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class GameDataManager : MonoBehaviour
{
    public static GameDataManager singleton;
    [SerializeField]private DialogueDatabase storyTexts;
    [SerializeField]private FeedsDatabase storyFeed;
    public bool isRPGWindowOpen = false;
    private int currMsgEvent = -1;
    private int currFeedEvent = -1;
    [SerializeField] private int currRPGLevelNum = 0;
    public CubeSpawner cs;
    public int numEnemiesRemaining = 0;
    public bool beatLevel = false;
    public bool RPGDownloaded = false;
    public bool DataSortDownload = false;
    private int CorrectInfoFound = 0;
    public bool dataSorted = false;
    public bool catburglar = false;
    public bool GameOver = false;
    public bool revealCalled = false;
    public bool dayPassed = false;
    private PlayerCharacter RPGplayer = null;
    void Awake()
    {
        if(singleton != null){
            Destroy(this.gameObject);
        }
        singleton = this;
    }
    void Start(){
        UserManager.singleton.LoadTwitterWindow();
    }

    public void LoadCubeSpawner(){
        if(cs == null){
            cs = GameObject.FindWithTag("DataWindow").GetComponent<CubeSpawner>();
        }
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

    // public void ClosedWindow(string window){
    //     if(window.Equals("ChirpWindow") && currFeedEvent == 0){
    //         UserManager.singleton.LoadChatboxWindow();
    //     }
    //     if(window.Equals("BrowserWindow") && currMsgEvent == 0){
    //         RPGDownloaded = true;
    //         UserManager.singleton.ShowRPGIcon();
    //         UserManager.singleton.LoadChatboxWindow();
    //     }
    //     if(window.Equals("BrowserWindow") && currMsgEvent == 1 && RPGDownloaded){
    //         DataSortDownload = true;
    //         UserManager.singleton.ShowDataIcon();
    //     }
    //     if(window.Equals("RPGWindow") && currMsgEvent == 2 && RPGDownloaded){
    //         UserManager.singleton.LoadChatboxWindow();
    //     }
    //     if(window.Equals("RPGWindow") && currMsgEvent == 3 && RPGDownloaded){
    //         UserManager.singleton.LoadChatboxWindow();
    //     }
    //     if(window.Equals("ChatboxWindow") && currMsgEvent == 4){
    //         UserManager.singleton.LoadTwitterWindow();
    //         UserManager.singleton.LoadChatboxWindow();
    //     }
    // }

    // public void OpenWindow(string window){
    //     if(window.Equals("RPGWindow") && currMsgEvent == 1 && RPGDownloaded){
    //         UserManager.singleton.LoadChatboxWindow();
    //     }
    // }
}
