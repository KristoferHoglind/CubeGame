using UnityEngine;

public class Jump : MonoBehaviour {
    public int forceConst = 5;
    public GameManager gameManager;

    private Rigidbody selfRigidbody;
    private bool isGrounded;
    private bool canDoDoubleJump = false;
    private int noJumps = 0;
    private int noDoubleJumps = 0;
    private bool isFinished = false;

    void Start() {
        selfRigidbody = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.layer == 9 || collision.gameObject.layer == 11
            && !isGrounded) {
            isGrounded = true;
        }

        if(collision.gameObject.layer == 11 && isGrounded) {
            if(!isFinished) {
                gameManager.CompleteLevel();
                isFinished = true;
            }
        }
    }

    void OnCollisionExit(Collision collision) {
        if(collision.gameObject.layer == 9
            && isGrounded) {
            canDoDoubleJump = true; // if still in air, only do double jump
        }
    }

    void Update() {
        if(Input.GetKeyUp(KeyCode.Space)) {
            if(isGrounded) {
                isGrounded = false;
                canDoDoubleJump = true;
                selfRigidbody.velocity = new Vector3(selfRigidbody.velocity.x, 0, selfRigidbody.velocity.z);
                selfRigidbody.AddForce(0, forceConst, 0, ForceMode.Impulse);
                noJumps++;
            } else {
                if(canDoDoubleJump) {
                    canDoDoubleJump = false;
                    selfRigidbody.velocity = new Vector3(selfRigidbody.velocity.x, 0, selfRigidbody.velocity.z);
                    selfRigidbody.AddForce(0, forceConst, 0, ForceMode.Impulse);
                    noDoubleJumps++;
                }
            }
        }

    }

    public int GetNoJumps() {
        return noJumps;
    }

    public int GetNoDoubleJumps() {
        return noDoubleJumps;
    }

}
