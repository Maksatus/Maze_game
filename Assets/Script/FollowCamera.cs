using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    //follow player
    
    [SerializeField] private Transform target;
    [SerializeField] private float smooth = 5.0f;
    [SerializeField] private Vector3 offset = new Vector3(0, 0, 0);
    //[SerializeField] private Quaternion rotate = new Quaternion();

    private Quaternion oldRotation;
    private Vector3 speed;
    private Vector3 oldPosition;

    private void Start()
    {
        oldPosition = target.position;
        oldRotation = target.rotation;
    }
    void Update()
    {
        speed = (target.position - oldPosition);


        //var offsetPos = new Vector3 (offset.x, offset.y, offset.z + 0.015f);
        //transform.rotation = Quaternion.Lerp(transform.rotation,rotate, Time.deltaTime * smooth);
        transform.position = Vector3.MoveTowards(transform.position, target.position + offset, Time.deltaTime * smooth);
        // transform.rotation = Quaternion.Lerp(transform.rotation, oldRotation, Time.deltaTime * smooth);
        transform.position = Vector3.MoveTowards(transform.position, target.position + offset, Time.deltaTime * smooth);

        oldPosition = target.position;
    }

    void rotate()
    {
        transform.localEulerAngles = Vector3.Lerp(transform.position, target.position + offset, Time.deltaTime* smooth);
    }
}
