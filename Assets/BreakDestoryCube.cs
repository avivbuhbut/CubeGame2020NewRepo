using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakDestoryCube : MonoBehaviour
{
    public GameObject PowerCircleTrans;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     void OnCollisionEnter(Collision collision)
    {
      //  Debug.Log("Destroy cube  Colided with " + collision.transform.name);
        if(collision.transform.tag == "Floor")
        {
            this.transform.GetComponent<MeshDestroy>().DestroyMesh(this.transform.gameObject.GetComponent<MeshFilter>().mesh, this.transform.GetComponent<MeshDestroy>(), this.transform.gameObject);
   
                Instantiate(PowerCircleTrans, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
            PowerCircleTrans.SetActive(true);
        }
    }

}
