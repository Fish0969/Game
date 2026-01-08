using UnityEngine;
using UnityEngine.SceneManagement;

public class resetScene : MonoBehaviour
{
    public void Reset()
    {
        // Reset challenge progress before reloading scene
        Save saveSystem = FindObjectOfType<Save>();
        if (saveSystem != null)
        {
            saveSystem.ResetProgress();
        }
        
        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}