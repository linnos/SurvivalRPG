using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    //F value of tile for use in A* algorithm
    public float fValue { get; set; } = 0;
    public Node next;
    public Node left;
    public Node right;
    public Node up;
    public Node down;
}
