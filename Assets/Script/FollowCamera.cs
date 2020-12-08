using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    //follow player
    
    [SerializeField] private Transform target;
    [SerializeField] private float smooth = 5.0f;
    [SerializeField] private Vector3 offset = new Vector3(0, 0, 0);
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position + offset, Time.deltaTime * smooth);
    }
}
