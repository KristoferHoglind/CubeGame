using UnityEngine;

public class Fail : MonoBehaviour {

    public GameObject playerCharacters;
    private PlayerCharactersLoader charactersLoader;
    private Rigidbody playerRigidbody;
    private int noFails = 0;

    private void Start() {
        charactersLoader = new PlayerCharactersLoader(playerCharacters);
        GameObject player = charactersLoader.GetCharacter(CharacterSwapIndexTracker.CurrentId);
        playerRigidbody = player.GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter() {
        noFails++;
        playerRigidbody.position = new Vector3(0, 4f, 0);
        playerRigidbody.rotation = Quaternion.Euler(45f, 0, 45f);
        playerRigidbody.velocity = Vector3.zero;
        playerRigidbody.angularVelocity = Vector3.zero;
    }

    public int GetNoFails() {
        return noFails;
    }

}
