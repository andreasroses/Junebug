using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TerminalManager : MonoBehaviour
{
    [SerializeField] GameDataManager gm;
    [SerializeField] RPGManager rpgManager;
    [SerializeField] GameObject playerInput;
    [SerializeField] GameObject terminalLine;
    [SerializeField] List<string> dataSorts;
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private List<string> termsList;
    private TMP_InputField terminalInput;
    private bool toggleTerminal = false;
    private bool frozeControls = false;
    void OnEnable(){
        rpgManager.LoadLevel();
    }
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
            if(userInput.Contains("catburglar")){
                UserManager.singleton.LoadDataSortWindow();
                UserManager.singleton.LoadBrowserWindow();
                BrowserManager tmpLoader = GameObject.FindGameObjectWithTag("BrowserWindow").GetComponent<BrowserManager>();
                tmpLoader.BrowserSearch(dataSorts[Random.Range(0,2)]);
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

    public void FreezeRPG(){
        playerInput.SetActive(false);
        frozeControls = true;
    }

    public void UnfreezeRPG(){
        if(frozeControls){
            playerInput.SetActive(true);
            frozeControls = false;
        }
        
    }
}
