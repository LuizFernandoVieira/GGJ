using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
    
    public Transform[] spawnLocations;
    
    public GameObject[] prefabs;
    
	// Use this for initialization
	void Start () {
        Invoke("CreateZombie", 1);
	}
	
	// Update is called once per frame
	void Update () {
	}
    
    void CreateZombie() {
        GameObject clone = Instantiate(prefabs[0], spawnLocations[0].position, Quaternion.identity) as GameObject;
    }
}
