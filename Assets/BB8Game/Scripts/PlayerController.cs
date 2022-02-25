using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public UDPReceiver updReceiver;
    [SerializeField] private Transform playerHead;
    [SerializeField] private Rigidbody playerBody;
    public float speed;
    public float maxSpeed;

    private Transform targetTransform;
    private float moveHorizontal;
    private float moveVertical;
    private Quaternion targetRotation;

    private Vector3 startPosition;

    private AudioSource audioSource;
    public AudioClip helloSound;
    public AudioClip moveSound;

    // Start is called before the first frame update
    void Start()
    {
        playerHead.GetComponent<Transform>();
        playerBody.GetComponent<Rigidbody>();
        targetTransform = playerBody.GetComponent<Transform>();

        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = helloSound;
        audioSource.Play();
        audioSource.clip = moveSound;

        // reset playerHead
        playerHead.SetPositionAndRotation(playerBody.transform.position, playerBody.transform.rotation);

        // UDP
        UDPReceiver.AccelCallBack += AccelAction;
        UDPReceiver.GyroCallBack += GyroAction;
        updReceiver.UDPStart();

    }

    public void AccelAction(float xx, float yy, float zz)
    {

    }

    public void GyroAction(float xx, float yy, float zz, float ww)
    {
        // head movement
        Quaternion newQuat = new Quaternion((-1) * xx, 0, (-1) * yy, ww);
        targetRotation = newQuat.normalized;

        // body movement
        moveHorizontal = (-1) * xx;
        moveVertical = (-1) * yy;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        /* KEYBOARD MOVEMENT 
        // get movement
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        // move playerBody
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical); // x,y,z
        playerBody.AddForce(movement * speed, ForceMode.Force);
        // move playerHead
        Vector3 movementDirection = Vector3.Normalize(movement);
        Quaternion headRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
        */

        /* ZigSim MOVEMENT  */
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        playerBody.AddForce(movement * speed, ForceMode.Acceleration); // ForceMode.Force

        playerBody.velocity = Vector3.ClampMagnitude(playerBody.velocity, maxSpeed);

        Quaternion headRotation = targetRotation;
        playerHead.SetPositionAndRotation(playerBody.transform.position, headRotation);

        /* MOVEMENT SOUND */
        if (playerBody.velocity.magnitude > 0.01)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }

        }
        else
        {
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
    }
}