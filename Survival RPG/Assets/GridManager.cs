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

    private void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid(){
        Node[,] tempMap = new Node[width, height];

        for(int x = 0; x < width; x++){
            for(int y = 0; y < height; y++){
                var spawnedTile = Instantiate(tilePrefab, new Vector3(x,y), Quaternion.identity, gameObject.transform);
                spawnedTile.name = $"Tile {x} {y}";

                //Keep an array of tiles in the current map.

                var isOffset = (x + y) % 2 == 1;
                spawnedTile.Init(isOffset);

                tempMap[x,y] = spawnedTile.gameObject.AddComponent<Node>();
            }
        }

        setNodes(tempMap);
    }

    //Check if array is in bound
    private bool inBounds (int index, int length) 
    {
        return (index >= 0) && (index < length);
    }

    public void setNodes(Node[,] tempMap)
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if(!tempMap[x,y].GetComponent<Tile>().isEnabled) { continue; }
                
                tempMap[x, y].right = inBounds(x + 1, width) ? tempMap[x + 1, y] : null;
                tempMap[x, y].left = inBounds(x - 1, width) ? tempMap[x - 1, y] : null;
                tempMap[x, y].up = inBounds(y + 1, height) ? tempMap[x, y + 1] : null;
                tempMap[x, y].down = inBounds(y - 1, height) ? tempMap[x, y - 1] : null;
            }
        }
    }
}