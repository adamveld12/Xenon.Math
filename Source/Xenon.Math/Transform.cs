
namespace Xenon.Math
{
    /// <summary>
    /// A rotation, position and scale in 3d space
    /// </summary>
    public struct Transform
    {
        /// <summary>
        /// An absolute rotation in 3D space
        /// </summary>
        public Quaternion Rotation;

        /// <summary>
        /// An absolute position in 3D space
        /// </summary>
        public Vector3 Position;
				
        /// <summary>
        /// An absolute scale in 3D space
        /// </summary>
        public Vector3 Scale;

        private static Transform _zero = default(Transform);

        /// <summary>
        /// Returns a matrix that represents the attributes of this transform
        /// </summary>
				/// <returns></returns>
        public Matrix GetTransformAsMatrix()
        {
            Matrix translationMatrix;
            Matrix.Translation(ref Position, out translationMatrix);

            Matrix scaleMatrix;
            Matrix.Scaling(ref Scale, out scaleMatrix);

            Matrix rotationMatrix;
            Matrix.RotationQuaternion(ref Rotation, out rotationMatrix);

            Matrix finalMatrix;
            Matrix.Multiply(ref scaleMatrix, ref rotationMatrix, out finalMatrix);
            Matrix.Multiply(ref finalMatrix, ref translationMatrix, out finalMatrix);

            return finalMatrix;
        }

        /// <summary>
        /// A transform with all properties initialized to zero
        /// </summary>
        public static Transform Zero
        { get { return _zero; } }
    }
}
