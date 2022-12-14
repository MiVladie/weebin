using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	public GameObject Player;

	public Vector3 PositionOffset;

    public float smoothTime = 0.15f;
    private Vector3 velocity = Vector3.zero;

	private void Start()
	{
		ResetCamera();
	}

	public void AssignPlayer(GameObject player)
	{
		Player = player;
	}

	private void FixedUpdate()
	{
		if(!Player)
			return;

		Vector3 desiredPosition = Player.transform.position + PositionOffset;
        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothTime);
	}

	public void ResetCamera()
	{
		if(!Player)
			return;
			
		transform.position = Player.transform.position + PositionOffset;
	}


}
