using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gridBehavior : MonoBehaviour {
    //Gets all grid game Objects
    public Hashtable playGrid = new Hashtable();
    //Defines how high the character float above the square.
    public float charHover = 0.7f;
    public float rayOffset = 0.5f;
    public float rayDistance = 1f;
    //Adjusts raycasts starting position for grid.
    public float raySkew = 0.1f;
    
    //Accounts for rectangular shape of player and adjusts bottom raycast
    public float bottomOffSet = 2.5f;

	// Use this for initialization
	void Start () {
        playGrid.Add("x1", GameObject.Find("x1"));
        playGrid.Add("x2", GameObject.Find("x2"));
        playGrid.Add("x3", GameObject.Find("x3"));
        playGrid.Add("x4", GameObject.Find("x4"));
        playGrid.Add("y1", GameObject.Find("y1"));
        playGrid.Add("y2", GameObject.Find("y2"));
        playGrid.Add("y3", GameObject.Find("y3"));
        playGrid.Add("y4", GameObject.Find("y4"));
        playGrid.Add("z1", GameObject.Find("z1"));
        playGrid.Add("z2", GameObject.Find("z2"));
        playGrid.Add("z3", GameObject.Find("z3"));
        playGrid.Add("z4", GameObject.Find("z4"));
        playGrid.Add("a1", GameObject.Find("a1"));
        playGrid.Add("a2", GameObject.Find("a2"));
        playGrid.Add("a3", GameObject.Find("a3"));
        playGrid.Add("a4", GameObject.Find("a4"));
        //Playgrid Hashtable 4x4


 
    }
	
	// Update is called once per frame
	void Update () {
        //Ray Directions
        Vector2 directionX = new Vector2(rayDistance, 0);
        Vector2 directionY = new Vector2(0, rayDistance);


        //Get Input for Grid Movement
        showRayCast(directionX, directionY);
        if (Input.GetKeyDown(KeyCode.RightArrow)|| Input.GetKeyDown(KeyCode.LeftArrow)|| Input.GetKeyDown(KeyCode.UpArrow)|| Input.GetKeyDown(KeyCode.DownArrow))
        {
            print("Direction key presed. Starting Collider check");
            RaycastHit2D hit = checkCollide(directionX, directionY);
            if (hit.collider)
            {
                Debug.Log(hit.collider.name);
                GameObject collidedObject = hit.collider.gameObject;
                SpriteRenderer color = collidedObject.GetComponent<SpriteRenderer>();
                color.color = Color.red;
                this.transform.position = new Vector3(collidedObject.transform.position.x, collidedObject.transform.position.y+charHover, this.transform.position.z);
                
            }

        }

    }

    private void OnMouseDown()
    {
        GameObject testObj = (GameObject)playGrid["y2"];
       //foreach (Transform child in testObj.transform)
       // {
       //     Debug.Log(child);
       // }
        GameObject center = testObj.transform.GetChild(4).gameObject;
        Debug.Log("obj pos: " + testObj.transform.position);
        Debug.Log("player pos: " + this.transform.position);
        this.transform.position = new Vector3(center.transform.position.x, center.transform.position.y+charHover,this.transform.position.z);
        Debug.Log("obj pos: " + testObj.transform.position);
        Debug.Log("player pos: " + this.transform.position);
    }
    private RaycastHit2D checkCollide(Vector2 directionX,Vector2 directionY)
    {
        Vector2 startingxRight = new Vector2(transform.position.x +rayOffset, transform.position.y - raySkew);
        Vector2 startingxLeft = new Vector2(transform.position.x -rayOffset, transform.position.y- raySkew);
        Vector2 startingyUp = new Vector2(transform.position.x, transform.position.y + rayOffset);
        Vector2 startingYdown = new Vector2(transform.position.x, transform.position.y - rayOffset * 2.5f);

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            return Physics2D.Raycast(startingxRight, directionX, rayDistance);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            return Physics2D.Raycast(startingxLeft, -directionX, rayDistance);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            return Physics2D.Raycast(startingyUp, directionY, rayDistance);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            return Physics2D.Raycast(startingYdown, -directionY, rayDistance);
        }


        return Physics2D.Raycast(startingxRight, directionX, 0);
    }
    private void showRayCast(Vector2 directionX, Vector2 directionY)
    {
        Vector2 startingxRight = new Vector2(transform.position.x + rayOffset, transform.position.y - raySkew);
        Vector2 startingxLeft = new Vector2(transform.position.x - rayOffset, transform.position.y - raySkew);
        Vector2 startingyUp = new Vector2(transform.position.x, transform.position.y + rayOffset);
        Vector2 startingYdown = new Vector2(transform.position.x, transform.position.y - rayOffset * 2.5f);
        Debug.DrawRay(startingxRight, directionX, Color.red);
        Debug.DrawRay(startingxLeft, -directionX, Color.red);
        Debug.DrawRay(startingyUp, directionY, Color.red);
        Debug.DrawRay(startingYdown, -directionY, Color.red);
        
    }
}
