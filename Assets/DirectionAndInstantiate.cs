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
                DownArrowDirectinCube.transform.GetComponent<Renderer>().material.color = LeftArrowDirectinCubeOriginalColor;
            }

        }
        /////////////////////DownARROW (End)////////////////////////////////
    }









}
