using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserManager : MonoBehaviour
{
    public static UserManager singleton;
    [SerializeField] private GameObject RPGWindow;
    [SerializeField] private GameObject rpgIcon;
    [SerializeField] private GameObject dataIcon;
    [SerializeField] private GameObject RPGMenu;
    [SerializeField] private GameObject BrowserWindow;
    [SerializeField] private GameObject ChatboxWindow;
    [SerializeField] private GameObject DataSortWindow;
    [SerializeField] private GameObject TwitterWindow;
    [SerializeField] private Transform canvasTransform;

    void Awake(){
        if(singleton != null){
            Destroy(this.gameObject);
        }
        singleton = this;
    }
    public void DataSortResults(){
        LoadBrowserWindow();
        BrowserManager tmpLoader = GameObject.FindGameObjectWithTag("BrowserWindow").GetComponent<BrowserManager>();
        tmpLoader.BrowserSearch("?data-results");
        
    }
    public void LoadRPGMenu(){
        RPGMenu.SetActive(true);
    }
    public void LoadRPGGame(){
        RPGWindow.SetActive(true);
    }

    public void LoadBrowserWindow(){
        BrowserWindow.SetActive(true);
    }

    public void LoadChatboxWindow(){
        ChatboxWindow.SetActive(true);
    }

    public void LoadDataSortWindow(){
        if(RPGWindow.activeSelf){
            DataSortWindow.SetActive(true);
        }
    }

    public void LoadTwitterWindow(){
        TwitterWindow.SetActive(true);
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
