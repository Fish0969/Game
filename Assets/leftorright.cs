using System.Collections;
using UnityEngine;

public class leftorright : MonoBehaviour
{

    public GameObject player1;
    public GameObject player2;
    void Start()
    {
        // StartCoroutine(Decide());

    }

    // IEnumerator Decide()
    // {
    //     if (player1.activeSelf)
    //     {
    //         player2.SetActive(true);
    //         player1.SetActive(false);
    //     }
    //     if (!player1.activeSelf)
    //     {
    //         player1.SetActive(true);
    //         player2.SetActive(false);
    //     }
    // }
}
