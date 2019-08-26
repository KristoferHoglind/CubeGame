using UnityEngine;

public class Movement : MonoBehaviour {
    public int forceConst = 5;

    private bool moveNorth;
    private bool moveEast;
    private bool moveSouth;
    private bool moveWest;
    private Rigidbody selfRigidbody;

    void Start() {
        selfRigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate() {
        if(moveNorth) {
            moveNorth = false;
            selfRigidbody.AddForce(0, 0, forceConst, ForceMode.Acceleration);
        }

        if(moveEast) {
            moveEast = false;
            selfRigidbody.AddForce(forceConst, 0, 0, ForceMode.Acceleration);
        }

        if(moveSouth) {
            moveSouth = false;
            selfRigidbody.AddForce(0, 0, -forceConst, ForceMode.Acceleration);
        }

        if(moveWest) {
            moveWest = false;
            selfRigidbody.AddForce(-forceConst, 0, 0, ForceMode.Acceleration);
        }
    }

    void Update() {
        if(Input.GetKey(KeyCode.UpArrow)) {
            moveNorth = true;
        }

        if(Input.GetKey(KeyCode.RightArrow)) {
            moveEast = true;
        }

        if(Input.GetKey(KeyCode.DownArrow)) {
            moveSouth = true;
        }

        if(Input.GetKey(KeyCode.LeftArrow)) {
            moveWest = true;
        }
    }
}
