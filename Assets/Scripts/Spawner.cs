using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    public Transform[] spawnLocations;
    public GameObject[] entities;
    public GameObject[] entityClone;

    public void spawnEntity(int ID)
    {
        int random = Random.Range(0, 5);
        entityClone[ID] = Instantiate(entities[ID], spawnLocations[random].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
    }

}
