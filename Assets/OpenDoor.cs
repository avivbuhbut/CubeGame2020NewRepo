using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    // Start is called before the first frame update

    public Material GreenMat;
    public Animator openDoorAnim;
    Material defaultMat;
    void Start()
    {
        openDoorAnim.SetBool("Activate", false);
        defaultMat = this.transform.GetComponent<Material>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }



     void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name == "Player")
        {
            openDoorAnim.SetBool("Activate", true);
            this.transform.GetComponent<Renderer>().material = GreenMat;
   
        }
    }
}
