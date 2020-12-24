using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class zoomInText : MonoBehaviour
{
    // Start is called before the first frame update
    bool PlayerHitTextFiledInput;
    public TMP_InputField UserInputField;
    // Start is called before the first frame update
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
        if (Input.GetKey(KeyCode.Mouse2))
        {
        //    Debug.Log(hit.tran.name);
            if ((hit.transform.name == "MoneyDroperMachine"))
            {
                UserInputField.enabled = true;
         
                PlayerHitTextFiledInput = true;

            }




        }
       // else PlayerHitTextFiledInput = false;

        if (PlayerHitTextFiledInput)
        {
           Camera.main.transform.position = new Vector3(GameObject.Find("MoneyDroperMachine").transform.position.x,
         GameObject.Find("MoneyDroperMachine").transform.position.y+1, GameObject.Find("MoneyDroperMachine").transform.position.z - 4);
        }


        if (MoneyDroperGetUserInput.buttonPreesed == true)
            PlayerHitTextFiledInput = false;
    }
    }
