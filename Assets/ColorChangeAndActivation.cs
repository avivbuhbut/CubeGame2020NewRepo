using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ColorChangeAndActivation : MonoBehaviour
{
    public TextMeshPro NoElectricityTMP;
    Color lerpedColor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        lerpedColor = Color.Lerp(Color.white, Color.red, Mathf.PingPong(Time.time, 1));
        NoElectricityTMP.color = lerpedColor;
        if (HitByElectricPlayer.ArmHasElectricity)
        {

            this.transform.gameObject.SetActive(false);
        }

    }
}
