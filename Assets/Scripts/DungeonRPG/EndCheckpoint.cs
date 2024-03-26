using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndCheckpoint : MonoBehaviour
{
    [SerializeField] ScreenFader screenFader;

    void OnTriggerEnter2D(Collider2D other){
        screenFader.FadeToColor("UserOSScene");
    }
}
