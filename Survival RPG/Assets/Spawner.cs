using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{

    public GameObject prefab;
    [Range(1,10)]
    public int spawnNumber;
    [Range(1,10)]
    public float spacer;
    [Range(1,100)]
    public int multiplicator;
    private int curNum;

    // Start is called before the first frame update
    void Start()
    {
        curNum = spawnNumber;
        SpawnPrefabs();
    }

    // Update is called once per frame
    void Update()
    {
        if(curNum != spawnNumber){
            curNum = spawnNumber;
            SpawnPrefabs();
        }
    }

    public void SpawnPrefabs(){

        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        for(int i = 0; i < spawnNumber; i++){
            var curObject = Instantiate(prefab, new Vector3( transform.position.x + ( i * 2.0f * multiplicator), transform.position.y, 0), Quaternion.identity, gameObject.transform);
        }
    }
}
