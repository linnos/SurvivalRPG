using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    //Position of node
    public float x;
    public float y;
    //F value of tile for use in A* algorithm
    public float fValue = 0;
    public float gValue = 0;
    public float hValue = 0;

    //Nodes directly touching this node
    public List<Node> neighbors = new List<Node>();

    public Node parent;
    
    public void OnEnable()
    {
        // x = gameObject.transform.position.x;
        // y = gameObject.transform.position.y;
    }

    public void setGValue(float num){
        gValue = num;
        fValue = gValue + hValue;
    }

    public void setHValue(float num){
        hValue = num;
        fValue = gValue + hValue;
    }
}
