using System;
using UnityEngine;
using Quaternion = XnaGeometryDecimal.Quaternion;
using Vector3 = XnaGeometryDecimal.Vector3;

[System.Serializable]
public class VirtualPhysicsTransform : ICloneable
{

	public VirtualPhysicsTransform() { }

	public VirtualPhysicsTransform(Vector3 initPos, Vector3 initVel, Quaternion initRot, Quaternion initRotVel)
	{
		Initialise(initPos, initVel, initRot, initRotVel);
	}

	public void Initialise(Vector3 initPos, Vector3 initVel, Quaternion initRot, Quaternion initRotVel)
	{
		pos = initPos;
		prevPos = initPos;

		vel = initVel;
		prevVel = initVel;

		rot = initRot;
		prevRot = initRot;

		rotVel = initRotVel;
		prevRotVel = initRotVel;
	}

	public void Initialise(VirtualPhysicsTransform fromData)
	{
		pos = fromData.pos;
		vel = fromData.vel;
		prevPos = fromData.prevPos;
		prevVel = fromData.prevVel;

		rot = fromData.rot;
		rotVel = fromData.rotVel;
		prevRot = fromData.prevRot;
		prevRotVel = fromData.prevRotVel;

		mass = fromData.mass;
	}

	#region Private Vars

	[SerializeField]
	Vector3
		pos = Vector3.Zero,
		vel = Vector3.Zero,
		prevPos = Vector3.Zero,
		prevVel = Vector3.Zero;

	[SerializeField]
	Quaternion
		rot = Quaternion.Identity,
		rotVel = Quaternion.Identity,
		prevRot = Quaternion.Identity,
		prevRotVel = Quaternion.Identity;

	[SerializeField]
	decimal
		mass = 1.0m;

	#endregion

	#region Properties

	public Vector3 Position { get { return pos; } set { pos = value; } }
	public Vector3 Velocity { get { return vel; } set { vel = value; } }

	public Quaternion Rotation { get { return rot; } set { rot = value; } }
	public Quaternion RotationalVelocity { get { return rotVel; } set { rotVel = value; } }

	public decimal Mass { get { return mass; } set { mass = value; } }

	public Vector3 EulerRotation { get { return rot.EulerAngles; } set { rot.EulerAngles = value; } }
	public Vector3 EulerRotationalVelocity { get { return rotVel.EulerAngles; } set { rotVel.EulerAngles = value; } }

	public Vector3 Forward { get { return Rotation * Vector3.Forward; } }
	public Vector3 Back { get { return Rotation * Vector3.Backward; } }
	public Vector3 Up { get { return Rotation * Vector3.Up; } }
	public Vector3 Down { get { return Rotation * Vector3.Down; } }
	public Vector3 Right { get { return Rotation * Vector3.Right; } }
	public Vector3 Left { get { return Rotation * Vector3.Left; } }

	public Vector3 PrevPosition => prevPos;
	public Vector3 PrevVelocity => prevVel;
	public Quaternion PrevRotation => prevRot;
	public Quaternion PrevRotationalVelocity => prevRotVel;

	public decimal SpinVelocity
	{
		get
		{
			decimal spinVel = 0.0m;
			Vector3 spinAxis = Vector3.Zero;
			RotationalVelocity.ToAngleAxis(out spinVel, out spinAxis);
			return spinVel;
		}
		set
		{
			decimal spinVel = 0.0m;
			Vector3 spinAxis = Vector3.Zero;
			RotationalVelocity.ToAngleAxis(out spinVel, out spinAxis);
			RotationalVelocity = Quaternion.CreateFromAxisAngle(spinAxis, value);
		}
	}

	public Vector3 SpinAxis
	{
		get
		{
			decimal spinVel = 0.0m;
			Vector3 spinAxis = Vector3.Zero;
			RotationalVelocity.ToAngleAxis(out spinVel, out spinAxis);
			return spinAxis;
		}
		set
		{
			decimal spinVel = 0.0m;
			Vector3 spinAxis = Vector3.Zero;
			RotationalVelocity.ToAngleAxis(out spinVel, out spinAxis);
			RotationalVelocity = Quaternion.CreateFromAxisAngle(value, spinVel);
		}
	}

	public decimal VelocityMagnitude
	{
		get { return vel.Magnitude; }
		set { vel = vel.Normalized * value; }
	}

	public Vector3 VelocityDirection
	{
		get { return Velocity.Normalized; }
		set { Velocity = value.Normalized * Velocity.Magnitude; }
	}

	#endregion

	#region Public Interface

	public virtual void Tick(decimal deltaTime)
	{

		prevPos = pos;
		prevVel = vel;
		prevRot = rot;
		prevRotVel = rotVel;

		pos += vel * deltaTime;
		rot *= Quaternion.Lerp(Quaternion.Identity, RotationalVelocity, deltaTime);

	}

	#region Transform

	//public void LookAt(Vector3 pos) => LookAt(pos, Vector3.Up);

	//public void LookAt(Vector3 pos, Vector3 up) => Rotation = Quaternion.LookRotation(pos - Position, up);

	public void RotateAround(Vector3 axis, decimal degrees) => rot *= Quaternion.CreateFromAxisAngle(axis, (decimal)degrees);

	public void Translate(Vector3 dist) => Position += dist;

	#endregion

	#region Physics

	public void AddForce(Vector3 force, ForceMode mode = ForceMode.Force, decimal deltaTime = -1m)
	{
		if (deltaTime < 0.0m)
			deltaTime = (decimal)Time.deltaTime;

		//Debug.Log($"deltaTime: {deltaTime}, force: {force}");
		switch (mode)
		{
			case ForceMode.Acceleration:
				vel += force * (decimal)deltaTime;
				return;
			case ForceMode.Force:
				vel += (force / (decimal)mass) * (decimal)deltaTime;
				return;
			case ForceMode.Impulse:
				vel += force / mass;
				return;
			case ForceMode.VelocityChange:
				vel += force;
				return;
		}
	}

	#endregion

	#endregion

	#region Debug

	public void RenderDebug(decimal deltaTime = -1m, decimal duration = 0.0m, decimal afterDrawDuration = 0.0m)
	{
		deltaTime = deltaTime < 0.0m ? (decimal)Time.deltaTime : deltaTime;

		Debug.DrawRay(Position, Velocity, new Color(0.5f, 0.5f, 0.5f, 1.0f), (float)duration); //Velocity
		Debug.DrawRay(Position, (Velocity - PrevVelocity) / deltaTime, Color.yellow, (float)duration); //Acceleration
		Debug.DrawLine(PrevPosition, Position, Color.white, (float)afterDrawDuration); //Delta Position

		DrawingFuncs.DrawStar(PrevPosition, Color.magenta, 0.5f, (float)afterDrawDuration); //Iteration positions

		//Directions
		Debug.DrawRay(Position, Right, Color.red, (float)duration); //X-Direction
		Debug.DrawRay(Position, Up, Color.green, (float)duration); //Y-Direction
		Debug.DrawRay(Position, Forward, Color.blue, (float)duration); //Z-Direction
	}

	#endregion

	#region ICloneable

	public virtual object Clone()
	{
		return MemberwiseClone() as VirtualPhysicsTransform;
	}

	#endregion

}
