using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPGManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> levels;
    [SerializeField] private List<GameObject> realityLevels;
    [SerializeField] private Transform gridTransform;
    private GameObject currTilemap;
    private int levelNum = 0;

    void Start(){
        levelNum = GameDataManager.singleton.GetCurrentRPGLevel();
        LoadNextLevel();
    }
    private void LoadNextLevel(){
        if(levelNum < levels.Count){
            currTilemap = Instantiate(levels[levelNum],gridTransform);
        }
    }

    private void LevelCompleted(){
        Destroy(currTilemap);
        levelNum++;
    }

    public void RevealLevel(){
        Destroy(currTilemap);
        currTilemap = Instantiate(realityLevels[levelNum],gridTransform);
    }

    public void LoadLevel(int numLevel){
        Destroy(currTilemap);
        currTilemap = Instantiate(levels[numLevel]);
    }

    public void UpdateRPGLevelNum(){
        GameDataManager.singleton.SetCurrentRPGLevel(levelNum);
    }
}
