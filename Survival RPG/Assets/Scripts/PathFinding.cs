using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PathFinding
{
    // A* (star) Pathfinding
    // Initialize both open and closed list
    // let the openList equal empty list of nodes
    List<Node> openList;
    // let the closedList equal empty list of nodes
    List<Node> closedList;

    public Node findPath(Node startNode, Node targetNode){
        openList = new List<Node>();
        // let the closedList equal empty list of nodes
        closedList = new List<Node>();
        // Add the start node
        // put the startNode on the openList (leave it's f at zero)
        startNode.parent = null;
        openList.Add(startNode);

        while (openList.Count != 0)
        {
            //current node is the node in openList with the lowest F cost
            Node curNode = null;
            foreach (Node node in openList)
            {
                if(curNode == null) { curNode = node; continue; }
                if(node.fValue < curNode.fValue){
                    curNode = node;
                }
                else if(node.fValue == curNode.fValue){
                    curNode = node.hValue < curNode.hValue ? node : curNode;
                }
            }

            //Remove current node from open list. Add it to closed list
            openList.Remove(curNode);
            closedList.Add(curNode);
            
            //If the target is found, stop the loop. Return node
            if(curNode.Equals(targetNode)){
                while(curNode.parent != null){
                    Debug.Log("Found path: " + curNode.x + ", " + curNode.y );
                    curNode = curNode.parent;
                }
                Debug.Log("Found path: " + curNode.x + ", " + curNode.y );
                return curNode;
            }

            Debug.Log($"CurNode: {curNode.x},{curNode.y}. FValue: {curNode.fValue}");

            foreach (Node node in curNode.neighbors)
            {
                if(closedList.Contains(node) || !node.isEnabled){
                    continue;
                }

                if(!openList.Contains(node)){
                    node.setGValue(curNode.gValue + 10);
                    node.setHValue(getHValue(node, targetNode));

                    node.parent = curNode;

                    if(!openList.Contains(node)){ openList.Add(node); }     
                    Debug.Log($"    Child Node: {node.x},{node.y}. FValue: {node.fValue}");               
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
