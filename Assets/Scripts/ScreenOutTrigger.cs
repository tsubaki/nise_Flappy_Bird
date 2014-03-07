using UnityEngine;
using System.Collections;

public class ScreenOutTrigger : MonoBehaviour {

	void OnTriggerExit2D(Collider2D col)
	{
		Rigidbody2D attachedRigidbody = col.attachedRigidbody;

		if( attachedRigidbody.CompareTag("Box") )
		{
			attachedRigidbody.transform.localPosition = new Vector3(7, col.transform.localPosition.y, 0); 
		}

		if( attachedRigidbody.CompareTag("Block"))
		{
			float y = Random.Range(-3.0f, 3.0f);
			attachedRigidbody.transform.localPosition = new Vector3(5, y, 0); 
		}
	}
}
