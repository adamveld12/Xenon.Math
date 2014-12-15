using System;
using System.Globalization;

namespace Xenon.Math
{
    /// <summary>
    /// A 2D point
    /// </summary>
    [Serializable]
    public struct Point : IEquatable<Point>
    {
        /// <summary>
        /// The X coordinate
        /// </summary>
        public int X;
        /// <summary>
        /// The Y coordinate
        /// </summary>
        public int Y;

        private static readonly Point _zero = default(Point);

        /// <summary>
        /// Initializes a new instance of Point
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Determines the equality between two points
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Point other)
        { return X == other.X && Y == other.Y; }

        /// <summary>
        /// Determines equality between this and another object
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            bool result = false;
            if (obj is Point)
                result = Equals((Point)obj);
            return result;
        }

        /// <summary>
        /// A code representing this structure
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return X.GetHashCode() + Y.GetHashCode();
        }

        /// <summary>
        /// The string representation of this object
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            CultureInfo currentCulture = CultureInfo.CurrentCulture;
            return string.Format(currentCulture, "{{X:{0} Y:{1}}}", new object[]
			{
				X.ToString(currentCulture), 
				Y.ToString(currentCulture)
			});
        }

        /// <summary>
        /// Equality operator
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator ==(Point a, Point b)
        { return a.Equals(b); }

        /// <summary>
        /// Not equals operator
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator !=(Point a, Point b)
        { return a.X != b.X || a.Y != b.Y;  }

        /// <summary>
        /// A Point with its components set to 0
        /// </summary>
        public static Point Zero
        { get { return _zero; } }
    }
}
