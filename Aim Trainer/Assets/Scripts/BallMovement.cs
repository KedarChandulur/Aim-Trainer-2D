using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public Transform Ball;
    [SerializeField] float movementspeed = 2f;
	public bool playerDead;
    private void FixedUpdate()
    {
		if (this.transform != null)
		{
			if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
			{
				Ball.transform.Translate(Vector3.up * movementspeed * Time.deltaTime);
			}
			if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
			{
				Ball.transform.Translate(Vector3.down * movementspeed * Time.deltaTime);
			}
			if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
			{
				Ball.transform.Translate(Vector3.left * movementspeed * Time.deltaTime);
			}
			if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
			{
				Ball.transform.Translate(Vector3.right * movementspeed * Time.deltaTime);
			}
		}
    }
}
