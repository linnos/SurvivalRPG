using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PathFinding : MonoBehaviour
{
    // A* (star) Pathfinding
    // Initialize both open and closed list
    // let the openList equal empty list of nodes
    [SerializeReference]
    List<Node> openList = new List<Node>();
    // let the closedList equal empty list of nodes
    List<Node> closedList = new List<Node>();

    public Node[,] map;

    public Node findPath(Node startNode, Node targetNode){
        
        // Add the start node
        // put the startNode on the openList (leave it's f at zero)
        startNode.parent = null;
        openList.Add(startNode);

        Node curNode = startNode;

        while (openList.Count != 0)
        {
            //current node is the node in openList with the lowest F cost
            
            foreach (Node node in openList)
            {
                if(curNode.fValue <= node.fValue){
                    curNode = node;
                }
            }

            //Remove current node from open list. Add it to closed list
            openList.Remove(curNode);
            closedList.Add(curNode);
            
            //If the target is found, stop the loop. Return node
            if(curNode.Equals(targetNode)){
                while(curNode.parent != null){
                    Debug.Log("tiles: " + curNode.parent.x + ", " + curNode.parent.y );
                    curNode = curNode.parent;
                }
                return curNode;
            }

            foreach (Node node in curNode.neighbors)
            {
                if(closedList.Contains(node)){
                    continue;
                }

                if(!openList.Contains(node)){
                    node.setGValue(curNode.gValue + 10);
                    node.setHValue(getHValue(node, targetNode));

                    node.parent = curNode;

                    if(!openList.Contains(node)){ openList.Add(node); }                    
                }
            }

        }

        return null;
    }
    
    //HELPER FUNCTIONS

    //gets the Manhattan distance to use as H value for the node
    private float getHValue(Node curNode, Node targetNode){
        return Math.Abs (curNode.x - targetNode.x) + Math.Abs (curNode.y - targetNode.y);
    }
}
