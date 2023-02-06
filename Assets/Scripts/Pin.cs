using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class Pin : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidBody;
    [SerializeField] private float _pinPower;
    [SerializeField] private Vector3 _torqueDirection;

    public void Beat()
    {
        _rigidBody.AddTorque(_torqueDirection * _pinPower);
    }

}
