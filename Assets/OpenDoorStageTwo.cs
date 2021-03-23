using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorStageTwo : MonoBehaviour
{

    // Start is called before the first frame update

    public Material GreenMat;
    public Animator openDoorAnim;
    Material defaultMat;
    bool PlayerNotStandingOnPlatform;
    public static bool PlayerFinishLevel;
    float ColorTimer = 3f;
    Color lerpedColor;
    public Material thisObjectMat;
    void Start()
    {
        openDoorAnim.SetBool("Activate", false);
        defaultMat = this.transform.GetComponent<Material>();
        PlayerNotStandingOnPlatform = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (StageOneDeliveryFlourPlatform.numberOfFourHit == 6 && PlayerNotStandingOnPlatform)
        {
            lerpedColor = Color.Lerp(Color.black, thisObjectMat.color, Mathf.PingPong(Time.time, 1));
            this.transform.GetComponent<Renderer>().material.color = lerpedColor;
        }
    }



    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name == "Player" && StageOneDeliveryFlourPlatform.numberOfFourHit == 6)
        {
            StageOneDeliveryFlourPlatform.numberOfFourHit = 0;
            PlayerFinishLevel = true;
            PlayerNotStandingOnPlatform = false;
            openDoorAnim.SetBool("Activate", true);
            this.transform.GetComponent<Renderer>().material = GreenMat;

        }
    }
}
