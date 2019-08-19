using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPosition : MonoBehaviour
{
    private Rigidbody selfRigidbody;

    void Start()
    {
        selfRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.KeypadEnter))
        {
            selfRigidbody.position = new Vector3(0, 4f, 0);
            selfRigidbody.rotation = Quaternion.Euler(45f, 0, 45f);
            selfRigidbody.velocity = Vector3.zero;
            selfRigidbody.angularVelocity = Vector3.zero;
        }
    }
}
