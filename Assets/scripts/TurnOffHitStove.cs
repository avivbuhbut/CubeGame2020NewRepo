using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffHitStove : MonoBehaviour
{

    bool colided;
    float TimerDown = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (colided)
        {
            TimerDown -= Time.deltaTime;

            if ((int)TimerDown == 0)
            {
                this.gameObject.SetActive(false);
                TimerDown = 2;
                colided = false;
            }
        }
    }


     void OnCollisionEnter(Collision collision)
    {





       if (collision.transform.tag == "Stove")
        {
            colided = true;

        }
    }

}
