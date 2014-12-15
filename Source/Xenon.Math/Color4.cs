/*
* Copyright (c) 2007-2010 SlimDX Group
* 
* Permission is hereby granted, free of charge, to any person obtaining a copy
* of this software and associated documentation files (the "Software"), to deal
* in the Software without restriction, including without limitation the rights
* to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
* copies of the Software, and to permit persons to whom the Software is
* furnished to do so, subject to the following conditions:
* 
* The above copyright notice and this permission notice shall be included in
* all copies or substantial portions of the Software.
* 
* THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
* IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
* FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
* AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
* LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
* OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
* THE SOFTWARE.
*/

using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.ComponentModel;

namespace Xenon.Math
{
    /// <summary>
    /// Represents a color in the form of argb.
    /// USES BYTE VALUES. SIZE = 4 * 1 = 4 BYTES WIDE
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public struct Color4 : IEquatable<Color4>, IFormattable
    {
        /// <summary>
        /// The red component of the color.
        /// </summary>
        public byte R;

        /// <summary>
        /// The green component of the color.
        /// </summary>
        public byte G;

        /// <summary>
        /// The blue component of the color.
        /// </summary>
        public byte B;

        /// <summary>
        /// The alpha component of the color.
        /// </summary>
        public byte A;

        /// <summary>
        /// Initializes a new instance of the <see cref="Xenon.Math.Color4"/> struct.
        /// </summary>
        /// <param name="value">The value that will be assigned to all components.</param>
        public Color4(float value)
        {
            A = R = G = B = (byte)(value * 255);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Xenon.Math.Color4"/> struct.
        /// </summary>
        /// <param name="red">The red component of the color.</param>
        /// <param name="green">The green component of the color.</param>
        /// <param name="blue">The blue component of the color.</param>
        public Color4(float red, float green, float blue)
        {
            A = 255;
            R = (byte)(255 * red);
            G = (byte)(255 * green);
            B = (byte)(255 * blue);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Xenon.Math.Color4"/> struct.
        /// </summary>
        /// <param name="alpha">The alpha component of the color.</param>
        /// <param name="red">The red component of the color.</param>
        /// <param name="green">The green component of the color.</param>
        /// <param name="blue">The blue component of the color.</param>
        public Color4(float alpha, float red, float green, float blue)
        {
            A = (byte)(255 * alpha);
            R = (byte)(255 * red);
            G = (byte)(255 * green);
            B = (byte)(255 * blue);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Xenon.Math.Color4"/> struct.
        /// </summary>
        /// <param name="value">The red, green, blue, and alpha components of the color.</param>
        public Color4(Vector4 value)
        {
            R = (byte)(255 * value.X);
            G = (byte)(255 * value.Y);
            B = (byte)(255 * value.Z);
            A = (byte)(255 * value.W);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Xenon.Math.Color4"/> struct.
        /// </summary>
        /// <param name="value">The red, green, and blue compoennts of the color.</param>
        /// <param name="alpha">The alpha component of the color.</param>
        public Color4(Vector3 value, float alpha)
        {
            R = (byte)(255 * value.X);
            G = (byte)(255 * value.Y);
            B = (byte)(255 * value.Z);
            A = (byte)(255 * alpha);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Xenon.Math.Color4"/> struct.
        /// </summary>
        /// <param name="argb">A packed integer containing all four color components.</param>
        public Color4(uint argb)
        {
            A = (byte)((argb >> 24) & 255);
            R = (byte)((argb >> 16) & 255);
            G = (byte)((argb >> 8) & 255);
            B = (byte)(argb & 255);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Xenon.Math.Color4"/> struct.
        /// </summary>
        /// <param name="red">The red component of the color.</param>
        /// <param name="green">The green component of the color.</param>
        /// <param name="blue">The blue component of the color.</param>
        public Color4(int red, int green, int blue)
        {
            A = 255;
            R = (byte)(red );
            G = (byte)(green);
            B = (byte)(blue );
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Xenon.Math.Color4"/> struct.
        /// </summary>
        /// <param name="alpha">The alpha component of the color.</param>
        /// <param name="red">The red component of the color.</param>
        /// <param name="green">The green component of the color.</param>
        /// <param name="blue">The blue component of the color.</param>
        public Color4(int alpha, int red, int green, int blue)
        {
            A = (byte)alpha;
            R = (byte)red;
            G = (byte)green;
            B = (byte)blue;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Xenon.Math.Color4"/> struct.
        /// </summary>
        /// <param name="values">The values to assign to the alpha, red, green, and blue components of the color. This must be an array with four elements.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="values"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="values"/> contains more or less than four elements.</exception>
        public Color4(float[] values)
        {
            if (values == null)
                throw new ArgumentNullException("values");
            if (values.Length != 4)
                throw new ArgumentOutOfRangeException("values", "There must be four and only four input values for Color4.");

            A = (byte)(255 * values[0]);
            R = (byte)(255 * values[1]);
            G = (byte)(255 * values[2]);
            B = (byte)(255 * values[3]);
        }


        /// <summary>
        /// The size of the <see cref="Xenon.Math.Vector4"/> type, in bytes.
        /// </summary>
        public static readonly int SizeInBytes = Marshal.SizeOf(typeof(Color4));


        /// <summary>
        /// Gets or sets the component at the specified index.
        /// </summary>
        /// <value>The value of the alpha, red, green, or blue component, depending on the index.</value>
        /// <param name="index">The index of the component to access. Use 0 for the alpha component, 1 for the red component, 2 for the green component, and 3 for the blue component.</param>
        /// <returns>The value of the component at the specified index.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when the <paramref name="index"/> is out of the range [0, 3].</exception>
        public byte this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0: return A;
                    case 1: return R;
                    case 2: return G;
                    case 3: return B;
                }

                throw new ArgumentOutOfRangeException("index", "Indices for Color4 run from 0 to 3, inclusive.");
            }

            set
            {
                switch (index)
                {
                    case 0: A = value; break;
                    case 1: R = value; break;
                    case 2: G = value; break;
                    case 3: B = value; break;
                    default: throw new ArgumentOutOfRangeException("index", "Indices for Color4 run from 0 to 3, inclusive.");
                }
            }
        }
        /// <summary>
        /// Scales a color.
        /// </summary>
        /// <param name="scalar">The amount by which to scale.</param>
        public void Scale(float scalar)
        {
            this.A = (byte)(this.A * scalar);
            this.R = (byte)(this.R * scalar);
            this.G = (byte)(this.G * scalar);
            this.B = (byte)(this.B * scalar);
        }

        /// <summary>
        /// Inverts the color (takes the complement of the color).
        /// </summary>
        public void Invert()
        {
            this.A = (byte)(255 - A);
            this.R = (byte)(255 - R);
            this.G = (byte)(255 - G);
            this.B = (byte)(255 - B);
        }

        /// <summary>
        /// Adjusts the contrast of a color.
        /// </summary>
        /// <param name="contrast">The amount by which to adjust the contrast.</param>
        public void AdjustContrast(float contrast)
        {
            this.R = (byte)(128 + contrast * (R - 128));
            this.G = (byte)(128 + contrast * (G - 128));
            this.B = (byte)(128 + contrast * (B - 128));
        }

        /// <summary>
        /// Adjusts the saturation of a color.
        /// </summary>
        /// <param name="saturation">The amount by which to adjust the saturation.</param>
        public void AdjustSaturation(float saturation)
        {
            float grey = R * 0.2125f + G * 0.7154f + B * 0.0721f;

            this.R = (byte)(grey + saturation * (R - grey));
            this.G = (byte)(grey + saturation * (G - grey));
            this.B = (byte)(grey + saturation * (B - grey));
        }

        /// <summary>
        /// Converts the color into a packed integer.
        /// </summary>
        /// <returns>A packed integer containing all four color components.</returns>
        public int ToArgb()
        {
            uint a = (uint)(A);
            uint r = (uint)(R);
            uint g = (uint)(G);
            uint b = (uint)(B);

            uint value = b;
            value |= g << 8;
            value |= r << 16;
            value |= a << 24;

            return (int)value;
        }

        /// <summary>
        /// Converts the color into a packed integer.
        /// </summary>
        /// <returns>A packed integer containing all four color components.</returns>
        public int ToRgba()
        {
            uint a = (uint)(A);
            uint r = (uint)(R);
            uint g = (uint)(G);
            uint b = (uint)(B);

            uint value = a;
            value |= b << 8;
            value |= g << 16;
            value |= r << 24;

            return (int)value;
        }

        /// <summary>
        /// Converts the color into a three component vector.
        /// </summary>
        /// <returns>A three component vector containing the red, green, and blue components of the color.</returns>
        public Vector3 ToVector3()
        { return new Vector3(R / 255.0f, G / 255.0f, B / 255.0f); }

        /// <summary>
        /// Converts the color into a four component vector.
        /// </summary>
        /// <returns>A four component vector containing all four color components.</returns>
        public Vector4 ToVector4()
        {
            return new Vector4(R / 255.0f, G / 255.0f, B / 255.0f, A / 255.0f);
        }

        /// <summary>
        /// Creates an array containing the elements of the color.
        /// </summary>
        /// <returns>A four-element array containing the components of the color in RGBA order.</returns>
        public float[] ToSingleArray()
        {
            return new[] { R / 255.0f, G / 255.0f, B / 255.0f, A / 255.0f };
        }

        /// <summary>
        /// Creates an array containing the elements of the color.
        /// </summary>
        /// <returns>A four-element array containing the components of the color in RGBA order.</returns>
        public byte[] ToByteArray()
        {
            return new[] { R, G, B, A  };
        }

        /// <summary>
        /// Adds two colors.
        /// </summary>
        /// <param name="left">The first color to add.</param>
        /// <param name="right">The second color to add.</param>
        /// <param name="result">When the method completes, completes the sum of the two colors.</param>
        public static void Add(ref Color4 left, ref Color4 right, out Color4 result)
        {
            result.A = (byte)(left.A + right.A);
            result.R = (byte)(left.R + right.R);
            result.G = (byte)(left.G + right.G);
            result.B = (byte)(left.B + right.B);
        }

        /// <summary>
        /// Adds two colors.
        /// </summary>
        /// <param name="left">The first color to add.</param>
        /// <param name="right">The second color to add.</param>
        /// <returns>The sum of the two colors.</returns>
        public static Color4 Add(Color4 left, Color4 right)
        {
            return new Color4(left.A + right.A, left.R + right.R, left.G + right.G, left.B + right.B);
        }

        /// <summary>
        /// Subtracts two colors.
        /// </summary>
        /// <param name="left">The first color to subtract.</param>
        /// <param name="right">The second color to subtract.</param>
        /// <param name="result">WHen the method completes, contains the difference of the two colors.</param>
        public static void Subtract(ref Color4 left, ref Color4 right, out Color4 result)
        {
            result.A = (byte)(left.A - right.A);
            result.R = (byte)(left.R - right.R);
            result.G = (byte)(left.G - right.G);
            result.B = (byte)(left.B - right.B);
        }

        /// <summary>
        /// Subtracts two colors.
        /// </summary>
        /// <param name="left">The first color to subtract.</param>
        /// <param name="right">The second color to subtract</param>
        /// <returns>The difference of the two colors.</returns>
        public static Color4 Subtract(Color4 left, Color4 right)
        {
            return new Color4(left.A - right.A, left.R - right.R, left.G - right.G, left.B - right.B);
        }

        /// <summary>
        /// Modulates two colors.
        /// </summary>
        /// <param name="left">The first color to modulate.</param>
        /// <param name="right">The second color to modulate.</param>
        /// <param name="result">When the method completes, contains the modulated color.</param>
        public static void Modulate(ref Color4 left, ref Color4 right, out Color4 result)
        {
            result.A = (byte)(left.A * right.A);
            result.R = (byte)(left.R * right.R);
            result.G = (byte)(left.G * right.G);
            result.B = (byte)(left.B * right.B);
        }

        /// <summary>
        /// Modulates two colors.
        /// </summary>
        /// <param name="left">The first color to modulate.</param>
        /// <param name="right">The second color to modulate.</param>
        /// <returns>The modulated color.</returns>
        public static Color4 Modulate(Color4 left, Color4 right)
        {
            return new Color4(left.A * right.A, left.R * right.R, left.G * right.G, left.B * right.B);
        }

        /// <summary>
        /// Scales a color.
        /// </summary>
        /// <param name="value">The color to scale.</param>
        /// <param name="scalar">The amount by which to scale.</param>
        /// <param name="result">When the method completes, contains the scaled color.</param>
        public static void Scale(ref Color4 value, float scalar, out Color4 result)
        {
            result.A = (byte)(value.A * scalar);
            result.R = (byte)(value.R * scalar);
            result.G = (byte)(value.G * scalar);
            result.B = (byte)(value.B * scalar);
        }

        /// <summary>
        /// Scales a color.
        /// </summary>
        /// <param name="value">The color to scale.</param>
        /// <param name="scalar">The amount by which to scale.</param>
        /// <returns>The scaled color.</returns>
        public static Color4 Scale(Color4 value, float scalar)
        {
            return new Color4(value.A * scalar, value.R * scalar, value.G * scalar, value.B * scalar);
        }


        /// <summary>
        /// Negates a color.
        /// </summary>
        /// <param name="value">The color to negate.</param>
        /// <returns>The negated color.</returns>
        public static Color4 Negate(Color4 value)
        {
            return new Color4(-value.A, -value.R, -value.G, -value.B);
        }

        /// <summary>
        /// Inverts the color (takes the complement of the color).
        /// </summary>
        /// <param name="value">The color to invert.</param>
        /// <param name="result">When the method completes, contains the inverted color.</param>
        public static void Invert(ref Color4 value, out Color4 result)
        {
            result.A = (byte)(255 - value.A);
            result.R = (byte)(255 - value.R);
            result.G = (byte)(255 - value.G);
            result.B = (byte)(255 - value.B);
        }

        /// <summary>
        /// Inverts the color (takes the complement of the color).
        /// </summary>
        /// <param name="value">The color to invert.</param>
        /// <returns>The inverted color.</returns>
        public static Color4 Invert(Color4 value)
        {
            return new Color4(-value.A, -value.R, -value.G, -value.B);
        }

        /// <summary>
        /// Restricts a value to be within a specified range.
        /// </summary>
        /// <param name="value">The value to clamp.</param>
        /// <param name="min">The minimum value.</param>
        /// <param name="max">The maximum value.</param>
        /// <param name="result">When the method completes, contains the clamped value.</param>
        public static void Clamp(ref Color4 value, ref Color4 min, ref Color4 max, out Color4 result)
        {
            float alpha = value.A;
            alpha = (alpha > max.A) ? max.A : alpha;
            alpha = (alpha < min.A) ? min.A : alpha;

            float red = value.R;
            red = (red > max.R) ? max.R : red;
            red = (red < min.R) ? min.R : red;

            float green = value.G;
            green = (green > max.G) ? max.G : green;
            green = (green < min.G) ? min.G : green;

            float blue = value.B;
            blue = (blue > max.B) ? max.B : blue;
            blue = (blue < min.B) ? min.B : blue;

            result = new Color4(alpha, red, green, blue);
        }

        /// <summary>
        /// Restricts a value to be within a specified range.
        /// </summary>
        /// <param name="value">The value to clamp.</param>
        /// <param name="min">The minimum value.</param>
        /// <param name="max">The maximum value.</param>
        /// <returns>The clamped value.</returns>
        public static Color4 Clamp(Color4 value, Color4 min, Color4 max)
        {
            Color4 result;
            Clamp(ref value, ref min, ref max, out result);
            return result;
        }

        /// <summary>
        /// Performs a linear interpolation between two colors.
        /// </summary>
        /// <param name="start">Start color.</param>
        /// <param name="end">End color.</param>
        /// <param name="amount">Value between 0 and 1 indicating the weight of <paramref name="end"/>.</param>
        /// <param name="result">When the method completes, contains the linear interpolation of the two colors.</param>
        /// <remarks>
        /// This method performs the linear interpolation based on the following formula.
        /// <code>start + (end - start) * amount</code>
        /// Passing <paramref name="amount"/> a value of 0 will cause <paramref name="start"/> to be returned; a value of 1 will cause <paramref name="end"/> to be returned. 
        /// </remarks>
        public static void Lerp(ref Color4 start, ref Color4 end, float amount, out Color4 result)
        {
            result.A = (byte)(start.A + amount * (end.A - start.A));
            result.R = (byte)(start.R + amount * (end.R - start.R));
            result.G = (byte)(start.G + amount * (end.G - start.G));
            result.B = (byte)(start.B + amount * (end.B - start.B));
        }

        /// <summary>
        /// Performs a linear interpolation between two colors.
        /// </summary>
        /// <param name="start">Start color.</param>
        /// <param name="end">End color.</param>
        /// <param name="amount">Value between 0 and 1 indicating the weight of <paramref name="end"/>.</param>
        /// <returns>The linear interpolation of the two colors.</returns>
        /// <remarks>
        /// This method performs the linear interpolation based on the following formula.
        /// <code>start + (end - start) * amount</code>
        /// Passing <paramref name="amount"/> a value of 0 will cause <paramref name="start"/> to be returned; a value of 1 will cause <paramref name="end"/> to be returned. 
        /// </remarks>
        public static Color4 Lerp(Color4 start, Color4 end, float amount)
        {
            return new Color4(
                start.A + amount * (end.A - start.A),
                start.R + amount * (end.R - start.R),
                start.G + amount * (end.G - start.G),
                start.B + amount * (end.B - start.B));
        }

        /// <summary>
        /// Performs a cubic interpolation between two colors.
        /// </summary>
        /// <param name="start">Start color.</param>
        /// <param name="end">End color.</param>
        /// <param name="amount">Value between 0 and 1 indicating the weight of <paramref name="end"/>.</param>
        /// <param name="result">When the method completes, contains the cubic interpolation of the two colors.</param>
        public static void SmoothStep(ref Color4 start, ref Color4 end, float amount, out Color4 result)
        {
            amount = (amount > 1.0f) ? 1.0f : ((amount < 0.0f) ? 0.0f : amount);
            amount = (amount * amount) * (3.0f - (2.0f * amount));

            result.A = (byte)(start.A + ((end.A - start.A) * amount));
            result.R = (byte)(start.R + ((end.R - start.R) * amount));
            result.G = (byte)(start.G + ((end.G - start.G) * amount));
            result.B = (byte)(start.B + ((end.B - start.B) * amount));
        }

        /// <summary>
        /// Performs a cubic interpolation between two colors.
        /// </summary>
        /// <param name="start">Start color.</param>
        /// <param name="end">End color.</param>
        /// <param name="amount">Value between 0 and 1 indicating the weight of <paramref name="end"/>.</param>
        /// <returns>The cubic interpolation of the two colors.</returns>
        public static Color4 SmoothStep(Color4 start, Color4 end, float amount)
        {
            amount = (amount > 1.0f) ? 1.0f : ((amount < 0.0f) ? 0.0f : amount);
            amount = (amount * amount) * (3.0f - (2.0f * amount));

            return new Color4(
                start.A + ((end.A - start.A) * amount),
                start.R + ((end.R - start.R) * amount),
                start.G + ((end.G - start.G) * amount),
                start.B + ((end.B - start.B) * amount));
        }

        /// <summary>
        /// Returns a color containing the smallest components of the specified colorss.
        /// </summary>
        /// <param name="left">The first source color.</param>
        /// <param name="right">The second source color.</param>
        /// <param name="result">When the method completes, contains an new color composed of the largest components of the source colorss.</param>
        public static void Max(ref Color4 left, ref Color4 right, out Color4 result)
        {
            result.A = (left.A > right.A) ? left.A : right.A;
            result.R = (left.R > right.R) ? left.R : right.R;
            result.G = (left.G > right.G) ? left.G : right.G;
            result.B = (left.B > right.B) ? left.B : right.B;
        }

        /// <summary>
        /// Returns a color containing the largest components of the specified colorss.
        /// </summary>
        /// <param name="left">The first source color.</param>
        /// <param name="right">The second source color.</param>
        /// <returns>A color containing the largest components of the source colors.</returns>
        public static Color4 Max(Color4 left, Color4 right)
        {
            Color4 result;
            Max(ref left, ref right, out result);
            return result;
        }

        /// <summary>
        /// Returns a color containing the smallest components of the specified colors.
        /// </summary>
        /// <param name="left">The first source color.</param>
        /// <param name="right">The second source color.</param>
        /// <param name="result">When the method completes, contains an new color composed of the smallest components of the source colors.</param>
        public static void Min(ref Color4 left, ref Color4 right, out Color4 result)
        {
            result.A = (left.A < right.A) ? left.A : right.A;
            result.R = (left.R < right.R) ? left.R : right.R;
            result.G = (left.G < right.G) ? left.G : right.G;
            result.B = (left.B < right.B) ? left.B : right.B;
        }

        /// <summary>
        /// Returns a color containing the smallest components of the specified colors.
        /// </summary>
        /// <param name="left">The first source color.</param>
        /// <param name="right">The second source color.</param>
        /// <returns>A color containing the smallest components of the source colors.</returns>
        public static Color4 Min(Color4 left, Color4 right)
        {
            Color4 result;
            Min(ref left, ref right, out result);
            return result;
        }

        /// <summary>
        /// Adjusts the contrast of a color.
        /// </summary>
        /// <param name="value">The color whose contrast is to be adjusted.</param>
        /// <param name="contrast">The amount by which to adjust the contrast.</param>
        /// <param name="result">When the method completes, contains the adjusted color.</param>
        public static void AdjustContrast(ref Color4 value, float contrast, out Color4 result)
        {
            result.A = value.A;
            result.R = (byte)(128 + contrast * (value.R - 128));
            result.G = (byte)(128 + contrast * (value.G - 128));
            result.B = (byte)(128 + contrast * (value.B - 128));
        }

        /// <summary>
        /// Adjusts the contrast of a color.
        /// </summary>
        /// <param name="value">The color whose contrast is to be adjusted.</param>
        /// <param name="contrast">The amount by which to adjust the contrast.</param>
        /// <returns>The adjusted color.</returns>
        public static Color4 AdjustContrast(Color4 value, float contrast)
        {
            return new Color4(
                value.A,
                0.5f + contrast * (value.R - 0.5f),
                0.5f + contrast * (value.G - 0.5f),
                0.5f + contrast * (value.B - 0.5f));
        }

        /// <summary>
        /// Adjusts the saturation of a color.
        /// </summary>
        /// <param name="value">The color whose saturation is to be adjusted.</param>
        /// <param name="saturation">The amount by which to adjust the saturation.</param>
        /// <param name="result">When the method completes, contains the adjusted color.</param>
        public static void AdjustSaturation(ref Color4 value, float saturation, out Color4 result)
        {
            float grey = value.R * 0.2125f + value.G * 0.7154f + value.B * 0.0721f;

            result.A = value.A;
            result.R = (byte)(grey + saturation * (value.R - grey));
            result.G = (byte)(grey + saturation * (value.G - grey));
            result.B = (byte)(grey + saturation * (value.B - grey));
        }

        /// <summary>
        /// Adjusts the saturation of a color.
        /// </summary>
        /// <param name="value">The color whose saturation is to be adjusted.</param>
        /// <param name="saturation">The amount by which to adjust the saturation.</param>
        /// <returns>The adjusted color.</returns>
        public static Color4 AdjustSaturation(Color4 value, float saturation)
        {
            float grey = value.R * 0.2125f + value.G * 0.7154f + value.B * 0.0721f;

            return new Color4(
                value.A,
                grey + saturation * (value.R - grey),
                grey + saturation * (value.G - grey),
                grey + saturation * (value.B - grey));
        }

        /// <summary>
        /// Inverts the color (takes the complement of the color).
        /// </summary>
        /// <param name="value">The color to invert.</param>
        /// <returns>The inverted color.</returns>
        public static Color4 operator ~(Color4 value)
        {
            return new Color4(1.0f - value.A, 1.0f - value.R, 1.0f - value.G, 1.0f - value.B);
        }

        /// <summary>
        /// Adds two colors.
        /// </summary>
        /// <param name="left">The first color to add.</param>
        /// <param name="right">The second color to add.</param>
        /// <returns>The sum of the two colors.</returns>
        public static Color4 operator +(Color4 left, Color4 right)
        {
            return new Color4(left.A + right.A, left.R + right.R, left.G + right.G, left.B + right.B);
        }

        /// <summary>
        /// Assert a color (return it unchanged).
        /// </summary>
        /// <param name="value">The color to assert (unchange).</param>
        /// <returns>The asserted (unchanged) color.</returns>
        public static Color4 operator +(Color4 value)
        {
            return value;
        }

        /// <summary>
        /// Subtracts two colors.
        /// </summary>
        /// <param name="left">The first color to subtract.</param>
        /// <param name="right">The second color to subtract.</param>
        /// <returns>The difference of the two colors.</returns>
        public static Color4 operator -(Color4 left, Color4 right)
        {
            return new Color4(left.A - right.A, left.R - right.R, left.G - right.G, left.B - right.B);
        }

        /// <summary>
        /// Negates a color.
        /// </summary>
        /// <param name="value">The color to negate.</param>
        /// <returns>A negated color.</returns>
        public static Color4 operator -(Color4 value)
        {
            return new Color4(-value.A, -value.R, -value.G, -value.B);
        }

        /// <summary>
        /// Scales a color.
        /// </summary>
        /// <param name="scalar">The factor by which to scale the color.</param>
        /// <param name="value">The color to scale.</param>
        /// <returns>The scaled color.</returns>
        public static Color4 operator *(float scalar, Color4 value)
        {
            return new Color4(value.A * scalar, value.R * scalar, value.G * scalar, value.B * scalar);
        }

        /// <summary>
        /// Scales a color.
        /// </summary>
        /// <param name="value">The factor by which to scale the color.</param>
        /// <param name="scalar">The color to scale.</param>
        /// <returns>The scaled color.</returns>
        public static Color4 operator *(Color4 value, float scalar)
        {
            return new Color4(value.A * scalar, value.R * scalar, value.G * scalar, value.B * scalar);
        }

        /// <summary>
        /// Modulates two colors.
        /// </summary>
        /// <param name="left">The first color to modulate.</param>
        /// <param name="right">The second color to modulate.</param>
        /// <returns>The modulated color.</returns>
        public static Color4 operator *(Color4 left, Color4 right)
        {
            return new Color4(left.A * right.A, left.R * right.R, left.G * right.G, left.B * right.B);
        }

        /// <summary>
        /// Tests for equality between two objects.
        /// </summary>
        /// <param name="left">The first value to compare.</param>
        /// <param name="right">The second value to compare.</param>
        /// <returns><c>true</c> if <paramref name="left"/> has the same value as <paramref name="right"/>; otherwise, <c>false</c>.</returns>
        public static bool operator ==(Color4 left, Color4 right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Tests for inequality between two objects.
        /// </summary>
        /// <param name="left">The first value to compare.</param>
        /// <param name="right">The second value to compare.</param>
        /// <returns><c>true</c> if <paramref name="left"/> has a different value than <paramref name="right"/>; otherwise, <c>false</c>.</returns>
        public static bool operator !=(Color4 left, Color4 right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Performs an explicit conversion from <see cref="Xenon.Math.Color4"/> to <see cref="Xenon.Math.Color3"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static explicit operator Color3(Color4 value)
        {
            return new Color3(value.R, value.G, value.B);
        }

        /// <summary>
        /// Performs an explicit conversion from <see cref="Xenon.Math.Color4"/> to <see cref="Xenon.Math.Vector3"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static explicit operator Vector3(Color4 value)
        {
            return new Vector3(value.R, value.G, value.B);
        }

        /// <summary>
        /// Performs an explicit conversion from <see cref="Xenon.Math.Color4"/> to <see cref="Xenon.Math.Vector4"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static explicit operator Vector4(Color4 value)
        {
            return new Vector4(value.R, value.G, value.B, value.A);
        }

        /// <summary>
        /// Performs an explicit conversion from <see cref="Xenon.Math.Vector3"/> to <see cref="Xenon.Math.Color4"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static explicit operator Color4(Vector3 value)
        {
            return new Color4(value.X, value.Y, value.Z, 1.0f);
        }

        /// <summary>
        /// Performs an explicit conversion from <see cref="Xenon.Math.Vector4"/> to <see cref="Xenon.Math.Color4"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static explicit operator Color4(Vector4 value)
        {
            return new Color4(value.X, value.Y, value.Z, value.W);
        }

        /// <summary>
        /// Performs an explicit conversion from <see cref="System.Int32"/> to <see cref="Xenon.Math.Color4"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static explicit operator Color4(int value)
        {
            return new Color4(value);
        }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return string.Format(CultureInfo.CurrentCulture, "Alpha:{0} Red:{1} Green:{2} Blue:{3}", A, R, G, B);
        }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public string ToString(string format)
        {
            if (format == null)
                return ToString();

            return string.Format(CultureInfo.CurrentCulture, "Alpha:{0} Red:{1} Green:{2} Blue:{3}", A.ToString(format, CultureInfo.CurrentCulture),
                R.ToString(format, CultureInfo.CurrentCulture), G.ToString(format, CultureInfo.CurrentCulture), B.ToString(format, CultureInfo.CurrentCulture));
        }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <param name="formatProvider">The format provider.</param>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public string ToString(IFormatProvider formatProvider)
        {
            return string.Format(formatProvider, "Alpha:{0} Red:{1} Green:{2} Blue:{3}", A, R, G, B);
        }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="formatProvider">The format provider.</param>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (format == null)
                return ToString(formatProvider);

            return string.Format(formatProvider, "Alpha:{0} Red:{1} Green:{2} Blue:{3}", A.ToString(format, formatProvider),
                R.ToString(format, formatProvider), G.ToString(format, formatProvider), B.ToString(format, formatProvider));
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            return A.GetHashCode() + R.GetHashCode() + G.GetHashCode() + B.GetHashCode();
        }

        /// <summary>
        /// Determines whether the specified <see cref="Xenon.Math.Color4"/> is equal to this instance.
        /// </summary>
        /// <param name="other">The <see cref="Xenon.Math.Color4"/> to compare with this instance.</param>
        /// <returns>
        /// <c>true</c> if the specified <see cref="Xenon.Math.Color4"/> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(Color4 other)
        {
            return (A == other.A) && (R == other.R) && (G == other.G) && (B == other.B);
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object"/> is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object"/> to compare with this instance.</param>
        /// <returns>
        /// <c>true</c> if the specified <see cref="System.Object"/> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (obj.GetType() != GetType())
                return false;

            return Equals((Color4)obj);
        }

#if SlimDX1xInterop
        /// <summary>
        /// Performs an implicit conversion from <see cref="SlimMath.Color4"/> to <see cref="SlimDX.Color4"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator SlimDX.Color4(Color value)
        {
            return new SlimDX.Color4(value.Alpha, value.Red, value.Green, value.Blue);
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="SlimDX.Color4"/> to <see cref="SlimMath.Color4"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator Color4(SlimDX.Color4 value)
        {
            return new Color4(value.Alpha, value.Red, value.Green, value.Blue);
        }
#endif

#if WPFInterop
        /// <summary>
        /// Performs an explicit conversion from <see cref="SlimMath.Color4"/> to <see cref="System.Windows.Media.Color"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static explicit operator System.Windows.Media.Color(Color value)
        {
            return new System.Windows.Media.Color()
            {
                A = (byte)(255f * value.A),
                R = (byte)(255f * value.R),
                G = (byte)(255f * value.G),
                B = (byte)(255f * value.B)
            };
        }

        /// <summary>
        /// Performs an explicit conversion from <see cref="System.Windows.Media.Color"/> to <see cref="SlimMath.Color4"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static explicit operator Color(System.Windows.Media.Color value)
        {
            return new Color()
            {
                A = (float)value.A / 255f,
                R = (float)value.R / 255f,
                G = (float)value.G / 255f,
                B = (float)value.B / 255f
            };
        }
#endif

#if WinFormsInterop
        /// <summary>
        /// Performs an explicit conversion from <see cref="SlimMath.Color4"/> to <see cref="System.Drawing.Color"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static explicit operator System.Drawing.Color(Color value)
        {
            return System.Drawing.Color.FromArgb(
                (byte)(255f * value.A),
                (byte)(255f * value.R),
                (byte)(255f * value.G),
                (byte)(255f * value.B));
        }

        /// <summary>
        /// Performs an explicit conversion from <see cref="System.Drawing.Color"/> to <see cref="SlimMath.Color4"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static explicit operator Color(System.Drawing.Color value)
        {
            return new Color()
            {
                A = (float)value.A / 255f,
                R = (float)value.R / 255f,
                G = (float)value.G / 255f,
                B = (float)value.B / 255f
            };
        }
#endif

        #region Preset Colors
        /// <summary>
        /// Gets a Color4 with the index R:240 G:248 B:255 A:255.
        /// </summary>
        public static Color4 AliceBlue
        {
            get
            {
                return new Color4(4294965488);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:250 G:235 B:215 A:255.
        /// </summary>
        public static Color4 AntiqueWhite
        {
            get
            {
                return new Color4(4292340730);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:0 G:255 B:255 A:255.
        /// </summary>
        public static Color4 Aqua
        {
            get
            {
                return new Color4(4294967040);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:127 G:255 B:212 A:255.
        /// </summary>
        public static Color4 Aquamarine
        {
            get
            {
                return new Color4(4292149119);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:240 G:255 B:255 A:255.
        /// </summary>
        public static Color4 Azure
        {
            get
            {
                return new Color4(4294967280);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:245 G:245 B:220 A:255.
        /// </summary>
        public static Color4 Beige
        {
            get
            {
                return new Color4(4292670965);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:255 G:228 B:196 A:255.
        /// </summary>
        public static Color4 Bisque
        {
            get
            {
                return new Color4(4291093759);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:0 G:0 B:0 A:255.
        /// </summary>
        public static Color4 Black
        {
            get
            {
                return new Color4(4278190080);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:255 G:235 B:205 A:255.
        /// </summary>
        public static Color4 BlanchedAlmond
        {
            get
            {
                return new Color4(4291685375);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:0 G:0 B:255 A:255.
        /// </summary>
        public static Color4 Blue
        {
            get
            {
                return new Color4(4294901760);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:138 G:43 B:226 A:255.
        /// </summary>
        public static Color4 BlueViolet
        {
            get
            {
                return new Color4(4293012362);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:165 G:42 B:42 A:255.
        /// </summary>
        public static Color4 Brown
        {
            get
            {
                return new Color4(4280953509);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:222 G:184 B:135 A:255.
        /// </summary>
        public static Color4 BurlyWood
        {
            get
            {
                return new Color4(4287084766);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:95 G:158 B:160 A:255.
        /// </summary>
        public static Color4 CadetBlue
        {
            get
            {
                return new Color4(4288716383);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:127 G:255 B:0 A:255.
        /// </summary>
        public static Color4 Chartreuse
        {
            get
            {
                return new Color4(4278255487);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:210 G:105 B:30 A:255.
        /// </summary>
        public static Color4 Chocolate
        {
            get
            {
                return new Color4(4280183250);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:255 G:127 B:80 A:255.
        /// </summary>
        public static Color4 Coral
        {
            get
            {
                return new Color4(4283465727);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:100 G:149 B:237 A:255.
        /// </summary>
        public static Color4 CornflowerBlue
        {
            get
            {
                return new Color4(4284782061);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:255 G:248 B:220 A:255.
        /// </summary>
        public static Color4 Cornsilk
        {
            get
            {
                return new Color4(4292671743);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:220 G:20 B:60 A:255.
        /// </summary>
        public static Color4 Crimson
        {
            get
            {
                return new Color4(4282127580);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:0 G:255 B:255 A:255.
        /// </summary>
        public static Color4 Cyan
        {
            get
            {
                return new Color4(4294967040);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:0 G:0 B:139 A:255.
        /// </summary>
        public static Color4 DarkBlue
        {
            get
            {
                return new Color4(4287299584);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:0 G:139 B:139 A:255.
        /// </summary>
        public static Color4 DarkCyan
        {
            get
            {
                return new Color4(4287335168);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:184 G:134 B:11 A:255.
        /// </summary>
        public static Color4 DarkGoldenrod
        {
            get
            {
                return new Color4(4278945464);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:169 G:169 B:169 A:255.
        /// </summary>
        public static Color4 DarkGray
        {
            get
            {
                return new Color4(4289309097);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:0 G:100 B:0 A:255.
        /// </summary>
        public static Color4 DarkGreen
        {
            get
            {
                return new Color4(4278215680);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:189 G:183 B:107 A:255.
        /// </summary>
        public static Color4 DarkKhaki
        {
            get
            {
                return new Color4(4285249469);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:139 G:0 B:139 A:255.
        /// </summary>
        public static Color4 DarkMagenta
        {
            get
            {
                return new Color4(4287299723);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:85 G:107 B:47 A:255.
        /// </summary>
        public static Color4 DarkOliveGreen
        {
            get
            {
                return new Color4(4281297749);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:255 G:140 B:0 A:255.
        /// </summary>
        public static Color4 DarkOrange
        {
            get
            {
                return new Color4(4278226175);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:153 G:50 B:204 A:255.
        /// </summary>
        public static Color4 DarkOrchid
        {
            get
            {
                return new Color4(4291572377);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:139 G:0 B:0 A:255.
        /// </summary>
        public static Color4 DarkRed
        {
            get
            {
                return new Color4(4278190219);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:233 G:150 B:122 A:255.
        /// </summary>
        public static Color4 DarkSalmon
        {
            get
            {
                return new Color4(4286224105);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:143 G:188 B:139 A:255.
        /// </summary>
        public static Color4 DarkSeaGreen
        {
            get
            {
                return new Color4(4287347855);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:72 G:61 B:139 A:255.
        /// </summary>
        public static Color4 DarkSlateBlue
        {
            get
            {
                return new Color4(4287315272);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:47 G:79 B:79 A:255.
        /// </summary>
        public static Color4 DarkSlateGray
        {
            get
            {
                return new Color4(4283387695);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:0 G:206 B:209 A:255.
        /// </summary>
        public static Color4 DarkTurquoise
        {
            get
            {
                return new Color4(4291939840);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:148 G:0 B:211 A:255.
        /// </summary>
        public static Color4 DarkViolet
        {
            get
            {
                return new Color4(4292018324);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:255 G:20 B:147 A:255.
        /// </summary>
        public static Color4 DeepPink
        {
            get
            {
                return new Color4(4287829247);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:0 G:191 B:255 A:255.
        /// </summary>
        public static Color4 DeepSkyBlue
        {
            get
            {
                return new Color4(4294950656);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:105 G:105 B:105 A:255.
        /// </summary>
        public static Color4 DimGray
        {
            get
            {
                return new Color4(4285098345);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:30 G:144 B:255 A:255.
        /// </summary>
        public static Color4 DodgerBlue
        {
            get
            {
                return new Color4(4294938654);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:178 G:34 B:34 A:255.
        /// </summary>
        public static Color4 Firebrick
        {
            get
            {
                return new Color4(4280427186);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:255 G:250 B:240 A:255.
        /// </summary>
        public static Color4 FloralWhite
        {
            get
            {
                return new Color4(4293982975);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:34 G:139 B:34 A:255.
        /// </summary>
        public static Color4 ForestGreen
        {
            get
            {
                return new Color4(4280453922);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:255 G:0 B:255 A:255.
        /// </summary>
        public static Color4 Fuchsia
        {
            get
            {
                return new Color4(4294902015);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:220 G:220 B:220 A:255.
        /// </summary>
        public static Color4 Gainsboro
        {
            get
            {
                return new Color4(4292664540);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:248 G:248 B:255 A:255.
        /// </summary>
        public static Color4 GhostWhite
        {
            get
            {
                return new Color4(4294965496);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:255 G:215 B:0 A:255.
        /// </summary>
        public static Color4 Gold
        {
            get
            {
                return new Color4(4278245375);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:218 G:165 B:32 A:255.
        /// </summary>
        public static Color4 Goldenrod
        {
            get
            {
                return new Color4(4280329690);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:128 G:128 B:128 A:255.
        /// </summary>
        public static Color4 Gray
        {
            get
            {
                return new Color4(4286611584);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:0 G:128 B:0 A:255.
        /// </summary>
        public static Color4 Green
        {
            get
            {
                return new Color4(4278222848);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:173 G:255 B:47 A:255.
        /// </summary>
        public static Color4 GreenYellow
        {
            get
            {
                return new Color4(4281335725);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:240 G:255 B:240 A:255.
        /// </summary>
        public static Color4 Honeydew
        {
            get
            {
                return new Color4(4293984240);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:255 G:105 B:180 A:255.
        /// </summary>
        public static Color4 HotPink
        {
            get
            {
                return new Color4(4290013695);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:205 G:92 B:92 A:255.
        /// </summary>
        public static Color4 IndianRed
        {
            get
            {
                return new Color4(4284243149);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:75 G:0 B:130 A:255.
        /// </summary>
        public static Color4 Indigo
        {
            get
            {
                return new Color4(4286709835);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:255 G:255 B:240 A:255.
        /// </summary>
        public static Color4 Ivory
        {
            get
            {
                return new Color4(4293984255);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:240 G:230 B:140 A:255.
        /// </summary>
        public static Color4 Khaki
        {
            get
            {
                return new Color4(4287424240);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:230 G:230 B:250 A:255.
        /// </summary>
        public static Color4 Lavender
        {
            get
            {
                return new Color4(4294633190);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:255 G:240 B:245 A:255.
        /// </summary>
        public static Color4 LavenderBlush
        {
            get
            {
                return new Color4(4294308095);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:124 G:252 B:0 A:255.
        /// </summary>
        public static Color4 LawnGreen
        {
            get
            {
                return new Color4(4278254716);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:255 G:250 B:205 A:255.
        /// </summary>
        public static Color4 LemonChiffon
        {
            get
            {
                return new Color4(4291689215);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:173 G:216 B:230 A:255.
        /// </summary>
        public static Color4 LightBlue
        {
            get
            {
                return new Color4(4293318829);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:240 G:128 B:128 A:255.
        /// </summary>
        public static Color4 LightCoral
        {
            get
            {
                return new Color4(4286611696);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:224 G:255 B:255 A:255.
        /// </summary>
        public static Color4 LightCyan
        {
            get
            {
                return new Color4(4294967264);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:250 G:250 B:210 A:255.
        /// </summary>
        public static Color4 LightGoldenrodYellow
        {
            get
            {
                return new Color4(4292016890);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:144 G:238 B:144 A:255.
        /// </summary>
        public static Color4 LightGreen
        {
            get
            {
                return new Color4(4287688336);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:211 G:211 B:211 A:255.
        /// </summary>
        public static Color4 LightGray
        {
            get
            {
                return new Color4(4292072403);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:255 G:182 B:193 A:255.
        /// </summary>
        public static Color4 LightPink
        {
            get
            {
                return new Color4(4290885375);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:255 G:160 B:122 A:255.
        /// </summary>
        public static Color4 LightSalmon
        {
            get
            {
                return new Color4(4286226687);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:32 G:178 B:170 A:255.
        /// </summary>
        public static Color4 LightSeaGreen
        {
            get
            {
                return new Color4(4289376800);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:135 G:206 B:250 A:255.
        /// </summary>
        public static Color4 LightSkyBlue
        {
            get
            {
                return new Color4(4294626951);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:119 G:136 B:153 A:255.
        /// </summary>
        public static Color4 LightSlateGray
        {
            get
            {
                return new Color4(4288252023);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:176 G:196 B:222 A:255.
        /// </summary>
        public static Color4 LightSteelBlue
        {
            get
            {
                return new Color4(4292789424);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:255 G:255 B:224 A:255.
        /// </summary>
        public static Color4 LightYellow
        {
            get
            {
                return new Color4(4292935679);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:0 G:255 B:0 A:255.
        /// </summary>
        public static Color4 Lime
        {
            get
            {
                return new Color4(4278255360);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:50 G:205 B:50 A:255.
        /// </summary>
        public static Color4 LimeGreen
        {
            get
            {
                return new Color4(4281519410);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:250 G:240 B:230 A:255.
        /// </summary>
        public static Color4 Linen
        {
            get
            {
                return new Color4(4293325050);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:255 G:0 B:255 A:255.
        /// </summary>
        public static Color4 Magenta
        {
            get
            {
                return new Color4(4294902015);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:128 G:0 B:0 A:255.
        /// </summary>
        public static Color4 Maroon
        {
            get
            {
                return new Color4(4278190208);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:102 G:205 B:170 A:255.
        /// </summary>
        public static Color4 MediumAquamarine
        {
            get
            {
                return new Color4(4289383782);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:0 G:0 B:205 A:255.
        /// </summary>
        public static Color4 MediumBlue
        {
            get
            {
                return new Color4(4291624960);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:186 G:85 B:211 A:255.
        /// </summary>
        public static Color4 MediumOrchid
        {
            get
            {
                return new Color4(4292040122);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:147 G:112 B:219 A:255.
        /// </summary>
        public static Color4 MediumPurple
        {
            get
            {
                return new Color4(4292571283);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:60 G:179 B:113 A:255.
        /// </summary>
        public static Color4 MediumSeaGreen
        {
            get
            {
                return new Color4(4285641532);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:123 G:104 B:238 A:255.
        /// </summary>
        public static Color4 MediumSlateBlue
        {
            get
            {
                return new Color4(4293814395);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:0 G:250 B:154 A:255.
        /// </summary>
        public static Color4 MediumSpringGreen
        {
            get
            {
                return new Color4(4288346624);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:72 G:209 B:204 A:255.
        /// </summary>
        public static Color4 MediumTurquoise
        {
            get
            {
                return new Color4(4291613000);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:199 G:21 B:133 A:255.
        /// </summary>
        public static Color4 MediumVioletRed
        {
            get
            {
                return new Color4(4286911943);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:25 G:25 B:112 A:255.
        /// </summary>
        public static Color4 MidnightBlue
        {
            get
            {
                return new Color4(4285536537);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:245 G:255 B:250 A:255.
        /// </summary>
        public static Color4 MintCream
        {
            get
            {
                return new Color4(4294639605);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:255 G:228 B:225 A:255.
        /// </summary>
        public static Color4 MistyRose
        {
            get
            {
                return new Color4(4292994303);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:255 G:228 B:181 A:255.
        /// </summary>
        public static Color4 Moccasin
        {
            get
            {
                return new Color4(4290110719);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:255 G:222 B:173 A:255.
        /// </summary>
        public static Color4 NavajoWhite
        {
            get
            {
                return new Color4(4289584895);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:0 G:0 B:128 A:255.
        /// </summary>
        public static Color4 Navy
        {
            get
            {
                return new Color4(4286578688);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:253 G:245 B:230 A:255.
        /// </summary>
        public static Color4 OldLace
        {
            get
            {
                return new Color4(4293326333);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:128 G:128 B:0 A:255.
        /// </summary>
        public static Color4 Olive
        {
            get
            {
                return new Color4(4278222976);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:107 G:142 B:35 A:255.
        /// </summary>
        public static Color4 OliveDrab
        {
            get
            {
                return new Color4(4280520299);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:255 G:165 B:0 A:255.
        /// </summary>
        public static Color4 Orange
        {
            get
            {
                return new Color4(4278232575);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:255 G:69 B:0 A:255.
        /// </summary>
        public static Color4 OrangeRed
        {
            get
            {
                return new Color4(4278207999);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:218 G:112 B:214 A:255.
        /// </summary>
        public static Color4 Orchid
        {
            get
            {
                return new Color4(4292243674);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:238 G:232 B:170 A:255.
        /// </summary>
        public static Color4 PaleGoldenrod
        {
            get
            {
                return new Color4(4289390830);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:152 G:251 B:152 A:255.
        /// </summary>
        public static Color4 PaleGreen
        {
            get
            {
                return new Color4(4288215960);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:175 G:238 B:238 A:255.
        /// </summary>
        public static Color4 PaleTurquoise
        {
            get
            {
                return new Color4(4293848751);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:219 G:112 B:147 A:255.
        /// </summary>
        public static Color4 PaleVioletRed
        {
            get
            {
                return new Color4(4287852763);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:255 G:239 B:213 A:255.
        /// </summary>
        public static Color4 PapayaWhip
        {
            get
            {
                return new Color4(4292210687);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:255 G:218 B:185 A:255.
        /// </summary>
        public static Color4 PeachPuff
        {
            get
            {
                return new Color4(4290370303);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:205 G:133 B:63 A:255.
        /// </summary>
        public static Color4 Peru
        {
            get
            {
                return new Color4(4282353101);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:255 G:192 B:203 A:255.
        /// </summary>
        public static Color4 Pink
        {
            get
            {
                return new Color4(4291543295);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:221 G:160 B:221 A:255.
        /// </summary>
        public static Color4 Plum
        {
            get
            {
                return new Color4(4292714717);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:176 G:224 B:230 A:255.
        /// </summary>
        public static Color4 PowderBlue
        {
            get
            {
                return new Color4(4293320880);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:128 G:0 B:128 A:255.
        /// </summary>
        public static Color4 Purple
        {
            get
            {
                return new Color4(4286578816);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:255 G:0 B:0 A:255.
        /// </summary>
        public static Color4 Red
        {
            get
            {
                return new Color4(4278190335);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:188 G:143 B:143 A:255.
        /// </summary>
        public static Color4 RosyBrown
        {
            get
            {
                return new Color4(4287598524);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:65 G:105 B:225 A:255.
        /// </summary>
        public static Color4 RoyalBlue
        {
            get
            {
                return new Color4(4292962625);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:139 G:69 B:19 A:255.
        /// </summary>
        public static Color4 SaddleBrown
        {
            get
            {
                return new Color4(4279453067);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:250 G:128 B:114 A:255.
        /// </summary>
        public static Color4 Salmon
        {
            get
            {
                return new Color4(4285694202);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:244 G:164 B:96 A:255.
        /// </summary>
        public static Color4 SandyBrown
        {
            get
            {
                return new Color4(4284523764);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:46 G:139 B:87 A:255.
        /// </summary>
        public static Color4 SeaGreen
        {
            get
            {
                return new Color4(4283927342);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:255 G:245 B:238 A:255.
        /// </summary>
        public static Color4 SeaShell
        {
            get
            {
                return new Color4(4293850623);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:160 G:82 B:45 A:255.
        /// </summary>
        public static Color4 Sienna
        {
            get
            {
                return new Color4(4281160352);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:192 G:192 B:192 A:255.
        /// </summary>
        public static Color4 Silver
        {
            get
            {
                return new Color4(4290822336);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:135 G:206 B:235 A:255.
        /// </summary>
        public static Color4 SkyBlue
        {
            get
            {
                return new Color4(4293643911);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:106 G:90 B:205 A:255.
        /// </summary>
        public static Color4 SlateBlue
        {
            get
            {
                return new Color4(4291648106);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:112 G:128 B:144 A:255.
        /// </summary>
        public static Color4 SlateGray
        {
            get
            {
                return new Color4(4287660144);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:255 G:250 B:250 A:255.
        /// </summary>
        public static Color4 Snow
        {
            get
            {
                return new Color4(4294638335);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:0 G:255 B:127 A:255.
        /// </summary>
        public static Color4 SpringGreen
        {
            get
            {
                return new Color4(4286578432);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:70 G:130 B:180 A:255.
        /// </summary>
        public static Color4 SteelBlue
        {
            get
            {
                return new Color4(4290019910);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:210 G:180 B:140 A:255.
        /// </summary>
        public static Color4 Tan
        {
            get
            {
                return new Color4(4287411410);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:0 G:128 B:128 A:255.
        /// </summary>
        public static Color4 Teal
        {
            get
            {
                return new Color4(4286611456);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:216 G:191 B:216 A:255.
        /// </summary>
        public static Color4 Thistle
        {
            get
            {
                return new Color4(4292394968);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:255 G:99 B:71 A:255.
        /// </summary>
        public static Color4 Tomato
        {
            get
            {
                return new Color4(4282868735);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:64 G:224 B:208 A:255.
        /// </summary>
        public static Color4 Turquoise
        {
            get
            {
                return new Color4(4291878976);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:238 G:130 B:238 A:255.
        /// </summary>
        public static Color4 Violet
        {
            get
            {
                return new Color4(4293821166);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:245 G:222 B:179 A:255.
        /// </summary>
        public static Color4 Wheat
        {
            get
            {
                return new Color4(4289978101);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:255 G:255 B:255 A:255.
        /// </summary>
        public static Color4 White
        {
            get
            {
                return new Color4(uint.MaxValue);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:245 G:245 B:245 A:255.
        /// </summary>
        public static Color4 WhiteSmoke
        {
            get
            {
                return new Color4(4294309365);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:255 G:255 B:0 A:255.
        /// </summary>
        public static Color4 Yellow
        {
            get
            {
                return new Color4(4278255615);
            }
        }

        /// <summary>
        /// Gets a Color4 with the index R:154 G:205 B:50 A:255.
        /// </summary>
        public static Color4 YellowGreen
        {
            get
            {
                return new Color4(4281519514);
            }
        }


        #endregion

    }
}
