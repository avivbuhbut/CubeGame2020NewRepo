using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class IfPlayerEnterPlayerDies : MonoBehaviour
{
    Transform StartTimerTrans;

    //public TextMeshPro PlayerTimer;
    // Start is called before the first frame update
    void Start()
    {
        StartTimerTrans = GameObject.Find("StartTimerTrans").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }



     void OnTriggerEnter(Collider other)
    {
        if (other.transform.name == "Player")
            StartTimerTrans.GetComponent<StageOneTimer>().timeLeft = 1;
    }
}
