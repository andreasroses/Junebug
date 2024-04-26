using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChatboxManager : MonoBehaviour
{
    [SerializeField] private GameObject playerMsg;
    [SerializeField] private GameObject friendMsg;
    [SerializeField] private RectTransform MsgBox;
    [SerializeField] private Scrollbar scroll;
    public void SpawnNewPlayerMessage(){
        GameObject newMsg = Instantiate(playerMsg,Vector3.zero,Quaternion.identity);
        newMsg.transform.SetParent(MsgBox,false);
        scroll.value = 0f;
    }

    public void SpawnNewFriendMessage(){
        GameObject newMsg = Instantiate(friendMsg,Vector3.zero,Quaternion.identity);
        newMsg.transform.SetParent(MsgBox,false);
        scroll.value = 0f;
    }
}
