using UnityEngine;

public class Exploding_obstacle : obstacle
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    internal override void OnCollision(Collision collision)
    {
        base.OnCollision(collision);
        Destroy(gameObject);
    }
}
