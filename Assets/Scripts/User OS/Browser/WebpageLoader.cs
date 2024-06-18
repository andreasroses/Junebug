using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WebpageLoader : MonoBehaviour
{
    [SerializeField] private List<Sprite> pgImgList;
    [SerializeField] private Image currImage;
    [SerializeField] private GameObject homeSearchbar;
    [SerializeField] private RectTransform webpageRes;
    [SerializeField] private int lastHomeRes;
    [SerializeField] private Vector2 longPageRes;
    [SerializeField] private Vector2 homePageRes;
    private bool otteryOn = true;

    
    public void UpdateViewport(string imgName){
        OtteryBarOff();
        if(!imgName.Equals("not-found")){
            if(!imgName.Equals(currImage.name)){
                for(int i = 0; i < pgImgList.Count;i++){
                    if(pgImgList[i].name.Equals(imgName)){
                        currImage.sprite = pgImgList[i];
                        if(i > lastHomeRes){
                            webpageRes.sizeDelta = longPageRes;
                            webpageRes.position = new Vector3(webpageRes.position.x,(longPageRes.y/2) * -1,webpageRes.position.z);
                            return;
                        }
                        webpageRes.sizeDelta = homePageRes;
                        return;
                    }
                }
            }
        }
        webpageRes.sizeDelta = homePageRes;
        currImage.sprite = pgImgList[1];
        
    }

    public void LoadHome(){
        if(!"home".Equals(currImage.name)){
            currImage.sprite = pgImgList[0];
            webpageRes.sizeDelta = homePageRes;
            OtteryBarOn();
        }
    }

    private void ToggleOtteryBar(){
        otteryOn = !otteryOn;
        homeSearchbar.SetActive(otteryOn);
    }
    private void OtteryBarOn(){
        homeSearchbar.SetActive(true);
    }
    private void OtteryBarOff(){
        homeSearchbar.SetActive(false);
    }
}
