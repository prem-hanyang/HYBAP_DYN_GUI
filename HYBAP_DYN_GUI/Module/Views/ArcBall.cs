using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module.Views
{
    internal struct Vector2D
    {
        public double X;
        public double Y;
    }

    internal struct Vector3D
    {
        public double X;
        public double Y;
        public double Z;
    }

    internal struct Vector4D
    {
        public double X;
        public double Y;
        public double Z;
        public double W;
    }

    internal struct Matrix3D
    {
        public double XX;
        public double XY;
        public double XZ;
        public double YX;
        public double YY;
        public double YZ;
        public double ZX;
        public double ZY;
        public double ZZ;
    }

    internal struct Matrix4D
    {
        public double XX;
        public double XY;
        public double XZ;
        public double XW;
        public double YX;
        public double YY;
        public double YZ;
        public double YW;
        public double ZX;
        public double ZY;
        public double ZZ;
        public double ZW;
        public double TX;
        public double TY;
        public double TZ;
        public double TW;
    }

    internal class ArcBall
    {
        public static void Vector2DAdd(ref Vector2D NewObj, Vector2D t1)
        {
            NewObj.X += t1.X;
            NewObj.Y += t1.Y;
        }

        public static void Vector2DSub(ref Vector2D NewObj, Vector2D t1)
        {
            NewObj.X -= t1.X;
            NewObj.Y -= t1.Y;
        }

        public static void Vector3DCross(ref Vector3D NewObj, Vector3D v1, Vector3D v2)
        {
            NewObj.X = (v1.Y * v2.Z) - (v1.Z * v2.Y);
            NewObj.Y = (v1.Z * v2.X) - (v1.X * v2.Z);
            NewObj.Z = (v1.X * v2.Y) - (v1.Y * v2.X);
        }

        public static double Vector3DDot(Vector3D v1, Vector3D v2)
        {
            return (v1.X * v2.X) + (v1.Y * v2.Y) + (v1.Z * v2.Z);
        }

        public static double Vector3DLengthSquared(Vector3D v1)
        {
            return (v1.X * v1.X) + (v1.Y * v1.Y) + (v1.Z * v1.Z);
        }

        public static double Vector3DLength(Vector3D v1)
        {
            return Math.Sqrt(Vector3DLengthSquared(v1));
        }

        public static void Matrix3DSetZero(ref Matrix3D NewObj)
        {
            NewObj.XX = NewObj.XY = NewObj.XZ = 
            NewObj.YX = NewObj.YY = NewObj.YZ = 
            NewObj.ZX = NewObj.ZY = NewObj.ZZ = 0.0;
        }

        public static void Matrix3DSetIdentity(ref Matrix3D NewObj)
        {
            Matrix3DSetZero(ref NewObj);
            NewObj.XX = NewObj.YY = NewObj.ZZ = 1.0;
        }

        public static void Matrix3DSetRotationFromVector4D(ref Matrix3D NewObj, Vector4D q1)
        {
            double n, s;
            double xs, ys, zs;
            double wx, wy, wz;
            double xx, xy, xz;
            double yy, yz, zz;

            n = (q1.X * q1.X) + (q1.Y * q1.Y) + (q1.Z * q1.Z) + (q1.W * q1.W);
            s = (n > 0.0f) ? (2.0f / n) : 0.0f;

            xs = q1.X * s; ys = q1.Y * s; zs = q1.Z * s;
            wx = q1.W * xs; wy = q1.W * ys; wz = q1.W * zs;
            xx = q1.X * xs; xy = q1.X * ys; xz = q1.X * zs;
            yy = q1.Y * ys; yz = q1.Y * zs; zz = q1.Z * zs;

            NewObj.XX = 1.0f - (yy + zz); NewObj.YX = xy - wz; NewObj.ZX = xz + wy;
            NewObj.XY = xy + wz; NewObj.YY = 1.0f - (xx + zz); NewObj.ZY = yz - wx;
            NewObj.XZ = xz - wy; NewObj.YZ = yz + wx; NewObj.ZZ = 1.0f - (xx + yy);
        }

        public static void Matrix3DMulMatrix3D(ref Matrix3D NewObj, Matrix3D m1, Matrix3D m2)
        {
            NewObj.XX = (m1.XX * m2.XX) + (m1.YX * m2.XY) + (m1.ZX * m2.XZ);
            NewObj.YX = (m1.XX * m2.YX) + (m1.YX * m2.YY) + (m1.ZX * m2.YZ);
            NewObj.ZX = (m1.XX * m2.ZX) + (m1.YX * m2.ZY) + (m1.ZX * m2.ZZ);

            NewObj.XY = (m1.XY * m2.XX) + (m1.YY * m2.XY) + (m1.ZY * m2.XZ);
            NewObj.YY = (m1.XY * m2.YX) + (m1.YY * m2.YY) + (m1.ZY * m2.YZ);
            NewObj.ZY = (m1.XY * m2.ZX) + (m1.YY * m2.ZY) + (m1.ZY * m2.ZZ);

            NewObj.XZ = (m1.XZ * m2.XX) + (m1.YZ * m2.XY) + (m1.ZZ * m2.XZ);
            NewObj.YZ = (m1.XZ * m2.YX) + (m1.YZ * m2.YY) + (m1.ZZ * m2.YZ);
            NewObj.ZZ = (m1.XZ * m2.ZX) + (m1.YZ * m2.ZY) + (m1.ZZ * m2.ZZ);
        }

        public static void Matrix4DSetRotationScaleFromMatrix4D(ref Matrix4D NewObj, Matrix4D m1)
        {
            NewObj.XX = m1.XX; NewObj.YX = m1.YX; NewObj.ZX = m1.ZX;
            NewObj.XY = m1.XY; NewObj.YY = m1.YY; NewObj.ZY = m1.ZY;
            NewObj.XZ = m1.XZ; NewObj.YZ = m1.YZ; NewObj.ZZ = m1.ZZ;
        }

        public static double Matrix4DSVD(Matrix4D m1)
        {
            return Math.Sqrt(
                ((m1.XX * m1.XX) + (m1.XY * m1.XY) + (m1.XZ * m1.XZ) +
                (m1.YX * m1.YX) + (m1.YY * m1.YY) + (m1.YZ * m1.YZ) +
                (m1.ZX * m1.ZX) + (m1.ZY * m1.ZY) + (m1.ZZ * m1.ZZ)) / 3.0f);
        }

        public static void Matrix4DSetRotationScaleFromMatrix3D(ref Matrix4D NewObj, Matrix3D m1)
        {
            NewObj.XX = m1.XX; NewObj.YX = m1.YX; NewObj.ZX = m1.ZX;
            NewObj.XY = m1.XY; NewObj.YY = m1.YY; NewObj.ZY = m1.ZY;
            NewObj.XZ = m1.XZ; NewObj.YZ = m1.YZ; NewObj.ZZ = m1.ZZ;
        }

        public static void Matrix4DMulRotationScale(ref Matrix4D NewObj, double scale)
        {
            NewObj.XX *= scale; NewObj.YX *= scale; NewObj.ZX *= scale;
            NewObj.XY *= scale; NewObj.YY *= scale; NewObj.ZY *= scale;
            NewObj.XZ *= scale; NewObj.YZ *= scale; NewObj.ZZ *= scale;
        }

        public static void Matrix4DSetRotationFromMatrix3D(ref Matrix4D NewObj, Matrix3D m1)
        {
            double scale = Matrix4DSVD(NewObj);
            Matrix4DSetRotationScaleFromMatrix3D(ref NewObj, m1);
            Matrix4DMulRotationScale(ref NewObj, scale);
        }

        public static void Matrix4DSetRotationFromMatrix3D(ref double[] NewObj, Matrix3D m1)
        {
            Matrix4D _NewObj = new Matrix4D();
            _NewObj.XX = NewObj[0];
            _NewObj.XY = NewObj[1];
            _NewObj.XZ = NewObj[2];
            _NewObj.XW = NewObj[3];

            _NewObj.YX = NewObj[4];
            _NewObj.YY = NewObj[5];
            _NewObj.YZ = NewObj[6];
            _NewObj.YW = NewObj[7];

            _NewObj.ZX = NewObj[8];
            _NewObj.ZY = NewObj[9];
            _NewObj.ZZ = NewObj[10];
            _NewObj.ZW = NewObj[11];

            _NewObj.TX = NewObj[12];
            _NewObj.TY = NewObj[13];
            _NewObj.TZ = NewObj[14];
            _NewObj.TW = NewObj[15];

            double scale = Matrix4DSVD(_NewObj);
            Matrix4DSetRotationScaleFromMatrix3D(ref _NewObj, m1);
            Matrix4DMulRotationScale(ref _NewObj, scale);

            NewObj[0] = _NewObj.XX;
            NewObj[1] = _NewObj.XY;
            NewObj[2] = _NewObj.XZ;
            NewObj[3] = _NewObj.XW;

            NewObj[4] = _NewObj.YX;
            NewObj[5] = _NewObj.YY;
            NewObj[6] = _NewObj.YZ;
            NewObj[7] = _NewObj.YW;

            NewObj[8] = _NewObj.ZX;
            NewObj[9] = _NewObj.ZY;
            NewObj[10] = _NewObj.ZZ;
            NewObj[11] = _NewObj.ZW;

            NewObj[12] = _NewObj.TX;
            NewObj[13] = _NewObj.TY;
            NewObj[14] = _NewObj.TZ;
            NewObj[15] = _NewObj.TW;
        }

        public ArcBall(double NewWidth, double NewHeight)
        {
            StVec.X =
            StVec.Y =
            StVec.Z =

            EnVec.X =
            EnVec.Y =
            EnVec.Z = 0.0;

            setBounds(NewWidth, NewHeight);
        }

        public void setBounds(double NewWidth, double NewHeight)
        {
            System.Diagnostics.Debug.Assert((NewWidth > 1.0) && (NewHeight > 1.0));

            AdjustWidth = 1.0 / ((NewWidth - 1.0) * 0.5);
            AdjustHeight = 1.0 / ((NewHeight - 1.0) * 0.5);
        }

        public void click(Vector2D NewPt)
        {
            _mapToSphere(NewPt, ref StVec);
        }

        public void drag(Vector2D NewPt, ref Vector4D NewRot)
        {
            _mapToSphere(NewPt, ref EnVec);

            Vector3D Perp = new Vector3D();
            Vector3DCross(ref Perp, StVec, EnVec);
            if (Epsilon < Vector3DLength(Perp))
            {
                NewRot.X = Perp.X;
                NewRot.Y = Perp.Y;
                NewRot.Z = Perp.Z;
                NewRot.W = Vector3DDot(StVec, EnVec);
            }
            else
            {
                NewRot.X =
                NewRot.Y =
                NewRot.Z =
                NewRot.W = 0.0;
            }
        }

        protected void _mapToSphere(Vector2D NewPt, ref Vector3D NewVec)
        {
            Vector2D TempPt = new Vector2D();
            TempPt.X = (NewPt.X * AdjustWidth) - 1.0;
            TempPt.Y = 1.0 - (NewPt.Y * AdjustHeight);
            double length = (TempPt.X * TempPt.X) + (TempPt.Y * TempPt.Y);

            if (1.0 < length)
            {
                double norm = 1.0 / Math.Sqrt(length);
                NewVec.X = TempPt.X * norm;
                NewVec.Y = TempPt.Y * norm;
                NewVec.Z = 0.0;
            }
            else
            {
                NewVec.X = TempPt.X;
                NewVec.Y = TempPt.Y;
                NewVec.Z = Math.Sqrt(1.0 - length);
            }
        }

        protected Vector3D StVec;
        protected Vector3D EnVec;
        protected double AdjustWidth;
        protected double AdjustHeight;

        private const double Epsilon = 1.0e-5;
    }
}
