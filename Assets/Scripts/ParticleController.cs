using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    [SerializeField] ParticleSystem movement;

    [Range(0, 10)]
    [SerializeField] int occurAfterVelocity;

    [Range(0, 0.2f)]
    [SerializeField] float period;

    [SerializeField] Rigidbody2D missileRb;

    float counter;

    private void Update()
    {
        counter += Time.deltaTime;

        if (Mathf.Abs(missileRb.velocity.y) > occurAfterVelocity)
        {
            if(counter > period)
            {
                movement.Play();
                counter = 0;
            }
        }
    }
}
