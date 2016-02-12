using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	public int velocidade;
	// Use this for initialization
	void Start () {
		moveSpeed = 20f;
		velocidade = 30;
	}
	
	// Update is called once per frame
	void Update () {

		transform.Translate (moveSpeed * Input.GetAxis("Horizontal")*Time.deltaTime, 0f, moveSpeed * Input.GetAxis("Vertical")*Time.deltaTime);
		if(Input.GetKey(KeyCode.RightArrow))
			transform.Rotate(Vector3.up * velocidade * Time.deltaTime);
		if (Input.GetKey (KeyCode.LeftArrow))
			transform.Rotate (Vector3.down * velocidade * Time.deltaTime);
	}
}
