using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ConvertMoneyToTime : MonoBehaviour { 
    public Button button;

void OnEnable()
{

        button.onClick.AddListener(MyFunction);//adds a listener for when you click the button

}
void MyFunction()// your listener calls this function
{
        Debug.Log("this button is pressed!");
}

}
