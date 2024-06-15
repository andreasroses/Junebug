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
    [SerializeField] private int currFeedEvent = -1;
    [SerializeField]private int progNum = 0;
    public CubeSpawner cs;
    public int numEnemiesRemaining = 0;
    public bool beatGame = false;
    public List<ProgressionEvent> progEvents;
    public ProgressionEvent currProgEvent;
    public int CorrectInfoFound = 0;
    public StoryEvent progressMsg;
    public StoryEvent progressFeed;
    void Start(){
        UserManager.singleton.LoadTwitterWindow();
        currProgEvent = progEvents[progNum];
        currProgEvent.SetEventReqs();
    }
    void Update(){
        if (!beatGame && currProgEvent != null){
            currProgEvent.currRPGLvl = CurrRPGLevel;
            if (currProgEvent.IsEventDone()){
                HandleEventResults(currProgEvent.results);
                if (progNum < progEvents.Count - 1){
                    currProgEvent = progEvents[++progNum];
                    currProgEvent.SetEventReqs();
                }
                else{
                    beatGame = true;
                }
            }
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
    public void RPGEventStarted(){
        currProgEvent.MarkEventDone(EventType.RPGStart);
    }
    public void RPGEventDone(){
        currProgEvent.MarkEventDone(EventType.RPGEnd);
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
            ++currFeedEvent;
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

    private void HandleEventResults(List<EventResult> results){
        foreach (var result in results){
            switch (result){
                case EventResult.RPGIcon:
                    UserManager.singleton.ShowRPGIcon();
                    break;
                case EventResult.DataIcon:
                    UserManager.singleton.ShowDataIcon();
                    break;
                case EventResult.Message:
                    progressMsg?.Invoke();
                    break;
                case EventResult.FeedUpdate:
                    progressFeed?.Invoke();
                    break;
                case EventResult.None:
                    break;
            }
        }
    }
}
