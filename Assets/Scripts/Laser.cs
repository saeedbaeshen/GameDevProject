using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour {

	LineRenderer laser;
	public int score;

	// Use this for initialization
	void Start () {

		laser = gameObject.GetComponent<LineRenderer> ();
		laser.enabled = false;
		score = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.F)) {
			StopCoroutine ("FireLaser");
			StartCoroutine ("FireLaser");
		}
	}

	IEnumerator FireLaser()
	{
		laser.enabled = true;

		while (Input.GetKey (KeyCode.F)) {
			Ray ray = new Ray (transform.position, transform.forward);
			RaycastHit hit;

			laser.SetPosition (0, ray.origin);

			if (Physics.Raycast (ray, out hit, 200)) {
				laser.SetPosition (1, hit.point);
				if (hit.rigidbody) {

					if (hit.rigidbody.tag == "cube") {
						score++;
					}
					hit.rigidbody.AddForceAtPosition (transform.forward * 10, hit.point);

				}
			}

			else
				laser.SetPosition (1, ray.GetPoint (200));

			yield return null;
		}

		laser.enabled = false;

	}



}
