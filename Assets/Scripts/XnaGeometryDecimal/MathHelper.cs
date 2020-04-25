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
using System.Collections.Generic;
using System.Text;

namespace XnaGeometryDecimal
{
    public static class MathHelper
    {
        public const decimal E = (decimal)Math.E;
        public const decimal Log10E = 0.4342945m;
        public const decimal Log2E = 1.442695m;
        public const decimal Pi = (decimal)Math.PI;
        public const decimal PiOver2 = (decimal)(Math.PI / 2.0);
        public const decimal PiOver4 = (decimal)(Math.PI / 4.0);
        public const decimal TwoPi = (decimal)(Math.PI * 2.0);
        
        public static decimal Barycentric(decimal value1, decimal value2, decimal value3, decimal amount1, decimal amount2)
        {
            return value1 + (value2 - value1) * amount1 + (value3 - value1) * amount2;
        }

        public static decimal CatmullRom(decimal value1, decimal value2, decimal value3, decimal value4, decimal amount)
        {
            // Using formula from http://www.mvps.org/directx/articles/catmull/
            // Internally using decimals not to lose precission
            decimal amountSquared = amount * amount;
            decimal amountCubed = amountSquared * amount;
            return (decimal)(0.5m * (2.0m * value2 +
                (value3 - value1) * amount +
                (2.0m * value1 - 5.0m * value2 + 4.0m * value3 - value4) * amountSquared +
                (3.0m * value2 - value1 - 3.0m * value3 + value4) * amountCubed));
        }

        public static decimal Clamp(decimal value, decimal min, decimal max)
        {
            // First we check to see if we're greater than the max
            value = (value > max) ? max : value;

            // Then we check to see if we're less than the min.
            value = (value < min) ? min : value;

            // There's no check to see if min > max.
            return value;
        }
        
        public static decimal Distance(decimal value1, decimal value2)
        {
            return Math.Abs(value1 - value2);
        }
        
        public static decimal Hermite(decimal value1, decimal tangent1, decimal value2, decimal tangent2, decimal amount)
        {
            // All transformed to decimal not to lose precission
            // Otherwise, for high numbers of param:amount the result is NaN instead of Infinity
            decimal v1 = value1, v2 = value2, t1 = tangent1, t2 = tangent2, s = amount, result;
            decimal sCubed = s * s * s;
            decimal sSquared = s * s;

            if (amount == 0m)
                result = value1;
            else if (amount == 1m)
                result = value2;
            else
                result = (2 * v1 - 2 * v2 + t2 + t1) * sCubed +
                    (3 * v2 - 3 * v1 - 2 * t1 - t2) * sSquared +
                    t1 * s +
                    v1;
            return (decimal)result;
        }
        
        
        public static decimal Lerp(decimal value1, decimal value2, decimal amount)
        {
            return value1 + (value2 - value1) * amount;
        }

        public static decimal Max(decimal value1, decimal value2)
        {
            return Math.Max(value1, value2);
        }
        
        public static decimal Min(decimal value1, decimal value2)
        {
            return Math.Min(value1, value2);
        }
        
        public static decimal SmoothStep(decimal value1, decimal value2, decimal amount)
        {
            // It is expected that 0 < amount < 1
            // If amount < 0, return value1
            // If amount > 1, return value2
#if(USE_FARSEER)
            decimal result = SilverSpriteMathHelper.Clamp(amount, 0f, 1f);
            result = SilverSpriteMathHelper.Hermite(value1, 0f, value2, 0f, result);
#else
            decimal result = MathHelper.Clamp(amount, 0m, 1m);
            result = MathHelper.Hermite(value1, 0m, value2, 0m, result);
#endif
            return result;
        }
        
        public static decimal ToDegrees(decimal radians)
        {
            // This method uses decimal precission internally,
            // though it returns single decimal
            // Factor = 180 / pi
            return (decimal)(radians * 57.295779513082320876798154814105m);
        }
        
        public static decimal ToRadians(decimal degrees)
        {
            // This method uses decimal precission internally,
            // though it returns single decimal
            // Factor = pi / 180
            return (decimal)(degrees * 0.017453292519943295769236907684886m);
        }

	public static decimal WrapAngle(decimal angle)
	{
		angle = (decimal)Math.IEEERemainder((double)angle, 6.2831854820251465);
		if (angle <= -3.14159274m)
		{
			angle += 6.28318548m;
		}
		else
		{
		if (angle > 3.14159274m)
		{
			angle -= 6.28318548m;
		}
		}
		return angle;
	}

		public static bool IsPowerOfTwo(int value)
		{
			return (value > 0) && ((value & (value - 1)) == 0);
		}

        public static decimal DSqrt(decimal square)
        {
            if (square < 0) return 0;

            decimal root = square / 3;
            int i;
            for (i = 0; i < 32; i++)
                root = (root + square / root) / 2;
            return root;
        }
    }
}
