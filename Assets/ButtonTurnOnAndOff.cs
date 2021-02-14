using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ButtonTurnOnAndOff : MonoBehaviour
{
    public Button OnOffButton;
 //   public TextMeshPro OffOnTMP;
 public static int  counterClicks=0;
    Color OriginalBtnColor;
    [SerializeField] TextMeshProUGUI OnOffTMP;
    // Start is called before the first frame update
    void Start()
    {
        OriginalBtnColor = this.transform.GetComponentInChildren<Image>().color;


    }

    // Update is called once per frame
    void Update()
    {
        if (counterClicks == 2)
            counterClicks = 0;

    }



     void OnEnable()
    {
        OnOffButton.onClick.AddListener(TurnOn);

    }


    void TurnOn()
    {
        counterClicks++;
        if (counterClicks == 1)
        {
            this.transform.GetComponentInChildren<Image>().color = Color.green;
            OnOffTMP.text = "On";

        }


        if (counterClicks == 2)
        {
            this.transform.GetComponentInChildren<Image>().color = OriginalBtnColor;
            OnOffTMP.text = "Off";
    
        }
    }
    }
