using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

    [SerializeField] private GameObject fighterPrefab;
    [SerializeField] private Vector2 startPos1 = new Vector2(-5.0f, -3.0f);
    [SerializeField] private Vector2 startPos2 = new Vector2(5.0f, -3.0f);

    private GameObject player1, player2;

    // Use this for initialization
    void Start () {
        spawnFighters();
	}

    void spawnFighters() {
        player1 = Instantiate(fighterPrefab, startPos1, Quaternion.identity);
        player2 = Instantiate(fighterPrefab, startPos2, Quaternion.identity);
    }
  
}
