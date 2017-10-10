using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintTool : MonoBehaviour {

	// Use this for initialization
	Vector3 position;
	public GameObject[] prefabs;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//arreglar el random
		var ran = Random.Range (0, 2);
		Debug.Log (ran);
		if(Input.GetMouseButtonDown(0))
		{
			LocatePosition();
			for (int i = 0; i < prefabs.Length; i++)
			{
				var e = prefabs [ran];
				Instantiate (e, position,Quaternion.identity);
			}
		}
	}

	void LocatePosition()
	{

		RaycastHit hit;
		Ray ray= Camera.main.ScreenPointToRay(Input.mousePosition);
		if(Physics.Raycast(ray,out hit,1000))
		{
			position =  new Vector3(hit.point.x, hit.point.y, hit.point.z);
			Debug.Log (position);
		}
	}
}
