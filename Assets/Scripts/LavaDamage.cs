using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaDamage : MonoBehaviour
{
    private PlayerController player = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Player")
            return;

        player = collision.gameObject.GetComponent<PlayerController>();
        Vector3 impact = collision.GetContact(0).normal;
        player.TakeDamage(25);
        player.TakeForce(impact);
    }
}
