using UnityEngine;

public class TriggerDoorController : MonoBehaviour
{
    [SerializeField] private Animator mydoor = null;
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
                gameObject.SetActive(false);
            }
        }
    }

}
