using UnityEngine;

public class weaponchange : MonoBehaviour
{
    public GameObject weapon1;
    public GameObject weapon2;
    public GameObject player;




    void Update()
    {
        if (player.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                weapon1.SetActive(true);
                weapon2.SetActive(false);
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                weapon1.SetActive(false);
                weapon2.SetActive(true);
            }
        }
    }
}
