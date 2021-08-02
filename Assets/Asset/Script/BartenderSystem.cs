using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BartenderSystem : MonoBehaviour
{
    public ScriptableDrinks[] Drinks;

    [HideInInspector] public int alcoNum = 0;
    [HideInInspector] public int sugarNum = 0;
    [HideInInspector] public int waterNum = 0;
    [HideInInspector] public bool iced = false;
    [HideInInspector] public bool olden = false;
    [Header("Assign Interface Object")]
    public Text alcoText;
    public Text sugarText;
    public Text waterText;
    public Text icedText;
    public Text oldenText;
    public Image drinkImage;
    public Text drinkNameText;
    public Text drinkDetailText;
    public GameObject makeButton;
    public GameObject presentButton;
    
    [Header("Assign Default Settings")]
    public Sprite defaultSprite;
    public string defaultDrinkName;
    void Start()
    {
        ResetSystem();
    }

    public void ResetSystem()
    {
        alcoNum = 0;
        sugarNum = 0;
        waterNum = 0;
        iced = false;
        olden = false;
        alcoText.text = "0";
        sugarText.text = "0";
        waterText.text = "0";
        icedText.text = "否";
        oldenText.text = "否";
        makeButton.SetActive(true);
        presentButton.SetActive(false);
        drinkNameText.text = defaultDrinkName;
        drinkImage.sprite = defaultSprite;
        
        
    }

    public void AlcoAdd()
    {
        alcoNum++;
        alcoText.text = alcoNum.ToString();
    }
    
    public void SugarAdd()
    {
        sugarNum++;
        sugarText.text = sugarNum.ToString();
    }

    public void WaterAdd()
    {
        waterNum++;
        waterText.text = waterNum.ToString();
    }

    public void IcedToggle()
    {
        iced = !iced;
        icedText.text = iced ? "是" : "否";
    }

    public void OldenToggle()
    {
        olden = !olden;
        oldenText.text = olden ? "是" : "否";
    }

    public void Bartender()
    {
        List<ScriptableDrinks> candidate = new List<ScriptableDrinks>();
        foreach (var VARIABLE in Drinks)
        {
            candidate.Add(VARIABLE);
        }

        foreach (var VARIABLE in candidate)
        {
            if (alcoNum == VARIABLE.alcohol && waterNum == VARIABLE.water && sugarNum == VARIABLE.water
                && iced == VARIABLE.iced && olden == VARIABLE.olden)
            {
                drinkImage.sprite = VARIABLE.drinkSprite;
                drinkNameText.text = VARIABLE.drinkName;
                drinkDetailText.text = VARIABLE.description;
                makeButton.SetActive(false);
                presentButton.SetActive(true);
                break;
            }
        }
        
    }
}