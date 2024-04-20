using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

[System.Serializable]
public class ViewportEvent : UnityEvent<Texture2D> {}
public class BrowserManager : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private List<Texture2D> pgImgList;
    [SerializeField] private List<string> webpageList;
    public ViewportEvent updateWebpage;
    public void UpdateViewport(string userInput){
        if(inputField.wasCanceled){
            return;
        }
        if(webpageList.Contains(userInput)){
            updateWebpage.Invoke(pgImgList[0]);
        }
    }
}
