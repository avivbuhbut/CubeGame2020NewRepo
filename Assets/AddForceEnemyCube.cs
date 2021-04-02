using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForceEnemyCube : MonoBehaviour
{
    bool ColidedWithPlayer;
    Transform PlayerTrans;
    public Material HitPlayerMaterial;
    float Timer = 3;
    float GravityTimer = 10;
    Material thisDesCubeMat;
    // Start is called before the first frame update
    void Start()
    {
        PlayerTrans = GameObject.Find("Player").transform;
        thisDesCubeMat = this.transform.GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {




        if (ColidedWithPlayer)
        {
            GravityTimer -= 0.8f * Time.deltaTime;
            Timer -= 0.8f * Time.deltaTime;

            if ((int)Timer == 0)
            {
                // this.transform.localScale += this.transform.localScale * 0.2f;
                if (this.transform.position.x < PlayerTrans.position.x)
                    this.transform.GetComponent<Rigidbody>().AddForce(Vector3.left * 50);
                if (this.transform.position.x > PlayerTrans.position.x)
                    this.transform.GetComponent<Rigidbody>().AddForce(Vector3.right * 50);

            }

            if ((int)GravityTimer == 0)
            {
                this.transform.GetComponent<Rigidbody>().useGravity = true;
                GravityTimer = 10;
                this.transform.GetComponent<Renderer>().material = thisDesCubeMat;
            }

        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name == "Player" && PlayerTrans.GetComponent<CheckIfRainHitPlayer>().PlayerElectricFull)
        {
            // this.transform.GetComponent<Rigidbody>().angularDrag = 10f;
            this.transform.GetComponent<Renderer>().material = HitPlayerMaterial;
            Timer = 3;
            this.transform.GetComponent<Rigidbody>().useGravity = false;
            ColidedWithPlayer = true;
        }
        // else
        //  ColidedWithPlayer = false;
    }

    void OnMouseOver()
    {
        // if (Input.GetKey(KeyCode.LeftShift))
        /// {
        //   this.transform.GetComponent<Rigidbody>().useGravity = true;

        //}

    }
}
