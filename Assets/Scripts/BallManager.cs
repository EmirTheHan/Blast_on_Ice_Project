﻿using UnityEngine;

public class BallManager : MonoBehaviour
{
    public static int owner;
    public Rigidbody rb;
    public AudioSource b;
    private float speed, selfspeed;
    private void OnCollisionEnter(Collision obj)
    {
        if (obj.gameObject.CompareTag("P1"))
        {
            owner = 1;
            speed = obj.rigidbody.velocity.magnitude;
            selfspeed = rb.velocity.magnitude;
            if (speed >= 1 || selfspeed >= 4)
            {
                b.volume = .15f * speed;
                b.Play();
            }
        }        
        else if (obj.gameObject.CompareTag("P2"))
        {
            owner = 2;
            speed = obj.rigidbody.velocity.magnitude;
            selfspeed = rb.velocity.magnitude;
            if (speed >= 1 || selfspeed >= 4)
            {
                b.volume = .15f * speed;
                b.Play();
            }
        }
        else
        {
            selfspeed = rb.velocity.magnitude;
            if (selfspeed >= 4 && gameObject.transform.position.y >= 1.5f)
            {
                b.volume = .15f * speed;
                b.Play();
            }
        }
    }
}
