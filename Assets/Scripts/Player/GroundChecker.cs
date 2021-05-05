using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] private GameObject _whatIsGround;

    public bool IsGrounded { get; private set; }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.layer == _whatIsGround.layer)
        {
            IsGrounded = true;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.layer == _whatIsGround.layer)
        {
            IsGrounded = false;
        }
        
    }
}
