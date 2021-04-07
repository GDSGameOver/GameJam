using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayInside : MonoBehaviour {


	void Update () {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -8.3f, 8.3f),
            Mathf.Clamp(transform.position.y, -2.48f, 4.7f), transform.position.z);
	}
}
