using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour {

    //Type of mask
    public LayerMask unwalkableMask;

    //The size of the Grid
    public Vector2 gridWorldSize;

    //Radius of the node
    public float nodeRadius;


    //Created a two dimensional grid 
    //Uses the Node class and it is declared with name called "grid"
    Node[,] grid;

    // Diameter of the node
    float nodeDiameter;

    //Size of the X and Y values
    int gridSizeX, gridSizeY;


    void Start()
    {
        nodeDiameter = nodeRadius * 2; // Node radius is being set to the diameter
        gridSizeX = Mathf.RoundToInt(gridWorldSize.x / nodeDiameter);
        gridSizeY = Mathf.RoundToInt(gridWorldSize.y / nodeDiameter);

        //Call the Create grid method
        CreateGrid();
           

    }



    //Function to generate the Grid
    void CreateGrid()
    {
       
        grid = new Node[gridSizeX, gridSizeY];

        //For loop to generate the grid
        //Generate the X rows
        for (int x = 0; x < gridSizeX; x++)
        {
            // Bottom left corner
            Vector3 worldBottomLeft = transform.position - Vector3.right * gridWorldSize.x / 2 - Vector3.up * gridWorldSize.y/2;
            
            //Generate the Y Cols
            for (int y = 0; y < gridSizeY; y++)
            {
                //
                Vector3 worldPoint = worldBottomLeft + Vector3.forward * (x * nodeDiameter + nodeRadius) + Vector3.forward * (y * nodeDiameter + nodeRadius);
                
                //Collision Check
                bool walkable = !(Physics.CheckSphere)
            }
        }
          


    }

    //Function for creating the Gizmo 
    void OnDrawGizmos()
    {
        //Creating the wire cube which uses X and y
        Gizmos.DrawWireCube(transform.position, new Vector3(gridWorldSize.x, 1, gridWorldSize.y));

    }



}
