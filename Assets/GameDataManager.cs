using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataManager : MonoBehaviour
{
    public static GameDataManager singleton;
    public StoryData storyData;
    void Awake()
    {
        if(singleton != null){
            Destroy(this.gameObject);
        }
        singleton = this;
        storyData = new StoryData();
    }

    public void StoryInfoTracker(){
        storyData.UpdateInfoCount();
    }
}
