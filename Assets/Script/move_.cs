using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class move_ : MonoBehaviour
{
    public float Speed = 10f;
    private Rigidbody _rb;


    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // обратите внимание что все действия с физикой 
    // необходимо обрабатывать в FixedUpdate, а не в Update
    void FixedUpdate()
    {
        MovementLogic();;
    }

    private void MovementLogic()
    {
        //пк
        /*float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);*/

        // android
        Vector3 acceleration = Input.acceleration;
        Vector3 movement = new Vector3(acceleration.x, 0.0f, acceleration.y);

        _rb.AddForce(movement*Speed);

    }

}
