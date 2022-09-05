using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    //Position of node
    public float x;
    public float y;
    //F value of tile for use in A* algorithm
    public float fValue = 0;
    public float gValue = 0;
    public float hValue = 0;

    //Nodes directly touching this node
    public Node left;
    public Node right;
    public Node up;
    public Node down;
    
    void start()
    {
        x = gameObject.transform.position.x;
        y = gameObject.transform.position.y;
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
