using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserManager : MonoBehaviour
{
    private ScreenFader screenFader;
    void Start()
    {
        screenFader = GetComponent<ScreenFader>();
    }

    public void LoadPRGGame(){
        screenFader.FadeToColor("DungeonRPGScene");
    }

    public void LoadDataSort(){
        screenFader.FadeToColor("3DPuzzleScene");
    }

    public void Quit(){
        Application.Quit();
    }
}
