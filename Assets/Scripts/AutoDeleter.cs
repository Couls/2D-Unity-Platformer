using UnityEngine;

public class AutoDeleter : MonoBehaviour {
    [SerializeField] private float fallDistanceToDelete = 20f;

    private float originalPositionY;

    private void Start() {
        originalPositionY = transform.position.y;
    }

    private void Update() {
        if (Mathf.Abs(transform.position.y - originalPositionY) > fallDistanceToDelete) {
            Destroy(transform.gameObject, 0.1f);
        }
    }
}
