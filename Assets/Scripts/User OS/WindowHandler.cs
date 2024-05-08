using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowHandler : MonoBehaviour
{
    [SerializeField] string windowClosed;
    public void CloseWindow(){
        GameDataManager.singleton.ClosedWindow(windowClosed);
        Destroy(this.gameObject);
    }
}
