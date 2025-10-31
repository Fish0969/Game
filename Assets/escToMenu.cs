using UnityEngine;

public class escToMenu : MonoBehaviour
{
    public GameObject restartScreen;
    public GameObject cam;
    public GameObject crosshair;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            cam.SetActive(false);
            restartScreen.SetActive(true);
            Time.timeScale = 0;
        }

    }
}
