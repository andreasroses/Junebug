using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> cubePrefabs;
    [SerializeField] private int totalToSort;

    [SerializeField] private Transform puzzleWindow;
    [SerializeField] private GameObject cubeWindow;
    [SerializeField] private float waitTime;

    [SerializeField] private ScreenFader screenFader;

    private InspectItem currCube;
    private int numSorted = -1;

    void Start(){
        SpawnCubesRandom();
    }
    // void SpawnCubes(){
    //     StartCoroutine(SpawnCubesRoutine());
    //     IEnumerator SpawnCubesRoutine(){
    //         while(true){
    //             SpawnCubesRandom();
    //             yield return new WaitForSeconds(waitTime);
    //         }
    //     }
    // }

    public void SpawnCubesRandom(){
        numSorted++;
        if(numSorted < totalToSort){
            int index = Random.Range(0,2);
            GameObject newCube = Instantiate(cubePrefabs[index],puzzleWindow.position, Quaternion.identity);
            currCube = newCube.GetComponent<InspectItem>();
            currCube.transform.parent = puzzleWindow;
        }
        if(numSorted == totalToSort){
            Destroy(cubeWindow);
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
}
