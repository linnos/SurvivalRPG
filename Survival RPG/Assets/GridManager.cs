using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    //Width and height of the map
    [SerializeField]
    private int width, height;
    //What tile prefab to use for the map
    [SerializeField]
    private Tile tilePrefab;

    //TEST VARIABLES DELETE LATER
    public int x,xx, y,yy;
    public bool search = false;
    public PathFinding findPath;
    Node[,] mapNodes;

    private void Start()
    {
        GenerateGrid();
    }

    private void Update()
    {
        if(search){
            search = false;
            findPath.findPath(mapNodes[x,y], mapNodes[xx,yy]);

        }
    }

    void GenerateGrid(){
        mapNodes = new Node[width, height];

        for(int x = 0; x < width; x++){
            for(int y = 0; y < height; y++){
                var spawnedTile = Instantiate(tilePrefab, new Vector3(x,y), Quaternion.identity, gameObject.transform);
                spawnedTile.name = $"Tile {x} {y}";

                var isOffset = (x + y) % 2 == 1;
                spawnedTile.Init(isOffset);

                mapNodes[x,y] = new Node();
                mapNodes[x,y].x = x;
                mapNodes[x,y].y = y;
            }
        }

        setNodes(mapNodes);
    }

    //Check if array is in bound
    private bool inBounds (int index, int length) 
    {
        return (index >= 0) && (index < length);
    }

    //Sets the left,right,up,down nodes for reference.
    public void setNodes(Node[,] mapNodes)
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                // if(!mapNodes[x,y].GetComponent<Tile>().isEnabled) { continue; }
                
                if(inBounds(x + 1, width)) { mapNodes[x, y].neighbors.Add(mapNodes[x + 1, y]); }
                if(inBounds(x - 1, width)) { mapNodes[x, y].neighbors.Add(mapNodes[x - 1, y]); }
                if(inBounds(y + 1, height)) { mapNodes[x, y].neighbors.Add(mapNodes[x, y + 1]); }
                if(inBounds(y - 1, height)) { mapNodes[x, y].neighbors.Add(mapNodes[x, y - 1]); }


                // mapNodes[x, y].right = inBounds(x + 1, width) ? mapNodes[x + 1, y] : null;
                // mapNodes[x, y].left = inBounds(x - 1, width) ? mapNodes[x - 1, y] : null;
                // mapNodes[x, y].up = inBounds(y + 1, height) ? mapNodes[x, y + 1] : null;
                // mapNodes[x, y].down = inBounds(y - 1, height) ? mapNodes[x, y - 1] : null;
            }
        }
    }
}