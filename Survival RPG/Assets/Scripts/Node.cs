using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    //Position of node
    public float x;
    public float y;
    //F value of tile for use in A* algorithm
    public float fValue { get; set; } = 0;
    public Node left;
    public Node right;
    public Node up;
    public Node down;

    private void Start()
    {
        x = gameObject.transform.position.x;
        y = gameObject.transform.position.y;
    }
}
