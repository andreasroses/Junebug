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
        CurrentLevel = gm.GetCurrentRPGLevel();
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
        currTilemap = Instantiate(realityLevels[CurrentLevel],gridTransform);
        revealEvent.Invoke();
    }

    public void LoadLevel(){
        Destroy(currTilemap);
        currTilemap = Instantiate(levels[CurrentLevel],gridTransform);
        playerTransform.position = currTilemap.transform.GetChild(0).position;
    }

    public void RPGLevelCompleted(){
        CurrentLevel++;
        gm.RPGEventDone();
        gm.CurrRPGLevel = CurrentLevel;
        transform.parent.gameObject.SetActive(false);
    }
}
