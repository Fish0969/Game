using System.Data;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Events;

public class Hearth : MonoBehaviour
{
public UnityEvent Healing;


  public void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.CompareTag("Player"))
    {
      Healing.Invoke();
      Destroy(gameObject);
    }
  }

}
