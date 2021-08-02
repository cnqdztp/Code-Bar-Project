using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptableRecipe : ScriptableObject
{
    public string name;
    public ScriptableObject Production;

    public int alcohool;
    public int sugar;
    public int water;
    public bool iced;
    public bool olden;
}
