using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Random = System.Random;

public class BartenderSystem : MonoBehaviour
{
    [Header("Assign Scriptable Object List")]
    public ScriptableDrinks[] Drinks;
    public ScriptableLogs[] Logs;
    
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
    public List<Button> buttonToDisable;
    public GameObject bartenderAnimation;
    public AudioSource SESource;
    
    [Header("Assign Default Settings")]
    public Sprite defaultSprite;
    public string defaultDrinkName;
    public ScriptableLogs defaultLog;
    
    
    private bool inBartending = false;
    void Start()
    {
        drinkDetailText.DOText(defaultLog.logContent,2f);
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
        ToggleButton(true);
        drinkDetailText.text = "";
        drinkDetailText.DOText(randomizeLogText(), 3f);
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
        bool hasEleceted = false;
        inBartending = !inBartending;
        if (inBartending)
        {
            drinkDetailText.enabled = false;
            bartenderAnimation.SetActive(true);
            ToggleButton(false);
            return;
        }
        drinkDetailText.enabled = true;
        bartenderAnimation.SetActive(false);
        List<ScriptableDrinks> candidate = new List<ScriptableDrinks>();
        foreach (var VARIABLE in Drinks)
        {
            candidate.Add(VARIABLE);
        }
      
        foreach (var eachCandidate in candidate)
        {
            
            // print(alcoNum == eachCandidate.alcohol && waterNum == eachCandidate.water && sugarNum == eachCandidate.sugar
            //       && iced == eachCandidate.iced && olden == eachCandidate.olden);
            if (alcoNum == eachCandidate.alcohol && waterNum == eachCandidate.water && sugarNum == eachCandidate.sugar
                && iced == eachCandidate.iced && olden == eachCandidate.olden)
            {
                DisplayDrink(eachCandidate);
                hasEleceted = true;
                break;
                
            }
        }
        if(!hasEleceted)
        {
            DisplayDrink(candidate[0]);
        }
        
        
        
    }

    private string randomizeLogText()
    {
        return Logs[UnityEngine.Random.Range(0, Logs.Length-1)].logContent;
    }

    private void ToggleButton(bool toggle)
    {
        foreach (var buttons in buttonToDisable)
        {
            buttons.interactable = toggle;
        }
    }

    private void DisplayDrink(ScriptableDrinks _eachCandidate)
    {
        var eachCandidate = _eachCandidate;
        drinkImage.sprite = eachCandidate.drinkSprite;
        drinkNameText.text = eachCandidate.drinkName;
        drinkDetailText.text = "";
        drinkDetailText.DOText(eachCandidate.description.ToString(),2f);
        makeButton.SetActive(false);
        presentButton.SetActive(true);
        SESource.Play();
    }
}