using UnityEngine;

public class obstacle : MonoBehaviour
{
    public delegate void playerHitAction();
    public static event playerHitAction OnPlayerHit;
    private void OnCollisionEnter(Collision collision)
    {
        OnCollision(collision);
    }

    internal virtual void OnCollision(Collision collision)
    {
        if(collision.collider.tag.Equals("Player"))
        {
            Debug.Log("Player collided with obstacle");
        }
        OnPlayerHit.Invoke();
    }
}
