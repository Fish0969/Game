using JetBrains.Annotations;
using TMPro;
using UnityEngine;

public class LuckyButton : MonoBehaviour, IInteractable
{
        public GameObject enemy;
        public GameObject player;
        public GameObject Fred;
        public GameObject Bob;
        private int RandomNumber;
        public GameObject buttons;
        public TextMeshProUGUI bufftext;
        public GameObject laser;
        public GameObject Gun;
        public GameObject scripts;

 public void Interact()
    {
        UnluckyButtonPress();
        Debug.Log("Button pressed");
        disActivate();
                if (Fred.activeSelf)
        {
            player = Fred;
        }

        if (Bob.activeSelf)
        {
            player = Bob;
        }

        
    }
    public void disActivate()
        {
                buttons.SetActive(false);
        }
    public void UnluckyButtonPress()
    {
        RandomNumber = Random.Range(1,10);
        Debug.Log(RandomNumber);
        if (RandomNumber == 1)
        {
         player.GetComponent<MoveScript>().walkingSpeed = player.GetComponent<MoveScript>().walkingSpeed*0.95f;   
         Debug.Log("Rolled 1");   
        
        bufftext.text = ("Last buff / debuff: \n Walking speed decreased ");

        }
                if (RandomNumber == 2)
        {
        enemy.GetComponent<enemylookingplayer>().speed = enemy.GetComponent<enemylookingplayer>().speed* .95f;   
        Debug.Log("Rolled 2");   
        
        bufftext.text = ("Last buff / debuff: \n Enemy speed decreased ");
        }
                if (RandomNumber == 3)
        {
            enemy.GetComponent<enemylookingplayer>().detectionRadius = enemy.GetComponent<enemylookingplayer>().detectionRadius* .95f;   
        Debug.Log("Rolled 3");   
        
        bufftext.text = ("Last buff / debuff: \n Enemy hit range decreased ");
        }
                if (RandomNumber == 4)
        {
        enemy.GetComponent<enemylookingplayer>().attackInterval = enemy.GetComponent<enemylookingplayer>().attackInterval*0.95f;   
        Debug.Log("Rolled 4");   
        
        bufftext.text = ("Last buff / debuff: \n Enemy attack speed decreased ");
        }
                if (RandomNumber == 5)
        {
            enemy.GetComponent<enemylookingplayer>().damageAmount = enemy.GetComponent<enemylookingplayer>().damageAmount*1.1f;   
        Debug.Log("Rolled 5");   
        
        bufftext.text = ("Last buff / debuff: \n Enemy damage increased ");
        }
                if (RandomNumber == 6)
        {
            enemy.GetComponent<entity>().StartingHealth = enemy.GetComponent<entity>().StartingHealth*.95f;   
        Debug.Log("Rolled 6");   
        
        bufftext.text = ("Last buff / debuff: \n Enemy health decreased ");
        }
                if (RandomNumber == 7)
        {
            player.GetComponent<MoveScript>().MaxStamina = player.GetComponent<MoveScript>().MaxStamina*1.1f;   
        Debug.Log("Rolled 7");   
        
        bufftext.text = ("Last buff / debuff: \n Max stamina increased ");
        }
                if (RandomNumber == 8)
        {
            laser.GetComponent<LaserDamage>().Damage = laser.GetComponent<LaserDamage>().Damage*1.1f;
            Gun.GetComponent<DamageGun>().Damage = Gun.GetComponent<DamageGun>().Damage*1.1f;   
        Debug.Log("Rolled 8");   
        
        bufftext.text = ("Last buff / debuff: \n Damage increased ");
        }

                if (RandomNumber == 9)
        {
            player.GetComponent<MoveScript>().MaxStamina = player.GetComponent<MoveScript>().MaxStamina*1.1f;   
        Debug.Log("Rolled 9");   
        
        bufftext.text = ("Last buff / debuff: \n Max stamina increased ");
        }
                if (RandomNumber == 10)
        {
            player.GetComponent<MoveScript>().walkingSpeed = player.GetComponent<MoveScript>().walkingSpeed*1.1f;   
        Debug.Log("Rolled 10");   

        bufftext.text = ("Last buff / debuff: \n Walking Speed increased");
        }

    }
}
