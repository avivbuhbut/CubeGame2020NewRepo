using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryPressCreateConvyer : MonoBehaviour
{
    bool ButtonPressed;
    public Button ButtonInvenMonDroper;
    public GameObject ConvyerBeltGamObj;
    public Transform Player;


    void OnEnable()
    {

        ButtonInvenMonDroper.onClick.AddListener(MyFunction);//adds a listener for when you click the button

    }

    void MyFunction()// your listener calls this function
    {
        ButtonPressed = true;
        Debug.Log("You pressed on money Droper Inven Slot");
        GameObject Clone2 =  Instantiate(ConvyerBeltGamObj, new Vector3(Player.transform.position.x + 1, Player.transform.position.y + 2f, Player.transform.position.z), Quaternion.identity);
        Clone2.transform.localRotation = Quaternion.Euler(-89.98f, 0, 0);
  

    }

}
