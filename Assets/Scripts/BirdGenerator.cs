using UnityEngine;

public class BirdGenerator : MonoBehaviour {
    [Header("Generation Region")]
    [SerializeField] private float minimumX = -4f;
    [SerializeField] private float maximumX = 4f;
    [SerializeField] private float minimumY = -5f;
    [SerializeField] private float maximumY = 5f;

    [Header("Generation Parameters")]
    [SerializeField] private GameObject birdPrefab;
    [SerializeField] private int numToGenerate = 20;

    [ContextMenu("Generate")]
    public void Generate() {
        for (int i = 0; i < numToGenerate; i++) {
            // determine a random spawn location
            float xOffset = Random.Range(minimumX, maximumX);
            float yOffset = Random.Range(minimumY, maximumY);
            Vector3 newPosition = transform.position + new Vector3(xOffset, yOffset, 0f);

            // create a new bird
            GameObject newBird = Instantiate(birdPrefab, newPosition, Quaternion.identity, transform);

            // manually re-parent the object
            //newBird.transform.SetParent(transform);
        }
    }
}
