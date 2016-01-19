using UnityEngine;
using System.Collections;

public class Modify : MonoBehaviour
{
	
	Vector2 rot;
	Rigidbody rb;


	void Start() {
		//playerHeight = transform.position.y;
	}

	void Update()
	{
		if (Input.GetButtonDown("Fire1"))
		{
			RaycastHit hit;
			if (Physics.Raycast(transform.position, transform.forward,out hit, 100 ))
			{
				Debug.Log ("hit");
				EditTerrain.SetBlock(hit, new BlockAir());
			}
		}

//		rot= new Vector2(
//			rot.x + Input.GetAxis("Mouse X") * 3,
//			rot.y + Input.GetAxis("Mouse Y") * 3);
//
//		transform.localRotation = Quaternion.AngleAxis(rot.x, Vector3.up);
//		transform.localRotation *= Quaternion.AngleAxis(rot.y, Vector3.left);


	}

	private int FastFloor(float x)
	{
		return (x > 0) ? ((int)x) : (((int)x) - 1);
	}

}