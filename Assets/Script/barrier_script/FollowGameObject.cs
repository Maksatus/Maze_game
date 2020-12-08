using UnityEngine;

public class FollowGameObject : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0, 2, 0);
    private Vector3 speed;
    private Vector3 oldPosition;

    private void Start()
    {
        oldPosition = target.position;
    }

    void FixedUpdate()
    {
        speed = (target.position - oldPosition);
        if (speed.z<0 || speed.x < 0)
        {
            transform.position = new Vector3(target.position.x + offset.x, target.position.y + offset.y, target.position.z + offset.z);
        }
        if (speed.z > 0|| speed.x > 0)
        {
            transform.position = new Vector3(target.position.x - offset.x, target.position.y - offset.y*(-1), target.position.z - offset.z);
        }
        oldPosition = target.position;
    }
}
