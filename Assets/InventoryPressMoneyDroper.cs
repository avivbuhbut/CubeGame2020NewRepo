using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.UI;

public class InventoryPressMoneyDroper : MonoBehaviour
{
    bool ButtonPressed;
    public Button ButtonInvenMonDroper;
    public GameObject MoneyDropper;
    public Transform Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ButtonPressed)
        {


        }
    }

    void OnEnable()
    {

        ButtonInvenMonDroper.onClick.AddListener(MyFunction);//adds a listener for when you click the button

    }

    void MyFunction()// your listener calls this function
    {
        ButtonPressed = true;
        Debug.Log("You pressed on money Droper Inven Slot");
        GameObject Clone2 = Instantiate(MoneyDropper, new Vector3(Player.transform.position.x+1, Player.transform.position.y+2f, Player.transform.position.z ), Quaternion.identity);
        Clone2.transform.localRotation = Quaternion.Euler(0, 182.171f, 0);
        Clone2.transform.parent = GameObject.Find("Canvas").transform;

    }

}
