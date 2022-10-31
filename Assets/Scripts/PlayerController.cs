using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float moveSpeed = 15f;

	private Vector3 _moveDirection;

	private Rigidbody _rigidbody;

	private void Start()
	{
		_rigidbody = GetComponent<Rigidbody>();
	}

	private void Update()
	{
		_moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
	}

	private void FixedUpdate()
	{
		_rigidbody.AddForce(transform.TransformDirection(_moveDirection) * (moveSpeed * Time.fixedDeltaTime), ForceMode.VelocityChange);
		_rigidbody.velocity = Vector3.ClampMagnitude(_rigidbody.velocity, moveSpeed);
	}
}
