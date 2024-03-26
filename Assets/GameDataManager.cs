using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataManager : MonoBehaviour
{
    public static GameDataManager singleton;
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
}
