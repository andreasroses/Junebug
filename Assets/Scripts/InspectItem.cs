using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

[System.Serializable]
public class StoryEvent : UnityEvent {}
public class InspectItem : MonoBehaviour
{
    public StoryEvent InfoTrackingEvent;
    private bool isSafe;
    private char matColor;
    private Transform itemTransform;

    private Vector3 startPosition;
    private Vector3 startRotation;
    void Start()
    {
        var tmp = GetComponent<MeshRenderer>().material.name;
        matColor = tmp[0];
        itemTransform = GetComponent<Transform>();
        switch(matColor){
            case 'r':
                isSafe = false;
                break;
            case 'g':
                isSafe = true;
                break;
            default:
                isSafe = true;
                break;
        }
        
    }

    void OnMouseDown()
    {
        startPosition = Input.mousePosition;
        startRotation = itemTransform.eulerAngles;
        //OnSelect.Invoke(isSafe);
    }

    void OnMouseDrag()
    {
        Vector3 currentPosition = Input.mousePosition;
        Vector3 direction = currentPosition - startPosition;

        float rotationAmountX = -direction.y * 0.5f; // Adjust the rotation speed as needed
        float rotationAmountY = direction.x * 0.5f;

        itemTransform.eulerAngles = startRotation + new Vector3(-rotationAmountX, -rotationAmountY, 0f);
    }

    public void Keep(){
        if(isSafe){
            //update story progress tracker w/ good result
            InfoTrackingEvent.Invoke();
        }
        //update story progress tracker w/ bad result
        Destroy(this.gameObject);
    }

    public void Toss(){
        if(!isSafe){
            //update story progress tracker w/ good result
            InfoTrackingEvent.Invoke();
        }
        //update story progress tracker w/ bad result
        Destroy(this.gameObject);
    }
}
