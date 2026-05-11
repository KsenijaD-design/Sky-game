using UnityEngine;
using static GameManager;

public class karogs : MonoBehaviour
{
    private enum Direction {Left, Right};

    [SerializeField] private Direction flagDirection;
    private bool flagPassed = false;
    [SerializeField] private Material good, bad;
    public static event TimerEvent Penalty; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerControler.playerposition != null && PlayerControler.playerposition.position.z < transform.position.z
            && !flagPassed)
        {
            flagPassed = true; 
            Direction direction = Direction.Right;
            if (PlayerControler.playerposition.position.x < transform.position.x)
            {
                direction = Direction.Left;
            }
            
            MeshRenderer mr = GetComponent<MeshRenderer>();
            if (direction == flagDirection)
            {
                mr.material = good;
            }
            else
            {
                mr.material = bad;
                Penalty.Invoke();
            }
        }
        
    }
}
