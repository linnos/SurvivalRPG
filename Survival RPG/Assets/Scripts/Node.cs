using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    private int x;
    private int y;
    private float fValue = 0;
    private float gValue = 0;
    private float hValue = 0;
    private bool isEnabled = true;

    public int X { get => x; }
    public int Y { get => y; }
    public float FValue { get => fValue; }
    public float GValue { get => gValue; }
    public float HValue { get => hValue; }
    public bool IsEnabled { get => isEnabled; }

    public List<Node> neighbors = new List<Node>();
    public Node parent;

    public Node(int x, int y, bool isEnabled = true)
    {
        this.x = x;
        this.y = y;
        this.isEnabled = isEnabled;
    }

    public void setGValue(float num)
    {
        gValue = num;
        fValue = gValue + hValue;
    }

    public void setHValue(float num)
    {
        hValue = num;
        fValue = gValue + hValue;
    }

    public void setX(int num)
    {
        x = num;
    }

    public void setY(int num)
    {
        y = num;
    }
    public void setIsEnabled(bool enabled)
    {
        isEnabled = enabled;
    }
}
