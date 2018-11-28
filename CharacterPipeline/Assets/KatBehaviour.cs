using UnityEngine;

static class Kat {
    public const string Walking = "KatWalking";
    public const string NotWalking = "KatNotWalking";
}

public class KatBehaviour : MonoBehaviour {
    Animator animator;
    KeyCode lastKey;
    public float speed = 0.15f;

    void Start () {
        animator = GetComponent<Animator>();
	}

    void Update() {
        if (Input.GetKeyDown(KeyCode.D)) {
            setKatTriggerTo(Kat.Walking);
            setLastKeyTo(KeyCode.D);
        } else if (Input.GetKeyDown(KeyCode.S)) {
            setKatTriggerTo(Kat.NotWalking);
            setLastKeyTo(KeyCode.S);
        } else if (Input.GetKeyDown(KeyCode.A)) {
            setKatInitialPosition();
            setKatTriggerTo(Kat.Walking);
            setLastKeyTo(KeyCode.A);
        } else if (Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
        }
    }

    void FixedUpdate() {
        if (lastKey == KeyCode.A) {
            makeKatWalk();
        }    
    }

    void setKatTriggerTo(string trigger) {
        animator.SetTrigger(trigger);
    }

    void setLastKeyTo(KeyCode key) {
        lastKey = key;
    }

    void setKatInitialPosition() {
        transform.position = new Vector3(10f, 0f, -25f);
    }

    void makeKatWalk() {
        var currentPosition = transform.position;
        var newPosition = calculateNewPosition(currentPosition);
        setNewPosition(newPosition);
        resetKatPositionIfNeeded(currentPosition);
    }

    Vector3 calculateNewPosition(Vector3 currentPosition) {
        var newPosition = currentPosition;
        newPosition.z += speed;
        return newPosition;
    }

    void setNewPosition(Vector3 newPosition) {
        transform.position = newPosition;
    }

    void resetKatPositionIfNeeded(Vector3 currentPosition) {
        if (currentPosition.z > 25) {
            setKatInitialPosition();
        }
    }
}
