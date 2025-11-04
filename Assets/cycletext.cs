using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class cycletext : MonoBehaviour
{
    public GameObject characters;

    private int currentCharacter;
    private int characterCount;

    private void Start()
    {
        characterCount = characters.transform.childCount;
    }

public void CycleCharacter()
    {
        characters.transform.GetChild(currentCharacter).gameObject.SetActive(false);
        currentCharacter = (currentCharacter + 1) % characterCount;
        characters.transform.GetChild(currentCharacter).gameObject.SetActive(true);
    }
}
