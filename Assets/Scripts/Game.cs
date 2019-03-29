using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {
    public static string fighter1 = "Prefabs/GenericFighter", fighter2 = "Prefabs/GenericFighter";
    public GameObject player1, player2;
    public Vector2 startPos1 = new Vector2(-10.0f, -3.0f);
    public Vector2 startPos2 = new Vector2(10.0f, -3.0f);

    // Use this for initialization
    void Start () {
        spawnFighters();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void spawnFighters() {
        player1 = (GameObject)Instantiate(Resources.Load(fighter1, typeof(GameObject)), startPos1, Quaternion.identity);
        //player2 = (GameObject)Instantiate(Resources.Load(fighter2, typeof(GameObject)), startPos2, Quaternion.identity);
    }

  
}
