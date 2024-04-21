using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;


public class BrowserManager : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private TMP_InputField homeInput;
    [SerializeField] private List<string> webpageList;
    [SerializeField] private List<string> termsList;
    
    
    private WebpageLoader webpageLoader;

    void Start(){
        webpageLoader = GetComponent<WebpageLoader>();
    }
    public void BrowserSearch(string userInput){
        if(inputField.wasCanceled){
            return;
        }
        if(webpageList.Contains(userInput)){
            var imgNameIndex = userInput.IndexOf('?') + 1;
            string imgName = userInput.Substring(imgNameIndex);
            webpageLoader.UpdateViewport(imgName);
        }
        else{
            webpageLoader.UpdateViewport("not-found");
        }
    }

    public void HomeSearch(string userInput){
        if(homeInput.wasCanceled){
            return;
        }
        if(termsList.Contains(userInput)){
            webpageLoader.UpdateViewport(userInput);
        }
        else{
            webpageLoader.UpdateViewport("not-found");
        }
    }

    
}
