using JetBrains.Annotations;
using UnityEngine;

public class Debuffs : MonoBehaviour
{

    public GameObject enemy;
    public GameObject player;
    public int RandomNumber;
    public void UnluckyButtonPress()
    {
        RandomNumber = Random.Range(1,10);
        Debug.Log(RandomNumber);
        if (RandomNumber == 1)
        {
         player.GetComponent<MoveScript>().walkingSpeed = 1;   
        }
                if (RandomNumber == 2)
        {
            
        }
                if (RandomNumber == 3)
        {
            
        }
                if (RandomNumber == 4)
        {
            
        }
                if (RandomNumber == 5)
        {
            
        }
                if (RandomNumber == 6)
        {
            
        }
                if (RandomNumber == 7)
        {
            
        }
                if (RandomNumber == 8)
        {
            
        }

                if (RandomNumber == 9)
        {
            
        }
                if (RandomNumber == 10)
        {
            
        }

    }
}
