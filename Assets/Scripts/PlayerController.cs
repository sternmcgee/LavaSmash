﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private int health = 0;
    public float slowTimeFactor = 0.2f;
    public float speed;
    public float jumpFactor;
    private Rigidbody rb;
    public AudioSource oraSound;
    public AudioSource warudoSound;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private IEnumerator SlowTime()
    {
        warudoSound.Play();
        Time.timeScale = slowTimeFactor;
        Time.fixedDeltaTime = slowTimeFactor * 0.02f;

        yield return new WaitForSecondsRealtime(8f);

        Time.timeScale = 1.0f;
        Time.fixedDeltaTime = 0.02f;
    }

    public void TakeDamage(int damage)
    {
        oraSound.PlayScheduled(Time.time);
        health += damage;
        Debug.Log("HEALTH: " + health);
    }

    public void TakeForce(Vector3 force)
    {
        force = -1f * force;
        rb.AddForce(force * health);
        Debug.Log(force);
    }
    private void FixedUpdate()
    {
        float xForce = 0f;
        float yForce = 0f;
        //handle side to side movement
        if (Input.GetKey(KeyCode.A))
        {
            xForce = -1f;
        }

        if (Input.GetKey(KeyCode.D))
        {
            xForce = 1f;
        }

        //handle jumping
        if (Input.GetKeyDown(KeyCode.W))
        {
            yForce = 1f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            yForce = -1f;
        }

        //slow time
        if (Input.GetKeyDown(KeyCode.Q))
        {
            StartCoroutine(SlowTime());
        }

        //make vector
        Vector3 moveForce = new Vector3(xForce * speed, yForce * jumpFactor, 0f);

        //apply force
        rb.AddForce(moveForce);
    }
}
