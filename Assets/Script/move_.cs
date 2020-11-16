using UnityEngine;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(Rigidbody))]
public class move_ : MonoBehaviour
{
    public float Speed = 10f;
    private Rigidbody _rb;
    public Quaternion calibrationQuaternion;
    public Joystick joystickUI;
    //public Joystick joystickVertical;
    [Header("Инвертирование движение")]
    public   bool Snap = false;

    public static bool MoveControls;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        CalibtationAccelerometr();
    }

    // обратите внимание что все действия с физикой
    // необходимо обрабатывать в FixedUpdate, а не в Update
    void FixedUpdate()
    {
        MovementLogic(); ;
    }

    public void CalibtationAccelerometr()
    {
        Vector3 accelerometrSnapshot = Input.acceleration;
        Quaternion rotateQuaternion = Quaternion.FromToRotation(new Vector3(0.0f, 0.0f, -1.0f), accelerometrSnapshot);
        calibrationQuaternion = Quaternion.Inverse(rotateQuaternion);
    }
    public Vector3 FixeAcceleration(Vector3 accelerometr)
    {
        Vector3 fixedAccelerometr = calibrationQuaternion * accelerometr;
        return fixedAccelerometr;
    }

    private void MovementLogic()
    {
        //пк
        /*float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);*/

        // android
        Vector3 direction = new Vector3();
        if (MoveControls)
        {
            Vector3 accelerationRaw = Input.acceleration;
            Vector3 acceleration = FixeAcceleration(accelerationRaw);
            if (acceleration.sqrMagnitude > 1)
                acceleration.Normalize();
             direction = new Vector3(acceleration.x, 0.0f, acceleration.y);
        }
        else
        {
             direction = Vector3.forward * joystickUI.Vertical + Vector3.right * joystickUI.Horizontal;
        }
        if (Snap)
        {
            direction = (-1) * direction;
        }
        _rb.AddForce(direction * Speed * Time.fixedDeltaTime, ForceMode.VelocityChange);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Death")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (other.tag.Equals("Victory"))
        {
            GamesManager.GameIsVictory = true;
        }
        if (other.tag.Equals("MovePlatform"))
        {
            this.transform.parent = other.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("MovePlatform"))
        {
            this.transform.parent = null;
        }
    }
}