using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;
public static class DrawingFuncs {
	public static void DrawStar(Vector3 position, Color color, float starRadius = 1.0f, float time = 0.0f) {
		Debug.DrawLine(position - new Vector3(starRadius, 0, 0), position + new Vector3(starRadius, 0, 0), color, time);
		Debug.DrawLine(position - new Vector3(0, starRadius, 0), position + new Vector3(0, starRadius, 0), color, time);
		Debug.DrawLine(position - new Vector3(0, 0, starRadius), position + new Vector3(0, 0, starRadius), color, time);
	}
}