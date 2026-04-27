using UnityEngine;
using static GameManager;
public class FinishGate : MonoBehaviour
{
    public static event TimerEvent FinishRaice; 
    void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            FinishRaice.Invoke();
        }
    }
}
