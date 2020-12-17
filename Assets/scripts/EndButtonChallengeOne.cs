using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndButtonChallengeOne : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
            if (GameObject.Find("KitchenAreaEnter").GetComponent< PSauceWaterPassButtonTurnRed>().TurnButtonToRed)
                this.transform.GetComponent<Renderer>().material.color = Color.Lerp(Color.white, Color.black, Mathf.PingPong(Time.deltaTime, 1));

    }

      


 
}
