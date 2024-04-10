using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndCheckpoint : MonoBehaviour
{
    [SerializeField] private GameObject rpgWindow;

    void OnTriggerEnter2D(Collider2D other){
        Destroy(rpgWindow);
    }
}
