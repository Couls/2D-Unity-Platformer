using UnityEngine;
using UnityEngine.UI;

public class EnemyCollisionDetector : MonoBehaviour {
    [SerializeField] private Slider playerHealthSlider;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            playerHealthSlider.value -= 10;
            Debug.Log("Ouch!");
        }
    }
}
