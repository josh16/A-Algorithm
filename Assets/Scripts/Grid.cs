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
        gridSizeX = Mathf.RoundToInt(gridWorldSize.x/nodeDiameter);
        gridSizeY = Mathf.RoundToInt(gridWorldSize.y/nodeDiameter);

        //Call the Create grid method
        CreateGrid();
           

    }



    //Function to generate the Grid
    void CreateGrid()
    {
       grid = new Node[gridSizeX, gridSizeY];
        
        Vector3 worldBottomLeft = transform.position - Vector3.right * gridWorldSize.x/2 - Vector3.forward * gridWorldSize.y/2;

        //For loop to generate the grid
        //Generate the X rows
        for (int x = 0; x < gridSizeX; x++)
        {
            //Generate the Y Cols
            for (int y = 0; y < gridSizeY; y++)
            {
                //
                Vector3 worldPoint = worldBottomLeft + Vector3.right * (x * nodeDiameter + nodeRadius) + Vector3.forward * (y * nodeDiameter + nodeRadius);

                //Collision Check
                bool walkable = !(Physics.CheckSphere(worldPoint, nodeRadius,unwalkableMask));

                //Create a new node(Populate the grid with nodes)
                grid[x, y] = new Node(walkable, worldPoint);
            }
        }
          


    }

    //Function for creating the Gizmo 
    void OnDrawGizmos()
    {
        //Creating the wire cube which uses X and Y
        Gizmos.DrawWireCube(transform.position, new Vector3(gridWorldSize.x, 1, gridWorldSize.y));

      

        //
        if(grid != null)
        {
            foreach(Node n in grid)
            {
                //Setting the Gizmos colour. White: main colour, collison: Red colour
                Gizmos.color = (n.walkable) ? Color.white : Color.red;
              Gizmos.DrawCube(n.worldPosition, Vector3.one * (nodeDiameter -.1f));
            }
        }
    }



}
