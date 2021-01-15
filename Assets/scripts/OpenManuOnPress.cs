using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenManuOnPress : MonoBehaviour
{



    /*FLOUR Buttons*/

      /*Right Button*/
    public Button RightFlourBtn;
    Color OriginColorRightFlourBtn;
    public static bool bolFlourGoesRight;
    int FlourCounterPresBtnRight;

    /*Left Button*/
    public Button LeftFlourBtn;
    Color OriginColorLeftFlourBtn;
    public static bool bolFlourGoesLeft;
    int FlourCounterPresBtnLeft;


    /*Switch Button*/
    public Button SwitchFlourBtn;
    Color OriginColorSwitchFlourBtn;
    public static bool bolFlourGoesSwitch;
    int FlourCounterPresBtnSwitch;



    /*ints flour*/


    public Button ConveyLogicButton;

    public GameObject PanelGamObj;
    int coutnerButtonPressed = 0;
    // Start is called before the first frame update
    void Start()
    {
        OriginColorSwitchFlourBtn = SwitchFlourBtn.image.color;
        OriginColorLeftFlourBtn = LeftFlourBtn.image.color;
        OriginColorRightFlourBtn = RightFlourBtn.image.color;
        PanelGamObj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        /*open and close panel(logic menu)*/
        if (coutnerButtonPressed == 2 && PanelGamObj.activeSelf)
        {
            coutnerButtonPressed = 0;
            PanelGamObj.SetActive(false);

        }

        /***********(START) FLOUR****************************/

        /*********** (START)Flour goes RIGHT Activate and deactivate***************/
        if (FlourCounterPresBtnRight==1)
        {
            bolFlourGoesRight = true;
            RightFlourBtn.image.color = Color.green;

        }
        /*if the player pressed twice change the color to red */
        if (FlourCounterPresBtnRight == 2)
        {
            FlourCounterPresBtnRight = 0;
            RightFlourBtn.image.color = OriginColorRightFlourBtn;
            bolFlourGoesRight = false;

        }

        /*********** (END)Flour goes right Activate and deactivate***************/


        /*********** (START)Flour goes LEFT Activate and deactivate***************/

        if (FlourCounterPresBtnLeft == 1)
        {
            bolFlourGoesLeft = true;
            LeftFlourBtn.image.color = Color.green;

        }

        if (FlourCounterPresBtnLeft == 2)
        {
            FlourCounterPresBtnLeft = 0;
            LeftFlourBtn.image.color = OriginColorLeftFlourBtn;
            bolFlourGoesLeft = false;

        }
        /*********** (END)Flour goes LEFT Activate and deactivate***************/


        /*********** (START)Flour goes Switch Activate and deactivate***************/
        if (FlourCounterPresBtnSwitch == 1)
        {
            bolFlourGoesSwitch = true;
            SwitchFlourBtn.image.color = Color.green;

        }

        if (FlourCounterPresBtnSwitch == 2)
        {
            FlourCounterPresBtnSwitch = 0;
            SwitchFlourBtn.image.color = OriginColorSwitchFlourBtn;
            bolFlourGoesSwitch = false;

        }

        /*********** (END)Flour goes Switch Activate and deactivate***************/

        /***********(END) FLOUR****************************/




    }



    void OnEnable()
    {

        ConveyLogicButton.onClick.AddListener(OpenPanel);//adds a listener for when you click the button
        RightFlourBtn.onClick.AddListener(FlourGoesRight);
        LeftFlourBtn.onClick.AddListener(FlourGoesLeft);
        SwitchFlourBtn.onClick.AddListener(FlourSwitchLeftRight);

    }


    void OpenPanel()// your listener calls this function
    {
        coutnerButtonPressed++;
        PanelGamObj.SetActive(true);
    }

    /*Flour goes right button was pressed*/
    void FlourGoesRight()
    {
        FlourCounterPresBtnRight++;
    
    }


    /*Flour goes LEFT button was pressed*/
    void FlourGoesLeft()
    {
        FlourCounterPresBtnLeft++;

    }

    /*Flour goes Switch button was pressed*/
    void FlourSwitchLeftRight()
    {
        FlourCounterPresBtnSwitch++;
    }

}
