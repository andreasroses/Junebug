using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LinkHandler : MonoBehaviour
{
    [SerializeField] private GameObject browserWindow;
    [SerializeField] private TextMeshProUGUI linkTxt;

    public void OpenLinkInBrowser(){
        string link = linkTxt.text;
        GameObject newWindow = Instantiate(browserWindow, transform.root,false);
        BrowserManager tmpLoader = newWindow.GetComponent<BrowserManager>();
        tmpLoader.BrowserSearch(link);
    }
}
