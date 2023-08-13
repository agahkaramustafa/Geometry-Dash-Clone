using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEffectsHandler : MonoBehaviour
{
    [SerializeField] private ParticleSystem trailParticleSystem;
    [SerializeField] private ParticleSystem deathParticleSystem;

    PlayerMovement playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMovement.gameMode == GameMode.Cube)
        {
            if (playerMovement.IsOnGround)
            {
                if (trailParticleSystem.isPlaying == false)
                {
                    trailParticleSystem.Play();
                }
            }
            else
            {
                trailParticleSystem.Stop();
            }
        }
        else if (playerMovement.gameMode == GameMode.Ship)
        {
            if (trailParticleSystem.isPlaying == false)
            {
                trailParticleSystem.Play();
            }
        }
        
    }

    public void StopTrailParticleSystem()
    {
        trailParticleSystem.Stop();
    }

    public void PlayDeathParticleSystem()
    {
        deathParticleSystem.Play();
    }
}
