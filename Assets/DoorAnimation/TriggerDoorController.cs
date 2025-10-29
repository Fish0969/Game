using UnityEngine;

public class TriggerDoorController : MonoBehaviour
{
    [SerializeField] private Animator mydoor = null;
    [SerializeField] private GameObject pressureplate;
    [SerializeField] private Animator Dead1;
    [SerializeField] private Animator Dead2;

    [SerializeField] private Animator wall;
    [SerializeField] private bool open = false;
    [SerializeField] private bool close = false;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (open)
            {
                mydoor.Play("wdooropen", 0, 0.0f);
                gameObject.SetActive(false);
            }
            if (close)
            {
                mydoor.Play("wdoorclose", 0, 0.0f);
                wall.Play("comeup", 0, 0.0f);
                Dead1.Play("Dead1", 0, 0.0f);
                Dead2.Play("Dead2", 0, 0.0f);
                gameObject.SetActive(false);
                pressureplate.SetActive(false);
            }


        }
    }
    

}
