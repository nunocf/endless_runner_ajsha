using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private PlayerController player;
    private Vector3 lastPlayerPosition;
    private float distanceToMove;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        lastPlayerPosition = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        distanceToMove = player.transform.position.x - lastPlayerPosition.x;
        transform.position = transform.position + new Vector3(distanceToMove, 0, 0);

        lastPlayerPosition = player.transform.position;
    }
}
