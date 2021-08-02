using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "ScriptableObjects/ScriptableDrinks")]
public class ScriptableDrinks : ScriptableObject
{
    [Header("Basic Information")]
    // Start is called before the first frame update
    public string drinkName;
    public Sprite drinkSprite;
    [TextArea(15, 20)] public string description;
    
    [Header("Drink Feature")]
    public bool isAlcoholic;
    public bool isForbidden;
    public int drinkPrice;
    
    [Header("Recipe")]
    public int alcohol;
    public int sugar;
    public int water;
    public bool iced;
    public bool olden;
}
