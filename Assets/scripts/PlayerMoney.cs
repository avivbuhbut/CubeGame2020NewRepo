using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerMoney : MonoBehaviour
{

    public  TextMeshPro PlayerMoneyTMP;
    public  TextMeshPro PlayerMoneyWideTMP;
    public static int moneyCounter = 3;
    // Start is called before the first frame update
    void Start()
    {
        PlayerMoneyTMP.text = moneyCounter + "$";
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoneyTMP.text = moneyCounter + "$";
        PlayerMoneyWideTMP.text = PlayerMoneyTMP.text;
    }
}
