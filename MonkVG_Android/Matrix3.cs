using System;
#if OSX
using MonoMac.OpenGL;
#else
using OpenTK;
#endif

namespace MonkVG
{
	public partial class VG
	{
	[Serializable]
	public struct Matrix3 : IEquatable<Matrix3>
	{
		//
		// Static Fields
		//
		public static readonly Matrix3 Zero;
		public static readonly Matrix3 Identity=new Matrix3(1,0,0, 0,1,0, 0,0,1);
		//
		// Fields
		//
		public float R0C0;
		public float R0C1;
		public float R0C2;
		public float R1C0;
		public float R1C1;
		public float R1C2;
		public float R2C0;
		public float R2C1;
		public float R2C2;
		//
		// Properties
		//
		public float Determinant
		{
			get
			{
				return this.R0C0 * this.R1C1 * this.R2C2 - this.R0C0 * this.R1C2 * this.R2C1 - this.R0C1 * this.R1C0 * this.R2C2 + this.R0C2 * this.R1C0 * this.R2C1 + this.R0C1 * this.R1C2 * this.R2C0 - this.R0C2 * this.R1C1 * this.R2C0;
			}
		}
		//
		// Indexer
		//
		public float this [int index]
		{
			get
			{
				switch (index)
				{
					case 0:
					return this.R0C0;
					case 1:
					return this.R0C1;
					case 2:
					return this.R0C2;
					case 3:
					return this.R1C0;
					case 4:
					return this.R1C1;
					case 5:
					return this.R1C2;
					case 6:
					return this.R2C0;
					case 7:
					return this.R2C1;
					case 8:
					return this.R2C2;
					default:
					throw new IndexOutOfRangeException ();
				}
			}
			set
			{
				switch (index)
				{
					case 0:
					this.R0C0 = value;
					return;
					case 1:
					this.R0C1 = value;
					return;
					case 2:
					this.R0C2 = value;
					return;
					case 3:
					this.R1C0 = value;
					return;
					case 4:
					this.R1C1 = value;
					return;
					case 5:
					this.R1C2 = value;
					return;
					case 6:
					this.R2C0 = value;
					return;
					case 7:
					this.R2C1 = value;
					return;
					case 8:
					this.R2C2 = value;
					return;
					default:
					throw new IndexOutOfRangeException ();
				}
			}
		}
		public float this [int row, int column]
		{
			get
			{
				if (row != 0)
				{
					if (row != 1)
					{
						if (row == 2)
						{
							if (column == 0)
							{
								return this.R2C0;
							}
							if (column == 1)
							{
								return this.R2C1;
							}
							if (column == 2)
							{
								return this.R2C2;
							}
						}
					}
					else
					{
						if (column == 0)
						{
							return this.R1C0;
						}
						if (column == 1)
						{
							return this.R1C1;
						}
						if (column == 2)
						{
							return this.R1C2;
						}
					}
				}
				else
				{
					if (column == 0)
					{
						return this.R0C0;
					}
					if (column == 1)
					{
						return this.R0C1;
					}
					if (column == 2)
					{
						return this.R0C2;
					}
				}
				throw new IndexOutOfRangeException ();
			}
			set
			{
				if (row != 0)
				{
					if (row != 1)
					{
						if (row == 2)
						{
							if (column == 0)
							{
								this.R2C0 = value;
								return;
							}
							if (column == 1)
							{
								this.R2C1 = value;
								return;
							}
							if (column == 2)
							{
								this.R2C2 = value;
								return;
							}
						}
					}
					else
					{
						if (column == 0)
						{
							this.R1C0 = value;
							return;
						}
						if (column == 1)
						{
							this.R1C1 = value;
							return;
						}
						if (column == 2)
						{
							this.R1C2 = value;
							return;
						}
					}
				}
				else
				{
					if (column == 0)
					{
						this.R0C0 = value;
						return;
					}
					if (column == 1)
					{
						this.R0C1 = value;
						return;
					}
					if (column == 2)
					{
						this.R0C2 = value;
						return;
					}
				}
				throw new IndexOutOfRangeException ();
			}
		}
		//
		// Constructors
		//
		public Matrix3 (float[] floatArray)
		{
			if (floatArray == null || floatArray.GetLength (0) < 9)
			{
				throw new MissingFieldException ();
			}
			this.R0C0 = floatArray [0];
			this.R0C1 = floatArray [1];
			this.R0C2 = floatArray [2];
			this.R1C0 = floatArray [3];
			this.R1C1 = floatArray [4];
			this.R1C2 = floatArray [5];
			this.R2C0 = floatArray [6];
			this.R2C1 = floatArray [7];
			this.R2C2 = floatArray [8];
		}
		public Matrix3 (float r0c0, float r0c1, float r0c2, float r1c0, float r1c1, float r1c2, float r2c0, float r2c1, float r2c2)
		{
			this.R0C0 = r0c0;
			this.R0C1 = r0c1;
			this.R0C2 = r0c2;
			this.R1C0 = r1c0;
			this.R1C1 = r1c1;
			this.R1C2 = r1c2;
			this.R2C0 = r2c0;
			this.R2C1 = r2c1;
			this.R2C2 = r2c2;
		}
		public Matrix3 (ref Matrix3 matrix)
		{
			this.R0C0 = matrix.R0C0;
			this.R0C1 = matrix.R0C1;
			this.R0C2 = matrix.R0C2;
			this.R1C0 = matrix.R1C0;
			this.R1C1 = matrix.R1C1;
			this.R1C2 = matrix.R1C2;
			this.R2C0 = matrix.R2C0;
			this.R2C1 = matrix.R2C1;
			this.R2C2 = matrix.R2C2;
		}

#if OSX
		public Matrix3(ref MonoMac.OpenGL.Matrix4 m) 
		{
			this.R0C0=m.Row0.X;
			this.R0C1=m.Row0.Y;
			this.R0C2=m.Row3.X;	// Tx
			this.R1C0=m.Row1.X;
			this.R1C1=m.Row1.Y;
			this.R1C2=m.Row3.Y;	// Ty
			this.R2C0=m.Row2.X;
			this.R2C1=m.Row2.Y;
			this.R2C2=m.Row2.Z;
		}
#else
		public Matrix3(ref OpenTK.Matrix4 m) 
		{
				this.R0C0=m.Row0.X;
				this.R0C1=m.Row0.Y;
				this.R0C2=m.Row3.X;	// Tx
				this.R1C0=m.Row1.X;
				this.R1C1=m.Row1.Y;
				this.R1C2=m.Row3.Y;	// Ty
				this.R2C0=m.Row2.X;
				this.R2C1=m.Row2.Y;
				this.R2C2=m.Row2.Z;
		}
#endif
		//
		// Static Methods
		//
		public static void Add (ref Matrix3 left, ref Matrix3 right, out Matrix3 result)
		{
			result.R0C0 = left.R0C0 + right.R0C0;
			result.R0C1 = left.R0C1 + right.R0C1;
			result.R0C2 = left.R0C2 + right.R0C2;
			result.R1C0 = left.R1C0 + right.R1C0;
			result.R1C1 = left.R1C1 + right.R1C1;
			result.R1C2 = left.R1C2 + right.R1C2;
			result.R2C0 = left.R2C0 + right.R2C0;
			result.R2C1 = left.R2C1 + right.R2C1;
			result.R2C2 = left.R2C2 + right.R2C2;
		}
		public static bool Equals (ref Matrix3 left, ref Matrix3 right)
		{
			return left.R0C0 == right.R0C0 && left.R0C1 == right.R0C1 && left.R0C2 == right.R0C2 && left.R1C0 == right.R1C0 && left.R1C1 == right.R1C1 && left.R1C2 == right.R1C2 && left.R2C0 == right.R2C0 && left.R2C1 == right.R2C1 && left.R2C2 == right.R2C2;
		}
		public static bool EqualsApprox (ref Matrix3 left, ref Matrix3 right, float tolerance)
		{
			return Math.Abs (left.R0C0 - right.R0C0) <= tolerance && Math.Abs (left.R0C1 - right.R0C1) <= tolerance && Math.Abs (left.R0C2 - right.R0C2) <= tolerance && Math.Abs (left.R1C0 - right.R1C0) <= tolerance && Math.Abs (left.R1C1 - right.R1C1) <= tolerance && Math.Abs (left.R1C2 - right.R1C2) <= tolerance && Math.Abs (left.R2C0 - right.R2C0) <= tolerance && Math.Abs (left.R2C1 - right.R2C1) <= tolerance && Math.Abs (left.R2C2 - right.R2C2) <= tolerance;
		}
		public static void Multiply (ref Matrix3 left, ref Matrix3 right, out Matrix3 result)
		{
			result.R0C0 = right.R0C0 * left.R0C0 + right.R0C1 * left.R1C0 + right.R0C2 * left.R2C0;
			result.R0C1 = right.R0C0 * left.R0C1 + right.R0C1 * left.R1C1 + right.R0C2 * left.R2C1;
			result.R0C2 = right.R0C0 * left.R0C2 + right.R0C1 * left.R1C2 + right.R0C2 * left.R2C2;
			result.R1C0 = right.R1C0 * left.R0C0 + right.R1C1 * left.R1C0 + right.R1C2 * left.R2C0;
			result.R1C1 = right.R1C0 * left.R0C1 + right.R1C1 * left.R1C1 + right.R1C2 * left.R2C1;
			result.R1C2 = right.R1C0 * left.R0C2 + right.R1C1 * left.R1C2 + right.R1C2 * left.R2C2;
			result.R2C0 = right.R2C0 * left.R0C0 + right.R2C1 * left.R1C0 + right.R2C2 * left.R2C0;
			result.R2C1 = right.R2C0 * left.R0C1 + right.R2C1 * left.R1C1 + right.R2C2 * left.R2C1;
			result.R2C2 = right.R2C0 * left.R0C2 + right.R2C1 * left.R1C2 + right.R2C2 * left.R2C2;
		}
		public static void Multiply (ref Matrix3 matrix, float scalar, out Matrix3 result)
		{
			result.R0C0 = scalar * matrix.R0C0;
			result.R0C1 = scalar * matrix.R0C1;
			result.R0C2 = scalar * matrix.R0C2;
			result.R1C0 = scalar * matrix.R1C0;
			result.R1C1 = scalar * matrix.R1C1;
			result.R1C2 = scalar * matrix.R1C2;
			result.R2C0 = scalar * matrix.R2C0;
			result.R2C1 = scalar * matrix.R2C1;
			result.R2C2 = scalar * matrix.R2C2;
		}
		public static void Rotate (ref Matrix3 matrix, float angle, out Matrix3 result)
		{
			float num = MathHelper.DegreesToRadians (angle);
			float num2 = (float)Math.Sin ((double)num);
			float num3 = (float)Math.Cos ((double)num);
			result.R0C0 = num3 * matrix.R0C0 + num2 * matrix.R1C0;
			result.R0C1 = num3 * matrix.R0C1 + num2 * matrix.R1C1;
			result.R0C2 = num3 * matrix.R0C2 + num2 * matrix.R1C2;
			result.R1C0 = num3 * matrix.R1C0 - num2 * matrix.R0C0;
			result.R1C1 = num3 * matrix.R1C1 - num2 * matrix.R0C1;
			result.R1C2 = num3 * matrix.R1C2 - num2 * matrix.R0C2;
			result.R2C0 = matrix.R2C0;
			result.R2C1 = matrix.R2C1;
			result.R2C2 = matrix.R2C2;
		}
		public static void RotateMatrix (float angle, out Matrix3 result)
		{
			float num = MathHelper.DegreesToRadians (angle);
			float num2 = (float)Math.Sin ((double)num);
			float num3 = (float)Math.Cos ((double)num);
			result.R0C0 = num3;
			result.R0C1 = num2;
			result.R0C2 = 0f;
			result.R1C0 = -num2;
			result.R1C1 = num3;
			result.R1C2 = 0f;
			result.R2C0 = 0f;
			result.R2C1 = 0f;
			result.R2C2 = 1f;
		}
		public static void Subtract (ref Matrix3 left, ref Matrix3 right, out Matrix3 result)
		{
			result.R0C0 = left.R0C0 + right.R0C0;
			result.R0C1 = left.R0C1 + right.R0C1;
			result.R0C2 = left.R0C2 + right.R0C2;
			result.R1C0 = left.R1C0 + right.R1C0;
			result.R1C1 = left.R1C1 + right.R1C1;
			result.R1C2 = left.R1C2 + right.R1C2;
			result.R2C0 = left.R2C0 + right.R2C0;
			result.R2C1 = left.R2C1 + right.R2C1;
			result.R2C2 = left.R2C2 + right.R2C2;
		}
		public static void Transform (ref Matrix3 matrix, ref Vector3 vector, out Vector3 result)
		{
			result.X = matrix.R0C0 * vector.X + matrix.R0C1 * vector.Y + matrix.R0C2 * vector.Z;
			result.Y = matrix.R1C0 * vector.X + matrix.R1C1 * vector.Y + matrix.R1C2 * vector.Z;
			result.Z = matrix.R2C0 * vector.X + matrix.R2C1 * vector.Y + matrix.R2C2 * vector.Z;
		}
		public static void Transform (ref Matrix3 matrix, ref Vector3 vector)
		{
			float x = matrix.R0C0 * vector.X + matrix.R0C1 * vector.Y + matrix.R0C2 * vector.Z;
			float y = matrix.R1C0 * vector.X + matrix.R1C1 * vector.Y + matrix.R1C2 * vector.Z;
			vector.Z = matrix.R2C0 * vector.X + matrix.R2C1 * vector.Y + matrix.R2C2 * vector.Z;
			vector.X = x;
			vector.Y = y;
		}
		public static void Transpose (ref Matrix3 matrix, out Matrix3 result)
		{
			result.R0C0 = matrix.R0C0;
			result.R0C1 = matrix.R1C0;
			result.R0C2 = matrix.R2C0;
			result.R1C0 = matrix.R0C1;
			result.R1C1 = matrix.R1C1;
			result.R1C2 = matrix.R2C1;
			result.R2C0 = matrix.R0C2;
			result.R2C1 = matrix.R1C2;
			result.R2C2 = matrix.R2C2;
		}
		//
		// Methods
		//
		public void Add (ref Matrix3 matrix)
		{
			this.R0C0 += matrix.R0C0;
			this.R0C1 += matrix.R0C1;
			this.R0C2 += matrix.R0C2;
			this.R1C0 += matrix.R1C0;
			this.R1C1 += matrix.R1C1;
			this.R1C2 += matrix.R1C2;
			this.R2C0 += matrix.R2C0;
			this.R2C1 += matrix.R2C1;
			this.R2C2 += matrix.R2C2;
		}
		public void Add (ref Matrix3 matrix, out Matrix3 result)
		{
			result.R0C0 = this.R0C0 + matrix.R0C0;
			result.R0C1 = this.R0C1 + matrix.R0C1;
			result.R0C2 = this.R0C2 + matrix.R0C2;
			result.R1C0 = this.R1C0 + matrix.R1C0;
			result.R1C1 = this.R1C1 + matrix.R1C1;
			result.R1C2 = this.R1C2 + matrix.R1C2;
			result.R2C0 = this.R2C0 + matrix.R2C0;
			result.R2C1 = this.R2C1 + matrix.R2C1;
			result.R2C2 = this.R2C2 + matrix.R2C2;
		}
		//[CLSCompliant (false)]
		public bool Equals (Matrix3 matrix)
		{
			return this.R0C0 == matrix.R0C0 && this.R0C1 == matrix.R0C1 && this.R0C2 == matrix.R0C2 && this.R1C0 == matrix.R1C0 && this.R1C1 == matrix.R1C1 && this.R1C2 == matrix.R1C2 && this.R2C0 == matrix.R2C0 && this.R2C1 == matrix.R2C1 && this.R2C2 == matrix.R2C2;
		}
		public bool Equals (ref Matrix3 matrix)
		{
			return this.R0C0 == matrix.R0C0 && this.R0C1 == matrix.R0C1 && this.R0C2 == matrix.R0C2 && this.R1C0 == matrix.R1C0 && this.R1C1 == matrix.R1C1 && this.R1C2 == matrix.R1C2 && this.R2C0 == matrix.R2C0 && this.R2C1 == matrix.R2C1 && this.R2C2 == matrix.R2C2;
		}
		public bool EqualsApprox (ref Matrix3 matrix, float tolerance)
		{
			return Math.Abs (this.R0C0 - matrix.R0C0) <= tolerance && Math.Abs (this.R0C1 - matrix.R0C1) <= tolerance && Math.Abs (this.R0C2 - matrix.R0C2) <= tolerance && Math.Abs (this.R1C0 - matrix.R1C0) <= tolerance && Math.Abs (this.R1C1 - matrix.R1C1) <= tolerance && Math.Abs (this.R1C2 - matrix.R1C2) <= tolerance && Math.Abs (this.R2C0 - matrix.R2C0) <= tolerance && Math.Abs (this.R2C1 - matrix.R2C1) <= tolerance && Math.Abs (this.R2C2 - matrix.R2C2) <= tolerance;
		}
		public override int GetHashCode ()
		{
			return this.R0C0.GetHashCode () ^ this.R0C1.GetHashCode () ^ this.R0C2.GetHashCode () ^ this.R1C0.GetHashCode () ^ this.R1C1.GetHashCode () ^ this.R1C2.GetHashCode () ^ this.R2C0.GetHashCode () ^ this.R2C1.GetHashCode () ^ this.R2C2.GetHashCode ();
		}
		public void Multiply (float scalar, out Matrix3 result)
		{
			result.R0C0 = scalar * this.R0C0;
			result.R0C1 = scalar * this.R0C1;
			result.R0C2 = scalar * this.R0C2;
			result.R1C0 = scalar * this.R1C0;
			result.R1C1 = scalar * this.R1C1;
			result.R1C2 = scalar * this.R1C2;
			result.R2C0 = scalar * this.R2C0;
			result.R2C1 = scalar * this.R2C1;
			result.R2C2 = scalar * this.R2C2;
		}
		public void Multiply (float scalar)
		{
			this.R0C0 = scalar * this.R0C0;
			this.R0C1 = scalar * this.R0C1;
			this.R0C2 = scalar * this.R0C2;
			this.R1C0 = scalar * this.R1C0;
			this.R1C1 = scalar * this.R1C1;
			this.R1C2 = scalar * this.R1C2;
			this.R2C0 = scalar * this.R2C0;
			this.R2C1 = scalar * this.R2C1;
			this.R2C2 = scalar * this.R2C2;
		}
		public void Multiply (ref Matrix3 matrix, out Matrix3 result)
		{
			result.R0C0 = matrix.R0C0 * this.R0C0 + matrix.R0C1 * this.R1C0 + matrix.R0C2 * this.R2C0;
			result.R0C1 = matrix.R0C0 * this.R0C1 + matrix.R0C1 * this.R1C1 + matrix.R0C2 * this.R2C1;
			result.R0C2 = matrix.R0C0 * this.R0C2 + matrix.R0C1 * this.R1C2 + matrix.R0C2 * this.R2C2;
			result.R1C0 = matrix.R1C0 * this.R0C0 + matrix.R1C1 * this.R1C0 + matrix.R1C2 * this.R2C0;
			result.R1C1 = matrix.R1C0 * this.R0C1 + matrix.R1C1 * this.R1C1 + matrix.R1C2 * this.R2C1;
			result.R1C2 = matrix.R1C0 * this.R0C2 + matrix.R1C1 * this.R1C2 + matrix.R1C2 * this.R2C2;
			result.R2C0 = matrix.R2C0 * this.R0C0 + matrix.R2C1 * this.R1C0 + matrix.R2C2 * this.R2C0;
			result.R2C1 = matrix.R2C0 * this.R0C1 + matrix.R2C1 * this.R1C1 + matrix.R2C2 * this.R2C1;
			result.R2C2 = matrix.R2C0 * this.R0C2 + matrix.R2C1 * this.R1C2 + matrix.R2C2 * this.R2C2;
		}
		public void Multiply (ref Matrix3 matrix)
		{
			float r0C = matrix.R0C0 * this.R0C0 + matrix.R0C1 * this.R1C0 + matrix.R0C2 * this.R2C0;
			float r0C2 = matrix.R0C0 * this.R0C1 + matrix.R0C1 * this.R1C1 + matrix.R0C2 * this.R2C1;
			float r0C3 = matrix.R0C0 * this.R0C2 + matrix.R0C1 * this.R1C2 + matrix.R0C2 * this.R2C2;
			float r1C = matrix.R1C0 * this.R0C0 + matrix.R1C1 * this.R1C0 + matrix.R1C2 * this.R2C0;
			float r1C2 = matrix.R1C0 * this.R0C1 + matrix.R1C1 * this.R1C1 + matrix.R1C2 * this.R2C1;
			float r1C3 = matrix.R1C0 * this.R0C2 + matrix.R1C1 * this.R1C2 + matrix.R1C2 * this.R2C2;
			this.R2C0 = matrix.R2C0 * this.R0C0 + matrix.R2C1 * this.R1C0 + matrix.R2C2 * this.R2C0;
			this.R2C1 = matrix.R2C0 * this.R0C1 + matrix.R2C1 * this.R1C1 + matrix.R2C2 * this.R2C1;
			this.R2C2 = matrix.R2C0 * this.R0C2 + matrix.R2C1 * this.R1C2 + matrix.R2C2 * this.R2C2;
			this.R0C0 = r0C;
			this.R0C1 = r0C2;
			this.R0C2 = r0C3;
			this.R1C0 = r1C;
			this.R1C1 = r1C2;
			this.R1C2 = r1C3;
		}
		public void Rotate (float angle)
		{
			float num = MathHelper.DegreesToRadians (angle);
			float num2 = (float)Math.Sin ((double)num);
			float num3 = (float)Math.Cos ((double)num);
			float r0C = num3 * this.R0C0 + num2 * this.R1C0;
			float r0C2 = num3 * this.R0C1 + num2 * this.R1C1;
			float r0C3 = num3 * this.R0C2 + num2 * this.R1C2;
			this.R1C0 = num3 * this.R1C0 - num2 * this.R0C0;
			this.R1C1 = num3 * this.R1C1 - num2 * this.R0C1;
			this.R1C2 = num3 * this.R1C2 - num2 * this.R0C2;
			this.R0C0 = r0C;
			this.R0C1 = r0C2;
			this.R0C2 = r0C3;
		}
		public void Rotate (float angle, out Matrix3 result)
		{
			float num = MathHelper.DegreesToRadians (angle);
			float num2 = (float)Math.Sin ((double)num);
			float num3 = (float)Math.Cos ((double)num);
			result.R0C0 = num3 * this.R0C0 + num2 * this.R1C0;
			result.R0C1 = num3 * this.R0C1 + num2 * this.R1C1;
			result.R0C2 = num3 * this.R0C2 + num2 * this.R1C2;
			result.R1C0 = num3 * this.R1C0 - num2 * this.R0C0;
			result.R1C1 = num3 * this.R1C1 - num2 * this.R0C1;
			result.R1C2 = num3 * this.R1C2 - num2 * this.R0C2;
			result.R2C0 = this.R2C0;
			result.R2C1 = this.R2C1;
			result.R2C2 = this.R2C2;
		}
		public void Subtract (ref Matrix3 matrix, out Matrix3 result)
		{
			result.R0C0 = this.R0C0 + matrix.R0C0;
			result.R0C1 = this.R0C1 + matrix.R0C1;
			result.R0C2 = this.R0C2 + matrix.R0C2;
			result.R1C0 = this.R1C0 + matrix.R1C0;
			result.R1C1 = this.R1C1 + matrix.R1C1;
			result.R1C2 = this.R1C2 + matrix.R1C2;
			result.R2C0 = this.R2C0 + matrix.R2C0;
			result.R2C1 = this.R2C1 + matrix.R2C1;
			result.R2C2 = this.R2C2 + matrix.R2C2;
		}
		public void Subtract (ref Matrix3 matrix)
		{
			this.R0C0 += matrix.R0C0;
			this.R0C1 += matrix.R0C1;
			this.R0C2 += matrix.R0C2;
			this.R1C0 += matrix.R1C0;
			this.R1C1 += matrix.R1C1;
			this.R1C2 += matrix.R1C2;
			this.R2C0 += matrix.R2C0;
			this.R2C1 += matrix.R2C1;
			this.R2C2 += matrix.R2C2;
		}

