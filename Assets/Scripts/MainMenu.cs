using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Vector3 initialpos = new Vector3(-5.5f, -3.26f, 0f);
    public Vector3 playerpos;
    public Vector3 temppos;
    public bool saved = false;
    public bool loading = false;
    public void Awake()
    {
        temppos = new Vector3(PlayerPrefs.GetFloat("FinalX"), PlayerPrefs.GetFloat("FinalY"), PlayerPrefs.GetFloat("FinalZ"));
    }
    public void PlayGame()
    {
        Debug.Log("Play Game");
        SceneManager.LoadScene("SampleScene");
    }
    public void LoadGame()
    {
        if (PlayerPrefs.HasKey("SavedX")) // if we saved their x position we probably saved their y and z
        {
            loading = true;
            SceneManager.LoadScene("SampleScene");
            if (PlayerPrefs.GetInt("GameSaved") == 1)
            {
                Debug.Log("Loading The save and setting playerpos to temppos");
                playerpos = temppos;
                PlayerPrefs.Save();
            }
            SceneManager.sceneLoaded += LoadFinalize;
            Debug.Log("Game data loaded!");
        }
        else
            Debug.LogError("There is no save data!");
    }
    public void LoadFinalize(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "SampleScene")
        {
            GameObject player = GameObject.Find("Player");
            if (loading)
            {
                player.transform.position = playerpos;
                loading = false;
            }
            else player.transform.position = initialpos;

        }
    }
    public void SaveGame()
    {
        // the fact that game is saved as true, save the final coordinates in a new save slot to remove the temporary ones
        PlayerPrefs.SetInt("GameSaved", 1);
        PlayerPrefs.SetFloat("FinalX", PlayerPrefs.GetFloat("SavedX"));
        PlayerPrefs.SetFloat("FinalY", PlayerPrefs.GetFloat("SavedY"));
        PlayerPrefs.SetFloat("FinalZ", PlayerPrefs.GetFloat("SavedZ"));
        temppos = new Vector3(PlayerPrefs.GetFloat("FinalX"), PlayerPrefs.GetFloat("FinalY"), PlayerPrefs.GetFloat("FinalZ"));
        PlayerPrefs.Save();
    }
    public void Settings()
    {
        Debug.Log("Settings");
    }

    public void ExitGame()
    {
        Debug.Log("Exit Game");
    }
}
