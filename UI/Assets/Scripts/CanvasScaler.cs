using UnityEngine;
using System.Collections;

public class CanvasScaler : MonoBehaviour {
	public float pixelsPerUnit = 25f;

	public void OnValidate()
	{
		transform.localScale = 
			new Vector3(
			1 / pixelsPerUnit,
			1 / pixelsPerUnit,
			1);
	}
}