using System;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.InteropServices;

namespace Xenon.Math
{
    /// <summary>
    /// Represents an integral rectangular area
    /// </summary>
    [TypeConverter(typeof(Xenon.Math.Converters.RectangleConverter))]
    [Serializable]
    [StructLayout(LayoutKind.Explicit)]
    public struct Rectangle : IEquatable<Rectangle>
    {
        #region Fields
        /// <summary>
        /// The location along the X axis
        /// </summary>
        [FieldOffset(0)]
        public int X;
        /// <summary>
        /// The location along the Y axis
        /// </summary>
        [FieldOffset(4)]
        public int Y;
        /// <summary>
        /// The size along the X axis
        /// </summary>
        [FieldOffset(8)]
        public int Width;
        /// <summary>
        /// The size along the Y axis
        /// </summary>
        [FieldOffset(12)]
        public int Height;

        #endregion

        private static Rectangle _empty = default(Rectangle);

        /// <summary>
        /// Initializes a new instance of <see cref="Rectangle"/>
        /// </summary>
        /// <param name="x">The <see cref="Rectangle"/> position on the X axis</param>
        /// <param name="y">The <see cref="Rectangle"/> position on the Y axis</param>
        /// <param name="width">The <see cref="Rectangle"/> width</param>
        /// <param name="height">The <see cref="Rectangle"/> height</param>
        public Rectangle(int x, int y, int width, int height)
        {
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
        }

        #region Methods

        /// <summary>
        /// Moves the <see cref="Rectangle"/>'s location by the specified amount
        /// </summary>
        /// <param name="amount">A <see cref="Point"/> that specifies how much to move</param>
        public void Offset(Point amount)
        {
            this.X += amount.X;
            this.Y += amount.Y;
        }

        /// <summary>
        /// Moves the <see cref="Rectangle"/>'s location by the specified amount
        /// </summary>
        /// <param name="offsetX">How much to offset in the X axis</param>
        /// <param name="offsetY">How much to offset in the Y axis</param>
        public void Offset(int offsetX, int offsetY)
        {
            this.X += offsetX;
            this.Y += offsetY;
        }

        /// <summary>
        /// Expands the width and height
        /// </summary>
        /// <param name="horizontalAmount">How much to increase the width</param>
        /// <param name="verticalAmount">How much to increase the height</param>
        public void Inflate(int horizontalAmount, int verticalAmount)
        {
            this.X -= horizontalAmount;
            this.Y -= verticalAmount;
            this.Width += horizontalAmount * 2;
            this.Height += verticalAmount * 2;
        }

        /// <summary>
        /// Determines if a point is contained within this <see cref="Rectangle"/>
        /// </summary>
        /// <param name="x">The point's X location</param>
        /// <param name="y">The point's Y location</param>
        /// <returns>True if the x, y position is inside of the <see cref="Rectangle"/></returns>
        public bool Contains(int x, int y)
        { return this.X <= x && x < this.X + this.Width && this.Y <= y && y < this.Y + this.Height; }

        /// <summary>
        /// Determines if a <see cref="Point"/> is contained within this <see cref="Rectangle"/>
        /// </summary>
        /// <param name="value">A <see cref="Point"/> that contains an X and Y coordinate to test</param>
        /// <returns>True if the <see cref="Point"/> is inside of the <see cref="Rectangle"/></returns>
        public bool Contains(Point value)
        { return this.X <= value.X && value.X < this.X + this.Width && this.Y <= value.Y && value.Y < this.Y + this.Height; }

        /// <summary>
        /// Determines if a <see cref="Point"/> is contained within this <see cref="Rectangle"/>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="result"></param>
        public void Contains(ref Point value, out bool result)
        { result = (this.X <= value.X && value.X < this.X + this.Width && this.Y <= value.Y && value.Y < this.Y + this.Height);  }

        /// <summary>
        /// Determines if a point is contained within this <see cref="Rectangle"/>
        /// </summary>
        /// <param name="x">The point's X location</param>
        /// <param name="y">The point's Y location</param>
        /// <returns>True if the x, y position is inside of the <see cref="Rectangle"/></returns>
        public bool Contains(float x, float y)
        { return this.X <= x && x < this.X + this.Width && this.Y <= y && y < this.Y + this.Height; }

        /// <summary>
        /// Determines if a <see cref="Vector2"/> is contained within this <see cref="Rectangle"/>
        /// </summary>
        /// <param name="value">A <see cref="Point"/> that contains an X and Y coordinate to test</param>
        /// <returns>True if the <see cref="Point"/> is inside of the <see cref="Rectangle"/></returns>
        public bool Contains(Vector2 value)
        { return this.X <= value.X && value.X < this.X + this.Width && this.Y <= value.Y && value.Y < this.Y + this.Height; }

        /// <summary>
        /// Determines if a <see cref="Vector2"/> is contained within this <see cref="Rectangle"/>
        /// </summary>
        /// <param name="value">The <see cref="Vector2"/> to test</param>
        /// <param name="result">True if this point is contained inside of this <see cref="Rectangle"/></param>
        public void Contains(ref Vector2 value, out bool result)
        { result = (this.X <= value.X && value.X < this.X + this.Width && this.Y <= value.Y && value.Y < this.Y + this.Height); }

