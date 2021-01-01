using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionAndInstantiate : MonoBehaviour
{

    Transform LeftArrowDirectinCube, RightArrowDirectinCube, DownArrowDirectinCube;

    Color LeftArrowDirectinCubeOriginalColor;
    Color DownArrowDirectinCubeOriginalColor;
    Color RightArrowDirectinCubeOriginalColor;
    float timer;
    float TimeLeftToNextCreation = 0;
    GameObject TransToOutPut;

    bool NotDone;
    bool LeftArrowActive;
    bool RightArrowActive;
    bool DownArrowActive;

    bool LeftInstantiateDone;
    bool DownInstantiateDone;
    bool RightInstantiateDone;
    // Start is called before the first frame update
    void Start()
    {
        RightArrowDirectinCube = this.transform.Find("DirectionArrowRight");
        LeftArrowDirectinCube = this.transform.Find("DirectionArrowLeft");
        DownArrowDirectinCube = this.transform.Find("DirectionArrowDown");
        // RightArrow = this.transform.Find("ArrowRight");

        LeftArrowDirectinCubeOriginalColor = LeftArrowDirectinCube.transform.GetComponent<Renderer>().material.color;
        DownArrowDirectinCubeOriginalColor = DownArrowDirectinCube.transform.GetComponent<Renderer>().material.color;
        RightArrowDirectinCubeOriginalColor = RightArrowDirectinCube.transform.GetComponent<Renderer>().material.color;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);                    ///Very Useful Code! - tells the object name when clicked by the mouse

        // Casts the ray and get the first game object hit
        Physics.Raycast(ray, out hit);
        int counter = 0;
        /////////////////////LEFTARROW (Start)////////////////////////////////
        if (Input.GetMouseButtonDown(0))
        {



            Debug.Log(hit.collider.gameObject.name);
            if (hit.collider.gameObject == LeftArrowDirectinCube.gameObject)
            {
                LeftArrowDirectinCube.transform.GetComponent<Renderer>().material.color = Color.blue;

                LeftArrowActive = true;
            }
        }
        if (Input.GetKey(KeyCode.Mouse0) &&
     hit.collider.gameObject == LeftArrowDirectinCube.gameObject && LeftArrowDirectinCube.transform.GetComponent<Renderer>().material.color == Color.blue)
        {

            timer += 0.8f * Time.deltaTime;
            Debug.Log((int)timer);
            if ((int)timer == 1)
            {
                timer = 0;
                LeftArrowActive = false;
                LeftArrowDirectinCube.transform.GetComponent<Renderer>().material.color = LeftArrowDirectinCubeOriginalColor;
            }

        }

        /////////////////////LEFTARROW (End)////////////////////////////////


        /////////////////////RightARROW (Start)////////////////////////////////
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(hit.collider.gameObject.name);
            if (hit.collider.gameObject == RightArrowDirectinCube.gameObject)
            {
                RightArrowDirectinCube.transform.GetComponent<Renderer>().material.color = Color.blue;

                RightArrowActive = true;
            }
        }
        if (Input.GetKey(KeyCode.Mouse0) &&
    hit.collider.gameObject == RightArrowDirectinCube.gameObject && RightArrowDirectinCube.transform.GetComponent<Renderer>().material.color == Color.blue)
        {

            timer += 0.8f * Time.deltaTime;
            Debug.Log((int)timer);
            if ((int)timer == 1)
            {
                timer = 0;
               RightArrowActive = false;
                RightArrowDirectinCube.transform.GetComponent<Renderer>().material.color = LeftArrowDirectinCubeOriginalColor;
            }

        }
        /////////////////////RightARROW (End)////////////////////////////////
        ///




        /////////////////////DownARROW (Start)////////////////////////////////
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(hit.collider.gameObject.name);
            if (hit.collider.gameObject == DownArrowDirectinCube.gameObject)
            {
                DownArrowDirectinCube.transform.GetComponent<Renderer>().material.color = Color.blue;

                DownArrowActive = true;
            }
        }
        if (Input.GetKey(KeyCode.Mouse0) &&
    hit.collider.gameObject == DownArrowDirectinCube.gameObject && DownArrowDirectinCube.transform.GetComponent<Renderer>().material.color == Color.blue)
        {

            timer += 0.8f * Time.deltaTime;
            Debug.Log((int)timer);
            if ((int)timer == 1)
            {
                timer = 0;
              DownArrowActive = false;
                DownArrowDirectinCube.transform.GetComponent<Renderer>().material.color = LeftArrowDirectinCubeOriginalColor;
            }

        }
        /////////////////////DownARROW (End)////////////////////////////////
        ///





        if (Colided || NotDone)
        {
            TimeLeftToNextCreation += 0.8f * Time.deltaTime;

            if (TimeLeftToNextCreation < 2 && TimeLeftToNextCreation > 0)
            {
                NotDone = true;
            }
            else
                NotDone = false;

            if (LeftArrowActive && (int)TimeLeftToNextCreation == 2)
            {
                GameObject Clone2 = Instantiate(TransToOutPut, new Vector3(this.transform.position.x - 1.3f, this.transform.position.y, this.transform.position.z), Quaternion.identity);
                //Clone2.transform.GetComponent<Rigidbody>().useGravity= true;-89.311
                Clone2.transform.localRotation = Quaternion.Euler(-89.311f, 0, 0);

                TimeLeftToNextCreation = 0;
            }
        

             if (DownArrowActive && (int)TimeLeftToNextCreation == 2 )
            {
                GameObject Clone3 = Instantiate(TransToOutPut, new Vector3(this.transform.position.x, this.transform.position.y - 1, this.transform.position.z), Quaternion.identity);
                Clone3.transform.localRotation = Quaternion.Euler(-89.311f, 0, 0);
                Debug.Log("Down");
                TimeLeftToNextCreation = 0;
            }

             if (RightArrowActive && (int)TimeLeftToNextCreation == 2)
            {
                
                GameObject Clone4 = Instantiate(TransToOutPut, new Vector3(this.transform.position.x + 1.5f, this.transform.position.y, this.transform.position.z), Quaternion.identity);
               Clone4.transform.localRotation = Quaternion.Euler(-89.311f, 0, 0);

                TimeLeftToNextCreation = 0;
            }


        


        }




    }

    static int counter = 0;
    bool Colided;

    void OnCollisionEnter(Collision collision)
    {


        TransToOutPut = collision.gameObject;
        Colided = true;
        /*

        if (LeftArrowActive && DownArrowActive)
        {
            GameObject Clone2 = Instantiate(TransToOutPut, new Vector3(this.transform.position.x - 1, this.transform.position.y, this.transform.position.z), Quaternion.identity);

            counter++;

            if(counter ==1 && (LeftArrowActive && DownArrowActive))
            {

            }
        }
        else
        {*/

  


    }

    void OnCollisionExit(Collision collision)
    {

      Colided = false;
        if (collision.transform == TransToOutPut)
            TransToOutPut = null;


        if (LeftArrowActive && LeftInstantiateDone == true)
        {
            LeftInstantiateDone = false;
        }

        if (DownArrowActive && DownInstantiateDone == true)
        {
            DownInstantiateDone = false;
        }


    }

}
