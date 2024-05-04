using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TerminalManager : MonoBehaviour
{
    [SerializeField] RPGManager rpgManager;
    [SerializeField] GameObject playerInput;
    [SerializeField] GameObject terminalLine;
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private List<string> termsList;
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

    public void TerminalCommand(string userInput){
        if(inputField.wasCanceled){
            return;
        }
        if(termsList.Contains(userInput)){
            if(userInput.Contains("rv")){
                rpgManager.RevealLevel();
            }
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
