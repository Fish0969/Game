using UnityEngine;

public class escToMenu : MonoBehaviour
{
    public GameObject restartScreen;
    public GameObject gameplay;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameplay.SetActive(false);
            restartScreen.SetActive(true);
        }
    }
}
