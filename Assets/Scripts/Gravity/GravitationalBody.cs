using UnityEngine;
using XnaGeometryDecimal;
using Vector3 = XnaGeometryDecimal.Vector3;

public class GravitationalBody : MonoBehaviour
{
	VirtualPhysicsTransform physicsTransform = new VirtualPhysicsTransform();

	[SerializeField]
	double mass = 1230.0f;

	[SerializeField]
	GravitationalBody orbitTarget;

	void Awake()
	{
		physicsTransform.Position = transform.position;
		physicsTransform.Mass = (decimal)mass;
	}

	void Start()
	{
		GravitySim.Instance.Add(this);

		if (orbitTarget != null)
			physicsTransform.Velocity =
				Vector3.Cross((physicsTransform.Position - orbitTarget.PhysicsTransform.Position), Vector3.Up).Normalized *
				MathHelper.DSqrt((GravitySim.G * orbitTarget.PhysicsTransform.Mass) / Vector3.Distance(physicsTransform.Position, orbitTarget.PhysicsTransform.Position));

		Debug.Log(physicsTransform.Velocity);
	}

	void Update()
	{
		physicsTransform.Tick((decimal)Time.deltaTime);
		transform.position = physicsTransform.Position;
	}

	void OnDestroy()
	{
		GravitySim.Instance.Remove(this);
	}

	public VirtualPhysicsTransform PhysicsTransform { get => physicsTransform; }
}
