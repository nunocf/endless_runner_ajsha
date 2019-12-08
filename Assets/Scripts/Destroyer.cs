using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private GameObject destructionPoint;
    // Start is called before the first frame update
    void Start()
    {
        destructionPoint = GameObject.Find("DestructionPoint");
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < destructionPoint.transform.position.x)
        {
            gameObject.SetActive(false);
            // Destroy(gameObject);
        }
    }
}
