using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lineHoldsArm : MonoBehaviour
{

    public Transform RoboricArmTrans;
    public Transform ArmTrans;
    public LineRenderer lineRender;
    // Start is called before the first frame update
    void Start()
    {
        ArmTrans.GetComponent<SpringJoint>().tolerance = 0.18f;
    }

    // Update is called once per frame
    void Update()
    {


        lineRender.SetPosition(0, RoboricArmTrans.position);
        lineRender.SetPosition(1, ArmTrans.position);


    }
}
