using UnityEngine;

public class FollowMainMenu : MonoBehaviour {
    public Transform target;

    void LateUpdate() {
        transform.LookAt(target);
        transform.Translate(Vector3.right * Time.deltaTime);
    }
}
