using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/PathScriptableObject", order = 1)]
public class PathScriptableObject : ScriptableObject
{
    public string pathName;

    public Color color;

    public Vector2[] pathPoints;

    public Vector2[] wayPoints;
}
