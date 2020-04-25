#region License
/*
MIT License
Copyright Â© 2006 The Mono.Xna Team

All rights reserved.

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/
#endregion License

using System;

namespace XnaGeometryDecimal
{
    public struct Matrix : IEquatable<Matrix>
    {
        #region Public Constructors
        
        public Matrix(decimal m11, decimal m12, decimal m13, decimal m14, decimal m21, decimal m22, decimal m23, decimal m24, decimal m31,
                      decimal m32, decimal m33, decimal m34, decimal m41, decimal m42, decimal m43, decimal m44)
        {
            this.M11 = m11;
            this.M12 = m12;
            this.M13 = m13;
            this.M14 = m14;
            this.M21 = m21;
            this.M22 = m22;
            this.M23 = m23;
            this.M24 = m24;
            this.M31 = m31;
            this.M32 = m32;
            this.M33 = m33;
            this.M34 = m34;
            this.M41 = m41;
            this.M42 = m42;
            this.M43 = m43;
            this.M44 = m44;
        }

        #endregion Public Constructors


        #region Public Fields

        public decimal M11;
        public decimal M12;
        public decimal M13;
        public decimal M14;
        public decimal M21;
        public decimal M22;
        public decimal M23;
        public decimal M24;
        public decimal M31;
        public decimal M32;
        public decimal M33;
        public decimal M34;
        public decimal M41;
        public decimal M42;
        public decimal M43;
        public decimal M44;

        #endregion Public Fields


        #region Private Members
        private static Matrix identity = new Matrix(1m, 0m, 0m, 0m, 
		                                            0m, 1m, 0m, 0m, 
		                                            0m, 0m, 1m, 0m, 
		                                            0m, 0m, 0m, 1m);
        #endregion Private Members


        #region Public Properties
        
        public Vector3 Backward
        {
            get
            {
                return new Vector3(this.M31, this.M32, this.M33);
            }
            set
            {
                this.M31 = value.X;
                this.M32 = value.Y;
                this.M33 = value.Z;
            }
        }

        
        public Vector3 Down
        {
            get
            {
                return new Vector3(-this.M21, -this.M22, -this.M23);
            }
            set
            {
                this.M21 = -value.X;
                this.M22 = -value.Y;
                this.M23 = -value.Z;
            }
        }

        
        public Vector3 Forward
        {
            get
            {
                return new Vector3(-this.M31, -this.M32, -this.M33);
            }
            set
            {
                this.M31 = -value.X;
                this.M32 = -value.Y;
                this.M33 = -value.Z;
            }
        }

        
        public static Matrix Identity
        {
            get { return identity; }
        }

		
		// required for OpenGL 2.0 projection matrix stuff
		public static decimal[] ToFloatArray(Matrix mat)
        {
			decimal [] matarray = {
									mat.M11, mat.M12, mat.M13, mat.M14,
									mat.M21, mat.M22, mat.M23, mat.M24,
									mat.M31, mat.M32, mat.M33, mat.M34,
									mat.M41, mat.M42, mat.M43, mat.M44
								};
			return matarray;
		}
        
        public Vector3 Left
        {
            get
            {
                return new Vector3(-this.M11, -this.M12, -this.M13);
            }
            set
            {
                this.M11 = -value.X;
                this.M12 = -value.Y;
                this.M13 = -value.Z;
            }
        }

        
        public Vector3 Right
        {
            get
            {
                return new Vector3(this.M11, this.M12, this.M13);
            }
            set
            {
                this.M11 = value.X;
                this.M12 = value.Y;
                this.M13 = value.Z;
            }
        }

        
        public Vector3 Translation
        {
            get
            {
                return new Vector3(this.M41, this.M42, this.M43);
            }
            set
            {
                this.M41 = value.X;
                this.M42 = value.Y;
                this.M43 = value.Z;
            }
        }

        
        public Vector3 Up
        {
            get
            {
                return new Vector3(this.M21, this.M22, this.M23);
            }
            set
            {
                this.M21 = value.X;
                this.M22 = value.Y;
                this.M23 = value.Z;
            }
        }
        #endregion Public Properties


        #region Public Methods

        public static Matrix Add(Matrix matrix1, Matrix matrix2)
        {
            matrix1.M11 += matrix2.M11;
            matrix1.M12 += matrix2.M12;
            matrix1.M13 += matrix2.M13;
            matrix1.M14 += matrix2.M14;
            matrix1.M21 += matrix2.M21;
            matrix1.M22 += matrix2.M22;
            matrix1.M23 += matrix2.M23;
            matrix1.M24 += matrix2.M24;
            matrix1.M31 += matrix2.M31;
            matrix1.M32 += matrix2.M32;
            matrix1.M33 += matrix2.M33;
            matrix1.M34 += matrix2.M34;
            matrix1.M41 += matrix2.M41;
            matrix1.M42 += matrix2.M42;
            matrix1.M43 += matrix2.M43;
            matrix1.M44 += matrix2.M44;
            return matrix1;
        }


        public static void Add(ref Matrix matrix1, ref Matrix matrix2, out Matrix result)
        {
            result.M11 = matrix1.M11 + matrix2.M11;
            result.M12 = matrix1.M12 + matrix2.M12;
            result.M13 = matrix1.M13 + matrix2.M13;
            result.M14 = matrix1.M14 + matrix2.M14;
            result.M21 = matrix1.M21 + matrix2.M21;
            result.M22 = matrix1.M22 + matrix2.M22;
            result.M23 = matrix1.M23 + matrix2.M23;
            result.M24 = matrix1.M24 + matrix2.M24;
            result.M31 = matrix1.M31 + matrix2.M31;
            result.M32 = matrix1.M32 + matrix2.M32;
            result.M33 = matrix1.M33 + matrix2.M33;
            result.M34 = matrix1.M34 + matrix2.M34;
            result.M41 = matrix1.M41 + matrix2.M41;
            result.M42 = matrix1.M42 + matrix2.M42;
            result.M43 = matrix1.M43 + matrix2.M43;
            result.M44 = matrix1.M44 + matrix2.M44;

        }

        
        public static Matrix CreateBillboard(Vector3 objectPosition, Vector3 cameraPosition,
            Vector3 cameraUpVector, Nullable<Vector3> cameraForwardVector)
        {
			var diff = cameraPosition - objectPosition;
			
			Matrix matrix = Matrix.Identity;
			
			diff.Normalize();
			matrix.Forward = diff;
			matrix.Left = Vector3.Cross(diff, cameraUpVector);
			matrix.Up = cameraUpVector;
			matrix.Translation = objectPosition;
			
			return matrix;
			
            /*Matrix matrix;
		    Vector3 vector;
		    Vector3 vector2;
		    Vector3 vector3;
		    vector.X = objectPosition.X - cameraPosition.X;
		    vector.Y = objectPosition.Y - cameraPosition.Y;
		    vector.Z = objectPosition.Z - cameraPosition.Z;
		    decimal num = vector.LengthSquared();
		    if (num < 0.0001m)
		    {
		        vector = cameraForwardVector.HasValue ? -cameraForwardVector.Value : Vector3.Forward;
		    }
		    else
		    {
		        Vector3.Multiply(ref vector, (decimal) (1m / ((decimal) MathHelper.DSqrt((decimal) num))), out vector);
		    }
		    Vector3.Cross(ref cameraUpVector, ref vector, out vector3);
		    vector3.Normalize();
		    Vector3.Cross(ref vector, ref vector3, out vector2);
		    matrix.M11 = vector3.X;
		    matrix.M12 = vector3.Y;
		    matrix.M13 = vector3.Z;
		    matrix.M14 = 0m;
		    matrix.M21 = vector2.X;
		    matrix.M22 = vector2.Y;
		    matrix.M23 = vector2.Z;
		    matrix.M24 = 0m;
		    matrix.M31 = vector.X;
		    matrix.M32 = vector.Y;
		    matrix.M33 = vector.Z;
		    matrix.M34 = 0m;
		    matrix.M41 = objectPosition.X;
		    matrix.M42 = objectPosition.Y;
		    matrix.M43 = objectPosition.Z;
		    matrix.M44 = 1m;
		    return matrix;*/
        }

        
        public static void CreateBillboard(ref Vector3 objectPosition, ref Vector3 cameraPosition,
            ref Vector3 cameraUpVector, Vector3? cameraForwardVector, out Matrix result)
        {
            Vector3 vector;
		    Vector3 vector2;
		    Vector3 vector3;
		    vector.X = objectPosition.X - cameraPosition.X;
		    vector.Y = objectPosition.Y - cameraPosition.Y;
		    vector.Z = objectPosition.Z - cameraPosition.Z;
		    decimal num = vector.LengthSquared();
		    if (num < 0.0001m)
		    {
		        vector = cameraForwardVector.HasValue ? -cameraForwardVector.Value : Vector3.Forward;
		    }
		    else
		    {
		        Vector3.Multiply(ref vector, (decimal) (1m / ((decimal) MathHelper.DSqrt((decimal) num))), out vector);
		    }
		    Vector3.Cross(ref cameraUpVector, ref vector, out vector3);
		    vector3.Normalize();
		    Vector3.Cross(ref vector, ref vector3, out vector2);
		    result.M11 = vector3.X;
		    result.M12 = vector3.Y;
		    result.M13 = vector3.Z;
		    result.M14 = 0m;
		    result.M21 = vector2.X;
		    result.M22 = vector2.Y;
		    result.M23 = vector2.Z;
		    result.M24 = 0m;
		    result.M31 = vector.X;
		    result.M32 = vector.Y;
		    result.M33 = vector.Z;
		    result.M34 = 0m;
		    result.M41 = objectPosition.X;
		    result.M42 = objectPosition.Y;
		    result.M43 = objectPosition.Z;
		    result.M44 = 1m;
        }

        
        public static Matrix CreateConstrainedBillboard(Vector3 objectPosition, Vector3 cameraPosition,
            Vector3 rotateAxis, Nullable<Vector3> cameraForwardVector, Nullable<Vector3> objectForwardVector)
        {
            decimal num;
		    Vector3 vector;
		    Matrix matrix;
		    Vector3 vector2;
		    Vector3 vector3;
		    vector2.X = objectPosition.X - cameraPosition.X;
		    vector2.Y = objectPosition.Y - cameraPosition.Y;
		    vector2.Z = objectPosition.Z - cameraPosition.Z;
		    decimal num2 = vector2.LengthSquared();
		    if (num2 < 0.0001m)
		    {
		        vector2 = cameraForwardVector.HasValue ? -cameraForwardVector.Value : Vector3.Forward;
		    }
		    else
		    {
		        Vector3.Multiply(ref vector2, (decimal) (1m / ((decimal) MathHelper.DSqrt((decimal) num2))), out vector2);
		    }
		    Vector3 vector4 = rotateAxis;
		    Vector3.Dot(ref rotateAxis, ref vector2, out num);
		    if (Math.Abs(num) > 0.9982547m)
		    {
		        if (objectForwardVector.HasValue)
		        {
		            vector = objectForwardVector.Value;
		            Vector3.Dot(ref rotateAxis, ref vector, out num);
		            if (Math.Abs(num) > 0.9982547m)
		            {
		                num = ((rotateAxis.X * Vector3.Forward.X) + (rotateAxis.Y * Vector3.Forward.Y)) + (rotateAxis.Z * Vector3.Forward.Z);
		                vector = (Math.Abs(num) > 0.9982547m) ? Vector3.Right : Vector3.Forward;
		            }
		        }
		        else
		        {
		            num = ((rotateAxis.X * Vector3.Forward.X) + (rotateAxis.Y * Vector3.Forward.Y)) + (rotateAxis.Z * Vector3.Forward.Z);
		            vector = (Math.Abs(num) > 0.9982547m) ? Vector3.Right : Vector3.Forward;
		        }
		        Vector3.Cross(ref rotateAxis, ref vector, out vector3);
		        vector3.Normalize();
		        Vector3.Cross(ref vector3, ref rotateAxis, out vector);
		        vector.Normalize();
		    }
		    else
		    {
		        Vector3.Cross(ref rotateAxis, ref vector2, out vector3);
		        vector3.Normalize();
		        Vector3.Cross(ref vector3, ref vector4, out vector);
		        vector.Normalize();
		    }
		    matrix.M11 = vector3.X;
		    matrix.M12 = vector3.Y;
		    matrix.M13 = vector3.Z;
		    matrix.M14 = 0m;
		    matrix.M21 = vector4.X;
		    matrix.M22 = vector4.Y;
		    matrix.M23 = vector4.Z;
		    matrix.M24 = 0m;
		    matrix.M31 = vector.X;
		    matrix.M32 = vector.Y;
		    matrix.M33 = vector.Z;
		    matrix.M34 = 0m;
		    matrix.M41 = objectPosition.X;
		    matrix.M42 = objectPosition.Y;
		    matrix.M43 = objectPosition.Z;
		    matrix.M44 = 1m;
		    return matrix;

        }

        
        public static void CreateConstrainedBillboard(ref Vector3 objectPosition, ref Vector3 cameraPosition,
            ref Vector3 rotateAxis, Vector3? cameraForwardVector, Vector3? objectForwardVector, out Matrix result)
        {
            decimal num;
		    Vector3 vector;
		    Vector3 vector2;
		    Vector3 vector3;
		    vector2.X = objectPosition.X - cameraPosition.X;
		    vector2.Y = objectPosition.Y - cameraPosition.Y;
		    vector2.Z = objectPosition.Z - cameraPosition.Z;
		    decimal num2 = vector2.LengthSquared();
		    if (num2 < 0.0001m)
		    {
		        vector2 = cameraForwardVector.HasValue ? -cameraForwardVector.Value : Vector3.Forward;
		    }
		    else
		    {
		        Vector3.Multiply(ref vector2, (decimal) (1m / ((decimal) MathHelper.DSqrt((decimal) num2))), out vector2);
		    }
		    Vector3 vector4 = rotateAxis;
		    Vector3.Dot(ref rotateAxis, ref vector2, out num);
		    if (Math.Abs(num) > 0.9982547m)
		    {
		        if (objectForwardVector.HasValue)
		        {
		            vector = objectForwardVector.Value;
		            Vector3.Dot(ref rotateAxis, ref vector, out num);
		            if (Math.Abs(num) > 0.9982547m)
		            {
		                num = ((rotateAxis.X * Vector3.Forward.X) + (rotateAxis.Y * Vector3.Forward.Y)) + (rotateAxis.Z * Vector3.Forward.Z);
		                vector = (Math.Abs(num) > 0.9982547m) ? Vector3.Right : Vector3.Forward;
		            }
		        }
		        else
		        {
		            num = ((rotateAxis.X * Vector3.Forward.X) + (rotateAxis.Y * Vector3.Forward.Y)) + (rotateAxis.Z * Vector3.Forward.Z);
		            vector = (Math.Abs(num) > 0.9982547m) ? Vector3.Right : Vector3.Forward;
		        }
		        Vector3.Cross(ref rotateAxis, ref vector, out vector3);
		        vector3.Normalize();
		        Vector3.Cross(ref vector3, ref rotateAxis, out vector);
		        vector.Normalize();
		    }
		    else
		    {
		        Vector3.Cross(ref rotateAxis, ref vector2, out vector3);
		        vector3.Normalize();
		        Vector3.Cross(ref vector3, ref vector4, out vector);
		        vector.Normalize();
		    }
		    result.M11 = vector3.X;
		    result.M12 = vector3.Y;
		    result.M13 = vector3.Z;
		    result.M14 = 0m;
		    result.M21 = vector4.X;
		    result.M22 = vector4.Y;
		    result.M23 = vector4.Z;
		    result.M24 = 0m;
		    result.M31 = vector.X;
		    result.M32 = vector.Y;
		    result.M33 = vector.Z;
		    result.M34 = 0m;
		    result.M41 = objectPosition.X;
		    result.M42 = objectPosition.Y;
		    result.M43 = objectPosition.Z;
		    result.M44 = 1m;

        }


        public static Matrix CreateFromAxisAngle(Vector3 axis, decimal angle)
        {
            Matrix matrix;
		    decimal x = axis.X;
		    decimal y = axis.Y;
		    decimal z = axis.Z;
		    decimal num2 = (decimal) Math.Sin((double) angle);
		    decimal num = (decimal) Math.Cos((double) angle);
		    decimal num11 = x * x;
		    decimal num10 = y * y;
		    decimal num9 = z * z;
		    decimal num8 = x * y;
		    decimal num7 = x * z;
		    decimal num6 = y * z;
		    matrix.M11 = num11 + (num * (1m - num11));
		    matrix.M12 = (num8 - (num * num8)) + (num2 * z);
		    matrix.M13 = (num7 - (num * num7)) - (num2 * y);
		    matrix.M14 = 0m;
		    matrix.M21 = (num8 - (num * num8)) - (num2 * z);
		    matrix.M22 = num10 + (num * (1m - num10));
		    matrix.M23 = (num6 - (num * num6)) + (num2 * x);
		    matrix.M24 = 0m;
		    matrix.M31 = (num7 - (num * num7)) + (num2 * y);
		    matrix.M32 = (num6 - (num * num6)) - (num2 * x);
		    matrix.M33 = num9 + (num * (1m - num9));
		    matrix.M34 = 0m;
		    matrix.M41 = 0m;
		    matrix.M42 = 0m;
		    matrix.M43 = 0m;
		    matrix.M44 = 1m;
		    return matrix;

        }


        public static void CreateFromAxisAngle(ref Vector3 axis, decimal angle, out Matrix result)
        {
            decimal x = axis.X;
		    decimal y = axis.Y;
		    decimal z = axis.Z;
		    decimal num2 = (decimal) Math.Sin((double) angle);
		    decimal num = (decimal) Math.Cos((double) angle);
		    decimal num11 = x * x;
		    decimal num10 = y * y;
		    decimal num9 = z * z;
		    decimal num8 = x * y;
		    decimal num7 = x * z;
		    decimal num6 = y * z;
		    result.M11 = num11 + (num * (1m - num11));
		    result.M12 = (num8 - (num * num8)) + (num2 * z);
		    result.M13 = (num7 - (num * num7)) - (num2 * y);
		    result.M14 = 0m;
		    result.M21 = (num8 - (num * num8)) - (num2 * z);
		    result.M22 = num10 + (num * (1m - num10));
		    result.M23 = (num6 - (num * num6)) + (num2 * x);
		    result.M24 = 0m;
		    result.M31 = (num7 - (num * num7)) + (num2 * y);
		    result.M32 = (num6 - (num * num6)) - (num2 * x);
		    result.M33 = num9 + (num * (1m - num9));
		    result.M34 = 0m;
		    result.M41 = 0m;
		    result.M42 = 0m;
		    result.M43 = 0m;
		    result.M44 = 1m;
        }


        public static Matrix CreateFromQuaternion(Quaternion quaternion)
        {
            Matrix matrix;
		    decimal num9 = quaternion.X * quaternion.X;
		    decimal num8 = quaternion.Y * quaternion.Y;
		    decimal num7 = quaternion.Z * quaternion.Z;
		    decimal num6 = quaternion.X * quaternion.Y;
		    decimal num5 = quaternion.Z * quaternion.W;
		    decimal num4 = quaternion.Z * quaternion.X;
		    decimal num3 = quaternion.Y * quaternion.W;
		    decimal num2 = quaternion.Y * quaternion.Z;
		    decimal num = quaternion.X * quaternion.W;
		    matrix.M11 = 1m - (2m * (num8 + num7));
		    matrix.M12 = 2m * (num6 + num5);
		    matrix.M13 = 2m * (num4 - num3);
		    matrix.M14 = 0m;
		    matrix.M21 = 2m * (num6 - num5);
		    matrix.M22 = 1m - (2m * (num7 + num9));
		    matrix.M23 = 2m * (num2 + num);
		    matrix.M24 = 0m;
		    matrix.M31 = 2m * (num4 + num3);
		    matrix.M32 = 2m * (num2 - num);
		    matrix.M33 = 1m - (2m * (num8 + num9));
		    matrix.M34 = 0m;
		    matrix.M41 = 0m;
		    matrix.M42 = 0m;
		    matrix.M43 = 0m;
		    matrix.M44 = 1m;
		    return matrix;
        }


        public static void CreateFromQuaternion(ref Quaternion quaternion, out Matrix result)
        {
            decimal num9 = quaternion.X * quaternion.X;
		    decimal num8 = quaternion.Y * quaternion.Y;
		    decimal num7 = quaternion.Z * quaternion.Z;
		    decimal num6 = quaternion.X * quaternion.Y;
		    decimal num5 = quaternion.Z * quaternion.W;
		    decimal num4 = quaternion.Z * quaternion.X;
		    decimal num3 = quaternion.Y * quaternion.W;
		    decimal num2 = quaternion.Y * quaternion.Z;
		    decimal num = quaternion.X * quaternion.W;
		    result.M11 = 1m - (2m * (num8 + num7));
		    result.M12 = 2m * (num6 + num5);
		    result.M13 = 2m * (num4 - num3);
		    result.M14 = 0m;
		    result.M21 = 2m * (num6 - num5);
		    result.M22 = 1m - (2m * (num7 + num9));
		    result.M23 = 2m * (num2 + num);
		    result.M24 = 0m;
		    result.M31 = 2m * (num4 + num3);
		    result.M32 = 2m * (num2 - num);
		    result.M33 = 1m - (2m * (num8 + num9));
		    result.M34 = 0m;
		    result.M41 = 0m;
		    result.M42 = 0m;
		    result.M43 = 0m;
		    result.M44 = 1m;
        }
		
		public static Matrix CreateFromYawPitchRoll(decimal yaw, decimal pitch, decimal roll)
		{
			Matrix matrix;
		    Quaternion quaternion;
		    Quaternion.CreateFromYawPitchRoll(yaw, pitch, roll, out quaternion);
		    CreateFromQuaternion(ref quaternion, out matrix);
		    return matrix;
		}
		
		public static void CreateFromYawPitchRoll(
         decimal yaw,
         decimal pitch,
         decimal roll,
         out Matrix result)
		{
			Quaternion quaternion;
		    Quaternion.CreateFromYawPitchRoll(yaw, pitch, roll, out quaternion);
		    CreateFromQuaternion(ref quaternion, out result);
		}

        public static Matrix CreateLookAt(Vector3 cameraPosition, Vector3 cameraTarget, Vector3 cameraUpVector)
        {
			Vector3 vector3_1 = Vector3.Normalize(cameraPosition - cameraTarget);
			Vector3 vector3_2 = Vector3.Normalize(Vector3.Cross(cameraUpVector, vector3_1));
			Vector3 vector1 = Vector3.Cross(vector3_1, vector3_2);
			Matrix matrix;
			matrix.M11 = vector3_2.X;
			matrix.M12 = vector1.X;
			matrix.M13 = vector3_1.X;
			matrix.M14 = 0.0m;
			matrix.M21 = vector3_2.Y;
			matrix.M22 = vector1.Y;
			matrix.M23 = vector3_1.Y;
			matrix.M24 = 0.0m;
			matrix.M31 = vector3_2.Z;
			matrix.M32 = vector1.Z;
			matrix.M33 = vector3_1.Z;
			matrix.M34 = 0.0m;
			matrix.M41 = -Vector3.Dot(vector3_2, cameraPosition);
			matrix.M42 = -Vector3.Dot(vector1, cameraPosition);
			matrix.M43 = -Vector3.Dot(vector3_1, cameraPosition);
			matrix.M44 = 1m;
			return matrix;
  
			
			/*
            Matrix m = identity;
			
			m.Translation = cameraPosition;
			
			var diff = cameraPosition - cameraTarget;
			diff.Normalize();
			m.Forward = -diff;
			
			Console.WriteLine("Forward: {0}", m.Forward);

			Vector3 right;
			Vector3.Cross(ref cameraUpVector, ref diff, out right);
			m.Right = right;
			
			Console.WriteLine("Right: {0}", right);
			
			Vector3 up;
			Vector3.Cross(ref diff, ref right, out up);
			m.Up = up;
			
			return Matrix.Invert(m);
			*/
			
			//return m;
        }


        public static void CreateLookAt(ref Vector3 cameraPosition, ref Vector3 cameraTarget, ref Vector3 cameraUpVector, out Matrix result)
        {
            Vector3 vector = Vector3.Normalize(cameraPosition - cameraTarget);
		    Vector3 vector2 = Vector3.Normalize(Vector3.Cross(cameraUpVector, vector));
		    Vector3 vector3 = Vector3.Cross(vector, vector2);
		    result.M11 = vector2.X;
		    result.M12 = vector3.X;
		    result.M13 = vector.X;
		    result.M14 = 0m;
		    result.M21 = vector2.Y;
		    result.M22 = vector3.Y;
		    result.M23 = vector.Y;
		    result.M24 = 0m;
		    result.M31 = vector2.Z;
		    result.M32 = vector3.Z;
		    result.M33 = vector.Z;
		    result.M34 = 0m;
		    result.M41 = -Vector3.Dot(vector2, cameraPosition);
		    result.M42 = -Vector3.Dot(vector3, cameraPosition);
		    result.M43 = -Vector3.Dot(vector, cameraPosition);
		    result.M44 = 1m;
        }


        public static Matrix CreateOrthographic(decimal width, decimal height, decimal zNearPlane, decimal zFarPlane)
        {
            Matrix matrix;
		    matrix.M11 = 2m / width;
		    matrix.M12 = matrix.M13 = matrix.M14 = 0m;
		    matrix.M22 = 2m / height;
		    matrix.M21 = matrix.M23 = matrix.M24 = 0m;
		    matrix.M33 = 1m / (zNearPlane - zFarPlane);
		    matrix.M31 = matrix.M32 = matrix.M34 = 0m;
		    matrix.M41 = matrix.M42 = 0m;
		    matrix.M43 = zNearPlane / (zNearPlane - zFarPlane);
		    matrix.M44 = 1m;
		    return matrix;
        }


        public static void CreateOrthographic(decimal width, decimal height, decimal zNearPlane, decimal zFarPlane, out Matrix result)
        {
            result.M11 = 2m / width;
		    result.M12 = result.M13 = result.M14 = 0m;
		    result.M22 = 2m / height;
		    result.M21 = result.M23 = result.M24 = 0m;
		    result.M33 = 1m / (zNearPlane - zFarPlane);
		    result.M31 = result.M32 = result.M34 = 0m;
		    result.M41 = result.M42 = 0m;
		    result.M43 = zNearPlane / (zNearPlane - zFarPlane);
		    result.M44 = 1m;
        }


        public static Matrix CreateOrthographicOffCenter(decimal left, decimal right, decimal bottom, decimal top, decimal zNearPlane, decimal zFarPlane)
        {
			Matrix matrix;
			matrix.M11 = (decimal)(2.0m / ((decimal)right - (decimal)left));
			matrix.M12 = 0.0m;
			matrix.M13 = 0.0m;
			matrix.M14 = 0.0m;
			matrix.M21 = 0.0m;
			matrix.M22 = (decimal)(2.0m / ((decimal)top - (decimal)bottom));
			matrix.M23 = 0.0m;
			matrix.M24 = 0.0m;
			matrix.M31 = 0.0m;
			matrix.M32 = 0.0m;
			matrix.M33 = (decimal)(1.0m / ((decimal)zNearPlane - (decimal)zFarPlane));
			matrix.M34 = 0.0m;
			matrix.M41 = (decimal)(((decimal)left + (decimal)right) / ((decimal)left - (decimal)right));
			matrix.M42 = (decimal)(((decimal)top + (decimal)bottom) / ((decimal)bottom - (decimal)top));
			matrix.M43 = (decimal)((decimal)zNearPlane / ((decimal)zNearPlane - (decimal)zFarPlane));
			matrix.M44 = 1.0m;
			return matrix;
        }

        
        public static void CreateOrthographicOffCenter(decimal left, decimal right, decimal bottom, decimal top, decimal zNearPlane, decimal zFarPlane, out Matrix result)
        {
			result.M11 = (decimal)(2.0m / ((decimal)right - (decimal)left));
			result.M12 = 0.0m;
			result.M13 = 0.0m;
			result.M14 = 0.0m;
			result.M21 = 0.0m;
			result.M22 = (decimal)(2.0m / ((decimal)top - (decimal)bottom));
			result.M23 = 0.0m;
			result.M24 = 0.0m;
			result.M31 = 0.0m;
			result.M32 = 0.0m;
			result.M33 = (decimal)(1.0m / ((decimal)zNearPlane - (decimal)zFarPlane));
			result.M34 = 0.0m;
			result.M41 = (decimal)(((decimal)left + (decimal)right) / ((decimal)left - (decimal)right));
			result.M42 = (decimal)(((decimal)top + (decimal)bottom) / ((decimal)bottom - (decimal)top));
			result.M43 = (decimal)((decimal)zNearPlane / ((decimal)zNearPlane - (decimal)zFarPlane));
			result.M44 = 1.0m;
		}

        public static Matrix CreatePerspective(decimal width, decimal height, decimal nearPlaneDistance, decimal farPlaneDistance)
        {
            Matrix matrix;
		    if (nearPlaneDistance <= 0m)
		    {
		        throw new ArgumentException("nearPlaneDistance <= 0");
		    }
		    if (farPlaneDistance <= 0m)
		    {
		        throw new ArgumentException("farPlaneDistance <= 0");
		    }
		    if (nearPlaneDistance >= farPlaneDistance)
		    {
		        throw new ArgumentException("nearPlaneDistance >= farPlaneDistance");
		    }
		    matrix.M11 = (2m * nearPlaneDistance) / width;
		    matrix.M12 = matrix.M13 = matrix.M14 = 0m;
		    matrix.M22 = (2m * nearPlaneDistance) / height;
		    matrix.M21 = matrix.M23 = matrix.M24 = 0m;
		    matrix.M33 = farPlaneDistance / (nearPlaneDistance - farPlaneDistance);
		    matrix.M31 = matrix.M32 = 0m;
		    matrix.M34 = -1m;
		    matrix.M41 = matrix.M42 = matrix.M44 = 0m;
		    matrix.M43 = (nearPlaneDistance * farPlaneDistance) / (nearPlaneDistance - farPlaneDistance);
		    return matrix;
        }


        public static void CreatePerspective(decimal width, decimal height, decimal nearPlaneDistance, decimal farPlaneDistance, out Matrix result)
        {
            if (nearPlaneDistance <= 0m)
		    {
		        throw new ArgumentException("nearPlaneDistance <= 0");
		    }
		    if (farPlaneDistance <= 0m)
		    {
		        throw new ArgumentException("farPlaneDistance <= 0");
		    }
		    if (nearPlaneDistance >= farPlaneDistance)
		    {
		        throw new ArgumentException("nearPlaneDistance >= farPlaneDistance");
		    }
		    result.M11 = (2m * nearPlaneDistance) / width;
		    result.M12 = result.M13 = result.M14 = 0m;
		    result.M22 = (2m * nearPlaneDistance) / height;
		    result.M21 = result.M23 = result.M24 = 0m;
		    result.M33 = farPlaneDistance / (nearPlaneDistance - farPlaneDistance);
		    result.M31 = result.M32 = 0m;
		    result.M34 = -1m;
		    result.M41 = result.M42 = result.M44 = 0m;
		    result.M43 = (nearPlaneDistance * farPlaneDistance) / (nearPlaneDistance - farPlaneDistance);
        }


        public static Matrix CreatePerspectiveFieldOfView(decimal fieldOfView, decimal aspectRatio, decimal nearPlaneDistance, decimal farPlaneDistance)
        {
            Matrix matrix;
		    if ((fieldOfView <= 0m) || (fieldOfView >= 3.141595m))
		    {
		        throw new ArgumentException("fieldOfView <= 0 O >= PI");
		    }
		    if (nearPlaneDistance <= 0m)
		    {
		        throw new ArgumentException("nearPlaneDistance <= 0");
		    }
		    if (farPlaneDistance <= 0m)
		    {
		        throw new ArgumentException("farPlaneDistance <= 0");
		    }
		    if (nearPlaneDistance >= farPlaneDistance)
		    {
		        throw new ArgumentException("nearPlaneDistance >= farPlaneDistance");
		    }
		    decimal num = 1m / ((decimal) Math.Tan((double) (fieldOfView * 0.5m)));
		    decimal num9 = num / aspectRatio;
		    matrix.M11 = num9;
		    matrix.M12 = matrix.M13 = matrix.M14 = 0m;
		    matrix.M22 = num;
		    matrix.M21 = matrix.M23 = matrix.M24 = 0m;
		    matrix.M31 = matrix.M32 = 0m;
		    matrix.M33 = farPlaneDistance / (nearPlaneDistance - farPlaneDistance);
		    matrix.M34 = -1m;
		    matrix.M41 = matrix.M42 = matrix.M44 = 0m;
		    matrix.M43 = (nearPlaneDistance * farPlaneDistance) / (nearPlaneDistance - farPlaneDistance);
		    return matrix;
        }


        public static void CreatePerspectiveFieldOfView(decimal fieldOfView, decimal aspectRatio, decimal nearPlaneDistance, decimal farPlaneDistance, out Matrix result)
        {
            if ((fieldOfView <= 0m) || (fieldOfView >= 3.141595m))
		    {
		        throw new ArgumentException("fieldOfView <= 0 or >= PI");
		    }
		    if (nearPlaneDistance <= 0m)
		    {
		        throw new ArgumentException("nearPlaneDistance <= 0");
		    }
		    if (farPlaneDistance <= 0m)
		    {
		        throw new ArgumentException("farPlaneDistance <= 0");
		    }
		    if (nearPlaneDistance >= farPlaneDistance)
		    {
		        throw new ArgumentException("nearPlaneDistance >= farPlaneDistance");
		    }
		    decimal num = 1m / ((decimal) Math.Tan((double) (fieldOfView * 0.5m)));
		    decimal num9 = num / aspectRatio;
		    result.M11 = num9;
		    result.M12 = result.M13 = result.M14 = 0m;
		    result.M22 = num;
		    result.M21 = result.M23 = result.M24 = 0m;
		    result.M31 = result.M32 = 0m;
		    result.M33 = farPlaneDistance / (nearPlaneDistance - farPlaneDistance);
		    result.M34 = -1m;
		    result.M41 = result.M42 = result.M44 = 0m;
		    result.M43 = (nearPlaneDistance * farPlaneDistance) / (nearPlaneDistance - farPlaneDistance);
        }


        public static Matrix CreatePerspectiveOffCenter(decimal left, decimal right, decimal bottom, decimal top, decimal nearPlaneDistance, decimal farPlaneDistance)
        {
            Matrix matrix;
		    if (nearPlaneDistance <= 0m)
		    {
		        throw new ArgumentException("nearPlaneDistance <= 0");
		    }
		    if (farPlaneDistance <= 0m)
		    {
		        throw new ArgumentException("farPlaneDistance <= 0");
		    }
		    if (nearPlaneDistance >= farPlaneDistance)
		    {
		        throw new ArgumentException("nearPlaneDistance >= farPlaneDistance");
		    }
		    matrix.M11 = (2m * nearPlaneDistance) / (right - left);
		    matrix.M12 = matrix.M13 = matrix.M14 = 0m;
		    matrix.M22 = (2m * nearPlaneDistance) / (top - bottom);
		    matrix.M21 = matrix.M23 = matrix.M24 = 0m;
		    matrix.M31 = (left + right) / (right - left);
		    matrix.M32 = (top + bottom) / (top - bottom);
		    matrix.M33 = farPlaneDistance / (nearPlaneDistance - farPlaneDistance);
		    matrix.M34 = -1m;
		    matrix.M43 = (nearPlaneDistance * farPlaneDistance) / (nearPlaneDistance - farPlaneDistance);
		    matrix.M41 = matrix.M42 = matrix.M44 = 0m;
		    return matrix;
        }


        public static void CreatePerspectiveOffCenter(decimal left, decimal right, decimal bottom, decimal top, decimal nearPlaneDistance, decimal farPlaneDistance, out Matrix result)
        {
            if (nearPlaneDistance <= 0m)
		    {
		        throw new ArgumentException("nearPlaneDistance <= 0");
		    }
		    if (farPlaneDistance <= 0m)
		    {
		        throw new ArgumentException("farPlaneDistance <= 0");
		    }
		    if (nearPlaneDistance >= farPlaneDistance)
		    {
		        throw new ArgumentException("nearPlaneDistance >= farPlaneDistance");
		    }
		    result.M11 = (2m * nearPlaneDistance) / (right - left);
		    result.M12 = result.M13 = result.M14 = 0m;
		    result.M22 = (2m * nearPlaneDistance) / (top - bottom);
		    result.M21 = result.M23 = result.M24 = 0m;
		    result.M31 = (left + right) / (right - left);
		    result.M32 = (top + bottom) / (top - bottom);
		    result.M33 = farPlaneDistance / (nearPlaneDistance - farPlaneDistance);
		    result.M34 = -1m;
		    result.M43 = (nearPlaneDistance * farPlaneDistance) / (nearPlaneDistance - farPlaneDistance);
		    result.M41 = result.M42 = result.M44 = 0m;
        }


        public static Matrix CreateRotationX(decimal radians)
        {
            Matrix returnMatrix = Matrix.Identity;

			var val1 = (decimal)Math.Cos((double)radians);
			var val2 = (decimal)Math.Sin((double)radians);
			
            returnMatrix.M22 = val1;
            returnMatrix.M23 = val2;
            returnMatrix.M32 = -val2;
            returnMatrix.M33 = val1;

            return returnMatrix;

        }


        public static void CreateRotationX(decimal radians, out Matrix result)
        {
            result = Matrix.Identity;

			var val1 = (decimal)Math.Cos((double)radians);
			var val2 = (decimal)Math.Sin((double)radians);
			
            result.M22 = val1;
            result.M23 = val2;
            result.M32 = -val2;
            result.M33 = val1;
        }

        public static Matrix CreateRotationY(decimal radians)
        {
            Matrix returnMatrix = Matrix.Identity;
			
			var val1 = (decimal)Math.Cos((double)radians);
			var val2 = (decimal)Math.Sin((double)radians);
			
            returnMatrix.M11 = val1;
            returnMatrix.M13 = -val2;
            returnMatrix.M31 = val2;
            returnMatrix.M33 = val1;

            return returnMatrix;
        }


        public static void CreateRotationY(decimal radians, out Matrix result)
        {
            result = Matrix.Identity;

            var val1 = (decimal)Math.Cos((double)radians);
			var val2 = (decimal)Math.Sin((double)radians);
			
            result.M11 = val1;
            result.M13 = -val2;
            result.M31 = val2;
            result.M33 = val1;
        }


        public static Matrix CreateRotationZ(decimal radians)
        {
            Matrix returnMatrix = Matrix.Identity;

			var val1 = (decimal)Math.Cos((double)radians);
			var val2 = (decimal)Math.Sin((double)radians);
			
            returnMatrix.M11 = val1;
            returnMatrix.M12 = val2;
            returnMatrix.M21 = -val2;
            returnMatrix.M22 = val1;

            return returnMatrix;
        }


        public static void CreateRotationZ(decimal radians, out Matrix result)
        {
            result = Matrix.Identity;

			var val1 = (decimal)Math.Cos((double)radians);
			var val2 = (decimal)Math.Sin((double)radians);
			
            result.M11 = val1;
            result.M12 = val2;
            result.M21 = -val2;
            result.M22 = val1;
        }


        public static Matrix CreateScale(decimal scale)
        {
			Matrix result;
            result.M11 = scale;
			result.M12 = 0;
			result.M13 = 0;
			result.M14 = 0;
			result.M21 = 0;
			result.M22 = scale;
			result.M23 = 0;
			result.M24 = 0;
			result.M31 = 0;
			result.M32 = 0;
			result.M33 = scale;
			result.M34 = 0;
			result.M41 = 0;
			result.M42 = 0;
			result.M43 = 0;
			result.M44 = 1;
			return result;
        }


        public static void CreateScale(decimal scale, out Matrix result)
        {
			result.M11 = scale;
			result.M12 = 0;
			result.M13 = 0;
			result.M14 = 0;
			result.M21 = 0;
			result.M22 = scale;
			result.M23 = 0;
			result.M24 = 0;
			result.M31 = 0;
			result.M32 = 0;
			result.M33 = scale;
			result.M34 = 0;
			result.M41 = 0;
			result.M42 = 0;
			result.M43 = 0;
			result.M44 = 1;
        }


        public static Matrix CreateScale(decimal xScale, decimal yScale, decimal zScale)
        {
            Matrix result;
			result.M11 = xScale;
			result.M12 = 0;
			result.M13 = 0;
			result.M14 = 0;
			result.M21 = 0;
			result.M22 = yScale;
			result.M23 = 0;
			result.M24 = 0;
			result.M31 = 0;
			result.M32 = 0;
			result.M33 = zScale;
			result.M34 = 0;
			result.M41 = 0;
			result.M42 = 0;
			result.M43 = 0;
			result.M44 = 1;
			return result;
        }


        public static void CreateScale(decimal xScale, decimal yScale, decimal zScale, out Matrix result)
        {
			result.M11 = xScale;
			result.M12 = 0;
			result.M13 = 0;
			result.M14 = 0;
			result.M21 = 0;
			result.M22 = yScale;
			result.M23 = 0;
			result.M24 = 0;
			result.M31 = 0;
			result.M32 = 0;
			result.M33 = zScale;
			result.M34 = 0;
			result.M41 = 0;
			result.M42 = 0;
			result.M43 = 0;
			result.M44 = 1;
        }


        public static Matrix CreateScale(Vector3 scales)
        {
            Matrix result;
			result.M11 = scales.X;
			result.M12 = 0;
			result.M13 = 0;
			result.M14 = 0;
			result.M21 = 0;
			result.M22 = scales.Y;
			result.M23 = 0;
			result.M24 = 0;
			result.M31 = 0;
			result.M32 = 0;
			result.M33 = scales.Z;
			result.M34 = 0;
			result.M41 = 0;
			result.M42 = 0;
			result.M43 = 0;
			result.M44 = 1;
			return result;
        }


        public static void CreateScale(ref Vector3 scales, out Matrix result)
        {
            result.M11 = scales.X;
			result.M12 = 0;
			result.M13 = 0;
			result.M14 = 0;
			result.M21 = 0;
			result.M22 = scales.Y;
			result.M23 = 0;
			result.M24 = 0;
			result.M31 = 0;
			result.M32 = 0;
			result.M33 = scales.Z;
			result.M34 = 0;
			result.M41 = 0;
			result.M42 = 0;
			result.M43 = 0;
			result.M44 = 1;
        }

        public static Matrix CreateTranslation(decimal xPosition, decimal yPosition, decimal zPosition)
        {
            Matrix result;
			result.M11 = 1;
			result.M12 = 0;
			result.M13 = 0;
			result.M14 = 0;
			result.M21 = 0;
			result.M22 = 1;
			result.M23 = 0;
			result.M24 = 0;
			result.M31 = 0;
			result.M32 = 0;
			result.M33 = 1;
			result.M34 = 0;
			result.M41 = xPosition;
			result.M42 = yPosition;
			result.M43 = zPosition;
			result.M44 = 1;
			return result;
        }


        public static void CreateTranslation(ref Vector3 position, out Matrix result)
        {
            result.M11 = 1;
			result.M12 = 0;
			result.M13 = 0;
			result.M14 = 0;
			result.M21 = 0;
			result.M22 = 1;
			result.M23 = 0;
			result.M24 = 0;
			result.M31 = 0;
			result.M32 = 0;
			result.M33 = 1;
			result.M34 = 0;
			result.M41 = position.X;
			result.M42 = position.Y;
			result.M43 = position.Z;
			result.M44 = 1;
        }


        public static Matrix CreateTranslation(Vector3 position)
        {
			Matrix result;
        	result.M11 = 1;
			result.M12 = 0;
			result.M13 = 0;
			result.M14 = 0;
			result.M21 = 0;
			result.M22 = 1;
			result.M23 = 0;
			result.M24 = 0;
			result.M31 = 0;
			result.M32 = 0;
			result.M33 = 1;
			result.M34 = 0;
			result.M41 = position.X;
			result.M42 = position.Y;
			result.M43 = position.Z;
			result.M44 = 1;
			return result;
        }


        public static void CreateTranslation(decimal xPosition, decimal yPosition, decimal zPosition, out Matrix result)
        {
            result.M11 = 1;
			result.M12 = 0;
			result.M13 = 0;
			result.M14 = 0;
			result.M21 = 0;
			result.M22 = 1;
			result.M23 = 0;
			result.M24 = 0;
			result.M31 = 0;
			result.M32 = 0;
			result.M33 = 1;
			result.M34 = 0;
			result.M41 = xPosition;
			result.M42 = yPosition;
			result.M43 = zPosition;
			result.M44 = 1;
        }


        public static Matrix CreateWorld(Vector3 position, Vector3 forward, Vector3 up)
        {
            Matrix ret;
                        CreateWorld(ref position, ref forward, ref up, out ret);
                        return ret;
        }

        public static void CreateWorld(ref Vector3 position, ref Vector3 forward, ref Vector3 up, out Matrix result)
        {
                        Vector3 x, y, z;
                        Vector3.Normalize(ref forward, out z);
                        Vector3.Cross(ref forward, ref up, out x);
                        Vector3.Cross(ref x, ref forward, out y);
                        x.Normalize();
                        y.Normalize();            
                        
                        result = new Matrix();
                        result.Right = x;
                        result.Up = y;
                        result.Forward = z;
                        result.Translation = position;
                        result.M44 = 1m;
        }
		
        public decimal Determinant()
        {
            decimal num22 = this.M11;
		    decimal num21 = this.M12;
		    decimal num20 = this.M13;
		    decimal num19 = this.M14;
		    decimal num12 = this.M21;
		    decimal num11 = this.M22;
		    decimal num10 = this.M23;
		    decimal num9 = this.M24;
		    decimal num8 = this.M31;
		    decimal num7 = this.M32;
		    decimal num6 = this.M33;
		    decimal num5 = this.M34;
		    decimal num4 = this.M41;
		    decimal num3 = this.M42;
		    decimal num2 = this.M43;
		    decimal num = this.M44;
		    decimal num18 = (num6 * num) - (num5 * num2);
		    decimal num17 = (num7 * num) - (num5 * num3);
		    decimal num16 = (num7 * num2) - (num6 * num3);
		    decimal num15 = (num8 * num) - (num5 * num4);
		    decimal num14 = (num8 * num2) - (num6 * num4);
		    decimal num13 = (num8 * num3) - (num7 * num4);
		    return ((((num22 * (((num11 * num18) - (num10 * num17)) + (num9 * num16))) - (num21 * (((num12 * num18) - (num10 * num15)) + (num9 * num14)))) + (num20 * (((num12 * num17) - (num11 * num15)) + (num9 * num13)))) - (num19 * (((num12 * num16) - (num11 * num14)) + (num10 * num13))));
        }


        public static Matrix Divide(Matrix matrix1, Matrix matrix2)
        {
		    matrix1.M11 = matrix1.M11 / matrix2.M11;
		    matrix1.M12 = matrix1.M12 / matrix2.M12;
		    matrix1.M13 = matrix1.M13 / matrix2.M13;
		    matrix1.M14 = matrix1.M14 / matrix2.M14;
		    matrix1.M21 = matrix1.M21 / matrix2.M21;
		    matrix1.M22 = matrix1.M22 / matrix2.M22;
		    matrix1.M23 = matrix1.M23 / matrix2.M23;
		    matrix1.M24 = matrix1.M24 / matrix2.M24;
		    matrix1.M31 = matrix1.M31 / matrix2.M31;
		    matrix1.M32 = matrix1.M32 / matrix2.M32;
		    matrix1.M33 = matrix1.M33 / matrix2.M33;
		    matrix1.M34 = matrix1.M34 / matrix2.M34;
		    matrix1.M41 = matrix1.M41 / matrix2.M41;
		    matrix1.M42 = matrix1.M42 / matrix2.M42;
		    matrix1.M43 = matrix1.M43 / matrix2.M43;
		    matrix1.M44 = matrix1.M44 / matrix2.M44;
		    return matrix1;
        }


        public static void Divide(ref Matrix matrix1, ref Matrix matrix2, out Matrix result)
        {
            result.M11 = matrix1.M11 / matrix2.M11;
		    result.M12 = matrix1.M12 / matrix2.M12;
		    result.M13 = matrix1.M13 / matrix2.M13;
		    result.M14 = matrix1.M14 / matrix2.M14;
		    result.M21 = matrix1.M21 / matrix2.M21;
		    result.M22 = matrix1.M22 / matrix2.M22;
		    result.M23 = matrix1.M23 / matrix2.M23;
		    result.M24 = matrix1.M24 / matrix2.M24;
		    result.M31 = matrix1.M31 / matrix2.M31;
		    result.M32 = matrix1.M32 / matrix2.M32;
		    result.M33 = matrix1.M33 / matrix2.M33;
		    result.M34 = matrix1.M34 / matrix2.M34;
		    result.M41 = matrix1.M41 / matrix2.M41;
		    result.M42 = matrix1.M42 / matrix2.M42;
		    result.M43 = matrix1.M43 / matrix2.M43;
		    result.M44 = matrix1.M44 / matrix2.M44;
        }


        public static Matrix Divide(Matrix matrix1, decimal divider)
        {
		    decimal num = 1m / divider;
		    matrix1.M11 = matrix1.M11 * num;
		    matrix1.M12 = matrix1.M12 * num;
		    matrix1.M13 = matrix1.M13 * num;
		    matrix1.M14 = matrix1.M14 * num;
		    matrix1.M21 = matrix1.M21 * num;
		    matrix1.M22 = matrix1.M22 * num;
		    matrix1.M23 = matrix1.M23 * num;
		    matrix1.M24 = matrix1.M24 * num;
		    matrix1.M31 = matrix1.M31 * num;
		    matrix1.M32 = matrix1.M32 * num;
		    matrix1.M33 = matrix1.M33 * num;
		    matrix1.M34 = matrix1.M34 * num;
		    matrix1.M41 = matrix1.M41 * num;
		    matrix1.M42 = matrix1.M42 * num;
		    matrix1.M43 = matrix1.M43 * num;
		    matrix1.M44 = matrix1.M44 * num;
		    return matrix1;
        }


        public static void Divide(ref Matrix matrix1, decimal divider, out Matrix result)
        {
            decimal num = 1m / divider;
		    result.M11 = matrix1.M11 * num;
		    result.M12 = matrix1.M12 * num;
		    result.M13 = matrix1.M13 * num;
		    result.M14 = matrix1.M14 * num;
		    result.M21 = matrix1.M21 * num;
		    result.M22 = matrix1.M22 * num;
		    result.M23 = matrix1.M23 * num;
		    result.M24 = matrix1.M24 * num;
		    result.M31 = matrix1.M31 * num;
		    result.M32 = matrix1.M32 * num;
		    result.M33 = matrix1.M33 * num;
		    result.M34 = matrix1.M34 * num;
		    result.M41 = matrix1.M41 * num;
		    result.M42 = matrix1.M42 * num;
		    result.M43 = matrix1.M43 * num;
		    result.M44 = matrix1.M44 * num;
        }


        public bool Equals(Matrix other)
        {
            return ((((((this.M11 == other.M11) && (this.M22 == other.M22)) && ((this.M33 == other.M33) && (this.M44 == other.M44))) && (((this.M12 == other.M12) && (this.M13 == other.M13)) && ((this.M14 == other.M14) && (this.M21 == other.M21)))) && ((((this.M23 == other.M23) && (this.M24 == other.M24)) && ((this.M31 == other.M31) && (this.M32 == other.M32))) && (((this.M34 == other.M34) && (this.M41 == other.M41)) && (this.M42 == other.M42)))) && (this.M43 == other.M43));
        }


        public override bool Equals(object obj)
        {
            bool flag = false;
		    if (obj is Matrix)
		    {
		        flag = this.Equals((Matrix) obj);
		    }
		    return flag;
        }


        public override int GetHashCode()
        {
            return (((((((((((((((this.M11.GetHashCode() + this.M12.GetHashCode()) + this.M13.GetHashCode()) + this.M14.GetHashCode()) + this.M21.GetHashCode()) + this.M22.GetHashCode()) + this.M23.GetHashCode()) + this.M24.GetHashCode()) + this.M31.GetHashCode()) + this.M32.GetHashCode()) + this.M33.GetHashCode()) + this.M34.GetHashCode()) + this.M41.GetHashCode()) + this.M42.GetHashCode()) + this.M43.GetHashCode()) + this.M44.GetHashCode());
        }


        public static Matrix Invert(Matrix matrix)
        {
            Invert(ref matrix, out matrix);
            return matrix;
        }


        public static void Invert(ref Matrix matrix, out Matrix result)
        {
			decimal num1 = matrix.M11;
			decimal num2 = matrix.M12;
			decimal num3 = matrix.M13;
			decimal num4 = matrix.M14;
			decimal num5 = matrix.M21;
			decimal num6 = matrix.M22;
			decimal num7 = matrix.M23;
			decimal num8 = matrix.M24;
			decimal num9 = matrix.M31;
			decimal num10 = matrix.M32;
			decimal num11 = matrix.M33;
			decimal num12 = matrix.M34;
			decimal num13 = matrix.M41;
			decimal num14 = matrix.M42;
			decimal num15 = matrix.M43;
			decimal num16 = matrix.M44;
			decimal num17 = (decimal) ((decimal) num11 * (decimal) num16 - (decimal) num12 * (decimal) num15);
			decimal num18 = (decimal) ((decimal) num10 * (decimal) num16 - (decimal) num12 * (decimal) num14);
			decimal num19 = (decimal) ((decimal) num10 * (decimal) num15 - (decimal) num11 * (decimal) num14);
			decimal num20 = (decimal) ((decimal) num9 * (decimal) num16 - (decimal) num12 * (decimal) num13);
			decimal num21 = (decimal) ((decimal) num9 * (decimal) num15 - (decimal) num11 * (decimal) num13);
			decimal num22 = (decimal) ((decimal) num9 * (decimal) num14 - (decimal) num10 * (decimal) num13);
			decimal num23 = (decimal) ((decimal) num6 * (decimal) num17 - (decimal) num7 * (decimal) num18 + (decimal) num8 * (decimal) num19);
			decimal num24 = (decimal) -((decimal) num5 * (decimal) num17 - (decimal) num7 * (decimal) num20 + (decimal) num8 * (decimal) num21);
			decimal num25 = (decimal) ((decimal) num5 * (decimal) num18 - (decimal) num6 * (decimal) num20 + (decimal) num8 * (decimal) num22);
			decimal num26 = (decimal) -((decimal) num5 * (decimal) num19 - (decimal) num6 * (decimal) num21 + (decimal) num7 * (decimal) num22);
			decimal num27 = (decimal) (1.0m / ((decimal) num1 * (decimal) num23 + (decimal) num2 * (decimal) num24 + (decimal) num3 * (decimal) num25 + (decimal) num4 * (decimal) num26));
			
			result.M11 = num23 * num27;
			result.M21 = num24 * num27;
			result.M31 = num25 * num27;
			result.M41 = num26 * num27;
			result.M12 = (decimal) -((decimal) num2 * (decimal) num17 - (decimal) num3 * (decimal) num18 + (decimal) num4 * (decimal) num19) * num27;
			result.M22 = (decimal) ((decimal) num1 * (decimal) num17 - (decimal) num3 * (decimal) num20 + (decimal) num4 * (decimal) num21) * num27;
			result.M32 = (decimal) -((decimal) num1 * (decimal) num18 - (decimal) num2 * (decimal) num20 + (decimal) num4 * (decimal) num22) * num27;
			result.M42 = (decimal) ((decimal) num1 * (decimal) num19 - (decimal) num2 * (decimal) num21 + (decimal) num3 * (decimal) num22) * num27;
			decimal num28 = (decimal) ((decimal) num7 * (decimal) num16 - (decimal) num8 * (decimal) num15);
			decimal num29 = (decimal) ((decimal) num6 * (decimal) num16 - (decimal) num8 * (decimal) num14);
			decimal num30 = (decimal) ((decimal) num6 * (decimal) num15 - (decimal) num7 * (decimal) num14);
			decimal num31 = (decimal) ((decimal) num5 * (decimal) num16 - (decimal) num8 * (decimal) num13);
			decimal num32 = (decimal) ((decimal) num5 * (decimal) num15 - (decimal) num7 * (decimal) num13);
			decimal num33 = (decimal) ((decimal) num5 * (decimal) num14 - (decimal) num6 * (decimal) num13);
			result.M13 = (decimal) ((decimal) num2 * (decimal) num28 - (decimal) num3 * (decimal) num29 + (decimal) num4 * (decimal) num30) * num27;
			result.M23 = (decimal) -((decimal) num1 * (decimal) num28 - (decimal) num3 * (decimal) num31 + (decimal) num4 * (decimal) num32) * num27;
			result.M33 = (decimal) ((decimal) num1 * (decimal) num29 - (decimal) num2 * (decimal) num31 + (decimal) num4 * (decimal) num33) * num27;
			result.M43 = (decimal) -((decimal) num1 * (decimal) num30 - (decimal) num2 * (decimal) num32 + (decimal) num3 * (decimal) num33) * num27;
			decimal num34 = (decimal) ((decimal) num7 * (decimal) num12 - (decimal) num8 * (decimal) num11);
			decimal num35 = (decimal) ((decimal) num6 * (decimal) num12 - (decimal) num8 * (decimal) num10);
			decimal num36 = (decimal) ((decimal) num6 * (decimal) num11 - (decimal) num7 * (decimal) num10);
			decimal num37 = (decimal) ((decimal) num5 * (decimal) num12 - (decimal) num8 * (decimal) num9);
			decimal num38 = (decimal) ((decimal) num5 * (decimal) num11 - (decimal) num7 * (decimal) num9);
			decimal num39 = (decimal) ((decimal) num5 * (decimal) num10 - (decimal) num6 * (decimal) num9);
			result.M14 = (decimal) -((decimal) num2 * (decimal) num34 - (decimal) num3 * (decimal) num35 + (decimal) num4 * (decimal) num36) * num27;
			result.M24 = (decimal) ((decimal) num1 * (decimal) num34 - (decimal) num3 * (decimal) num37 + (decimal) num4 * (decimal) num38) * num27;
			result.M34 = (decimal) -((decimal) num1 * (decimal) num35 - (decimal) num2 * (decimal) num37 + (decimal) num4 * (decimal) num39) * num27;
			result.M44 = (decimal) ((decimal) num1 * (decimal) num36 - (decimal) num2 * (decimal) num38 + (decimal) num3 * (decimal) num39) * num27;
			
			
			/*
			
			
            ///
            // Use Laplace expansion theorem to calculate the inverse of a 4x4 matrix
            // 
            // 1. Calculate the 2x2 determinants needed the 4x4 determinant based on the 2x2 determinants 
            // 3. Create the adjugate matrix, which satisfies: A * adj(A) = det(A) * I
            // 4. Divide adjugate matrix with the determinant to find the inverse
            
            decimal det1, det2, det3, det4, det5, det6, det7, det8, det9, det10, det11, det12;
            decimal detMatrix;
            findDeterminants(ref matrix, out detMatrix, out det1, out det2, out det3, out det4, out det5, out det6, 
                             out det7, out det8, out det9, out det10, out det11, out det12);
            
            decimal invDetMatrix = 1m / detMatrix;
            
            Matrix ret; // Allow for matrix and result to point to the same structure
            
            ret.M11 = (matrix.M22*det12 - matrix.M23*det11 + matrix.M24*det10) * invDetMatrix;
            ret.M12 = (-matrix.M12*det12 + matrix.M13*det11 - matrix.M14*det10) * invDetMatrix;
            ret.M13 = (matrix.M42*det6 - matrix.M43*det5 + matrix.M44*det4) * invDetMatrix;
            ret.M14 = (-matrix.M32*det6 + matrix.M33*det5 - matrix.M34*det4) * invDetMatrix;
            ret.M21 = (-matrix.M21*det12 + matrix.M23*det9 - matrix.M24*det8) * invDetMatrix;
            ret.M22 = (matrix.M11*det12 - matrix.M13*det9 + matrix.M14*det8) * invDetMatrix;
            ret.M23 = (-matrix.M41*det6 + matrix.M43*det3 - matrix.M44*det2) * invDetMatrix;
            ret.M24 = (matrix.M31*det6 - matrix.M33*det3 + matrix.M34*det2) * invDetMatrix;
            ret.M31 = (matrix.M21*det11 - matrix.M22*det9 + matrix.M24*det7) * invDetMatrix;
            ret.M32 = (-matrix.M11*det11 + matrix.M12*det9 - matrix.M14*det7) * invDetMatrix;
            ret.M33 = (matrix.M41*det5 - matrix.M42*det3 + matrix.M44*det1) * invDetMatrix;
            ret.M34 = (-matrix.M31*det5 + matrix.M32*det3 - matrix.M34*det1) * invDetMatrix;
            ret.M41 = (-matrix.M21*det10 + matrix.M22*det8 - matrix.M23*det7) * invDetMatrix;
            ret.M42 = (matrix.M11*det10 - matrix.M12*det8 + matrix.M13*det7) * invDetMatrix;
            ret.M43 = (-matrix.M41*det4 + matrix.M42*det2 - matrix.M43*det1) * invDetMatrix;
            ret.M44 = (matrix.M31*det4 - matrix.M32*det2 + matrix.M33*det1) * invDetMatrix;
            
            result = ret;
            */
        }


        public static Matrix Lerp(Matrix matrix1, Matrix matrix2, decimal amount)
        {
		    matrix1.M11 = matrix1.M11 + ((matrix2.M11 - matrix1.M11) * amount);
		    matrix1.M12 = matrix1.M12 + ((matrix2.M12 - matrix1.M12) * amount);
		    matrix1.M13 = matrix1.M13 + ((matrix2.M13 - matrix1.M13) * amount);
		    matrix1.M14 = matrix1.M14 + ((matrix2.M14 - matrix1.M14) * amount);
		    matrix1.M21 = matrix1.M21 + ((matrix2.M21 - matrix1.M21) * amount);
		    matrix1.M22 = matrix1.M22 + ((matrix2.M22 - matrix1.M22) * amount);
		    matrix1.M23 = matrix1.M23 + ((matrix2.M23 - matrix1.M23) * amount);
		    matrix1.M24 = matrix1.M24 + ((matrix2.M24 - matrix1.M24) * amount);
		    matrix1.M31 = matrix1.M31 + ((matrix2.M31 - matrix1.M31) * amount);
		    matrix1.M32 = matrix1.M32 + ((matrix2.M32 - matrix1.M32) * amount);
		    matrix1.M33 = matrix1.M33 + ((matrix2.M33 - matrix1.M33) * amount);
		    matrix1.M34 = matrix1.M34 + ((matrix2.M34 - matrix1.M34) * amount);
		    matrix1.M41 = matrix1.M41 + ((matrix2.M41 - matrix1.M41) * amount);
		    matrix1.M42 = matrix1.M42 + ((matrix2.M42 - matrix1.M42) * amount);
		    matrix1.M43 = matrix1.M43 + ((matrix2.M43 - matrix1.M43) * amount);
		    matrix1.M44 = matrix1.M44 + ((matrix2.M44 - matrix1.M44) * amount);
		    return matrix1;
        }


        public static void Lerp(ref Matrix matrix1, ref Matrix matrix2, decimal amount, out Matrix result)
        {
            result.M11 = matrix1.M11 + ((matrix2.M11 - matrix1.M11) * amount);
		    result.M12 = matrix1.M12 + ((matrix2.M12 - matrix1.M12) * amount);
		    result.M13 = matrix1.M13 + ((matrix2.M13 - matrix1.M13) * amount);
		    result.M14 = matrix1.M14 + ((matrix2.M14 - matrix1.M14) * amount);
		    result.M21 = matrix1.M21 + ((matrix2.M21 - matrix1.M21) * amount);
		    result.M22 = matrix1.M22 + ((matrix2.M22 - matrix1.M22) * amount);
		    result.M23 = matrix1.M23 + ((matrix2.M23 - matrix1.M23) * amount);
		    result.M24 = matrix1.M24 + ((matrix2.M24 - matrix1.M24) * amount);
		    result.M31 = matrix1.M31 + ((matrix2.M31 - matrix1.M31) * amount);
		    result.M32 = matrix1.M32 + ((matrix2.M32 - matrix1.M32) * amount);
		    result.M33 = matrix1.M33 + ((matrix2.M33 - matrix1.M33) * amount);
		    result.M34 = matrix1.M34 + ((matrix2.M34 - matrix1.M34) * amount);
		    result.M41 = matrix1.M41 + ((matrix2.M41 - matrix1.M41) * amount);
		    result.M42 = matrix1.M42 + ((matrix2.M42 - matrix1.M42) * amount);
		    result.M43 = matrix1.M43 + ((matrix2.M43 - matrix1.M43) * amount);
		    result.M44 = matrix1.M44 + ((matrix2.M44 - matrix1.M44) * amount);
        }

        public static Matrix Multiply(Matrix matrix1, Matrix matrix2)
        {
            var m11 = (((matrix1.M11 * matrix2.M11) + (matrix1.M12 * matrix2.M21)) + (matrix1.M13 * matrix2.M31)) + (matrix1.M14 * matrix2.M41);
            var m12 = (((matrix1.M11 * matrix2.M12) + (matrix1.M12 * matrix2.M22)) + (matrix1.M13 * matrix2.M32)) + (matrix1.M14 * matrix2.M42);
            var m13 = (((matrix1.M11 * matrix2.M13) + (matrix1.M12 * matrix2.M23)) + (matrix1.M13 * matrix2.M33)) + (matrix1.M14 * matrix2.M43);
            var m14 = (((matrix1.M11 * matrix2.M14) + (matrix1.M12 * matrix2.M24)) + (matrix1.M13 * matrix2.M34)) + (matrix1.M14 * matrix2.M44);
            var m21 = (((matrix1.M21 * matrix2.M11) + (matrix1.M22 * matrix2.M21)) + (matrix1.M23 * matrix2.M31)) + (matrix1.M24 * matrix2.M41);
            var m22 = (((matrix1.M21 * matrix2.M12) + (matrix1.M22 * matrix2.M22)) + (matrix1.M23 * matrix2.M32)) + (matrix1.M24 * matrix2.M42);
            var m23 = (((matrix1.M21 * matrix2.M13) + (matrix1.M22 * matrix2.M23)) + (matrix1.M23 * matrix2.M33)) + (matrix1.M24 * matrix2.M43);
            var m24 = (((matrix1.M21 * matrix2.M14) + (matrix1.M22 * matrix2.M24)) + (matrix1.M23 * matrix2.M34)) + (matrix1.M24 * matrix2.M44);
            var m31 = (((matrix1.M31 * matrix2.M11) + (matrix1.M32 * matrix2.M21)) + (matrix1.M33 * matrix2.M31)) + (matrix1.M34 * matrix2.M41);
            var m32 = (((matrix1.M31 * matrix2.M12) + (matrix1.M32 * matrix2.M22)) + (matrix1.M33 * matrix2.M32)) + (matrix1.M34 * matrix2.M42);
            var m33 = (((matrix1.M31 * matrix2.M13) + (matrix1.M32 * matrix2.M23)) + (matrix1.M33 * matrix2.M33)) + (matrix1.M34 * matrix2.M43);
            var m34 = (((matrix1.M31 * matrix2.M14) + (matrix1.M32 * matrix2.M24)) + (matrix1.M33 * matrix2.M34)) + (matrix1.M34 * matrix2.M44);
            var m41 = (((matrix1.M41 * matrix2.M11) + (matrix1.M42 * matrix2.M21)) + (matrix1.M43 * matrix2.M31)) + (matrix1.M44 * matrix2.M41);
            var m42 = (((matrix1.M41 * matrix2.M12) + (matrix1.M42 * matrix2.M22)) + (matrix1.M43 * matrix2.M32)) + (matrix1.M44 * matrix2.M42);
            var m43 = (((matrix1.M41 * matrix2.M13) + (matrix1.M42 * matrix2.M23)) + (matrix1.M43 * matrix2.M33)) + (matrix1.M44 * matrix2.M43);
           	var m44 = (((matrix1.M41 * matrix2.M14) + (matrix1.M42 * matrix2.M24)) + (matrix1.M43 * matrix2.M34)) + (matrix1.M44 * matrix2.M44);
            matrix1.M11 = m11;
			matrix1.M12 = m12;
			matrix1.M13 = m13;
			matrix1.M14 = m14;
			matrix1.M21 = m21;
			matrix1.M22 = m22;
			matrix1.M23 = m23;
			matrix1.M24 = m24;
			matrix1.M31 = m31;
			matrix1.M32 = m32;
			matrix1.M33 = m33;
			matrix1.M34 = m34;
			matrix1.M41 = m41;
			matrix1.M42 = m42;
			matrix1.M43 = m43;
			matrix1.M44 = m44;
			return matrix1;
        }


        public static void Multiply(ref Matrix matrix1, ref Matrix matrix2, out Matrix result)
        {
            var m11 = (((matrix1.M11 * matrix2.M11) + (matrix1.M12 * matrix2.M21)) + (matrix1.M13 * matrix2.M31)) + (matrix1.M14 * matrix2.M41);
            var m12 = (((matrix1.M11 * matrix2.M12) + (matrix1.M12 * matrix2.M22)) + (matrix1.M13 * matrix2.M32)) + (matrix1.M14 * matrix2.M42);
            var m13 = (((matrix1.M11 * matrix2.M13) + (matrix1.M12 * matrix2.M23)) + (matrix1.M13 * matrix2.M33)) + (matrix1.M14 * matrix2.M43);
            var m14 = (((matrix1.M11 * matrix2.M14) + (matrix1.M12 * matrix2.M24)) + (matrix1.M13 * matrix2.M34)) + (matrix1.M14 * matrix2.M44);
            var m21 = (((matrix1.M21 * matrix2.M11) + (matrix1.M22 * matrix2.M21)) + (matrix1.M23 * matrix2.M31)) + (matrix1.M24 * matrix2.M41);
            var m22 = (((matrix1.M21 * matrix2.M12) + (matrix1.M22 * matrix2.M22)) + (matrix1.M23 * matrix2.M32)) + (matrix1.M24 * matrix2.M42);
            var m23 = (((matrix1.M21 * matrix2.M13) + (matrix1.M22 * matrix2.M23)) + (matrix1.M23 * matrix2.M33)) + (matrix1.M24 * matrix2.M43);
            var m24 = (((matrix1.M21 * matrix2.M14) + (matrix1.M22 * matrix2.M24)) + (matrix1.M23 * matrix2.M34)) + (matrix1.M24 * matrix2.M44);
            var m31 = (((matrix1.M31 * matrix2.M11) + (matrix1.M32 * matrix2.M21)) + (matrix1.M33 * matrix2.M31)) + (matrix1.M34 * matrix2.M41);
            var m32 = (((matrix1.M31 * matrix2.M12) + (matrix1.M32 * matrix2.M22)) + (matrix1.M33 * matrix2.M32)) + (matrix1.M34 * matrix2.M42);
            var m33 = (((matrix1.M31 * matrix2.M13) + (matrix1.M32 * matrix2.M23)) + (matrix1.M33 * matrix2.M33)) + (matrix1.M34 * matrix2.M43);
            var m34 = (((matrix1.M31 * matrix2.M14) + (matrix1.M32 * matrix2.M24)) + (matrix1.M33 * matrix2.M34)) + (matrix1.M34 * matrix2.M44);
            var m41 = (((matrix1.M41 * matrix2.M11) + (matrix1.M42 * matrix2.M21)) + (matrix1.M43 * matrix2.M31)) + (matrix1.M44 * matrix2.M41);
            var m42 = (((matrix1.M41 * matrix2.M12) + (matrix1.M42 * matrix2.M22)) + (matrix1.M43 * matrix2.M32)) + (matrix1.M44 * matrix2.M42);
            var m43 = (((matrix1.M41 * matrix2.M13) + (matrix1.M42 * matrix2.M23)) + (matrix1.M43 * matrix2.M33)) + (matrix1.M44 * matrix2.M43);
           	var m44 = (((matrix1.M41 * matrix2.M14) + (matrix1.M42 * matrix2.M24)) + (matrix1.M43 * matrix2.M34)) + (matrix1.M44 * matrix2.M44);
            result.M11 = m11;
			result.M12 = m12;
			result.M13 = m13;
			result.M14 = m14;
			result.M21 = m21;
			result.M22 = m22;
			result.M23 = m23;
			result.M24 = m24;
			result.M31 = m31;
			result.M32 = m32;
			result.M33 = m33;
			result.M34 = m34;
			result.M41 = m41;
			result.M42 = m42;
			result.M43 = m43;
			result.M44 = m44;
        }

        public static Matrix Multiply(Matrix matrix1, decimal factor)
        {
            matrix1.M11 *= factor;
            matrix1.M12 *= factor;
            matrix1.M13 *= factor;
            matrix1.M14 *= factor;
            matrix1.M21 *= factor;
            matrix1.M22 *= factor;
            matrix1.M23 *= factor;
            matrix1.M24 *= factor;
            matrix1.M31 *= factor;
            matrix1.M32 *= factor;
            matrix1.M33 *= factor;
            matrix1.M34 *= factor;
            matrix1.M41 *= factor;
            matrix1.M42 *= factor;
            matrix1.M43 *= factor;
            matrix1.M44 *= factor;
            return matrix1;
        }


        public static void Multiply(ref Matrix matrix1, decimal factor, out Matrix result)
        {
            result.M11 = matrix1.M11 * factor;
            result.M12 = matrix1.M12 * factor;
            result.M13 = matrix1.M13 * factor;
            result.M14 = matrix1.M14 * factor;
            result.M21 = matrix1.M21 * factor;
            result.M22 = matrix1.M22 * factor;
            result.M23 = matrix1.M23 * factor;
            result.M24 = matrix1.M24 * factor;
            result.M31 = matrix1.M31 * factor;
            result.M32 = matrix1.M32 * factor;
            result.M33 = matrix1.M33 * factor;
            result.M34 = matrix1.M34 * factor;
            result.M41 = matrix1.M41 * factor;
            result.M42 = matrix1.M42 * factor;
            result.M43 = matrix1.M43 * factor;
            result.M44 = matrix1.M44 * factor;

        }


        public static Matrix Negate(Matrix matrix)
        {
		    matrix.M11 = -matrix.M11;
		    matrix.M12 = -matrix.M12;
		    matrix.M13 = -matrix.M13;
		    matrix.M14 = -matrix.M14;
		    matrix.M21 = -matrix.M21;
		    matrix.M22 = -matrix.M22;
		    matrix.M23 = -matrix.M23;
		    matrix.M24 = -matrix.M24;
		    matrix.M31 = -matrix.M31;
		    matrix.M32 = -matrix.M32;
		    matrix.M33 = -matrix.M33;
		    matrix.M34 = -matrix.M34;
		    matrix.M41 = -matrix.M41;
		    matrix.M42 = -matrix.M42;
		    matrix.M43 = -matrix.M43;
		    matrix.M44 = -matrix.M44;
		    return matrix;
        }


        public static void Negate(ref Matrix matrix, out Matrix result)
        {
            result.M11 = -matrix.M11;
		    result.M12 = -matrix.M12;
		    result.M13 = -matrix.M13;
		    result.M14 = -matrix.M14;
		    result.M21 = -matrix.M21;
		    result.M22 = -matrix.M22;
		    result.M23 = -matrix.M23;
		    result.M24 = -matrix.M24;
		    result.M31 = -matrix.M31;
		    result.M32 = -matrix.M32;
		    result.M33 = -matrix.M33;
		    result.M34 = -matrix.M34;
		    result.M41 = -matrix.M41;
		    result.M42 = -matrix.M42;
		    result.M43 = -matrix.M43;
		    result.M44 = -matrix.M44;
        }


        public static Matrix operator +(Matrix matrix1, Matrix matrix2)
        {
            Matrix.Add(ref matrix1, ref matrix2, out matrix1);
            return matrix1;
        }


        public static Matrix operator /(Matrix matrix1, Matrix matrix2)
        {
		    matrix1.M11 = matrix1.M11 / matrix2.M11;
		    matrix1.M12 = matrix1.M12 / matrix2.M12;
		    matrix1.M13 = matrix1.M13 / matrix2.M13;
		    matrix1.M14 = matrix1.M14 / matrix2.M14;
		    matrix1.M21 = matrix1.M21 / matrix2.M21;
		    matrix1.M22 = matrix1.M22 / matrix2.M22;
		    matrix1.M23 = matrix1.M23 / matrix2.M23;
		    matrix1.M24 = matrix1.M24 / matrix2.M24;
		    matrix1.M31 = matrix1.M31 / matrix2.M31;
		    matrix1.M32 = matrix1.M32 / matrix2.M32;
		    matrix1.M33 = matrix1.M33 / matrix2.M33;
		    matrix1.M34 = matrix1.M34 / matrix2.M34;
		    matrix1.M41 = matrix1.M41 / matrix2.M41;
		    matrix1.M42 = matrix1.M42 / matrix2.M42;
		    matrix1.M43 = matrix1.M43 / matrix2.M43;
		    matrix1.M44 = matrix1.M44 / matrix2.M44;
		    return matrix1;
        }


        public static Matrix operator /(Matrix matrix, decimal divider)
        {
		    decimal num = 1m / divider;
		    matrix.M11 = matrix.M11 * num;
		    matrix.M12 = matrix.M12 * num;
		    matrix.M13 = matrix.M13 * num;
		    matrix.M14 = matrix.M14 * num;
		    matrix.M21 = matrix.M21 * num;
		    matrix.M22 = matrix.M22 * num;
		    matrix.M23 = matrix.M23 * num;
		    matrix.M24 = matrix.M24 * num;
		    matrix.M31 = matrix.M31 * num;
		    matrix.M32 = matrix.M32 * num;
		    matrix.M33 = matrix.M33 * num;
		    matrix.M34 = matrix.M34 * num;
		    matrix.M41 = matrix.M41 * num;
		    matrix.M42 = matrix.M42 * num;
		    matrix.M43 = matrix.M43 * num;
		    matrix.M44 = matrix.M44 * num;
		    return matrix;
        }


        public static bool operator ==(Matrix matrix1, Matrix matrix2)
        {
            return (
                matrix1.M11 == matrix2.M11 &&
                matrix1.M12 == matrix2.M12 &&
                matrix1.M13 == matrix2.M13 &&
                matrix1.M14 == matrix2.M14 &&
                matrix1.M21 == matrix2.M21 &&
                matrix1.M22 == matrix2.M22 &&
                matrix1.M23 == matrix2.M23 &&
                matrix1.M24 == matrix2.M24 &&
                matrix1.M31 == matrix2.M31 &&
                matrix1.M32 == matrix2.M32 &&
                matrix1.M33 == matrix2.M33 &&
                matrix1.M34 == matrix2.M34 &&
                matrix1.M41 == matrix2.M41 &&
                matrix1.M42 == matrix2.M42 &&
                matrix1.M43 == matrix2.M43 &&
                matrix1.M44 == matrix2.M44                  
                );
        }


        public static bool operator !=(Matrix matrix1, Matrix matrix2)
        {
            return (
                matrix1.M11 != matrix2.M11 ||
                matrix1.M12 != matrix2.M12 ||
                matrix1.M13 != matrix2.M13 ||
                matrix1.M14 != matrix2.M14 ||
                matrix1.M21 != matrix2.M21 ||
                matrix1.M22 != matrix2.M22 ||
                matrix1.M23 != matrix2.M23 ||
                matrix1.M24 != matrix2.M24 ||
                matrix1.M31 != matrix2.M31 ||
                matrix1.M32 != matrix2.M32 ||
                matrix1.M33 != matrix2.M33 ||
                matrix1.M34 != matrix2.M34 || 
                matrix1.M41 != matrix2.M41 ||
                matrix1.M42 != matrix2.M42 ||
                matrix1.M43 != matrix2.M43 ||
                matrix1.M44 != matrix2.M44                  
                );
        }


        public static Matrix operator *(Matrix matrix1, Matrix matrix2)
        {
            var m11 = (((matrix1.M11 * matrix2.M11) + (matrix1.M12 * matrix2.M21)) + (matrix1.M13 * matrix2.M31)) + (matrix1.M14 * matrix2.M41);
            var m12 = (((matrix1.M11 * matrix2.M12) + (matrix1.M12 * matrix2.M22)) + (matrix1.M13 * matrix2.M32)) + (matrix1.M14 * matrix2.M42);
            var m13 = (((matrix1.M11 * matrix2.M13) + (matrix1.M12 * matrix2.M23)) + (matrix1.M13 * matrix2.M33)) + (matrix1.M14 * matrix2.M43);
            var m14 = (((matrix1.M11 * matrix2.M14) + (matrix1.M12 * matrix2.M24)) + (matrix1.M13 * matrix2.M34)) + (matrix1.M14 * matrix2.M44);
            var m21 = (((matrix1.M21 * matrix2.M11) + (matrix1.M22 * matrix2.M21)) + (matrix1.M23 * matrix2.M31)) + (matrix1.M24 * matrix2.M41);
            var m22 = (((matrix1.M21 * matrix2.M12) + (matrix1.M22 * matrix2.M22)) + (matrix1.M23 * matrix2.M32)) + (matrix1.M24 * matrix2.M42);
            var m23 = (((matrix1.M21 * matrix2.M13) + (matrix1.M22 * matrix2.M23)) + (matrix1.M23 * matrix2.M33)) + (matrix1.M24 * matrix2.M43);
            var m24 = (((matrix1.M21 * matrix2.M14) + (matrix1.M22 * matrix2.M24)) + (matrix1.M23 * matrix2.M34)) + (matrix1.M24 * matrix2.M44);
            var m31 = (((matrix1.M31 * matrix2.M11) + (matrix1.M32 * matrix2.M21)) + (matrix1.M33 * matrix2.M31)) + (matrix1.M34 * matrix2.M41);
            var m32 = (((matrix1.M31 * matrix2.M12) + (matrix1.M32 * matrix2.M22)) + (matrix1.M33 * matrix2.M32)) + (matrix1.M34 * matrix2.M42);
            var m33 = (((matrix1.M31 * matrix2.M13) + (matrix1.M32 * matrix2.M23)) + (matrix1.M33 * matrix2.M33)) + (matrix1.M34 * matrix2.M43);
            var m34 = (((matrix1.M31 * matrix2.M14) + (matrix1.M32 * matrix2.M24)) + (matrix1.M33 * matrix2.M34)) + (matrix1.M34 * matrix2.M44);
            var m41 = (((matrix1.M41 * matrix2.M11) + (matrix1.M42 * matrix2.M21)) + (matrix1.M43 * matrix2.M31)) + (matrix1.M44 * matrix2.M41);
            var m42 = (((matrix1.M41 * matrix2.M12) + (matrix1.M42 * matrix2.M22)) + (matrix1.M43 * matrix2.M32)) + (matrix1.M44 * matrix2.M42);
            var m43 = (((matrix1.M41 * matrix2.M13) + (matrix1.M42 * matrix2.M23)) + (matrix1.M43 * matrix2.M33)) + (matrix1.M44 * matrix2.M43);
           	var m44 = (((matrix1.M41 * matrix2.M14) + (matrix1.M42 * matrix2.M24)) + (matrix1.M43 * matrix2.M34)) + (matrix1.M44 * matrix2.M44);
            matrix1.M11 = m11;
			matrix1.M12 = m12;
			matrix1.M13 = m13;
			matrix1.M14 = m14;
			matrix1.M21 = m21;
			matrix1.M22 = m22;
			matrix1.M23 = m23;
			matrix1.M24 = m24;
			matrix1.M31 = m31;
			matrix1.M32 = m32;
			matrix1.M33 = m33;
			matrix1.M34 = m34;
			matrix1.M41 = m41;
			matrix1.M42 = m42;
			matrix1.M43 = m43;
			matrix1.M44 = m44;
			return matrix1;
        }


        public static Matrix operator *(Matrix matrix, decimal scaleFactor)
        {
		    matrix.M11 = matrix.M11 * scaleFactor;
		    matrix.M12 = matrix.M12 * scaleFactor;
		    matrix.M13 = matrix.M13 * scaleFactor;
		    matrix.M14 = matrix.M14 * scaleFactor;
		    matrix.M21 = matrix.M21 * scaleFactor;
		    matrix.M22 = matrix.M22 * scaleFactor;
		    matrix.M23 = matrix.M23 * scaleFactor;
		    matrix.M24 = matrix.M24 * scaleFactor;
		    matrix.M31 = matrix.M31 * scaleFactor;
		    matrix.M32 = matrix.M32 * scaleFactor;
		    matrix.M33 = matrix.M33 * scaleFactor;
		    matrix.M34 = matrix.M34 * scaleFactor;
		    matrix.M41 = matrix.M41 * scaleFactor;
		    matrix.M42 = matrix.M42 * scaleFactor;
		    matrix.M43 = matrix.M43 * scaleFactor;
		    matrix.M44 = matrix.M44 * scaleFactor;
		    return matrix;
        }


        public static Matrix operator -(Matrix matrix1, Matrix matrix2)
        {
		    matrix1.M11 = matrix1.M11 - matrix2.M11;
		    matrix1.M12 = matrix1.M12 - matrix2.M12;
		    matrix1.M13 = matrix1.M13 - matrix2.M13;
		    matrix1.M14 = matrix1.M14 - matrix2.M14;
		    matrix1.M21 = matrix1.M21 - matrix2.M21;
		    matrix1.M22 = matrix1.M22 - matrix2.M22;
		    matrix1.M23 = matrix1.M23 - matrix2.M23;
		    matrix1.M24 = matrix1.M24 - matrix2.M24;
		    matrix1.M31 = matrix1.M31 - matrix2.M31;
		    matrix1.M32 = matrix1.M32 - matrix2.M32;
		    matrix1.M33 = matrix1.M33 - matrix2.M33;
		    matrix1.M34 = matrix1.M34 - matrix2.M34;
		    matrix1.M41 = matrix1.M41 - matrix2.M41;
		    matrix1.M42 = matrix1.M42 - matrix2.M42;
		    matrix1.M43 = matrix1.M43 - matrix2.M43;
		    matrix1.M44 = matrix1.M44 - matrix2.M44;
		    return matrix1;
        }


        public static Matrix operator -(Matrix matrix)
        {
		    matrix.M11 = -matrix.M11;
		    matrix.M12 = -matrix.M12;
		    matrix.M13 = -matrix.M13;
		    matrix.M14 = -matrix.M14;
		    matrix.M21 = -matrix.M21;
		    matrix.M22 = -matrix.M22;
		    matrix.M23 = -matrix.M23;
		    matrix.M24 = -matrix.M24;
		    matrix.M31 = -matrix.M31;
		    matrix.M32 = -matrix.M32;
		    matrix.M33 = -matrix.M33;
		    matrix.M34 = -matrix.M34;
		    matrix.M41 = -matrix.M41;
		    matrix.M42 = -matrix.M42;
		    matrix.M43 = -matrix.M43;
		    matrix.M44 = -matrix.M44;
			return matrix;
        }


        public static Matrix Subtract(Matrix matrix1, Matrix matrix2)
        {
		    matrix1.M11 = matrix1.M11 - matrix2.M11;
		    matrix1.M12 = matrix1.M12 - matrix2.M12;
		    matrix1.M13 = matrix1.M13 - matrix2.M13;
		    matrix1.M14 = matrix1.M14 - matrix2.M14;
		    matrix1.M21 = matrix1.M21 - matrix2.M21;
		    matrix1.M22 = matrix1.M22 - matrix2.M22;
		    matrix1.M23 = matrix1.M23 - matrix2.M23;
		    matrix1.M24 = matrix1.M24 - matrix2.M24;
		    matrix1.M31 = matrix1.M31 - matrix2.M31;
		    matrix1.M32 = matrix1.M32 - matrix2.M32;
		    matrix1.M33 = matrix1.M33 - matrix2.M33;
		    matrix1.M34 = matrix1.M34 - matrix2.M34;
		    matrix1.M41 = matrix1.M41 - matrix2.M41;
		    matrix1.M42 = matrix1.M42 - matrix2.M42;
		    matrix1.M43 = matrix1.M43 - matrix2.M43;
		    matrix1.M44 = matrix1.M44 - matrix2.M44;
		    return matrix1;
        }


        public static void Subtract(ref Matrix matrix1, ref Matrix matrix2, out Matrix result)
        {
            result.M11 = matrix1.M11 - matrix2.M11;
		    result.M12 = matrix1.M12 - matrix2.M12;
		    result.M13 = matrix1.M13 - matrix2.M13;
		    result.M14 = matrix1.M14 - matrix2.M14;
		    result.M21 = matrix1.M21 - matrix2.M21;
		    result.M22 = matrix1.M22 - matrix2.M22;
		    result.M23 = matrix1.M23 - matrix2.M23;
		    result.M24 = matrix1.M24 - matrix2.M24;
		    result.M31 = matrix1.M31 - matrix2.M31;
		    result.M32 = matrix1.M32 - matrix2.M32;
		    result.M33 = matrix1.M33 - matrix2.M33;
		    result.M34 = matrix1.M34 - matrix2.M34;
		    result.M41 = matrix1.M41 - matrix2.M41;
		    result.M42 = matrix1.M42 - matrix2.M42;
		    result.M43 = matrix1.M43 - matrix2.M43;
		    result.M44 = matrix1.M44 - matrix2.M44;
        }


        public override string ToString()
        {
            return "{" + String.Format("M11:{0} M12:{1} M13:{2} M14:{3}", M11, M12, M13, M14) + "}"
				+ " {" + String.Format("M21:{0} M22:{1} M23:{2} M24:{3}", M21, M22, M23, M24) + "}"
				+ " {" + String.Format("M31:{0} M32:{1} M33:{2} M34:{3}", M31, M32, M33, M34) + "}"
				+ " {" + String.Format("M41:{0} M42:{1} M43:{2} M44:{3}", M41, M42, M43, M44) + "}";
        }


        public static Matrix Transpose(Matrix matrix)
        {
            Matrix ret;
            Transpose(ref matrix, out ret);
            return ret;
        }

        
        public static void Transpose(ref Matrix matrix, out Matrix result)
        {
            result.M11 = matrix.M11;
            result.M12 = matrix.M21;
            result.M13 = matrix.M31;
            result.M14 = matrix.M41;

            result.M21 = matrix.M12;
            result.M22 = matrix.M22;
            result.M23 = matrix.M32;
            result.M24 = matrix.M42;

            result.M31 = matrix.M13;
            result.M32 = matrix.M23;
            result.M33 = matrix.M33;
            result.M34 = matrix.M43;

            result.M41 = matrix.M14;
            result.M42 = matrix.M24;
            result.M43 = matrix.M34;
            result.M44 = matrix.M44;
        }
        #endregion Public Methods
		
		#region Private Static Methods
        
        /// <summary>
        /// Helper method for using the Laplace expansion theorem using two rows expansions to calculate major and 
        /// minor determinants of a 4x4 matrix. This method is used for inverting a matrix.
        /// </summary>
        private static void findDeterminants(ref Matrix matrix, out decimal major, 
                                             out decimal minor1, out decimal minor2, out decimal minor3, out decimal minor4, out decimal minor5, out decimal minor6,
                                             out decimal minor7, out decimal minor8, out decimal minor9, out decimal minor10, out decimal minor11, out decimal minor12)
        {
                decimal det1 = (decimal)matrix.M11 * (decimal)matrix.M22 - (decimal)matrix.M12 * (decimal)matrix.M21;
                decimal det2 = (decimal)matrix.M11 * (decimal)matrix.M23 - (decimal)matrix.M13 * (decimal)matrix.M21;
                decimal det3 = (decimal)matrix.M11 * (decimal)matrix.M24 - (decimal)matrix.M14 * (decimal)matrix.M21;
                decimal det4 = (decimal)matrix.M12 * (decimal)matrix.M23 - (decimal)matrix.M13 * (decimal)matrix.M22;
                decimal det5 = (decimal)matrix.M12 * (decimal)matrix.M24 - (decimal)matrix.M14 * (decimal)matrix.M22;
                decimal det6 = (decimal)matrix.M13 * (decimal)matrix.M24 - (decimal)matrix.M14 * (decimal)matrix.M23;
                decimal det7 = (decimal)matrix.M31 * (decimal)matrix.M42 - (decimal)matrix.M32 * (decimal)matrix.M41;
                decimal det8 = (decimal)matrix.M31 * (decimal)matrix.M43 - (decimal)matrix.M33 * (decimal)matrix.M41;
                decimal det9 = (decimal)matrix.M31 * (decimal)matrix.M44 - (decimal)matrix.M34 * (decimal)matrix.M41;
                decimal det10 = (decimal)matrix.M32 * (decimal)matrix.M43 - (decimal)matrix.M33 * (decimal)matrix.M42;
                decimal det11 = (decimal)matrix.M32 * (decimal)matrix.M44 - (decimal)matrix.M34 * (decimal)matrix.M42;
                decimal det12 = (decimal)matrix.M33 * (decimal)matrix.M44 - (decimal)matrix.M34 * (decimal)matrix.M43;
                
                major = (decimal)(det1*det12 - det2*det11 + det3*det10 + det4*det9 - det5*det8 + det6*det7);
                minor1 = (decimal)det1;
                minor2 = (decimal)det2;
                minor3 = (decimal)det3;
                minor4 = (decimal)det4;
                minor5 = (decimal)det5;
                minor6 = (decimal)det6;
                minor7 = (decimal)det7;
                minor8 = (decimal)det8;
                minor9 = (decimal)det9;
                minor10 = (decimal)det10;
                minor11 = (decimal)det11;
                minor12 = (decimal)det12;
        }
		
        #endregion Private Static Methods
		
		public bool Decompose(out Vector3 scale, out Quaternion rotation, out Vector3 translation)
        {
                translation.X = this.M41;
                translation.Y = this.M42;
                translation.Z = this.M43;
                
                decimal xs = (Math.Sign(M11 * M12 * M13 * M14) < 0) ? -1m : 1m;
                decimal ys = (Math.Sign(M21 * M22 * M23 * M24) < 0) ? -1m : 1m;
				decimal zs = (Math.Sign(M31 * M32 * M33 * M34) < 0) ? -1m : 1m;                               
                
                scale.X = xs * (decimal)MathHelper.DSqrt(this.M11 * this.M11 + this.M12 * this.M12 + this.M13 * this.M13);
                scale.Y = ys * (decimal)MathHelper.DSqrt(this.M21 * this.M21 + this.M22 * this.M22 + this.M23 * this.M23);
                scale.Z = zs * (decimal)MathHelper.DSqrt(this.M31 * this.M31 + this.M32 * this.M32 + this.M33 * this.M33);
                
                if (scale.X == 0.0m || scale.Y == 0.0m || scale.Z == 0.0m)
                {
                        rotation = Quaternion.Identity;
                        return false;
                }

                Matrix m1 = new Matrix(this.M11/scale.X, M12/scale.X, M13/scale.X, 0,
                       				   this.M21/scale.Y, M22/scale.Y, M23/scale.Y, 0,
                       				   this.M31/scale.Z, M32/scale.Z, M33/scale.Z, 0,
                       				   0, 0, 0, 1);
                
                rotation = Quaternion.CreateFromRotationMatrix(m1);
                return true;
        }
			
    }
}