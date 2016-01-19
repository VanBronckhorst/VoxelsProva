using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	public World world;
	float fallSpeed = 20f;
	public float playerCenterHeight;
	public float speed;
	public Modify pointer;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	

		transform.position += pointer.transform.forward  * speed *  Input.GetAxis("Vertical") * Time.deltaTime;
		transform.position += pointer.transform.right * speed  * Input.GetAxis("Horizontal") * Time.deltaTime;

		int blockX = FastFloor (transform.position.x);
		int blockY = FastFloor (transform.position.y);
		int blockZ = FastFloor (transform.position.z);


		if (world.GetBlock (blockX, blockY, blockZ).IsSolid (Block.Direction.up)) {
			// Inside Solid block
			int i=1;
			while (world.GetBlock (blockX, blockY + i, blockZ).IsSolid (Block.Direction.up)) {
				i++;
			}
			transform.position = new Vector3 (transform.position.x, blockY + i + playerCenterHeight,transform.position.z);

		}else if (!world.GetBlock(blockX,blockY - 1,blockZ).IsSolid(Block.Direction.up)) {
			// Flying
			transform.position -= new Vector3(0,1,0) * fallSpeed * Time.deltaTime;
		}
	}

	private int FastFloor(float x)
	{
		return (x > 0) ? ((int)x) : (((int)x) - 1);
	}
}
