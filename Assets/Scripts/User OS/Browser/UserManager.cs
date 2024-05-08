using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserManager : MonoBehaviour
{
    private ScreenFader screenFader;
    [SerializeField] private GameObject RPGWindow;
    [SerializeField] private GameObject BrowserWindow;
    [SerializeField] private GameObject ChatboxWindow;
    [SerializeField] private GameObject DataSortWindow;
    [SerializeField] private GameObject TwitterWindow;
    [SerializeField] private Transform canvasTransform;
    void Start()
    {
        screenFader = GetComponent<ScreenFader>();
    }

    public void LoadRPGGame(){
        Instantiate(RPGWindow,canvasTransform);
    }

    public void LoadDataSort(){
        
    }

    public void Quit(){
        Application.Quit();
    }
}
