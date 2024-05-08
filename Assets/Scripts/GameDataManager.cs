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
    public bool Event0 = false;
    public bool Event1 = false;
    public bool Event2 = false;
    public bool Event3 = false;
    public bool Event4 = false;
    public bool Event5 = false;
    public bool Event6 = false;
    public bool Event7 = false;

    // void Update(){
    //     switch (true){
    //         case var _ when Event0:
    //         UserManager.singleton.LoadChatboxWindow();
    //         Event0 = false;
    //         break;
    //         case var _ when Event1:
    //         UserManager.singleton.LoadChatboxWindow();
    //         Event1= false;
    //         break;
    //         case var _ when Event2:
    //         UserManager.singleton.LoadChatboxWindow();
    //         Event2 = false;
    //         break;
    //         case var _ when Event3:
    //         UserManager.singleton.LoadChatboxWindow();
    //         Event3 = false;
    //         break;
    //         case var _ when Event4:
    //         UserManager.singleton.LoadChatboxWindow();
    //         Event4 = false;
    //         break;
    //         case var _ when Event5:
    //         UserManager.singleton.LoadChatboxWindow();
    //         Event5 = false;
    //         break;
    //         case var _ when Event6:
    //         cs.SpawnCubesRandom();
    //         Event6 = false;
    //         break;
    //         case var _ when Event7:
    //         UserManager.singleton.LoadChatboxWindow();
    //         Event7 = false;
    //         break;
    //         case var _ when GameOver:
    //         Application.Quit();
    //         break;
    //         default:
    //         break;
    //     }
    // }
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

    public void ClosedWindow(string window){
        if(window.Equals("ChirpWindow") && currFeedEvent == 0){
            UserManager.singleton.LoadChatboxWindow();
        }
        if(window.Equals("BrowserWindow") && currMsgEvent == 0){
            RPGDownloaded = true;
            UserManager.singleton.ShowRPGIcon();
            UserManager.singleton.LoadChatboxWindow();
        }
        if(window.Equals("BrowserWindow") && currMsgEvent == 1 && RPGDownloaded){
            DataSortDownload = true;
            UserManager.singleton.ShowDataIcon();
        }
        if(window.Equals("RPGWindow") && currMsgEvent == 2 && RPGDownloaded){
            UserManager.singleton.LoadChatboxWindow();
        }
        if(window.Equals("RPGWindow") && currMsgEvent == 3 && RPGDownloaded){
            UserManager.singleton.LoadChatboxWindow();
        }
        if(window.Equals("ChatboxWindow") && currMsgEvent == 4){
            UserManager.singleton.LoadTwitterWindow();
            UserManager.singleton.LoadChatboxWindow();
        }
    }

    public void OpenWindow(string window){
        if(window.Equals("RPGWindow") && currMsgEvent == 1 && RPGDownloaded){
            UserManager.singleton.LoadChatboxWindow();
        }
        // if(window.Equals("DataWindow") && currMsgEvent == 3){
            
        //     cs.SpawnCubesRandom();
        // }
    }
}
