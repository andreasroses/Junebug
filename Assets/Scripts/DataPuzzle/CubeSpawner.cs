using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] GameDataManager gm;
    [SerializeField] private List<GameObject> packets;
    [SerializeField] private int totalToSort;
    [SerializeField] private GameObject cubeWindow;
    
    [SerializeField] private float waitTime;
    [SerializeField] private ScreenFader screenFader;
    private List<GameObject> packetsLoaded = new();

    private InspectItem currCube;
    private int numSorted = -1;

    void OnEnable(){
        if(packetsLoaded.Any()){
            foreach(GameObject obj in packetsLoaded){
                Destroy(obj);
            }
        }
        SpawnCubesRandom();
    }
    void OnDisable(){
        Destroy(currCube);
    }
    public void SpawnCubesRandom(){
        numSorted++;
        Destroy(currCube);
        if(numSorted < totalToSort){
            int index = Random.Range(0,packets.Count);
            GameObject newCube = Instantiate(packets[index],cubeWindow.transform);
            packetsLoaded.Add(newCube);
            currCube = newCube.GetComponent<InspectItem>();
            currCube.transform.localPosition = new Vector3(0, currCube.transform.localPosition.y, -1);
        }
        if(numSorted == totalToSort){
            UserManager.singleton.DataSortResults(true);
            gm.DataSortDone();
            transform.parent.parent.gameObject.SetActive(false);
        }
    }

    public void MarkedSafe(){
        currCube.Keep();
        SpawnCubesRandom();
    }

    public void MarkedUnsafe(){
        currCube.Toss();
        SpawnCubesRandom();
    }

    public void TimerRanOut(){
        gm.TimerPenalty();
        numSorted = 0;
        UserManager.singleton.DataSortResults(false);
        transform.parent.parent.gameObject.SetActive(false);
    }
}
