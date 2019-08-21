using UnityEngine;

public class Fail : MonoBehaviour
{

    public Rigidbody playerRigidbody;
    private int noFails = 0;

    private void OnTriggerEnter()
    {
        noFails++;
        playerRigidbody.position = new Vector3(0, 4f, 0);
        playerRigidbody.rotation = Quaternion.Euler(45f, 0, 45f);
        playerRigidbody.velocity = Vector3.zero;
        playerRigidbody.angularVelocity = Vector3.zero;
    }

    public int GetNoFails()
    {
        return noFails;
    }

}