        /// <summary>
        /// Determines if a <see cref="Rectangle"/> is contained inside of this instance of <see cref="Rectangle"/>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Contains(Rectangle value)
        { return this.X <= value.X && value.X + value.Width <= this.X + this.Width && this.Y <= value.Y && value.Y + value.Height <= this.Y + this.Height; }

        /// <summary>
        /// Determines if a <see cref="RectangleF"/> is contained inside of this instance of <see cref="Rectangle"/>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Contains(RectangleF value)
        { return this.X <= value.X && value.X + value.Width <= this.X + this.Width && this.Y <= value.Y && value.Y + value.Height <= this.Y + this.Height; }

        /// <summary>
        /// Determines if a <see cref="Rectangle"/> is contained inside of this instance of <see cref="Rectangle"/>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="result"></param>
        public void Contains(ref Rectangle value, out bool result)
        { result = (this.X <= value.X && value.X + value.Width <= this.X + this.Width && this.Y <= value.Y && value.Y + value.Height <= this.Y + this.Height); }

        /// <summary>
        /// Determines if a <see cref="RectangleF"/> is contained inside of this instance of <see cref="Rectangle"/>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="result"></param>
        public void Contains(ref RectangleF value, out bool result)
        { result = (this.X <= value.X && value.X + value.Width <= this.X + this.Width && this.Y <= value.Y && value.Y + value.Height <= this.Y + this.Height); }

        /// <summary>
        /// Determines if two <see cref="Rectangle"/> structures are intersecting
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Intersects(Rectangle value)
        { return value.X < this.X + this.Width && this.X < value.X + value.Width && value.Y < this.Y + this.Height && this.Y < value.Y + value.Height; }

        /// <summary>
        /// Determines if two <see cref="Rectangle"/> structures are intersecting
        /// </summary>
        /// <param name="value"></param>
        /// <param name="result"></param>
        public void Intersects(ref Rectangle value, out bool result)
        { result = (value.X < this.X + this.Width && this.X < value.X + value.Width && value.Y < this.Y + this.Height && this.Y < value.Y + value.Height); }


        /// <summary>
        /// Determines if two <see cref="RectangleF"/> structures are intersecting
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Intersects(RectangleF value)
        { return value.X < this.X + this.Width && this.X < value.X + value.Width && value.Y < this.Y + this.Height && this.Y < value.Y + value.Height; }

        /// <summary>
        /// Determines if two <see cref="RectangleF"/> structures are intersecting
        /// </summary>
        /// <param name="value"></param>
        /// <param name="result"></param>
        public void Intersects(ref RectangleF value, out bool result)
        { result = (value.X < this.X + this.Width && this.X < value.X + value.Width && value.Y < this.Y + this.Height && this.Y < value.Y + value.Height); }

        /// <summary>
        /// Determines if two <see cref="Rectangle"/>s are equal
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Rectangle other)
        { return this.X == other.X && this.Y == other.Y && this.Width == other.Width && this.Height == other.Height; }

