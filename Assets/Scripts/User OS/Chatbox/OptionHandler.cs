using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class OptionHandler : MonoBehaviour
{
    public void ChooseOption(){
        ChatboxManager.singleton.PlayerReply();
    }
}
