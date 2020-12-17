using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerMoney : MonoBehaviour
{

    public TextMeshPro PlayerMoneyTMP;
    public TextMeshPro PlayerMoneyWideTMP;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoneyWideTMP = PlayerMoneyTMP;
    }
}
