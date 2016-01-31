using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
    
    public GameObject[] enemies;
    public Transform[] enemiesSpawnLocations;
    
    public GameObject saplin;
    
    public Transform[] saplinSpawnLocations;
    private GameObject saplinClone;
   
	void Start () {
        Invoke("CreateZombie", 1);
        InitSaplin();
        InvokeRepeating("ChangeSaplinPosition", 3, 20);
	}
    
    void CreateZombie() 
    {
        GameObject clone = Instantiate(enemies[0], enemiesSpawnLocations[0].position, Quaternion.identity) as GameObject;
    }
    
    void InitSaplin()
    {   
        saplinClone = Instantiate(saplin, saplinSpawnLocations[0].position, Quaternion.identity) as GameObject;
    }
    
    void ChangeSaplinPosition()
    {
        for (int i = 0; i < saplinSpawnLocations.Length; i++)
        {            
            if(saplinClone.transform.position == saplinSpawnLocations[i].position)
            {
                int n = ++i;
                if(i < saplinSpawnLocations.Length)
                {
                    saplinClone.transform.position = saplinSpawnLocations[n].position;
                }
                else
                {
                    saplinClone.transform.position = saplinSpawnLocations[0].position;
                }
            }
        }
    }
}