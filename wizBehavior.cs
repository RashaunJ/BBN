using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wizBehavior : MonoBehaviour {

    public int health;
    public int trackHealth;
    GameObject enemy;
    GameObject[] tiles;
    public int globalTimer;
    private int cooldown;

	// Use this for initialization
	void Start () {
        health = 10;
        trackHealth = 10;
        enemy = this.gameObject;
        tiles = GameObject.FindGameObjectsWithTag("enemyMovable");

        //Frame timer before an action can be done;
        globalTimer = 12;

        cooldown = globalTimer;
        
	}

    // Update is called once per frame
    void Update()
    {
        

    }

    private void FixedUpdate()
    {
        

        if (cooldown == 0)
        {
            randomMove();
            cooldown = globalTimer;
        }
        else
        {
            cooldown -= 1;
        }
        
    }

    private void randomMove()
    {
        
        int rand = Random.Range(0,tiles.Length);
        Transform tileTransform = tiles[rand].gameObject.transform;
        enemy.transform.position = new Vector3(tileTransform.position.x, tileTransform.position.y, enemy.transform.position.z);

    }
}

