using UnityEngine;

public class Follow : MonoBehaviour {
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    public GameObject playerCharacters;
    private PlayerCharactersLoader charactersLoader;
    private Transform target;

    private void Start() {
        charactersLoader = new PlayerCharactersLoader(playerCharacters);
        target = charactersLoader.GetCharacter(CharacterSwapIndexTracker.CurrentId).GetComponent<Transform>();
    }

    void LateUpdate() {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
