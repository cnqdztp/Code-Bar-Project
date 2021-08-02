using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/ScriptableLogs")]
public class ScriptableLogs : ScriptableObject
{
    public int logIndex;
    [TextArea(15, 20)] public string logContent;
    
}