		public override string ToString ()
		{
			return string.Format ("|{00}, {01}, {02}|\n|{03}, {04}, {05}|\n|{06}, {07}, {18}|\n" + this.R0C0, new object[]
			                      {
				this.R0C1,
				this.R0C2,
				this.R1C0,
				this.R1C1,
				this.R1C2,
				this.R2C0,
				this.R2C1,
				this.R2C2
			});
		}
		public void Transform (ref Vector3 vector, out Vector3 result)
		{
			result.X = this.R0C0 * vector.X + this.R0C1 * vector.Y + this.R0C2 * vector.Z;
			result.Y = this.R1C0 * vector.X + this.R1C1 * vector.Y + this.R1C2 * vector.Z;
			result.Z = this.R2C0 * vector.X + this.R2C1 * vector.Y + this.R2C2 * vector.Z;
		}
		public void Transform (ref Vector3 vector)
		{
			float x = this.R0C0 * vector.X + this.R0C1 * vector.Y + this.R0C2 * vector.Z;
			float y = this.R1C0 * vector.X + this.R1C1 * vector.Y + this.R1C2 * vector.Z;
			vector.Z = this.R2C0 * vector.X + this.R2C1 * vector.Y + this.R2C2 * vector.Z;
			vector.X = x;
			vector.Y = y;
		}
		public void Transpose (out Matrix3 result)
		{
			result.R0C0 = this.R0C0;
			result.R0C1 = this.R1C0;
			result.R0C2 = this.R2C0;
			result.R1C0 = this.R0C1;
			result.R1C1 = this.R1C1;
			result.R1C2 = this.R2C1;
			result.R2C0 = this.R0C2;
			result.R2C1 = this.R1C2;
			result.R2C2 = this.R2C2;
		}
		public void Transpose ()
		{
			MathHelper.Swap (ref this.R0C1, ref this.R1C0);
			MathHelper.Swap (ref this.R0C2, ref this.R2C0);
			MathHelper.Swap (ref this.R1C2, ref this.R2C1);
		}
		//
		// Operators
		//
		//[CLSCompliant (false)]
		public unsafe static explicit operator float* (Matrix3 matrix)
		{
			return &matrix.R0C0;
		}
		public static explicit operator float[] (Matrix3 matrix)
		{
			return new float[]
			{
				matrix.R0C0,
				matrix.R0C1,
				matrix.R0C2,
				matrix.R1C0,
				matrix.R1C1,
				matrix.R1C2,
				matrix.R2C0,
				matrix.R2C1,
				matrix.R2C2
			};
		}
		public unsafe static explicit operator IntPtr (Matrix3 matrix)
			{
				return (IntPtr)((void*)(&matrix.R0C0));
			}
		}

	}
}

