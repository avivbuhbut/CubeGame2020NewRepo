using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTwardsPlayer : MonoBehaviour
{

    ParticleSystem ParticaleSys;
    Transform Player;
    ParticleSystem m_System;
    ParticleSystem.Particle[] m_Particles;
    public float m_Drift = 0.01f;
    // Start is called before the first frame update
    void Start()
    {
        ParticaleSys = this.transform.GetComponent<ParticleSystem>();
        Player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position, Player.position, Time.deltaTime * 2f);


        // GetParticles is allocation free because we reuse the m_Particles buffer between updates
        /*
        int numParticlesAlive = m_System.GetParticles(m_Particles);

        // Change only the particles that are alive
        for (int i = 0; i < numParticlesAlive; i++)
        {
            m_Particles[i].position = Vector3.MoveTowards(m_Particles[i].position, Player.position, Time.deltaTime * 2f); 
        }

        // Apply the particle changes to the Particle System
        m_System.SetParticles(m_Particles, numParticlesAlive);
    */

    }

    void InitializeIfNeeded()
    {
        if (m_System == null)
            m_System = GetComponent<ParticleSystem>();

        if (m_Particles == null || m_Particles.Length < m_System.main.maxParticles)
            m_Particles = new ParticleSystem.Particle[m_System.main.maxParticles];
    }

     void OnTriggerEnter(Collider other)
    {



        if (other.transform.name == "Player")
            Debug.Log("Player Is In Radius");
    }


     void OnParticleTrigger()
    {
        Debug.Log("Here");
    }

}
