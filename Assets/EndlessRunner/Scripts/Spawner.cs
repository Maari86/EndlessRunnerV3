using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<GameObject> objectsToSpawn = new List<GameObject>();
    public bool isTimer;
    public float timeToSpawn;
    private float currentTimeToSpawn;
    public bool isRandomized;
    // Start is called before the first frame update
    void Start()
    {
        currentTimeToSpawn = timeToSpawn;
    }

    // Update is called once per frame
   // void Update()
   // {
   //     if(currentTimeToSpawn > 0)
   //     {
   //         currentTimeToSpawn -= Time.deltaTime;
   //     }
   //     else
   //     {
   //         SpawnObject();
   //         currentTimeToSpawn = timeToSpawn;
//
   //     }
  //  }
//
    public void SpawnObject()
    {

        int index = isRandomized ? Random.Range(0, objectsToSpawn.Count) : 0;
        if(objectsToSpawn.Count > 0)
        {
            Instantiate(objectsToSpawn[index], transform.position, transform.rotation);
        }
        
    }
}
