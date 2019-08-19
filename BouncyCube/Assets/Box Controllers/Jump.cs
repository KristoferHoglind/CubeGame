using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public int forceConst = 5;
    public GameManager gameManager;

    private bool canJump;
    private Rigidbody selfRigidbody;
    private const int maxDoubleJump = 2;
    public bool isGrounded;
    private bool canDoDoubleJump = false;

    void Start()
    {
        selfRigidbody = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 9 || collision.gameObject.layer == 11
            && !isGrounded)
        {
            isGrounded = true;
        }

        if(collision.gameObject.layer == 11 && isGrounded)
        {
            gameManager.CompleteLevel();
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == 9
            && isGrounded)
        {
            canDoDoubleJump = true; // if still in air, only do double jump
        }
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if(isGrounded)
            {
                isGrounded = false;
                canDoDoubleJump = true;
                selfRigidbody.velocity = new Vector3(selfRigidbody.velocity.x, 0, selfRigidbody.velocity.z);
                selfRigidbody.AddForce(0, forceConst, 0, ForceMode.Impulse);
            }
            else
            {
                if(canDoDoubleJump)
                {
                    canDoDoubleJump = false;
                    selfRigidbody.velocity = new Vector3(selfRigidbody.velocity.x, 0, selfRigidbody.velocity.z);
                    selfRigidbody.AddForce(0, forceConst, 0, ForceMode.Impulse);
                }
            }
        }

    }
}
