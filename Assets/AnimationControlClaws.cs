using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControlClaws : MonoBehaviour
{

  public  Animation ClawCubeWithANim;
    public Animation LowerCLaw;
    // Start is called before the first frame update
    void Start()
    {
      ClawCubeWithANim.Stop("CloseClaw");
       // ClawCubeWithANim.Stop("LowerClaw");
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            ClawCubeWithANim.Play("CloseClaw");
        

        }


        


        // if (Input.GetKeyDown(KeyCode.UpArrow))
        // {
        //    ClawCubeWithANim.Play("LowerClaw");

        //  }

    }
}
