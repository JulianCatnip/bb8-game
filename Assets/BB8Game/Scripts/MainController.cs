using UnityEngine;

public class MainController : MonoBehaviour
{

    public UDPReceiver updReceiver;
    public Transform targetTransform;
    private Quaternion targetRotation;

    void Start ()
    {
        UDPReceiver.AccelCallBack += AccelAction;
        UDPReceiver.GyroCallBack += GyroAction;
        updReceiver.UDPStart ();
    }

    public void AccelAction (float xx, float yy, float zz)
    {

    }

    public void GyroAction(float xx, float yy, float zz, float ww)
    {
        var newQut = new Quaternion(0, 0, (-1) * yy, ww);
        targetRotation = newQut;
    }

    void Update ()
    {
        targetTransform.localRotation = targetRotation;
    }
}