using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CreatePizza : MonoBehaviour
{

    /*Stove Tempetrue*/

    /*animation fire*/
  
    public ParticleSystem FireStove1ParticleSystem;
    public ParticleSystem FireStove2ParticleSystem;
    ParticleSystem.EmissionModule emissionModule;
    ParticleSystem.EmissionModule emissionModule2;
    /**animation fire - end**///

    public Button StoveOnOffButton;
    [SerializeField] TextMeshProUGUI OnOffTMP;
    [SerializeField] TextMeshProUGUI TempetureTMP;

    public TextMeshPro TimerTMP;
    public Transform PizzaBoxesParentTrans;
    public static int counterPizzaGen = 0;
    //public GameObject DoughAndSauceGamObjClone;//
    public GameObject DoughAndSauceGamObj;
    public GameObject PizzaBox1GamObj;
    bool ButtonPreesed;
    public Transform PlayerTrans;
    public TextMeshPro TimerPizza;

    bool colidedWithSauceAndDough;

   public float  timeLeft = 4f;
    float timerPizza = 0;
    int counter = 0;
    float TempTimePressedButton;
    float buttonPresseCounter = 0;
    Color onOffOriginalColor;
    Color TempetureOriginalColor;
    bool TemeptureRise;
    float timerTempetureRise;
    bool maxTemp;
    static bool FirstTimeCreatingPizza;
    static int numberTImeHit;
    // Start is called before the first frame update
    void Start()
    {
        TempetureOriginalColor = TempetureTMP.color;
        onOffOriginalColor = OnOffTMP.color;
        emissionModule = FireStove1ParticleSystem.emission;
        emissionModule2 = FireStove2ParticleSystem.emission;
        FireStove1ParticleSystem.Stop();
        FireStove2ParticleSystem.Stop();
        TempetureTMP.gameObject.SetActive(false);
        PizzaBox1GamObj.gameObject.SetActive(false);
        DoughAndSauceGamObj.gameObject.SetActive(false);
        PizzaBox1GamObj.name = "PizzaBoxClone1";
        TimerPizza.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (numberTImeHit>0)
        {

            Debug.Log(numberTImeHit);
            //if(numberTImeHit==0)
             //   colidedWithSauceAndDough = false;

      
            TimerPizza.gameObject.SetActive(true);
            timeLeft -= Time.deltaTime;
            TimerPizza.text = (int)timeLeft + "S";
            TimerPizza.color = Color.red;
            Debug.Log("HEREEEE");
            if((int)timeLeft == 0)
            {
                if (FirstTimeCreatingPizza == false)
                {
                    PizzaBox1GamObj.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - 2, PizzaBox1GamObj.transform.position.z);
                    FirstTimeCreatingPizza = true;
                    numberTImeHit--;
                }
                else
                {
                    numberTImeHit--;
                    GameObject Clone = Instantiate(PizzaBox1GamObj, new Vector3(this.transform.position.x, this.transform.position.y - 2, PizzaBox1GamObj.transform.position.z), Quaternion.identity);
                    Clone.transform.name = "PizzaBoxClone" + counterPizzaGen;
                    Clone.transform.parent = PizzaBoxesParentTrans;
                    PizzaBox1GamObj.gameObject.SetActive(true);

                    timeLeft = 4;
                    //TimerPizza.gameObject.SetActive(false);
                }

            }
        }

        /*
            if (colidedWithSauceAndDough && timeLeft>0 && GameObject.Find("CubeCheckForRainColision").GetComponent<CubeCheckForRainHit>().hit.transform.name != "StoveCelling")
        {
            timeLeft -= Time.deltaTime;


            timerPizza = 1;
        }
        else if(timeLeft <=0f && timerPizza==1)
        {
            timeLeft = 4f;
            timerPizza++;
            colidedWithSauceAndDough = false;
            if (counterPizzaGen < 2)
            {


                GameObject Clone = Instantiate(PizzaBox1GamObj, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
                Clone.transform.name = "PizzaBoxClone" + counterPizzaGen;
                PizzaBox1GamObj.gameObject.SetActive(true);
                //  GameObject.Find("DoughAndSauce(Clone)").SetActive(false);
                //      Destroy(GameObject.Find("DoughAndSauce(Clone)"));

            }
            else
            {


                GameObject Clone = Instantiate(PizzaBox1GamObj, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
                Clone.transform.name = "PizzaBoxClone" + counterPizzaGen;
                Clone.transform.parent = PizzaBox1GamObj.transform.parent;

                //  Destroy(GameObject.Find("DoughAndSauce(Clone)"));


            }
        }


        */


        RaycastHit hit;
       
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);                    ///Very Useful Code! - tells the object name when clicked by the mouse

            // Casts the ray and get the first game object hit
            Physics.Raycast(ray, out hit);

        // if (hit.transform.name == "TurnOnStove" || hit.transform.name == "StoveTurned")
        //Debug.Log("hit stove button" + hit.transform.name);

        if (TemeptureRise && hit.transform.name == "RightSideStove")
        {
            TempetureTMP.gameObject.SetActive(true);
            timerTempetureRise += 0.8f * Time.deltaTime;

            if((int)timerTempetureRise == 3)
            {
                
                TempetureTMP.text = "100c";
                    TempetureTMP.color = Color.gray;
            }

            if ((int)timerTempetureRise == 5)
            {
                TempetureTMP.text = "130c";
                TempetureTMP.color = Color.yellow;
            }

            if ((int)timerTempetureRise == 7)
            {
                TempetureTMP.text = "180c";
                TempetureTMP.color = TempetureOriginalColor;
                maxTemp = true;

            }
        }
      
      
         


        


            if (Input.GetKey(KeyCode.Mouse0) && ButtonPreesed && hit.transform.name == "RightSideStove")
        {
            TemeptureRise = true;
            buttonPresseCounter = 0;
            TempTimePressedButton += 0.8f * Time.deltaTime;
         
            OnOffTMP.text = "On";
            OnOffTMP.color = Color.green;
            FireStove1ParticleSystem.Play();
            FireStove2ParticleSystem.Play();

            if ((int)TempTimePressedButton >= 3)
            {
                emissionModule.rateOverTime = 5f;
                emissionModule2.rateOverTime = 5f;
            }
            if ((int)TempTimePressedButton >= 7)
            {
                emissionModule.rateOverTime = 15f;
                emissionModule2.rateOverTime = 15f;
            }


            Debug.Log("Button" +
                " is pressed down!");
        }

            /*
          if(Input.GetMouseButton(0))
        
                if (ButtonPreesed && maxTemp)
           {
            emissionModule.rateOverTime = 3f;
            emissionModule2.rateOverTime = 3f;
            //  OnOffTMP.text = "On";
           
          
        
        if(ButtonPreesed )
           {
            
               OnOffTMP.text = "Off";
              OnOffTMP.color = onOffOriginalColor;
             emissionModule.rateOverTime = 0;
             emissionModule2.rateOverTime = 0;
               TempetureTMP.gameObject.SetActive(false);
            // maxTemp = false;
          }
        }*/

        // OnOffTMP.text = "Off";
        // OnOffTMP.color = onOffOriginalColor;

        // FireStove1ParticleSystem.Stop();
        // FireStove2ParticleSystem.Stop();
        //  emissionModule.rateOverTime = 0;
        //  emissionModule2.rateOverTime = 0;




    }

     void OnCollisionEnter(Collision collision)
    {

        Debug.Log("collision.gameObject.transform.name " + collision.gameObject.transform.name);
        if (collision.gameObject.transform.name == "DoughAndSauce(Clone)" || collision.gameObject.transform.name == "DoughAndSauce" 
            || colidedWithSauceAndDough)
        {
       

            colidedWithSauceAndDough = true;

                counterPizzaGen++;



            
        }

      
   

    

        
    }


     void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.name == "DoughAndSauce(Clone)" || other.gameObject.transform.name == "DoughAndSauce")
               numberTImeHit++;
    }
    void OnEnable()
    {

        StoveOnOffButton.onClick.AddListener(MyFunction);//adds a listener for when you click the button

    }


    void MyFunction()// your listener calls this function
    {

        ButtonPreesed = true;
   

    }



}
