
using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {

	public float moveSpeed;
	private GameObject mainCamera;

	private Transform target;
	private Vector3 offset;

	// Use this for initialization
	void Start () {

		//Udemy Code
		//Kod ile çocugun pozisiyonu alındı
		target = GameObject.Find("Player").transform;
		//Youtube
		//Kamera ile hedefin arasındaki mesafe hesaplandı
		offset = transform.position - target.position;

		//Original Code
		//mainCamera.transform.localPosition = new Vector3 ( 0, 10, -10 );
		//mainCamera.transform.localRotation = Quaternion.Euler (0, 0, 0);

	}
	void LateUpdate()
	{
		//Udemy Code
		//cameraToPlayerDistance = new Vector3(playerPosition.position.x, transform.position.y, playerPosition.position.z - 10);
		//transform.position = Vector3.Lerp(transform.position, cameraToPlayerDistance, Time.deltaTime);
		//Youtube
		//Kamera ile hedefin arasındaki mesafe ile hedefin pozisiyuna eklendi.
		//Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, offset.z + target.position.z);
	    //transform.position = newPosition;

	}

	// Update is called once per frame
	void Update () {

		
	}

	void FixedUpdate()
	{
		moveCameraWithTarget();

		//Original Code
		/*if (Input.GetKeyDown (KeyCode.A)) {
			ChangeView01();
		}
		
		if (Input.GetKeyDown (KeyCode.S)) {
			ChangeView02();
		}*/
		
	}
	
	
	void moveCameraWithTarget() {

		/*float moveAmount = Time.smoothDeltaTime * moveSpeed;
		transform.Translate ( 0f, 0f, moveAmount );	*/

		// Kamera ile hedefin arasındaki mesafe ile hedefin pozisiyuna eklendi.
		Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, offset.z + target.position.z);

		transform.position = Vector3.Lerp(transform.position, newPosition, 10 * Time.deltaTime);

	}


	//Original Code

	void ChangeView01() {
		transform.position = new Vector3 (0, 2, 10);
		// x:0, y:1, z:52
		mainCamera.transform.localPosition = new Vector3 ( -8, 2, 0 );
		mainCamera.transform.localRotation = Quaternion.Euler (14, 90, 0);
	}

	void ChangeView02() {
		transform.position = new Vector3 (0, 2, 10);
		// x:0, y:1, z:52
		mainCamera.transform.localPosition = new Vector3 ( 0, 0, 0 );
		mainCamera.transform.localRotation = Quaternion.Euler ( 19, 180, 0 );
		moveSpeed = -20f;
		
	}
}























