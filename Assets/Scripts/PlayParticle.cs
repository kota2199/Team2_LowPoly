using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayParticle : MonoBehaviour
{

    [SerializeField]
    ParticleSystem[] particles;

    // Start is called before the first frame update
    void Start()
    {
        particles[0].Play();
        particles[1].Play();
        particles[2].Play();
        particles[3].Play();
        particles[4].Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
