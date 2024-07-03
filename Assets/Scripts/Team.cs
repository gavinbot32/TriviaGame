using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Team
{
    public int id;
    public string teamName;
    public Color teamColor;

    public void Initialize(int index, string name, Color color)
    {
        id = index;
        teamName = name;
        teamColor = color;
    }
}
