using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartTimerEnterFirstChallange : MonoBehaviour
{

   // public Animator AnimHalfLevelGoUpAnim;
    bool PlayerPassThrow;
    bool PizzaBoxPassThrow;
    public TextMeshPro PlayerTimerTMP;
    public float timeLeft = 120;
    public Transform Player;
    // Start is called before the first frame update
    void Start()
    {
        PlayerTimerTMP.gameObject.SetActive(true);
      //  AnimHalfLevelGoUpAnim.SetBool("Activate", false);
    }

    // Update is called once per frame
    void Update()
    {
        int Min;


  

        //  PlayerTimerTMP.text = "TIME LEFT: \n" + timeLeft;
        if (PlayerPassThrow)
        {
           // Debug.Log(timeLeft % 60);
            //   AnimHalfLevelGoUpAnim.SetBool("Activate", true);

            timeLeft -= Time.deltaTime;
            Min = (int)timeLeft / 60;

            PlayerTimerTMP.gameObject.SetActive(true);
            if (timeLeft % 60 > 10 && timeLeft>0)
                PlayerTimerTMP.text = "TIME LEFT: \n" + Min + ":" + timeLeft % 60;
           else if (timeLeft % 60 < 10 && timeLeft > 0)
            {
                PlayerTimerTMP.text = "TIME LEFT: \n" + Min + ":" + "0" + timeLeft % 60;
            }else if(timeLeft%60 <=0)
            {

                Player.transform.GetComponent<MeshDestroy>().DestroyMesh(Player.transform.gameObject.GetComponent<MeshFilter>().mesh, Player.transform.GetComponent<MeshDestroy>(), Player.gameObject);

                //GameObject.Find("Player").transform.position = new Vector3(15.05f, 11.47f, 10.11741f); // try to teleport to the start
                //  GameObject.Find("PizzaBox").transform.position = new Vector3(15.05f, 11.47f, 10.11741f);
            }

        }



    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            PlayerPassThrow = true;

        }

       // if (other.transform.tag == "PizzaBox")
      //  {
      //      PizzaBoxPassThrow = true;
       // }
    }

    }
