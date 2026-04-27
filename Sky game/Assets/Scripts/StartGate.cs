using UnityEngine;
using static GameManager;

public class StartGate : MonoBehaviour
{
    public static event TimerEvent StartRaice; 
    void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            StartRaice.Invoke();
        }
    }
}
