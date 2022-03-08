using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarLauncherWalker : SplineWalker
{
	private PathEvents[] events;
	public PathEvents[] Events { set { events = value; } }

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
					GameObject player = transform.GetChild(0).gameObject;
					player.GetComponent<CharacterController>().enabled = true;
					player.GetComponent<CharacterMovement>().flying = false;
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

		if(events[0].progress < progress)
        {
			transform.rotation *= Quaternion.Euler(events[0].rotation);
        }

		Vector3 position = spline.GetPoint(progress);
		transform.localPosition = position;
		if (lookForward)
		{
			transform.LookAt(position + spline.GetDirection(progress));
		}
	}
}
