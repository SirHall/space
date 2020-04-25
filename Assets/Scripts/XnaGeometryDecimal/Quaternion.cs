#region License
/*
MIT License
Copyright © 2006 The Mono.Xna Team

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
#if WINRT
using System.Runtime.Serialization;
#endif

namespace XnaGeometryDecimal
{
#if WINRT
    [DataContract]
#else
    [Serializable]
#endif
    public struct Quaternion : IEquatable<Quaternion>
    {
#if WINRT
        [DataMember]
#endif
        public decimal X;
#if WINRT
        [DataMember]
#endif
        public decimal Y;
#if WINRT
        [DataMember]
#endif
        public decimal Z;
#if WINRT
        [DataMember]
#endif
        public decimal W;

        static Quaternion identity = new Quaternion(0, 0, 0, 1);


        public Quaternion(decimal x, decimal y, decimal z, decimal w)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
            this.W = w;
        }


        public Quaternion(Vector3 vectorPart, decimal scalarPart)
        {
            this.X = vectorPart.X;
            this.Y = vectorPart.Y;
            this.Z = vectorPart.Z;
            this.W = scalarPart;
        }

        public static Quaternion Identity
        {
            get { return identity; }
        }


        public static Quaternion Add(Quaternion quaternion1, Quaternion quaternion2)
        {
            //Syderis
            Quaternion quaternion;
            quaternion.X = quaternion1.X + quaternion2.X;
            quaternion.Y = quaternion1.Y + quaternion2.Y;
            quaternion.Z = quaternion1.Z + quaternion2.Z;
            quaternion.W = quaternion1.W + quaternion2.W;
            return quaternion;
        }


        public static void Add(ref Quaternion quaternion1, ref Quaternion quaternion2, out Quaternion result)
        {
            //Syderis
            result.X = quaternion1.X + quaternion2.X;
            result.Y = quaternion1.Y + quaternion2.Y;
            result.Z = quaternion1.Z + quaternion2.Z;
            result.W = quaternion1.W + quaternion2.W;
        }

        //Funcion añadida Syderis
        public static Quaternion Concatenate(Quaternion value1, Quaternion value2)
        {
            Quaternion quaternion;
            decimal x = value2.X;
            decimal y = value2.Y;
            decimal z = value2.Z;
            decimal w = value2.W;
            decimal num4 = value1.X;
            decimal num3 = value1.Y;
            decimal num2 = value1.Z;
            decimal num = value1.W;
            decimal num12 = (y * num2) - (z * num3);
            decimal num11 = (z * num4) - (x * num2);
            decimal num10 = (x * num3) - (y * num4);
            decimal num9 = ((x * num4) + (y * num3)) + (z * num2);
            quaternion.X = ((x * num) + (num4 * w)) + num12;
            quaternion.Y = ((y * num) + (num3 * w)) + num11;
            quaternion.Z = ((z * num) + (num2 * w)) + num10;
            quaternion.W = (w * num) - num9;
            return quaternion;

        }

        //Añadida por Syderis
        public static void Concatenate(ref Quaternion value1, ref Quaternion value2, out Quaternion result)
        {
            decimal x = value2.X;
            decimal y = value2.Y;
            decimal z = value2.Z;
            decimal w = value2.W;
            decimal num4 = value1.X;
            decimal num3 = value1.Y;
            decimal num2 = value1.Z;
            decimal num = value1.W;
            decimal num12 = (y * num2) - (z * num3);
            decimal num11 = (z * num4) - (x * num2);
            decimal num10 = (x * num3) - (y * num4);
            decimal num9 = ((x * num4) + (y * num3)) + (z * num2);
            result.X = ((x * num) + (num4 * w)) + num12;
            result.Y = ((y * num) + (num3 * w)) + num11;
            result.Z = ((z * num) + (num2 * w)) + num10;
            result.W = (w * num) - num9;
        }

        //Añadida por Syderis
        public void Conjugate()
        {
            this.X = -this.X;
            this.Y = -this.Y;
            this.Z = -this.Z;
        }

        //Añadida por Syderis
        public static Quaternion Conjugate(Quaternion value)
        {
            Quaternion quaternion;
            quaternion.X = -value.X;
            quaternion.Y = -value.Y;
            quaternion.Z = -value.Z;
            quaternion.W = value.W;
            return quaternion;
        }

        //Añadida por Syderis
        public static void Conjugate(ref Quaternion value, out Quaternion result)
        {
            result.X = -value.X;
            result.Y = -value.Y;
            result.Z = -value.Z;
            result.W = value.W;
        }

        public static Quaternion CreateFromAxisAngle(Vector3 axis, decimal angle)
        {

            Quaternion quaternion;
            decimal num2 = angle * 0.5m;
            decimal num = (decimal)Math.Sin((double)num2);
            decimal num3 = (decimal)Math.Cos((double)num2);
            quaternion.X = axis.X * num;
            quaternion.Y = axis.Y * num;
            quaternion.Z = axis.Z * num;
            quaternion.W = num3;
            return quaternion;

        }


        public static void CreateFromAxisAngle(ref Vector3 axis, decimal angle, out Quaternion result)
        {
            decimal num2 = angle * 0.5m;
            decimal num = (decimal)Math.Sin((double)num2);
            decimal num3 = (decimal)Math.Cos((double)num2);
            result.X = axis.X * num;
            result.Y = axis.Y * num;
            result.Z = axis.Z * num;
            result.W = num3;

        }


        public static Quaternion CreateFromRotationMatrix(Matrix matrix)
        {
            decimal num8 = (matrix.M11 + matrix.M22) + matrix.M33;
            Quaternion quaternion = new Quaternion();
            if (num8 > 0m)
            {
                decimal num = (decimal)MathHelper.DSqrt((decimal)(num8 + 1m));
                quaternion.W = num * 0.5m;
                num = 0.5m / num;
                quaternion.X = (matrix.M23 - matrix.M32) * num;
                quaternion.Y = (matrix.M31 - matrix.M13) * num;
                quaternion.Z = (matrix.M12 - matrix.M21) * num;
                return quaternion;
            }
            if ((matrix.M11 >= matrix.M22) && (matrix.M11 >= matrix.M33))
            {
                decimal num7 = (decimal)MathHelper.DSqrt((decimal)(((1m + matrix.M11) - matrix.M22) - matrix.M33));
                decimal num4 = 0.5m / num7;
                quaternion.X = 0.5m * num7;
                quaternion.Y = (matrix.M12 + matrix.M21) * num4;
                quaternion.Z = (matrix.M13 + matrix.M31) * num4;
                quaternion.W = (matrix.M23 - matrix.M32) * num4;
                return quaternion;
            }
            if (matrix.M22 > matrix.M33)
            {
                decimal num6 = (decimal)MathHelper.DSqrt((decimal)(((1m + matrix.M22) - matrix.M11) - matrix.M33));
                decimal num3 = 0.5m / num6;
                quaternion.X = (matrix.M21 + matrix.M12) * num3;
                quaternion.Y = 0.5m * num6;
                quaternion.Z = (matrix.M32 + matrix.M23) * num3;
                quaternion.W = (matrix.M31 - matrix.M13) * num3;
                return quaternion;
            }
            decimal num5 = (decimal)MathHelper.DSqrt((decimal)(((1m + matrix.M33) - matrix.M11) - matrix.M22));
            decimal num2 = 0.5m / num5;
            quaternion.X = (matrix.M31 + matrix.M13) * num2;
            quaternion.Y = (matrix.M32 + matrix.M23) * num2;
            quaternion.Z = 0.5m * num5;
            quaternion.W = (matrix.M12 - matrix.M21) * num2;

            return quaternion;

        }


        public static void CreateFromRotationMatrix(ref Matrix matrix, out Quaternion result)
        {
            decimal num8 = (matrix.M11 + matrix.M22) + matrix.M33;
            if (num8 > 0m)
            {
                decimal num = (decimal)MathHelper.DSqrt((decimal)(num8 + 1m));
                result.W = num * 0.5m;
                num = 0.5m / num;
                result.X = (matrix.M23 - matrix.M32) * num;
                result.Y = (matrix.M31 - matrix.M13) * num;
                result.Z = (matrix.M12 - matrix.M21) * num;
            }
            else if ((matrix.M11 >= matrix.M22) && (matrix.M11 >= matrix.M33))
            {
                decimal num7 = (decimal)MathHelper.DSqrt((decimal)(((1m + matrix.M11) - matrix.M22) - matrix.M33));
                decimal num4 = 0.5m / num7;
                result.X = 0.5m * num7;
                result.Y = (matrix.M12 + matrix.M21) * num4;
                result.Z = (matrix.M13 + matrix.M31) * num4;
                result.W = (matrix.M23 - matrix.M32) * num4;
            }
            else if (matrix.M22 > matrix.M33)
            {
                decimal num6 = (decimal)MathHelper.DSqrt((decimal)(((1m + matrix.M22) - matrix.M11) - matrix.M33));
                decimal num3 = 0.5m / num6;
                result.X = (matrix.M21 + matrix.M12) * num3;
                result.Y = 0.5m * num6;
                result.Z = (matrix.M32 + matrix.M23) * num3;
                result.W = (matrix.M31 - matrix.M13) * num3;
            }
            else
            {
                decimal num5 = (decimal)MathHelper.DSqrt((decimal)(((1m + matrix.M33) - matrix.M11) - matrix.M22));
                decimal num2 = 0.5m / num5;
                result.X = (matrix.M31 + matrix.M13) * num2;
                result.Y = (matrix.M32 + matrix.M23) * num2;
                result.Z = 0.5m * num5;
                result.W = (matrix.M12 - matrix.M21) * num2;
            }

        }

        public static Quaternion CreateFromYawPitchRoll(decimal yaw, decimal pitch, decimal roll)
        {
            Quaternion quaternion;
            decimal num9 = roll * 0.5m;
            decimal num6 = (decimal)Math.Sin((double)num9);
            decimal num5 = (decimal)Math.Cos((double)num9);
            decimal num8 = pitch * 0.5m;
            decimal num4 = (decimal)Math.Sin((double)num8);
            decimal num3 = (decimal)Math.Cos((double)num8);
            decimal num7 = yaw * 0.5m;
            decimal num2 = (decimal)Math.Sin((double)num7);
            decimal num = (decimal)Math.Cos((double)num7);
            quaternion.X = ((num * num4) * num5) + ((num2 * num3) * num6);
            quaternion.Y = ((num2 * num3) * num5) - ((num * num4) * num6);
            quaternion.Z = ((num * num3) * num6) - ((num2 * num4) * num5);
            quaternion.W = ((num * num3) * num5) + ((num2 * num4) * num6);
            return quaternion;
        }

        public static void CreateFromYawPitchRoll(decimal yaw, decimal pitch, decimal roll, out Quaternion result)
        {
            decimal num9 = roll * 0.5m;
            decimal num6 = (decimal)Math.Sin((double)num9);
            decimal num5 = (decimal)Math.Cos((double)num9);
            decimal num8 = pitch * 0.5m;
            decimal num4 = (decimal)Math.Sin((double)num8);
            decimal num3 = (decimal)Math.Cos((double)num8);
            decimal num7 = yaw * 0.5m;
            decimal num2 = (decimal)Math.Sin((double)num7);
            decimal num = (decimal)Math.Cos((double)num7);
            result.X = ((num * num4) * num5) + ((num2 * num3) * num6);
            result.Y = ((num2 * num3) * num5) - ((num * num4) * num6);
            result.Z = ((num * num3) * num6) - ((num2 * num4) * num5);
            result.W = ((num * num3) * num5) + ((num2 * num4) * num6);
        }

        public static Quaternion Divide(Quaternion quaternion1, Quaternion quaternion2)
        {
            Quaternion quaternion;
            decimal x = quaternion1.X;
            decimal y = quaternion1.Y;
            decimal z = quaternion1.Z;
            decimal w = quaternion1.W;
            decimal num14 = (((quaternion2.X * quaternion2.X) + (quaternion2.Y * quaternion2.Y)) + (quaternion2.Z * quaternion2.Z)) + (quaternion2.W * quaternion2.W);
            decimal num5 = 1m / num14;
            decimal num4 = -quaternion2.X * num5;
            decimal num3 = -quaternion2.Y * num5;
            decimal num2 = -quaternion2.Z * num5;
            decimal num = quaternion2.W * num5;
            decimal num13 = (y * num2) - (z * num3);
            decimal num12 = (z * num4) - (x * num2);
            decimal num11 = (x * num3) - (y * num4);
            decimal num10 = ((x * num4) + (y * num3)) + (z * num2);
            quaternion.X = ((x * num) + (num4 * w)) + num13;
            quaternion.Y = ((y * num) + (num3 * w)) + num12;
            quaternion.Z = ((z * num) + (num2 * w)) + num11;
            quaternion.W = (w * num) - num10;
            return quaternion;

        }

        public static void Divide(ref Quaternion quaternion1, ref Quaternion quaternion2, out Quaternion result)
        {
            decimal x = quaternion1.X;
            decimal y = quaternion1.Y;
            decimal z = quaternion1.Z;
            decimal w = quaternion1.W;
            decimal num14 = (((quaternion2.X * quaternion2.X) + (quaternion2.Y * quaternion2.Y)) + (quaternion2.Z * quaternion2.Z)) + (quaternion2.W * quaternion2.W);
            decimal num5 = 1m / num14;
            decimal num4 = -quaternion2.X * num5;
            decimal num3 = -quaternion2.Y * num5;
            decimal num2 = -quaternion2.Z * num5;
            decimal num = quaternion2.W * num5;
            decimal num13 = (y * num2) - (z * num3);
            decimal num12 = (z * num4) - (x * num2);
            decimal num11 = (x * num3) - (y * num4);
            decimal num10 = ((x * num4) + (y * num3)) + (z * num2);
            result.X = ((x * num) + (num4 * w)) + num13;
            result.Y = ((y * num) + (num3 * w)) + num12;
            result.Z = ((z * num) + (num2 * w)) + num11;
            result.W = (w * num) - num10;

        }


        public static decimal Dot(Quaternion quaternion1, Quaternion quaternion2)
        {
            return ((((quaternion1.X * quaternion2.X) + (quaternion1.Y * quaternion2.Y)) + (quaternion1.Z * quaternion2.Z)) + (quaternion1.W * quaternion2.W));
        }


        public static void Dot(ref Quaternion quaternion1, ref Quaternion quaternion2, out decimal result)
        {
            result = (((quaternion1.X * quaternion2.X) + (quaternion1.Y * quaternion2.Y)) + (quaternion1.Z * quaternion2.Z)) + (quaternion1.W * quaternion2.W);
        }


        public override bool Equals(object obj)
        {
            bool flag = false;
            if (obj is Quaternion)
            {
                flag = this.Equals((Quaternion)obj);
            }
            return flag;
        }


        public bool Equals(Quaternion other)
        {
            return ((((this.X == other.X) && (this.Y == other.Y)) && (this.Z == other.Z)) && (this.W == other.W));
        }


        public override int GetHashCode()
        {
            return (((this.X.GetHashCode() + this.Y.GetHashCode()) + this.Z.GetHashCode()) + this.W.GetHashCode());
        }


        public static Quaternion Inverse(Quaternion quaternion)
        {
            Quaternion quaternion2;
            decimal num2 = (((quaternion.X * quaternion.X) + (quaternion.Y * quaternion.Y)) + (quaternion.Z * quaternion.Z)) + (quaternion.W * quaternion.W);
            decimal num = 1m / num2;
            quaternion2.X = -quaternion.X * num;
            quaternion2.Y = -quaternion.Y * num;
            quaternion2.Z = -quaternion.Z * num;
            quaternion2.W = quaternion.W * num;
            return quaternion2;

        }

        public static void Inverse(ref Quaternion quaternion, out Quaternion result)
        {
            decimal num2 = (((quaternion.X * quaternion.X) + (quaternion.Y * quaternion.Y)) + (quaternion.Z * quaternion.Z)) + (quaternion.W * quaternion.W);
            decimal num = 1m / num2;
            result.X = -quaternion.X * num;
            result.Y = -quaternion.Y * num;
            result.Z = -quaternion.Z * num;
            result.W = quaternion.W * num;
        }

        public decimal Length()
        {
            decimal num = (((this.X * this.X) + (this.Y * this.Y)) + (this.Z * this.Z)) + (this.W * this.W);
            return (decimal)MathHelper.DSqrt((decimal)num);
        }


        public decimal LengthSquared()
        {
            return ((((this.X * this.X) + (this.Y * this.Y)) + (this.Z * this.Z)) + (this.W * this.W));
        }


        public static Quaternion Lerp(Quaternion quaternion1, Quaternion quaternion2, decimal amount)
        {
            decimal num = amount;
            decimal num2 = 1m - num;
            Quaternion quaternion = new Quaternion();
            decimal num5 = (((quaternion1.X * quaternion2.X) + (quaternion1.Y * quaternion2.Y)) + (quaternion1.Z * quaternion2.Z)) + (quaternion1.W * quaternion2.W);
            if (num5 >= 0m)
            {
                quaternion.X = (num2 * quaternion1.X) + (num * quaternion2.X);
                quaternion.Y = (num2 * quaternion1.Y) + (num * quaternion2.Y);
                quaternion.Z = (num2 * quaternion1.Z) + (num * quaternion2.Z);
                quaternion.W = (num2 * quaternion1.W) + (num * quaternion2.W);
            }
            else
            {
                quaternion.X = (num2 * quaternion1.X) - (num * quaternion2.X);
                quaternion.Y = (num2 * quaternion1.Y) - (num * quaternion2.Y);
                quaternion.Z = (num2 * quaternion1.Z) - (num * quaternion2.Z);
                quaternion.W = (num2 * quaternion1.W) - (num * quaternion2.W);
            }
            decimal num4 = (((quaternion.X * quaternion.X) + (quaternion.Y * quaternion.Y)) + (quaternion.Z * quaternion.Z)) + (quaternion.W * quaternion.W);
            decimal num3 = 1m / ((decimal)MathHelper.DSqrt((decimal)num4));
            quaternion.X *= num3;
            quaternion.Y *= num3;
            quaternion.Z *= num3;
            quaternion.W *= num3;
            return quaternion;
        }


        public static void Lerp(ref Quaternion quaternion1, ref Quaternion quaternion2, decimal amount, out Quaternion result)
        {
            decimal num = amount;
            decimal num2 = 1m - num;
            decimal num5 = (((quaternion1.X * quaternion2.X) + (quaternion1.Y * quaternion2.Y)) + (quaternion1.Z * quaternion2.Z)) + (quaternion1.W * quaternion2.W);
            if (num5 >= 0m)
            {
                result.X = (num2 * quaternion1.X) + (num * quaternion2.X);
                result.Y = (num2 * quaternion1.Y) + (num * quaternion2.Y);
                result.Z = (num2 * quaternion1.Z) + (num * quaternion2.Z);
                result.W = (num2 * quaternion1.W) + (num * quaternion2.W);
            }
            else
            {
                result.X = (num2 * quaternion1.X) - (num * quaternion2.X);
                result.Y = (num2 * quaternion1.Y) - (num * quaternion2.Y);
                result.Z = (num2 * quaternion1.Z) - (num * quaternion2.Z);
                result.W = (num2 * quaternion1.W) - (num * quaternion2.W);
            }
            decimal num4 = (((result.X * result.X) + (result.Y * result.Y)) + (result.Z * result.Z)) + (result.W * result.W);
            decimal num3 = 1m / ((decimal)MathHelper.DSqrt((decimal)num4));
            result.X *= num3;
            result.Y *= num3;
            result.Z *= num3;
            result.W *= num3;

        }


        public static Quaternion Slerp(Quaternion quaternion1, Quaternion quaternion2, decimal amount)
        {
            decimal num2;
            decimal num3;
            Quaternion quaternion;
            decimal num = amount;
            decimal num4 = (((quaternion1.X * quaternion2.X) + (quaternion1.Y * quaternion2.Y)) + (quaternion1.Z * quaternion2.Z)) + (quaternion1.W * quaternion2.W);
            bool flag = false;
            if (num4 < 0m)
            {
                flag = true;
                num4 = -num4;
            }
            if (num4 > 0.999999m)
            {
                num3 = 1m - num;
                num2 = flag ? -num : num;
            }
            else
            {
                decimal num5 = (decimal)Math.Acos((double)num4);
                decimal num6 = (decimal)(1.0 / Math.Sin((double)num5));
                num3 = ((decimal)Math.Sin((double)((1m - num) * num5))) * num6;
                num2 = flag ? (((decimal)-Math.Sin((double)(num * num5))) * num6) : (((decimal)Math.Sin((double)(num * num5))) * num6);
            }
            quaternion.X = (num3 * quaternion1.X) + (num2 * quaternion2.X);
            quaternion.Y = (num3 * quaternion1.Y) + (num2 * quaternion2.Y);
            quaternion.Z = (num3 * quaternion1.Z) + (num2 * quaternion2.Z);
            quaternion.W = (num3 * quaternion1.W) + (num2 * quaternion2.W);
            return quaternion;
        }


        public static void Slerp(ref Quaternion quaternion1, ref Quaternion quaternion2, decimal amount, out Quaternion result)
        {
            decimal num2;
            decimal num3;
            decimal num = amount;
            decimal num4 = (((quaternion1.X * quaternion2.X) + (quaternion1.Y * quaternion2.Y)) + (quaternion1.Z * quaternion2.Z)) + (quaternion1.W * quaternion2.W);
            bool flag = false;
            if (num4 < 0m)
            {
                flag = true;
                num4 = -num4;
            }
            if (num4 > 0.999999m)
            {
                num3 = 1m - num;
                num2 = flag ? -num : num;
            }
            else
            {
                decimal num5 = (decimal)Math.Acos((double)num4);
                decimal num6 = (decimal)(1.0 / Math.Sin((double)num5));
                num3 = ((decimal)Math.Sin((double)((1m - num) * num5))) * num6;
                num2 = flag ? (((decimal)-Math.Sin((double)(num * num5))) * num6) : (((decimal)Math.Sin((double)(num * num5))) * num6);
            }
            result.X = (num3 * quaternion1.X) + (num2 * quaternion2.X);
            result.Y = (num3 * quaternion1.Y) + (num2 * quaternion2.Y);
            result.Z = (num3 * quaternion1.Z) + (num2 * quaternion2.Z);
            result.W = (num3 * quaternion1.W) + (num2 * quaternion2.W);
        }


        public static Quaternion Subtract(Quaternion quaternion1, Quaternion quaternion2)
        {
            Quaternion quaternion;
            quaternion.X = quaternion1.X - quaternion2.X;
            quaternion.Y = quaternion1.Y - quaternion2.Y;
            quaternion.Z = quaternion1.Z - quaternion2.Z;
            quaternion.W = quaternion1.W - quaternion2.W;
            return quaternion;
        }


        public static void Subtract(ref Quaternion quaternion1, ref Quaternion quaternion2, out Quaternion result)
        {
            result.X = quaternion1.X - quaternion2.X;
            result.Y = quaternion1.Y - quaternion2.Y;
            result.Z = quaternion1.Z - quaternion2.Z;
            result.W = quaternion1.W - quaternion2.W;
        }


        public static Quaternion Multiply(Quaternion quaternion1, Quaternion quaternion2)
        {
            Quaternion quaternion;
            decimal x = quaternion1.X;
            decimal y = quaternion1.Y;
            decimal z = quaternion1.Z;
            decimal w = quaternion1.W;
            decimal num4 = quaternion2.X;
            decimal num3 = quaternion2.Y;
            decimal num2 = quaternion2.Z;
            decimal num = quaternion2.W;
            decimal num12 = (y * num2) - (z * num3);
            decimal num11 = (z * num4) - (x * num2);
            decimal num10 = (x * num3) - (y * num4);
            decimal num9 = ((x * num4) + (y * num3)) + (z * num2);
            quaternion.X = ((x * num) + (num4 * w)) + num12;
            quaternion.Y = ((y * num) + (num3 * w)) + num11;
            quaternion.Z = ((z * num) + (num2 * w)) + num10;
            quaternion.W = (w * num) - num9;
            return quaternion;
        }


        public static Quaternion Multiply(Quaternion quaternion1, decimal scaleFactor)
        {
            Quaternion quaternion;
            quaternion.X = quaternion1.X * scaleFactor;
            quaternion.Y = quaternion1.Y * scaleFactor;
            quaternion.Z = quaternion1.Z * scaleFactor;
            quaternion.W = quaternion1.W * scaleFactor;
            return quaternion;
        }


        public static void Multiply(ref Quaternion quaternion1, decimal scaleFactor, out Quaternion result)
        {
            result.X = quaternion1.X * scaleFactor;
            result.Y = quaternion1.Y * scaleFactor;
            result.Z = quaternion1.Z * scaleFactor;
            result.W = quaternion1.W * scaleFactor;
        }


        public static void Multiply(ref Quaternion quaternion1, ref Quaternion quaternion2, out Quaternion result)
        {
            decimal x = quaternion1.X;
            decimal y = quaternion1.Y;
            decimal z = quaternion1.Z;
            decimal w = quaternion1.W;
            decimal num4 = quaternion2.X;
            decimal num3 = quaternion2.Y;
            decimal num2 = quaternion2.Z;
            decimal num = quaternion2.W;
            decimal num12 = (y * num2) - (z * num3);
            decimal num11 = (z * num4) - (x * num2);
            decimal num10 = (x * num3) - (y * num4);
            decimal num9 = ((x * num4) + (y * num3)) + (z * num2);
            result.X = ((x * num) + (num4 * w)) + num12;
            result.Y = ((y * num) + (num3 * w)) + num11;
            result.Z = ((z * num) + (num2 * w)) + num10;
            result.W = (w * num) - num9;
        }


        public static Quaternion Negate(Quaternion quaternion)
        {
            Quaternion quaternion2;
            quaternion2.X = -quaternion.X;
            quaternion2.Y = -quaternion.Y;
            quaternion2.Z = -quaternion.Z;
            quaternion2.W = -quaternion.W;
            return quaternion2;
        }


        public static void Negate(ref Quaternion quaternion, out Quaternion result)
        {
            result.X = -quaternion.X;
            result.Y = -quaternion.Y;
            result.Z = -quaternion.Z;
            result.W = -quaternion.W;
        }


        public void Normalize()
        {
            decimal num2 = (((this.X * this.X) + (this.Y * this.Y)) + (this.Z * this.Z)) + (this.W * this.W);
            decimal num = 1m / ((decimal)MathHelper.DSqrt((decimal)num2));
            this.X *= num;
            this.Y *= num;
            this.Z *= num;
            this.W *= num;
        }


        public static Quaternion Normalize(Quaternion quaternion)
        {
            Quaternion quaternion2;
            decimal num2 = (((quaternion.X * quaternion.X) + (quaternion.Y * quaternion.Y)) + (quaternion.Z * quaternion.Z)) + (quaternion.W * quaternion.W);
            decimal num = 1m / ((decimal)MathHelper.DSqrt((decimal)num2));
            quaternion2.X = quaternion.X * num;
            quaternion2.Y = quaternion.Y * num;
            quaternion2.Z = quaternion.Z * num;
            quaternion2.W = quaternion.W * num;
            return quaternion2;
        }


        public static void Normalize(ref Quaternion quaternion, out Quaternion result)
        {
            decimal num2 = (((quaternion.X * quaternion.X) + (quaternion.Y * quaternion.Y)) + (quaternion.Z * quaternion.Z)) + (quaternion.W * quaternion.W);
            decimal num = 1m / ((decimal)MathHelper.DSqrt((decimal)num2));
            result.X = quaternion.X * num;
            result.Y = quaternion.Y * num;
            result.Z = quaternion.Z * num;
            result.W = quaternion.W * num;
        }


        public static Quaternion operator +(Quaternion quaternion1, Quaternion quaternion2)
        {
            Quaternion quaternion;
            quaternion.X = quaternion1.X + quaternion2.X;
            quaternion.Y = quaternion1.Y + quaternion2.Y;
            quaternion.Z = quaternion1.Z + quaternion2.Z;
            quaternion.W = quaternion1.W + quaternion2.W;
            return quaternion;
        }


        public static Quaternion operator /(Quaternion quaternion1, Quaternion quaternion2)
        {
            Quaternion quaternion;
            decimal x = quaternion1.X;
            decimal y = quaternion1.Y;
            decimal z = quaternion1.Z;
            decimal w = quaternion1.W;
            decimal num14 = (((quaternion2.X * quaternion2.X) + (quaternion2.Y * quaternion2.Y)) + (quaternion2.Z * quaternion2.Z)) + (quaternion2.W * quaternion2.W);
            decimal num5 = 1m / num14;
            decimal num4 = -quaternion2.X * num5;
            decimal num3 = -quaternion2.Y * num5;
            decimal num2 = -quaternion2.Z * num5;
            decimal num = quaternion2.W * num5;
            decimal num13 = (y * num2) - (z * num3);
            decimal num12 = (z * num4) - (x * num2);
            decimal num11 = (x * num3) - (y * num4);
            decimal num10 = ((x * num4) + (y * num3)) + (z * num2);
            quaternion.X = ((x * num) + (num4 * w)) + num13;
            quaternion.Y = ((y * num) + (num3 * w)) + num12;
            quaternion.Z = ((z * num) + (num2 * w)) + num11;
            quaternion.W = (w * num) - num10;
            return quaternion;
        }


        public static bool operator ==(Quaternion quaternion1, Quaternion quaternion2)
        {
            return ((((quaternion1.X == quaternion2.X) && (quaternion1.Y == quaternion2.Y)) && (quaternion1.Z == quaternion2.Z)) && (quaternion1.W == quaternion2.W));
        }


        public static bool operator !=(Quaternion quaternion1, Quaternion quaternion2)
        {
            if (((quaternion1.X == quaternion2.X) && (quaternion1.Y == quaternion2.Y)) && (quaternion1.Z == quaternion2.Z))
            {
                return (quaternion1.W != quaternion2.W);
            }
            return true;
        }


        public static Quaternion operator *(Quaternion quaternion1, Quaternion quaternion2)
        {
            Quaternion quaternion;
            decimal x = quaternion1.X;
            decimal y = quaternion1.Y;
            decimal z = quaternion1.Z;
            decimal w = quaternion1.W;
            decimal num4 = quaternion2.X;
            decimal num3 = quaternion2.Y;
            decimal num2 = quaternion2.Z;
            decimal num = quaternion2.W;
            decimal num12 = (y * num2) - (z * num3);
            decimal num11 = (z * num4) - (x * num2);
            decimal num10 = (x * num3) - (y * num4);
            decimal num9 = ((x * num4) + (y * num3)) + (z * num2);
            quaternion.X = ((x * num) + (num4 * w)) + num12;
            quaternion.Y = ((y * num) + (num3 * w)) + num11;
            quaternion.Z = ((z * num) + (num2 * w)) + num10;
            quaternion.W = (w * num) - num9;
            return quaternion;
        }


        public static Quaternion operator *(Quaternion quaternion1, decimal scaleFactor)
        {
            Quaternion quaternion;
            quaternion.X = quaternion1.X * scaleFactor;
            quaternion.Y = quaternion1.Y * scaleFactor;
            quaternion.Z = quaternion1.Z * scaleFactor;
            quaternion.W = quaternion1.W * scaleFactor;
            return quaternion;
        }


        public static Quaternion operator -(Quaternion quaternion1, Quaternion quaternion2)
        {
            Quaternion quaternion;
            quaternion.X = quaternion1.X - quaternion2.X;
            quaternion.Y = quaternion1.Y - quaternion2.Y;
            quaternion.Z = quaternion1.Z - quaternion2.Z;
            quaternion.W = quaternion1.W - quaternion2.W;
            return quaternion;

        }


        public static Quaternion operator -(Quaternion quaternion)
        {
            Quaternion quaternion2;
            quaternion2.X = -quaternion.X;
            quaternion2.Y = -quaternion.Y;
            quaternion2.Z = -quaternion.Z;
            quaternion2.W = -quaternion.W;
            return quaternion2;
        }

        public Vector3 EulerAngles
        {
            get
            {
                Vector3 euler = Vector3.Zero;
                euler.Y = (decimal)Math.Atan2((double)(2m * X * W + 2m * Y * Z), (double)(1m - 2m * ((Z * Z) + (W * W)))); // Yaw 
                euler.X = (decimal)Math.Asin((double)(2m * (X * Z - W * Y)));                                              // Pitch 
                euler.Z = (decimal)Math.Atan2((double)(2m * X * Y + 2m * Z * W), (double)(1m - 2m * ((Y * Y) + (Z * Z)))); // Roll
                return euler;
            }
            set
            {
                decimal rollOver2 = value.X * 0.5m;
                decimal sinRollOver2 = (decimal)Math.Sin((double)rollOver2);
                decimal cosRollOver2 = (decimal)Math.Cos((double)rollOver2);
                decimal pitchOver2 = value.Y * 0.5m;
                decimal sinPitchOver2 = (decimal)Math.Sin((double)pitchOver2);
                decimal cosPitchOver2 = (decimal)Math.Cos((double)pitchOver2);
                decimal yawOver2 = value.X * 0.5m;
                decimal sinYawOver2 = (decimal)Math.Sin((double)yawOver2);
                decimal cosYawOver2 = (decimal)Math.Cos((double)yawOver2);
                X = cosYawOver2 * cosPitchOver2 * cosRollOver2 + sinYawOver2 * sinPitchOver2 * sinRollOver2;
                Y = cosYawOver2 * cosPitchOver2 * sinRollOver2 - sinYawOver2 * sinPitchOver2 * cosRollOver2;
                Z = cosYawOver2 * sinPitchOver2 * cosRollOver2 + sinYawOver2 * cosPitchOver2 * sinRollOver2;
                W = sinYawOver2 * cosPitchOver2 * cosRollOver2 - cosYawOver2 * sinPitchOver2 * sinRollOver2;
            }
        }

        public void ToAngleAxis(out decimal angle, out Vector3 axis)
        {
            Quaternion q = new Quaternion(X, Y, Z, W);
            if (W > 1m) q.Normalize(); // if w>1 acos and sqrt will produce errors, this cant happen if quaternion is normalised
            angle = 2m * (decimal)Math.Acos((double)q.W);
            decimal s = MathHelper.DSqrt(1m - q.W * q.W); // assuming quaternion normalised then w is less than 1, so term always positive.
            if (s < 0.001m)
            { // test to avoid divide by zero, s is always positive due to sqrt
                // if s close to zero then direction of axis not important
                axis.X = q.X; // if it is important that axis is normalised then replace with x=1; y=z=0;
                axis.Y = q.Y;
                axis.Z = q.Z;
            }
            else
            {
                axis.X = q.X / s; // normalise axis
                axis.Y = q.Y / s;
                axis.Z = q.Z / s;
            }
        }

        public override string ToString()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder(32);
            sb.Append("{X:");
            sb.Append(this.X);
            sb.Append(" Y:");
            sb.Append(this.Y);
            sb.Append(" Z:");
            sb.Append(this.Z);
            sb.Append(" W:");
            sb.Append(this.W);
            sb.Append("}");
            return sb.ToString();
        }

        internal Matrix ToMatrix()
        {
            Matrix matrix = Matrix.Identity;
            ToMatrix(out matrix);
            return matrix;
        }

        internal void ToMatrix(out Matrix matrix)
        {
            Quaternion.ToMatrix(this, out matrix);
        }

        internal static void ToMatrix(Quaternion quaternion, out Matrix matrix)
        {

            // source -> http://content.gpwiki.org/index.php/OpenGL:Tutorials:Using_Quaternions_to_represent_rotation#Quaternion_to_Matrix
            decimal x2 = quaternion.X * quaternion.X;
            decimal y2 = quaternion.Y * quaternion.Y;
            decimal z2 = quaternion.Z * quaternion.Z;
            decimal xy = quaternion.X * quaternion.Y;
            decimal xz = quaternion.X * quaternion.Z;
            decimal yz = quaternion.Y * quaternion.Z;
            decimal wx = quaternion.W * quaternion.X;
            decimal wy = quaternion.W * quaternion.Y;
            decimal wz = quaternion.W * quaternion.Z;

            // This calculation would be a lot more complicated for non-unit length quaternions
            // Note: The constructor of Matrix4 expects the Matrix in column-major format like expected by
            //   OpenGL
            matrix.M11 = 1.0m - 2.0m * (y2 + z2);
            matrix.M12 = 2.0m * (xy - wz);
            matrix.M13 = 2.0m * (xz + wy);
            matrix.M14 = 0.0m;

            matrix.M21 = 2.0m * (xy + wz);
            matrix.M22 = 1.0m - 2.0m * (x2 + z2);
            matrix.M23 = 2.0m * (yz - wx);
            matrix.M24 = 0.0m;

            matrix.M31 = 2.0m * (xz - wy);
            matrix.M32 = 2.0m * (yz + wx);
            matrix.M33 = 1.0m - 2.0m * (x2 + y2);
            matrix.M34 = 0.0m;

            matrix.M41 = 2.0m * (xz - wy);
            matrix.M42 = 2.0m * (yz + wx);
            matrix.M43 = 1.0m - 2.0m * (x2 + y2);
            matrix.M44 = 0.0m;

            //return Matrix4( 1.0m - 2.0m * (y2 + z2), 2.0m * (xy - wz), 2.0m * (xz + wy), 0.0m,
            //		2.0m * (xy + wz), 1.0m - 2.0m * (x2 + z2), 2.0m * (yz - wx), 0.0m,
            //		2.0m * (xz - wy), 2.0m * (yz + wx), 1.0m - 2.0m * (x2 + y2), 0.0m,
            //		0.0m, 0.0m, 0.0m, 1.0m)
            //	}
        }

        internal Vector3 Xyz
        {
            get
            {
                return new Vector3(X, Y, Z);
            }

            set
            {
                X = value.X;
                Y = value.Y;
                Z = value.Z;
            }
        }


    }
}

