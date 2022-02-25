using UnityEngine;
using UnityEngine.EventSystems;

public class Cube : MonoBehaviour
{
    [SerializeField]
    private float speed = 0f;
    [SerializeField]
    private GameObject TextObject;

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            speed = 0f;
            ExecuteEvents.Execute<IReceiveMessage>(
                target: TextObject,
                eventData: null,
                functor: (recieveTarget, y) => recieveTarget.OnRecieve("Game Over")
            );
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Finish")
        {
            speed = 0f;
            ExecuteEvents.Execute<IReceiveMessage>(
                target: TextObject,
                eventData: null,
                functor: (recieveTarget, y) => recieveTarget.OnRecieve("Clear!")
            );
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.forward * speed * Time.deltaTime;
    }
}
