using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
    
    public GameObject[] enemies;
    public Transform[] enemiesSpawnLocations;
    public Transform[] saplinSpawnLocations;
    private GameObject saplinClone;
    
    public GameObject saplin;
    
    private float spawnTimer = 10f;
    
    private float currentTimer = 0f;
    
    private int spawnChangeTime = 10;
    
    private int enemyCounter = 0;
    
	void Start () {
        Invoke("CreateZombie", 1);
        InitSaplin();
        InvokeRepeating("ChangeSaplinPosition", 3, 20);
	}
    
	// Update is called once per frame
	void Update () {
        currentTimer += Time.deltaTime;
        
        if (currentTimer >= spawnTimer) {
            
            currentTimer = 0;
            
            Random.seed = (int) System.Environment.TickCount;
            
            int spawnIndex = Random.Range(0, 5);
            
            int enemyIndex = Random.Range(0, 3);
            
            Debug.Log("enemy: " + enemyIndex);
            
            CreateEnemy(spawnIndex, enemyIndex);
        }
	}
    
    void CreateEnemy(int spawn, int enemy) {
        GameObject clone = Instantiate(enemies[enemy], enemiesSpawnLocations[spawn].position, Quaternion.identity) as GameObject;
        enemyCounter++;
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
