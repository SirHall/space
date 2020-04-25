using System.Collections.Generic;
using UnityEngine;
using Vector3 = XnaGeometryDecimal.Vector3;

public class GravitySim : MonoBehaviour
{
	public static GravitySim Instance { get; private set; }

	private List<GravitationalBody> bodies = new List<GravitationalBody>();

	//Gravitational constant
	public const decimal G = 6.6743015E-11m;

	void Awake()
	{
		Instance = this;
	}

	void Update()
	{
		for (int i = 0; i < bodies.Count - 1; i++)
		{
			for (int j = i + 1; j < bodies.Count; j++)
			{
				VirtualPhysicsTransform bodyA = bodies[i].PhysicsTransform, bodyB = bodies[j].PhysicsTransform;

				decimal squardDist = Vector3.DistanceSquared(bodyA.Position, bodyB.Position);

				decimal forceMagnitude = 0m;

				if (squardDist > 0.001m)
					forceMagnitude = (G * bodyA.Mass * bodyB.Mass) / squardDist;

				Vector3 force = (bodyA.Position - bodyB.Position).Normalized * forceMagnitude;

				//Two birds with one stone
				bodyA.AddForce(-force);
				Debug.DrawRay(bodyA.Position, -force / bodyA.Mass, Color.green, Time.deltaTime, false);
				bodyB.AddForce(force);
				Debug.DrawRay(bodyB.Position, force / bodyB.Mass, Color.yellow, Time.deltaTime, false);
			}
		}
	}

	public bool HasBody(GravitationalBody v) { return bodies.Contains(v); }

	public void Add(GravitationalBody v) { if (!bodies.Contains(v)) bodies.Add(v); }

	public void Remove(GravitationalBody v) { if (bodies.Contains(v)) bodies.Remove(v); }

}
