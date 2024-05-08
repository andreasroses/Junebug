using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserManager : MonoBehaviour
{
    public static UserManager singleton;
    private ScreenFader screenFader;
    [SerializeField] private GameObject RPGWindow;
    [SerializeField] private GameObject rpgIcon;
    [SerializeField] private GameObject dataIcon;
    [SerializeField] private GameObject RPGMenu;
    [SerializeField] private GameObject BrowserWindow;
    [SerializeField] private GameObject ChatboxWindow;
    [SerializeField] private GameObject DataSortWindow;
    [SerializeField] private GameObject TwitterWindow;
    [SerializeField] private Transform canvasTransform;

    void Awake()
    {
        if(singleton != null){
            Destroy(this.gameObject);
        }
        singleton = this;
    }
    void Start(){
        screenFader = GetComponent<ScreenFader>();
    }

    public void DataSortResults(){
        GameObject newWindow = Instantiate(BrowserWindow, canvasTransform);
        BrowserManager tmpLoader = newWindow.GetComponent<BrowserManager>();
        tmpLoader.BrowserSearch("?data-results");
        
    }
    public void LoadRPGMenu(){
        GameDataManager.singleton.OpenWindow("RPGWindow");
        Instantiate(RPGMenu,canvasTransform);
    }
    public void LoadRPGGame(){
        Instantiate(RPGWindow, canvasTransform);
    }

    public void LoadBrowserWindow(){
        GameDataManager.singleton.OpenWindow("BrowserWindow");
        Instantiate(BrowserWindow, canvasTransform);
    }

    public void LoadChatboxWindow(){
        //GameDataManager.singleton.OpenWindow("ChatboxWindow");
        Instantiate(ChatboxWindow, canvasTransform);
    }

    public void LoadDataSortWindow(){
        Instantiate(DataSortWindow, canvasTransform);
    }

    public void LoadTwitterWindow(){
        Instantiate(TwitterWindow, canvasTransform);
    }

    public void ShowRPGIcon(){
        rpgIcon.SetActive(true);
    }

    public GameObject GetBrowserWindow(){
        return BrowserWindow;
    }
    public void ShowDataIcon(){
        dataIcon.SetActive(true);
    }
    public void Quit(){
        Application.Quit();
    }
}
