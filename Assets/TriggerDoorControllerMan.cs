using UnityEngine;

public class TriggerDoorControllerMan : MonoBehaviour
{
    [SerializeField] private Animator mydoor = null;
    [SerializeField] private GameObject pressureplate;
    [SerializeField] private bool open = false;
    [SerializeField] private bool close = false;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (open)
            {
                mydoor.Play("mandooropen", 0, 0.0f);
                gameObject.SetActive(false);
            }
            if (close)
            {
                mydoor.Play("mandoorclose", 0, 0.0f);
                gameObject.SetActive(false);
                pressureplate.SetActive(false);
            }
        }
    }

}
