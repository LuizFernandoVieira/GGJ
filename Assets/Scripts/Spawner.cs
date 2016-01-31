using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
    
    public GameObject[] enemies;
    public Transform[] enemiesSpawnLocations;
    public Transform[] saplinSpawnLocations;
    private GameObject saplinClone;
    
    public GameObject saplin;
    
    private int spawnIndex = 0;
    
    private float spawnTimer = 3f;
    
    private float currentTimer = 0f;
    
    private int spawnCounter = 0;
    
    private int spawnChangeTime = 10;
    
    private float spawnTimerOffset = 0.5f;
	
	void Start () {
        Invoke("CreateZombie", 1);
        InitSaplin();
        InvokeRepeating("ChangeSaplinPosition", 3, 20);
	}
    
	// Update is called once per frame
	void Update () {
        currentTimer += Time.deltaTime;
        
        if (currentTimer >= spawnTimer) {
            
            if (spawnCounter > spawnChangeTime) {
                spawnTimer -= spawnTimerOffset;
                spawnCounter = 0;
            }
            
            currentTimer = 0;
            
            Random.seed = (int) System.Environment.TickCount;
            
            spawnIndex = Random.Range(0, 5);
            
            CreateZombie(spawnIndex);
            
            spawnCounter++;
        }
	}
    
    void CreateZombie(int index) {
        GameObject clone = Instantiate(enemies[0], enemiesSpawnLocations[index].position, Quaternion.identity) as GameObject;
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
