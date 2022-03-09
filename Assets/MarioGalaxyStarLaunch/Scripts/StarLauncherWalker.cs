using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class StarLauncherWalker : SplineWalker
{
	private Queue<PathEvents> events;
	public Queue<PathEvents> Events { set { events = value; } }

	public GameObject player;

	private void Start()
    {
		this.gameObject.transform.position = spline.GetControlPoint(0);
	}

    private void Update()
	{
		if (goingForward)
		{
			progress += Time.deltaTime / duration;
			if (progress > 1f)
			{
				if (mode == SplineWalkerMode.Once)
				{
					player.GetComponent<CharacterMovement>().Landing();
					
					this.gameObject.transform.DetachChildren();
					progress = 1f;
					Destroy(this.gameObject);
				}
				else if (mode == SplineWalkerMode.Loop)
				{
					progress -= 1f;
				}
				else
				{
					progress = 2f - progress;
					goingForward = false;
				}
			}
		}
		else
		{
			progress -= Time.deltaTime / duration;
			if (progress < 0f)
			{
				progress = -progress;
				goingForward = true;
			}
		} 


		if (events.Count > 0)
		{
			if (events.Peek().progress <= progress)
			{
				PathEvents pathEvent = events.Dequeue();
				transform.rotation *= Quaternion.Euler(pathEvent.rotationWalker);
				player.transform.rotation *= Quaternion.Euler(pathEvent.rotationPlayer);
				if(pathEvent.camera != null)
                {
					pathEvent.camera.LookAt = player.transform;
					pathEvent.camera.MoveToTopOfPrioritySubqueue();
                }
			}
		}

		Vector3 position = spline.GetPoint(progress);
		transform.localPosition = position;
		if (lookForward)
		{
			transform.LookAt(position + spline.GetDirection(progress));
		}
	}
}
