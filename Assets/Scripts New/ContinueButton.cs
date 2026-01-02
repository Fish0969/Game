using UnityEngine;
using UnityEngine.UI;

public class ContinueButton : MonoBehaviour
{
    public GameObject fred;
    public GameObject bob;

    public GameObject Gameplay;

    public GameObject Continue;
    public void ContinueButtonAppear()
    {

        if (fred.activeSelf || bob.activeSelf)
        {
            Continue.SetActive(true);
        }
    }
}
