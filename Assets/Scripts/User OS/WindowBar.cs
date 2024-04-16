using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WindowBar : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;
    private Vector2 newPosition;
    private Transform selectedObj;
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        selectedObj = eventData.pointerDrag.GetComponent<Transform>().parent;
        Debug.Log(selectedObj.name);
    }

    public void OnDrag(PointerEventData eventData)
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle((RectTransform)canvas.transform,eventData.position,canvas.worldCamera, out newPosition);
        selectedObj.position = canvas.transform.TransformPoint(newPosition);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }
}
