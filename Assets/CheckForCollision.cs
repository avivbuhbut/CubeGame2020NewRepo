using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForCollision : MonoBehaviour
{
    public ParticleSystem part;

    void Start()
    {
        part = GetComponent<ParticleSystem>();
    }

    public void OnParticleCollision(GameObject other)
    {

  
            Debug.Log("Particle hit  " + other.transform.name);
    
}
}
