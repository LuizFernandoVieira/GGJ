using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Level : MonoBehaviour {
    
    private GameObject player;
    
    public GameObject fireTotem;
    public GameObject waterTotem;
    public GameObject earthTotem;
    public GameObject airTotem;
    
    public GameObject zombie;
    
    // List<GameObject> fireTotems     = new List<GameObject>();
    // List<GameObject> waterTotems    = new List<GameObject>();
    // List<GameObject> earthTotems    = new List<GameObject>();
    // List<GameObject> airTotems      = new List<GameObject>();
    
    List<GameObject> zombies        = new List<GameObject>();
    
    public void Awake()
    {
        player = GameObject.Find("Player");
    }

	public void Start () 
    {
	}
	
	public void Update () 
    {
	}
    
    public void AddFireTotem()
    {
        if (player != null)
        {
            GameObject clone = Instantiate (fireTotem, player.transform.position, Quaternion.identity) as GameObject;
            GameObject.Destroy(clone, 5);     
        }
    }
    
    public void AddWaterTotem()
    {
        if (player != null)
        {
            GameObject clone = Instantiate (waterTotem, player.transform.position, Quaternion.identity) as GameObject;
            GameObject.Destroy(clone, 5);
        }
    }
    
    public void AddEarthTotem()
    {
        if (player != null)
        {        
            GameObject clone = Instantiate (earthTotem, player.transform.position, Quaternion.identity) as GameObject;
            GameObject.Destroy(clone, 5);
        } 
    }
    
    public void AddAirTotem()
    {
        if (player != null)
        {        
            GameObject clone = Instantiate (airTotem, player.transform.position, Quaternion.identity) as GameObject;
            GameObject.Destroy(clone, 5);
        }
    }
    
}
