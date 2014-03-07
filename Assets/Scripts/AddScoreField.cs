using UnityEngine;
using System.Collections;

public class AddScoreField : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col)
	{
		if( col.CompareTag("Player"))
			DataSet.SetInt( "SCORE", DataSet.GetInt("SCORE") + 1);
	}
}
