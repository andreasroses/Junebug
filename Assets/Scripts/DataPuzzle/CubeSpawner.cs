using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> cubePrefabs;
    [SerializeField] private int totalToSort;

    [SerializeField] private float spawnX = 0f;
    [SerializeField] private float spawnY = 0f;
    [SerializeField] private float spawnZ = 0f;
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
            Vector3 spawnPosition = new Vector3(spawnX,spawnY,spawnZ);
            GameObject newCube = Instantiate(cubePrefabs[index],spawnPosition, Quaternion.identity);
            currCube = newCube.GetComponent<InspectItem>();
        }
        if(numSorted == totalToSort){
            //screenFader.FadeToColor("UserOSScene");
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
