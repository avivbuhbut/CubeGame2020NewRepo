using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ButtonTurnOnAndOff : MonoBehaviour
{
    public Button OnOffButton;
    public Transform ContraierTrans;
    public Transform EndCube;
    public Transform PlayerTrans;

 //   public TextMeshPro OffOnTMP;
 public static int  counterClicks=0;
    Color OriginalBtnColor;
    [SerializeField] TextMeshProUGUI OnOffTMP;
    // Start is called before the first frame update
    void Start()
    {
        EndCube.gameObject.SetActive(false);
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
            //this.transform.GetComponentInParent<HitPlayerCreateLineAndConveyor>().enabled = true;
          
        //    this.transform.GetComponentInParent<LineRenderer>().SetPosition(0, this.transform.GetComponentInParent<Transform>().position); 
            this.transform.GetComponentInChildren<Image>().color = Color.green;
            OnOffTMP.text = "On";
            ContraierTrans.transform.GetComponent<Rigidbody>().isKinematic = true;
            EndCube.position = new Vector3(this.transform.position.x - 2, this.transform.position.y, PlayerTrans.transform.position.z);
            EndCube.gameObject.SetActive(true);
        }


        if (counterClicks == 2)
        {
            counterClicks = 0;
            //this.transform.GetComponentInParent<HitPlayerCreateLineAndConveyor>().enabled = false;
            EndCube.gameObject.SetActive(false);
            this.transform.GetComponentInParent<HitPlayerCreateLineAndConveyor>().ConveyorStach.gameObject.SetActive(false);
            this.transform.GetComponentInParent<LineRenderer>().enabled = false;
            PlayerTrans.GetComponent<HitEndCube>().PlayerHitEndCube = false;
            this.transform.GetComponentInParent<HitPlayerCreateLineAndConveyor>().ColidedWithPlayer = false;
            //this.transform.GetComponentInParent<LineRenderer>()
            //this.transform.GetComponentInParent<LineRenderer>().SetPosition(1, PlayerTrans.position);
            this.transform.GetComponentInChildren<Image>().color = OriginalBtnColor;
            OnOffTMP.text = "Off";
           ContraierTrans.transform.GetComponent<Rigidbody>().isKinematic = false;

        }
    }
    }
