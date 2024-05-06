using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountdownTimer : MonoBehaviour
{
    [SerializeField] public float remainingTime;
    [SerializeField] private TextMeshProUGUI timerTxt;
    [SerializeField]StoryEvent timerRanOut;
    void Update(){
        remainingTime -= Time.deltaTime;
        int minutes = Mathf.FloorToInt(remainingTime/60);
        int seconds = Mathf.FloorToInt(remainingTime%60);
        timerTxt.text = string.Format("{0:00}:{1:00}",minutes,seconds);

        if(remainingTime<=0){
            timerRanOut.Invoke();
        }
    }


}
