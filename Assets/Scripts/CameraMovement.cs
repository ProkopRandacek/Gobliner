using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform PlayerPos;
    public float startX;
    public float startY;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    public float xOffset;
    private Vector3 newPos;

    void Start()
    {
        StartPos();
    }
    void Update()
    {
        if (PlayerPos.transform.position.x > minX && PlayerPos.transform.position.x < maxX)
        {
            newPos = new Vector3(PlayerPos.transform.position.x - xOffset, transform.position.y, transform.position.z);
            transform.position = newPos;
        }
        if (PlayerPos.transform.position.y / 2 > minY && PlayerPos.transform.position.y / 2 < maxY)
        {
            newPos = new Vector3(transform.position.x, PlayerPos.transform.position.y / 2, transform.position.z);
            transform.position = newPos;
        }
    }
    public void StartPos()
    {
        transform.position = new Vector3(startX, startY, -10);
    }
}
