using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow_Script : MonoBehaviour
{
	public Action<float> Clicked;
	public AnimationCurve curve;

	public Vector3 positionA;  // left
	public Vector3 positionB;  // right

	public Quaternion rotationA;
	public Quaternion rotationB;

	[Range(0.1f, 3.0f)]
	public float speed = 2.0f;

	float t = 0;
	bool goingForward;

	void Update()
	{
		if (goingForward)
			t += Time.deltaTime * speed;
		else
			t -= Time.deltaTime * speed;

		if (t < 0.0f || t > 1.0f)
			goingForward = !goingForward;
		t = Mathf.Clamp01(t);
		// float t = Mathf.Sin(Time.time * speed) * 0.5f + 0.5f; // 0.0f...1.0f

		//transform.position = Vector3.Lerp(positionA, positionB, curve.Evaluate(t));
		transform.rotation = Quaternion.Lerp(rotationA, rotationB, curve.Evaluate(t));
	}
	public void OnClick()
	{
		var error = Mathf.Abs(curve.Evaluate(t) - 0.5f);
		Clicked?.Invoke(error);
	}
}
