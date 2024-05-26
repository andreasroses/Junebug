using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class RPGEvent : UnityEvent {}
public class RPGManager : MonoBehaviour
{
    [SerializeField] GameDataManager gm;
    public int CurrentLevel = 0;
    [SerializeField] private List<GameObject> levels;
    [SerializeField] private List<GameObject> realityLevels;
    [SerializeField] private Transform gridTransform;
    [SerializeField] private Transform playerTransform;
    public StoryEvent revealEvent;
    private GameObject currTilemap;
    private int levelNum = 0;

    void Start(){
        levelNum = gm.GetCurrentRPGLevel();
        if(levelNum > 1){
            levelNum = 0;
        }
        LoadNextLevel();
    }
    private void LoadNextLevel(){
        if(levelNum < levels.Count){
            currTilemap = Instantiate(levels[levelNum],gridTransform);
            playerTransform.position = currTilemap.transform.GetChild(0).position;
        }
    }

    private void LevelCompleted(){
        Destroy(currTilemap);
        levelNum++;
    }

    public void RevealLevel(){
        Destroy(currTilemap);
        currTilemap = Instantiate(realityLevels[levelNum],gridTransform);
        revealEvent.Invoke();
    }

    public void LoadLevel(int numLevel){
        Destroy(currTilemap);
        currTilemap = Instantiate(levels[numLevel]);
    }

    public void RPGLevelCompleted(){
        CurrentLevel++;
        gm.CurrRPGLevel = CurrentLevel;
    }
}
