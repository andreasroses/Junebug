using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class GameDataManager : MonoBehaviour
{
    [SerializeField]private DialogueDatabase storyTexts;
    [SerializeField]private FeedsDatabase storyFeed;
    public int CurrRPGLevel = 0;
    private int currMsgEvent = -1;
    private int currFeedEvent = -1;
    private int progNum = 0;
    public CubeSpawner cs;
    public int numEnemiesRemaining = 0;
    public bool beatLevel = false;
    public List<ProgressionEvent> progEvents;
    public ProgressionEvent currProgEvent;
    public int CorrectInfoFound = 0;

    void Start(){
        UserManager.singleton.LoadTwitterWindow();
        currProgEvent = progEvents[progNum];
    }
    void Update(){
        if(currProgEvent.IsEventDone()){
            currProgEvent = progEvents[++progNum];
        }
    }

    public void BrowserEventDone(){
        currProgEvent.MarkEventDone(EventType.Browser);
    }
    public void TextEventDone(){
        currProgEvent.MarkEventDone(EventType.Text);
    }
    public void FeedEventDone(){
        currProgEvent.MarkEventDone(EventType.Feed);
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
        return CurrRPGLevel;
    }

    public void TimerPenalty(){
        CorrectInfoFound-=5;
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
