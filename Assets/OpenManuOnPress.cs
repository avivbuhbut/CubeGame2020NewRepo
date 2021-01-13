using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenManuOnPress : MonoBehaviour
{

    public Button ConveyLogicButton;
    public GameObject PanelGamObj;
    // Start is called before the first frame update
    void Start()
    {

        PanelGamObj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    void OnEnable()
    {

        ConveyLogicButton.onClick.AddListener(MyFunction);//adds a listener for when you click the button

    }


    void MyFunction()// your listener calls this function
    {

        PanelGamObj.SetActive(true);
    }
}
