using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class cameraZoomInTextField : MonoBehaviour
{
    // Start is called before the first frame update
    bool PlayerHitTextFiledInput;
    public TMP_InputField UserInputField;
  
    int counter = 0;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

       // UserInputField.transform. = new Vector3(GameObject.Find("MoneyDroper").transform.position.x, GameObject.Find("MoneyDroper").transform.position.y
            //, UserInputField.transform.position.z);

        RaycastHit hit;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);                    ///Very Useful Code! - tells the object name when clicked by the mouse

        // Casts the ray and get the first game object hit
        
        Physics.Raycast(ray, out hit);
        if (Input.GetMouseButtonDown(0))
            if ((hit.transform.name == "TextMoneyDroper") )
        {
                UserInputField.enabled = true;

                PlayerHitTextFiledInput = true;

        }

        //UserInputField.transform.position = new Vector3(this.transform.parent.position.x, this.transform.parent.position.y,this.transform.position.z);

        if (PlayerHitTextFiledInput)
            if (MoneyDroperGetUserInput.userInputDONE == false)
            {
                Camera.main.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - 2);
                

            }
            else
            {

                PlayerHitTextFiledInput = false;
                MoneyDroperGetUserInput.userInputDONE = false;
            }

    }

}

