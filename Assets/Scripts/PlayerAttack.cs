using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public int damage = 20;
    private bool isAttacking = false;
    private bool inRange = false;
    private PlayerController player = null;
    private Rigidbody my_rb = null;
    // Start is called before the first frame update
    void Start()
    {
        my_rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //if player1 presses button and collides with player2, deal damage + force
        if (gameObject.name == "Player2")
        {
            if (Input.GetKeyDown(KeyCode.E) && !isAttacking)
            {
                StartCoroutine(Attack());
            }
        }
        if (gameObject.name == "Player")
        {
            if (Input.GetKeyDown(KeyCode.Period) && !isAttacking)
            {
                StartCoroutine(Attack());
            }
        }
    }

    private IEnumerator Attack()
    {
        isAttacking = true;

        if (isAttacking && inRange)
        {
            player.TakeDamage(damage);
            player.TakeForce(-1f * my_rb.velocity.normalized);
        }
        yield return new WaitForSeconds(1f);
        isAttacking = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            player = other.gameObject.GetComponent<PlayerController>();
            inRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            player = null;
            inRange = false;
        }
    }

}
