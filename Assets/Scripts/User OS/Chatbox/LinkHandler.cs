using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LinkHandler : MonoBehaviour{
    [SerializeField] private TextMeshProUGUI linkTxt;
    private UserManager userManager;
    private GameObject browser;
    private BrowserManager loader;
    void Awake(){
        userManager = GameObject.FindGameObjectWithTag("GM").GetComponent<UserManager>();

    }
    public void OpenLinkInBrowser(){
        userManager.LoadBrowserWindow();
        loader = GameObject.FindGameObjectWithTag("BrowserWindow").GetComponent<BrowserManager>();
        string link = linkTxt.text;
        loader.BrowserSearch(link);
    }

    public void SetLink(string link){
        linkTxt.text = link;
    }
}
