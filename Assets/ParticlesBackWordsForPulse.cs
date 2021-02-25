using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesBackWordsForPulse : MonoBehaviour
{
    // Start is called before the first frame update
    private ParticleSystem ps;
    public  ParticleSystem FireElectredParticles;
    public float hSliderValue = 1.0F;
    float SimulationSpeedTimer=2;
    bool exit;
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
      //  ps.Play();
        FireElectredParticles.Stop();
    }

    void Update()
    { 
        Debug.Log("SimulationSpeedTimer: " + SimulationSpeedTimer);
        var main = ps.main;
       // FireElectredParticles.Stop();
        if (Input.GetKey(KeyCode.LeftShift))
        {
            SimulationSpeedTimer -= 0.8f * Time.deltaTime;
            if ((int)SimulationSpeedTimer == 0 && exit == false)
            {
                main.simulationSpeed += 1.2f;
                SimulationSpeedTimer = 2;
            }


            if ((int)main.simulationSpeed >= 4)
            {
                exit = true;
            }
        }
        else
        {
            SimulationSpeedTimer = 2;
            if ((int)main.simulationSpeed >= 4)
            {
             
                main.simulationSpeed = 0.29f;
                FireElectredParticles.Play();

            }
        }
    }

    //void OnGUI()
   // {
   //     hSliderValue = GUI.HorizontalSlider(new Rect(25, 45, 100, 30), hSliderValue, 0.0F, 10.0F);
    //}
}