        /// <summary>
        /// Determines equality between two objects
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            bool result = false;
            if (obj is Rectangle)
                result = this.Equals((Rectangle)obj);
            return result;
        }

        /// <summary>
        /// Returns a string representation of this structure
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            CultureInfo currentCulture = CultureInfo.CurrentCulture;
            return string.Format(currentCulture, "{{X:{0} Y:{1} Width:{2} Height:{3}}}", new object[]
			{
				this.X.ToString(currentCulture), 
				this.Y.ToString(currentCulture), 
				this.Width.ToString(currentCulture), 
				this.Height.ToString(currentCulture)
			});
        }

        /// <summary>
        /// Gets a hashed value that represents this structure
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        { return this.X.GetHashCode() + this.Y.GetHashCode() + this.Width.GetHashCode() + this.Height.GetHashCode(); }

        #endregion

        #region Static Methods

        /// <summary>
        /// Determines if two <see cref="Rectangle"/>s are intersecting
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <returns></returns>
        public static Rectangle Intersect(Rectangle value1, Rectangle value2)
        {
            int num = value1.X + value1.Width;
            int num2 = value2.X + value2.Width;
            int num3 = value1.Y + value1.Height;
            int num4 = value2.Y + value2.Height;
            int num5 = (value1.X > value2.X) ? value1.X : value2.X;
            int num6 = (value1.Y > value2.Y) ? value1.Y : value2.Y;
            int num7 = (num < num2) ? num : num2;
            int num8 = (num3 < num4) ? num3 : num4;
            Rectangle result;
            if (num7 > num5 && num8 > num6)
            {
                result.X = num5;
                result.Y = num6;
                result.Width = num7 - num5;
                result.Height = num8 - num6;
            }
            else
            {
                result.X = 0;
                result.Y = 0;
                result.Width = 0;
                result.Height = 0;
            }
            return result;
        }

        /// <summary>
        /// Determines if two <see cref="Rectangle"/>s are intersecting
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <param name="result"></param>
        public static void Intersect(ref Rectangle value1, ref Rectangle value2, out Rectangle result)
        {
            int num = value1.X + value1.Width;
            int num2 = value2.X + value2.Width;
            int num3 = value1.Y + value1.Height;
            int num4 = value2.Y + value2.Height;
            int num5 = (value1.X > value2.X) ? value1.X : value2.X;
            int num6 = (value1.Y > value2.Y) ? value1.Y : value2.Y;
            int num7 = (num < num2) ? num : num2;
            int num8 = (num3 < num4) ? num3 : num4;
            if (num7 > num5 && num8 > num6)
            {
                result.X = num5;
                result.Y = num6;
                result.Width = num7 - num5;
                result.Height = num8 - num6;
                return;
            }
            result.X = 0;
            result.Y = 0;
            result.Width = 0;
            result.Height = 0;
        }

        /// <summary>
        /// Returns the Union of two <see cref="Rectangle"/>s
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <returns></returns>
        public static Rectangle Union(Rectangle value1, Rectangle value2)
        {
            int num = value1.X + value1.Width;
            int num2 = value2.X + value2.Width;
            int num3 = value1.Y + value1.Height;
            int num4 = value2.Y + value2.Height;
            int num5 = (value1.X < value2.X) ? value1.X : value2.X;
            int num6 = (value1.Y < value2.Y) ? value1.Y : value2.Y;
            int num7 = (num > num2) ? num : num2;
            int num8 = (num3 > num4) ? num3 : num4;
            Rectangle result;
            result.X = num5;
            result.Y = num6;
            result.Width = num7 - num5;
            result.Height = num8 - num6;
            return result;
        }

        /// <summary>
        /// Unions two <see cref="Rectangle"/> structures and returns the result
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <param name="result"></param>
        public static void Union(ref Rectangle value1, ref Rectangle value2, out Rectangle result)
        {
            int num = value1.X + value1.Width;
            int num2 = value2.X + value2.Width;
            int num3 = value1.Y + value1.Height;
            int num4 = value2.Y + value2.Height;
            int num5 = (value1.X < value2.X) ? value1.X : value2.X;
            int num6 = (value1.Y < value2.Y) ? value1.Y : value2.Y;
            int num7 = (num > num2) ? num : num2;
            int num8 = (num3 > num4) ? num3 : num4;
            result.X = num5;
            result.Y = num6;
            result.Width = num7 - num5;
            result.Height = num8 - num6;
        }

        /// <summary>
        /// Determines if two <see cref="Rectangle"/> instances are equal
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator ==(Rectangle a, Rectangle b)
        { return a.X == b.X && a.Y == b.Y && a.Width == b.Width && a.Height == b.Height; }

        /// <summary>
        /// Determines if two <see cref="Rectangle"/> instances are not equal
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator !=(Rectangle a, Rectangle b)
        { return a.X != b.X || a.Y != b.Y || a.Width != b.Width || a.Height != b.Height; }

        /// <summary>
        /// Determines if a <see cref="Rectangle"/> and <see cref="RectangleF"/> are equal
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator ==(Rectangle a, RectangleF b)
        { return a.X == b.X && a.Y == b.Y && a.Width == b.Width && a.Height == b.Height; }

        /// <summary>
        /// Determines if a <see cref="Rectangle"/> and <see cref="RectangleF"/> are not equal
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator !=(Rectangle a, RectangleF b)
        { return a.X != b.X || a.Y != b.Y || a.Width != b.Width || a.Height != b.Height; }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the x axis value of the far left edge of this <see cref="Rectangle"/>
        /// </summary>
        public int Left
        { get { return this.X; } }

        /// <summary>
        /// Gets the x axis value of the far right edge of this <see cref="Rectangle"/>
        /// </summary>
        public int Right
        { get { return this.X + this.Width; } }

        /// <summary>
        /// Gets the y axis value of the upper most edge of this <see cref="Rectangle"/>
        /// </summary>
        public int Top
        { get { return this.Y; } }

        /// <summary>
        /// Gets the y acis value of the lower most edge of this <see cref="Rectangle"/>
        /// </summary>
        public int Bottom
        { get { return this.Y + this.Height; } }

        /// <summary>
        /// Gets the <see cref="Point"/> that represents this <see cref="Rectangle"/>'s location
        /// </summary>
        public Point Location
        {
            get { return new Point(this.X, this.Y); }
            set
            {
                this.X = value.X;
                this.Y = value.Y;
            }
        }

        /// <summary>
        /// Gets the <see cref="Point"/> that lies in the center of this <see cref="Rectangle"/>
        /// </summary>
        public Point Center
        {
            get
            { return new Point(this.X + this.Width / 2, this.Y + this.Height / 2); }
        }

        /// <summary>
        /// Gets an instance of <see cref="Rectangle"/> that has all of it's fields iniitalized to 0
        /// </summary>
        public static Rectangle Empty
        { get { return Rectangle._empty; } }

        /// <summary>
        /// Determines if this <see cref="Rectangle"/> has an area of 0
        /// </summary>
        public bool IsEmpty
        {
            get { return this.Width == 0 && this.Height == 0; }
        }

        #endregion
    }
}
