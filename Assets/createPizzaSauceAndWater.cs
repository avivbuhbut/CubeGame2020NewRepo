using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class createPizzaSauceAndWater : MonoBehaviour
{

    public GameObject PizzaSauceGamObj;
    public GameObject WaterGameObj;
    float TimeLeftToNextCreation=20;
    float StartTimeLeftToNextCreation;
    [SerializeField] TextMeshProUGUI PizzaSauceNextCreationTMP;
    [SerializeField] TextMeshProUGUI WaterNextCreationTMP;
    // Start is called before the first frame update
    void Start()
    {
        StartTimeLeftToNextCreation = 20;


    }

    // Update is called once per frame
    void Update()
    {
        TimeLeftToNextCreation-= 0.8f * Time.deltaTime;


        if (TimeLeftToNextCreation <= 0)
        {
            GameObject Clone1 = Instantiate(PizzaSauceGamObj, new Vector3(this.transform.position.x-0.1f, this.transform.position.y, this.transform.position.z), Quaternion.identity);
            GameObject Clone2 = Instantiate(WaterGameObj, new Vector3(this.transform.position.x + 0.1f, this.transform.position.y, this.transform.position.z), Quaternion.identity);
            StartTimeLeftToNextCreation += 3;
            TimeLeftToNextCreation = StartTimeLeftToNextCreation;
        }

    }


    }
