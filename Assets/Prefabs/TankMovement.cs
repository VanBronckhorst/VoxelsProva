using UnityEngine;
using System.Collections;

public class TankMovement : MonoBehaviour {

	public float speed = 20f;
	public float rotSpeed = 180f;

	private Rigidbody rb;


	void Awake() {
		rb = GetComponent<Rigidbody> ();
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float hor = Input.GetAxis ("Horizontal");
		float ver = Input.GetAxis ("Vertical");

		Vector3 movement = transform.forward * speed * ver * Time.deltaTime;
		Quaternion rot = Quaternion.Euler (0, rotSpeed*hor* Time.deltaTime, 0);

		rb.MovePosition (rb.position + movement);
		rb.rotation *= rot;
	}
}
