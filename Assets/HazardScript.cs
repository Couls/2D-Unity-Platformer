using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class HazardScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Player") // reset scene
        {
            col.gameObject.transform.position = new Vector3(-5.5f, -3.26f, 0f);
            SceneManager.LoadScene("MainMenu");
        }
    }
}
