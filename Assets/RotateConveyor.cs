using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateConveyor : MonoBehaviour
{
    float Difficulty;
    bool hitMax;
    bool hitMax2;
    int ForwadInt;
    int BackWardsINt;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {




    


        //

        RaycastHit hit;
      
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);                 

            // Casts the ray and get the first game object hit
            Physics.Raycast(ray, out hit);

     



        if (Input.GetKey(KeyCode.Mouse0) && hit.transform.name == "BasicConveyorBelt(Clone)")
            {
            Debug.Log(Difficulty);
            if (Input.GetAxis("Mouse ScrollWheel") > 0 && Difficulty < 3 && hitMax==false)
            {

                Debug.Log("Er2");
                Debug.Log(Difficulty);
                Difficulty += Input.GetAxis("Mouse ScrollWheel");
                hit.transform.Rotate(0, Difficulty, 0);
                if (Difficulty >= 3)
                {
                  //  Difficulty = 0;
                    hitMax = true;
                    hitMax2 = true;
                }



            }


            if (Input.GetAxis("Mouse ScrollWheel") < 0 && Difficulty > -3 && hitMax2==false)
            {
                Debug.Log("Er");

                Debug.Log(Difficulty);
                Difficulty += Input.GetAxis("Mouse ScrollWheel");
                hit.transform.Rotate(0, Difficulty, 0);
                if (Difficulty <= -3)
                {
                  //  Difficulty = 0;
                    hitMax = true;
                    hitMax2 = true;

                }



            }
            // else if(hitMax && Input.GetAxis("Mouse ScrollWheel")<3)
            // {
            //   Difficulty -= Input.GetAxis("Mouse ScrollWheel");
            //   hit.transform.Rotate(0, Difficulty, 0);
            // }

            //   if (Input.GetAxis("Mouse ScrollWheel") > 0 && Input.GetAxis("Mouse ScrollWheel") < 3)
            //  {
            //      Difficulty -= Input.GetAxis("Mouse ScrollWheel");
            //      hit.transform.Rotate(0, Difficulty, 0);
            //  }
            //   else
            //      Difficulty = 0;

            /*
            if (Input.GetAxis("Mouse ScrollWheel") < 0 && Difficulty > -2)

            {
                Debug.Log(Difficulty);
                Difficulty -= Input.GetAxis("Mouse ScrollWheel");
                hit.transform.Rotate(0, Mathf.Clamp(Difficulty, 0, -2), 0);

            }
            else
                Difficulty = 0;  */

            //   if (Input.GetKey(KeyCode.R) )
            //  {
            // hit.transform.Rotate(Vector3.up * 3f * Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime);

            //    Difficulty = ;

            //   transform.Rotate(0, 0, Difficulty);
            // }
            // hit.transform.localRotation  = Quaternion.Euler(x, 0, z);

        }//else
       //Difficulty = 0;
    }
}