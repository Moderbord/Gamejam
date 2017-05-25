using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    public Transform[] spawnLocations;
    public GameObject[] entities;
    public GameObject[] entityClone;

    public void SpawnEntity(int player, int entityID)
    {
        int random = Random.Range(0, spawnLocations.Length);
        entityClone[entityID] = Instantiate(entities[entityID], spawnLocations[random].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
        entityClone[entityID].GetComponent<PlayerMovement>().SetControlledByPLayer(player);
        entityClone[entityID].GetComponent<Entity>().SetControlledByPlayer(player);
    }

    public void SpawnEntity(int player, int ID, int spawnlocation)
    {
        entityClone[ID] = Instantiate(entities[ID], spawnLocations[spawnlocation].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
        entityClone[ID].GetComponent<PlayerMovement>().SetControlledByPLayer(player);
        entityClone[ID].GetComponent<Entity>().SetControlledByPlayer(player);
    }

}
