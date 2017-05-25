using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node {

	//Boolean for what is walkable
	public bool walkable;

	//The nodes world position
	public Vector3 worldPosition;

    //Declaring the node Constructor
    public Node(bool _walkable, Vector3 _worldPos)
    {
        walkable = _walkable;
        worldPosition = _worldPos;

    }
    


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
