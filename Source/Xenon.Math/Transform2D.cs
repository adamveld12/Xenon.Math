using System;

namespace Xenon.Math
{
    /// <summary>
    /// A 2 dimensional transform
    /// </summary>
    public struct Transform2D
    {
        private static readonly Transform2D _one = new Transform2D
        {
            Position = Vector2.Zero,
            Scale = Vector2.One,
            Rotation = 0f,
            ZIndex = 0.5f
        };

        /// <summary>
        /// The absolute position of this <see cref="Transform2D"/>
        /// </summary>
        public Vector2 Position;
        
        /// <summary>
        /// The absolute rotation of this <see cref="Transform2D"/>
        /// </summary>
        public float Rotation;

        /// <summary>
        /// The absolute scale of this <see cref="Transform2D"/>
        /// </summary>
        public Vector2 Scale;

        /// <summary>
        /// The z-index for this transform
        /// </summary>
        public float ZIndex;

        /// <summary>
        /// Sets the rotation of this <see cref="Transform2D"/> from a rotation in degree units
        /// </summary>
        /// <param name="degrees"></param>
        public void SetRotationFromDegrees(float degrees)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the rotation of this <see cref="Transform2D"/> from a rotation in degrees
        /// </summary>
        /// <returns></returns>
        public float GetRotationAsDegrees()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns a matrix that represents the attributes of this <see cref="Transform2D"/>
        /// </summary>
        /// <returns></returns>
        public Matrix GetTransformAsMatrix()
        {
            Matrix translationMatrix;
            Matrix.Translation(Position.X, Position.Y, ZIndex, out translationMatrix);

            Matrix scaleMatrix;
            Matrix.Scaling(Scale.X, Scale.Y, 1, out scaleMatrix);

            Matrix rotationMatrix;
            Matrix.RotationZ(Rotation, out rotationMatrix);

//            Matrix.Multiply(ref rotationMatrix, ref scaleMatrix, out scaleMatrix);
//            Matrix.Multiply(ref scaleMatrix, ref translationMatrix, out translationMatrix);

            return scaleMatrix * translationMatrix;
        }

        /// <summary>
        /// Gets a <see cref="Transform2D"/> with all of its properties initialized to zero
        /// </summary>
        public static Transform2D Zero
        {
            get { return default(Transform2D); }
        }

        /// <summary>
        /// Gets a <see cref="Transform2D"/> with all of its properties initialized to one
        /// </summary>
        public static Transform2D One
        {
            get { return _one; }
        }
    }
}