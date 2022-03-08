using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarLauncherWalker : SplineWalker
{
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
					progress = 1f;
					Destroy(this);
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

		Vector3 position = spline.GetPoint(progress);
		transform.position = position;
		if (lookForward)
		{
			transform.LookAt(position + spline.GetDirection(progress));
		}
	}
}
