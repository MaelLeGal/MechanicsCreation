using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class StarLauncherWalker : SplineWalker
{
	private Queue<PathEvents> events;
	public Queue<PathEvents> Events { set { events = value; } }

	public GameObject character;
	public Animator characterAnimator;

	private void Start()
    {
		this.gameObject.transform.position = spline.GetControlPoint(0);
		characterAnimator = character.GetComponent<Animator>();
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

					Destroy(this.GetComponentInChildren<TrailRenderer>().gameObject);
					character.transform.rotation = Quaternion.identity;
					character.GetComponent<Character>().SetNewState(CharacterStateEnum.FALLING); // Change to notification ?
					
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
			ProcessPathEvent();
		}

		Vector3 position = spline.GetPoint(progress);
		transform.position = position; // Was transform.localPosition
		
		
		if (lookForward)
		{
			transform.LookAt(position + spline.GetDirection(progress));
		}

		transform.up = position + spline.GetDirection(progress);
		//character.transform.localEulerAngles = new Vector3(90, 0, 0);
		//character.transform.up = (position + spline.GetDirection(progress));
	}

	private void ProcessPathEvent()
    {
		if (events.Peek().progress <= progress)
		{
			PathEvents pathEvent = events.Dequeue();

			if(pathEvent.animationName != null)
            {
				characterAnimator.SetTrigger(pathEvent.animationName);
			}

			if (pathEvent.camera != null)
			{
				if (pathEvent.cameraTargets.lookAt)
				{
					pathEvent.camera.LookAt = pathEvent.cameraTargets.lookAt;
				}
				if (pathEvent.cameraTargets.follow)
				{
					pathEvent.camera.Follow = pathEvent.cameraTargets.follow;
				}
				pathEvent.camera.MoveToTopOfPrioritySubqueue();
			}
		}
	}
}
