using UnityEngine;

public class Body : MonoBehaviour
{
	private Attractor _attractor;

	private Transform _transform;
	private Rigidbody _rigidbody;

	private void Start()
	{
		_attractor = FindObjectOfType<Attractor>();

		_transform = transform;
		_rigidbody = GetComponent<Rigidbody>();

		_rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
		_rigidbody.useGravity = false;
	}

	private void FixedUpdate()
	{
		Attract();
	}

	private void Attract()
	{
		Vector3 gravityUp = (_transform.position - _attractor.transform.position).normalized;
		Vector3 bodyUp = _transform.up;

		_rigidbody.AddForce(gravityUp * -_attractor.gravity);

		Quaternion bodyRotation = _transform.rotation;
		Quaternion targetRotation = Quaternion.FromToRotation(bodyUp, gravityUp) * bodyRotation;
		bodyRotation = Quaternion.Slerp(bodyRotation, targetRotation, _attractor.rotationSpeed * Time.fixedDeltaTime);
		_transform.rotation = bodyRotation;
	}
}
