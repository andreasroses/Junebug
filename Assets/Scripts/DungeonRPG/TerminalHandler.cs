using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TerminalHandler : MonoBehaviour
{
    [SerializeField] GameObject playerInput;
    [SerializeField] GameObject terminalLine;
    private TMP_InputField terminalInput;
    private bool toggleTerminal = false;


    void Awake(){
        terminalInput = terminalLine.GetComponent<TMP_InputField>();
    }
    void Update(){
        if(Input.GetKeyDown(KeyCode.Slash)){
            EnterTerminal();
        }
    }
    public void EnterTerminal(){
        toggleTerminal = !toggleTerminal;
        terminalLine.SetActive(toggleTerminal);
        if(toggleTerminal == true){
            terminalInput.Select();
            terminalInput.text = "";
        }
        playerInput.SetActive(!toggleTerminal);
    }
}
