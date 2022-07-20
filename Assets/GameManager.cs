using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    Transform bar;
    int clickCount = 0;
    float addValueAtClick = 0.00125f;
    float value = 0.0f;

    private void Start()
    {
        FillBar();
    }

    public void OnFillButtonClick()
    {
        clickCount = GetClickCount();
        value = GetFillData();
        clickCount+=7;
        print("Click Count " + clickCount);
        if(clickCount == 14)
        {
            print("Gift is 10");
            EventHandler.Instance.InvokeOnGiftBoxShakeAnimation(10);
        }

        else if (clickCount == 56)
        {
            print("Gift is 50");
            EventHandler.Instance.InvokeOnGiftBoxShakeAnimation(50);
        }
        else if (clickCount == 203)
        {
            print("Gift is 200");
            EventHandler.Instance.InvokeOnGiftBoxShakeAnimation(200);
        }
        else if (clickCount == 406)
        {
            print("Gift is 400");
            EventHandler.Instance.InvokeOnGiftBoxShakeAnimation(400);
        }

        else if (clickCount == 805)
        {
            print("Gift is 800");
            EventHandler.Instance.InvokeOnGiftBoxShakeAnimation(800);
        }
        else
        {
            print("Game is complete");
        }
        value = value + (addValueAtClick * 7);
        SetFillData(value);
        SetClickCount(clickCount);
        //print("Click Count "+ clickCount);
        FillBar();
        
    }

    public void onResetButtonClick()
    {
        print("Clicked on Reset Button");
        SetFillData(0.0f);
        SetClickCount(0);
        FillBar();
        
    }

    void FillBar()
    {
        bar.transform.localScale = new Vector3(1f, GetFillData());
    }

    void SetFillData(float value)
    {
        PlayerPrefs.SetFloat("value", value);
    }

    void SetClickCount(int clickCount)
    {
        PlayerPrefs.SetInt("clickCount", clickCount);   
    }

    float GetFillData()
    {
        return PlayerPrefs.GetFloat("value", value);
    }

    int GetClickCount()
    {
        return PlayerPrefs.GetInt("clickCount", clickCount);
    }
}
