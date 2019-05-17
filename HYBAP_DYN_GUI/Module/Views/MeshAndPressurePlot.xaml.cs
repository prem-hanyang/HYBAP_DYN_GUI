using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SharpGL;
using Module.Models;

namespace Module.Views
{
    /// <summary>
    /// MeshAndPressurePlot.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MeshAndPressurePlot : UserControl
    {
        public MeshAndPressurePlot()
        {
            InitializeComponent();
            ArcBall = new Views.ArcBall(10.0, 10.0);
            LastRot = new Matrix3D();
            ArcBall.Matrix3DSetIdentity(ref LastRot);
            ThisRot = new Matrix3D();
            ArcBall.Matrix3DSetIdentity(ref ThisRot);
            transform = new double[] {  1.0, 0.0, 0.0, 0.0,
                                        0.0, 1.0, 0.0, 0.0,
                                        0.0, 0.0, 1.0, 0.0,
                                        0.0, 0.0, 0.0, 1.0  };
            dragging = false;

            ArcBall_p = new Views.ArcBall(10.0, 10.0);
            LastRot_p = new Matrix3D();
            ArcBall.Matrix3DSetIdentity(ref LastRot_p);
            ThisRot_p = new Matrix3D();
            ArcBall.Matrix3DSetIdentity(ref ThisRot_p);
            transform_p = new double[] {  1.0, 0.0, 0.0, 0.0,
                                        0.0, 1.0, 0.0, 0.0,
                                        0.0, 0.0, 1.0, 0.0,
                                        0.0, 0.0, 0.0, 1.0  };
            dragging_p = false;
        }

        private void OpenGLControl_OpenGLInitialized(object sender, SharpGL.SceneGraph.OpenGLEventArgs args)
        {
            OpenGL gl = args.OpenGL;

            gl.ClearColor(0.9f, 0.99f, 0.88f, 0.1f);
            gl.ClearDepth(1.0f);
            gl.DepthFunc(SharpGL.Enumerations.DepthFunction.LessThanOrEqual);
            gl.Enable(OpenGL.GL_DEPTH_TEST);
            gl.Enable(OpenGL.GL_LINE_SMOOTH);
            gl.ShadeModel(SharpGL.Enumerations.ShadeModel.Flat);
            gl.Hint(SharpGL.Enumerations.HintTarget.LineSmooth, SharpGL.Enumerations.HintMode.DontCare);

            gl.Enable(OpenGL.GL_LIGHT0);
            gl.Enable(OpenGL.GL_COLOR_MATERIAL);
        }

        private void OpenGLControl_OpenGLInitialized_p(object sender, SharpGL.SceneGraph.OpenGLEventArgs args)
        {
            OpenGL gl = args.OpenGL;

            gl.ClearColor(0.9f, 0.88f, 0.99f, 0.1f);
            gl.ClearDepth(1.0f);
            gl.DepthFunc(SharpGL.Enumerations.DepthFunction.LessThanOrEqual);
            gl.Enable(OpenGL.GL_DEPTH_TEST);
            //gl.Enable(OpenGL.GL_LINE_SMOOTH);
            gl.ShadeModel(SharpGL.Enumerations.ShadeModel.Smooth);
            gl.Hint(SharpGL.Enumerations.HintTarget.PerspectiveCorrection, SharpGL.Enumerations.HintMode.Nicest);

            //gl.Enable(OpenGL.GL_LIGHT0);
            //gl.Enable(OpenGL.GL_COLOR_MATERIAL);
        }

        private void DrawScene(OpenGL gl)
        {
            if (ready)
            {
                ViewModels.MeshAndPressurePlotViewModel vm = DataContext as ViewModels.MeshAndPressurePlotViewModel;
                if (null != vm && null != vm.Data)
                {
                    int nPart = vm.Data.MainData.PartCount;
                    double Max_Z = double.NegativeInfinity;
                    double Min_Z = double.PositiveInfinity;
                    double Max_X = double.NegativeInfinity;
                    double Min_X = double.PositiveInfinity;
                    double SizingFactor;
                    double TranslationFactor;

                    for (int i = 0; i < nPart; ++i)
                    {
                        Models.MeshDisplayData data = vm.Data.MainData.PartList[i].MeshDisplayData;
                        for (int j = 1; j < data.Column; j++)
                        {
                            for (int k = 0; k < data.Row; k++)
                            {
                                if (Max_Z < data.z[k * data.Column + j])
                                {
                                    Max_Z = data.z[k * data.Column + j];
                                }
                                else if (Min_Z > data.z[k * data.Column + j])
                                {
                                    Min_Z = data.z[k * data.Column + j];
                                }
                                if (Max_X < data.x[k * data.Column + j])
                                {
                                    Max_X = data.x[k * data.Column + j];
                                }
                                else if (Min_X > data.x[k * data.Column + j])
                                {
                                    Min_X = data.x[k * data.Column + j];
                                }

                            }
                        }
                    }

                    if ((Max_Z - Min_Z) > (Max_X - Min_X))
                    {
                        SizingFactor = 20 / (Max_Z - Min_Z);
                    }
                    else
                    {
                        SizingFactor = 20 / (Max_X - Min_X);
                    }
                    TranslationFactor = -SizingFactor * (Max_Z + Min_Z) * 0.5;
                        

                    for (int i = 0; i < nPart; ++i)
                    {
                        Models.MeshDisplayData data = vm.Data.MainData.PartList[i].MeshDisplayData;

                        gl.PolygonOffset(1.0f, 1.0f);
                        gl.Enable(SharpGL.OpenGL.GL_POLYGON_OFFSET_FILL);
                        gl.PolygonMode(SharpGL.Enumerations.FaceMode.FrontAndBack, SharpGL.Enumerations.PolygonMode.Filled);
                        for (int j = 0; j < data.Column - 1; ++j)
                        {
                            for (int k = 0; k + 1 < data.Row; ++k)
                            {
                                gl.Begin(SharpGL.Enumerations.BeginMode.QuadStrip);
                                if (1.0 < data.ind[k * data.Column + j])
                                    gl.Color(0.0, 0.5, 1.0);
                                else
                                    gl.Color(1.0 - data.ind[k * data.Column + j], data.ind[k * data.Column + j], 0.0);
                                gl.Vertex(SizingFactor * data.x[k * data.Column + j], SizingFactor * data.y[k * data.Column + j], SizingFactor * data.z[k * data.Column + j] + TranslationFactor);
                                gl.Vertex(SizingFactor * data.x[k * data.Column + j + 1], SizingFactor * data.y[k * data.Column + j + 1], SizingFactor * data.z[k * data.Column + j + 1] + TranslationFactor);
                                gl.Vertex(SizingFactor * data.x[(k + 1) * data.Column + j], SizingFactor * data.y[(k + 1) * data.Column + j], SizingFactor * data.z[(k + 1) * data.Column + j] + TranslationFactor);
                                gl.Vertex(SizingFactor * data.x[(k + 1) * data.Column + j + 1], SizingFactor * data.y[(k + 1) * data.Column + j + 1], SizingFactor * data.z[(k + 1) * data.Column + j + 1] + TranslationFactor);
                            }
                            if (1.0 < data.ind[(data.Row - 1) * data.Column + j])
                                gl.Color(0.0, 0.5, 1.0);
                            else
                                gl.Color(1.0 - data.ind[(data.Row - 1) * data.Column + j], data.ind[(data.Row - 1) * data.Column + j], 0.0);
                            gl.Vertex(SizingFactor * data.x[(data.Row - 1) * data.Column + j], SizingFactor * data.y[(data.Row - 1) * data.Column + j], SizingFactor * data.z[(data.Row - 1) * data.Column + j] + TranslationFactor);
                            gl.Vertex(SizingFactor * data.x[(data.Row - 1) * data.Column + j + 1], SizingFactor * data.y[(data.Row - 1) * data.Column + j + 1], SizingFactor * data.z[(data.Row - 1) * data.Column + j + 1] + TranslationFactor);
                            gl.Vertex(SizingFactor * data.x[j], SizingFactor * data.y[j], SizingFactor * data.z[j] + TranslationFactor);
                            gl.Vertex(SizingFactor * data.x[j + 1], SizingFactor * data.y[j + 1], SizingFactor * data.z[j + 1] + TranslationFactor);
                            gl.End();
                        }

                        gl.PolygonOffset(0.0f, 0.0f);
                        gl.Disable(SharpGL.OpenGL.GL_POLYGON_OFFSET_FILL);
                        gl.PolygonMode(SharpGL.Enumerations.FaceMode.FrontAndBack, SharpGL.Enumerations.PolygonMode.Lines);
                        gl.Color(0.0, 0.0, 0.0);
                        for (int k = 0; k < data.Row; ++k)
                        {
                            gl.Begin(SharpGL.Enumerations.BeginMode.Lines);
                            for (int j = 0; j < data.Column - 1; ++j)
                            {
                                gl.Vertex(SizingFactor * data.x[k * data.Column + j], SizingFactor * data.y[k * data.Column + j], SizingFactor * data.z[k * data.Column + j] + TranslationFactor);
                                gl.Vertex(SizingFactor * data.x[k * data.Column + j + 1], SizingFactor * data.y[k * data.Column + j + 1], SizingFactor * data.z[k * data.Column + j + 1] + TranslationFactor);
                            }
                            gl.End();
                        }

                        for (int j = 0; j < data.Column; ++j)
                        {
                            gl.Begin(SharpGL.Enumerations.BeginMode.Lines);
                            for (int k = 0; k < data.Row - 1; ++k)
                            {
                                gl.Vertex(SizingFactor * data.x[k * data.Column + j], SizingFactor * data.y[k * data.Column + j], SizingFactor * data.z[k * data.Column + j] + TranslationFactor);
                                gl.Vertex(SizingFactor * data.x[(k + 1) * data.Column + j], SizingFactor * data.y[(k + 1) * data.Column + j], SizingFactor * data.z[(k + 1) * data.Column + j] + TranslationFactor);
                            }
                            gl.Vertex(SizingFactor * data.x[(data.Row - 1) * data.Column + j], SizingFactor * data.y[(data.Row - 1) * data.Column + j], SizingFactor * data.z[(data.Row - 1) * data.Column + j] + TranslationFactor);
                            gl.Vertex(SizingFactor * data.x[j], SizingFactor * data.y[j], SizingFactor * data.z[j] + TranslationFactor);
                            gl.End();
                        }
                    }
                }
            }
        }

        private void DrawScene_p(OpenGL gl)
        {
            if (ready_p)
            {
                ViewModels.MeshAndPressurePlotViewModel vm = DataContext as ViewModels.MeshAndPressurePlotViewModel;
                if (null != vm && null != vm.Data)
                {
                    int nPart = vm.Data.MainData.PartCount;
                    double Max_Z = double.NegativeInfinity;
                    double Min_Z = double.PositiveInfinity;
                    double Max_X = double.NegativeInfinity;
                    double Min_X = double.PositiveInfinity;
                    double SizingFactor;
                    double TranslationFactor;

                    for (int i = 0; i < nPart; ++i)
                    {
                        Models.MeshDisplayData data = vm.Data.MainData.PartList[i].MeshDisplayData;
                        for (int j = 1; j < data.Column; j++)
                        {
                            for (int k = 0; k < data.Row; k++)
                            {
                                if (Max_Z < data.z[k * data.Column + j])
                                {
                                    Max_Z = data.z[k * data.Column + j];
                                }
                                else if (Min_Z > data.z[k * data.Column + j])
                                {
                                    Min_Z = data.z[k * data.Column + j];
                                }
                                if (Max_X < data.x[k * data.Column + j])
                                {
                                    Max_X = data.x[k * data.Column + j];
                                }
                                else if (Min_X > data.x[k * data.Column + j])
                                {
                                    Min_X = data.x[k * data.Column + j];
                                }

                            }
                        }
                    }

                    if ((Max_Z - Min_Z) > (Max_X - Min_X))
                    {
                        SizingFactor = 20 / (Max_Z - Min_Z);
                    }
                    else
                    {
                        SizingFactor = 20 / (Max_X - Min_X);
                    }
                    TranslationFactor = -SizingFactor * (Max_Z + Min_Z) * 0.5;
                        

                    double max = double.NegativeInfinity;
                    double min = double.PositiveInfinity;
                   

                    for (int i = 0; i < nPart; ++i)
                    {
                        Models.PressureDisplayData data_r = vm.Data.MainData.PartList[i].PressureDisplayData;
                        if (max < data_r.max)
                            max = data_r.max;
                        if (min > data_r.min)
                            min = data_r.min;
                    }

                    double range1 = (7.0 * max + min) / 8.0;
                    double range2 = (6.0 * max + min) / 8.0;
                    double range3 = (5.0 * max + min) / 8.0;
                    double range4 = (4.0 * max + min) / 8.0;
                    double range5 = (3.0 * max + min) / 8.0;
                    double range6 = (2.0 * max + min) / 8.0;
                    double range7 = (1.0 * max + min) / 8.0;
                    double p1 = 0.0;
                    double p2 = 0.0;

                    for (int i = 0; i < nPart; ++i)
                    {
                        Models.PressureDisplayData data_r = vm.Data.MainData.PartList[i].PressureDisplayData;
                        Models.MeshDisplayData data = vm.Data.MainData.PartList[i].MeshDisplayData;

                        for (int j = 0; j < data.Column - 1; ++j)
                        {
                            gl.Begin(SharpGL.Enumerations.BeginMode.QuadStrip);

                            for (int k = 0; k < data.Row; ++k)
                            {
                                p1 = data_r.p[k * data.Column + j];
                                p2 = data_r.p[k * data.Column + j + 1];

                                if (range1 <= p1 && p1 <= max)
                                    gl.Color(0.5 + 4.0 * (max - p1) / (max - min), 0.0, 0.0);
                                else if (range2 <= p1 && p1 < range1)
                                    gl.Color(1.0, 0.5 * ((7.0 * max + min - 8.0 * p1) / (max - min)), 0.0);
                                else if (range3 <= p1 && p1 < range2)
                                    gl.Color(1.0, 0.5 + 0.5 * ((6.0 * max + min - 8.0 * p1) / (max - min)), 0.0);
                                else if (range4 <= p1 && p1 < range3)
                                    gl.Color(1.0 - 0.5 * ((5.0 * max + min - 8.0 * p1) / (max - min)), 1.0, 0.0);
                                else if (range5 <= p1 && p1 < range4)
                                    gl.Color(0.0, 1.0, 0.5 + 0.5 * ((4.0 * max + min - 8.0 * p1) / (max - min)));
                                else if (range6 <= p1 && p1 < range5)
                                    gl.Color(0.0, 1.0 - 0.5 * ((3.0 * max + min - 8.0 * p1) / (max - min)), 1.0);
                                else if (range7 <= p1 && p1 < range6)
                                    gl.Color(0.0, 0.5 - 0.5 * ((2.0 * max + min - 8.0 * p1) / (max - min)), 1.0);
                                else if (min <= p1 && p1 < range7)
                                    gl.Color(0.0, 0.0, 0.5 + 4.0 * (p1 - min) / (max - min));
                                gl.Vertex(SizingFactor * data.x[k * data.Column + j], SizingFactor * data.y[k * data.Column + j], SizingFactor * data.z[k * data.Column + j] + TranslationFactor);
                                if (range1 <= p2 && p2 <= max)
                                    gl.Color(0.5 + 4.0 * (max - p2) / (max - min), 0.0, 0.0);
                                else if (range2 <= p2 && p2 < range1)
                                    gl.Color(1.0, 0.5 * ((7.0 * max + min - 8.0 * p2) / (max - min)), 0.0);
                                else if (range3 <= p2 && p2 < range2)
                                    gl.Color(1.0, 0.5 + 0.5 * ((6.0 * max + min - 8.0 * p2) / (max - min)), 0.0);
                                else if (range4 <= p2 && p2 < range3)
                                    gl.Color(1.0 - 0.5 * ((5.0 * max + min - 8.0 * p2) / (max - min)), 1.0, 0.0);
                                else if (range5 <= p2 && p2 < range4)
                                    gl.Color(0.0, 1.0, 0.5 + 0.5 * ((4.0 * max + min - 8.0 * p2) / (max - min)));
                                else if (range6 <= p2 && p2 < range5)
                                    gl.Color(0.0, 1.0 - 0.5 * ((3.0 * max + min - 8.0 * p2) / (max - min)), 1.0);
                                else if (range7 <= p2 && p2 < range6)
                                    gl.Color(0.0, 0.5 - 0.5 * ((2.0 * max + min - 8.0 * p2) / (max - min)), 1.0);
                                else if (min <= p2 && p2 < range7)
                                    gl.Color(0.0, 0.0, 0.5 + 4.0 * (p2 - min) / (max - min));
                                gl.Vertex(SizingFactor * data.x[k * data.Column + j + 1], SizingFactor * data.y[k * data.Column + j + 1], SizingFactor * data.z[k * data.Column + j + 1] + TranslationFactor);
                            }
                            p1 = data_r.p[j];
                            p2 = data_r.p[j + 1];

                            if (range1 <= p1 && p1 <= max)
                                gl.Color(0.5 + 4.0 * (max - p1) / (max - min), 0.0, 0.0);
                            else if (range2 <= p1 && p1 < range1)
                                gl.Color(1.0, 0.5 * ((7.0 * max + min - 8.0 * p1) / (max - min)), 0.0);
                            else if (range3 <= p1 && p1 < range2)
                                gl.Color(1.0, 0.5 + 0.5 * ((6.0 * max + min - 8.0 * p1) / (max - min)), 0.0);
                            else if (range4 <= p1 && p1 < range3)
                                gl.Color(1.0 - 0.5 * ((5.0 * max + min - 8.0 * p1) / (max - min)), 1.0, 0.0);
                            else if (range5 <= p1 && p1 < range4)
                                gl.Color(0.0, 1.0, 0.5 + 0.5 * ((4.0 * max + min - 8.0 * p1) / (max - min)));
                            else if (range6 <= p1 && p1 < range5)
                                gl.Color(0.0, 1.0 - 0.5 * ((3.0 * max + min - 8.0 * p1) / (max - min)), 1.0);
                            else if (range7 <= p1 && p1 < range6)
                                gl.Color(0.0, 0.5 - 0.5 * ((2.0 * max + min - 8.0 * p1) / (max - min)), 1.0);
                            else if (min <= p1 && p1 < range7)
                                gl.Color(0.0, 0.0, 0.5 + 4.0 * (p1 - min) / (max - min));
                            gl.Vertex(SizingFactor * data.x[j], SizingFactor * data.y[j], SizingFactor * data.z[j] + TranslationFactor);
                            if (range1 <= p2 && p2 <= max)
                                gl.Color(0.5 + 4.0 * (max - p2) / (max - min), 0.0, 0.0);
                            else if (range2 <= p2 && p2 < range1)
                                gl.Color(1.0, 0.5 * ((7.0 * max + min - 8.0 * p2) / (max - min)), 0.0);
                            else if (range3 <= p2 && p2 < range2)
                                gl.Color(1.0, 0.5 + 0.5 * ((6.0 * max + min - 8.0 * p2) / (max - min)), 0.0);
                            else if (range4 <= p2 && p2 < range3)
                                gl.Color(1.0 - 0.5 * ((5.0 * max + min - 8.0 * p2) / (max - min)), 1.0, 0.0);
                            else if (range5 <= p2 && p2 < range4)
                                gl.Color(0.0, 1.0, 0.5 + 0.5 * ((4.0 * max + min - 8.0 * p2) / (max - min)));
                            else if (range6 <= p2 && p2 < range5)
                                gl.Color(0.0, 1.0 - 0.5 * ((3.0 * max + min - 8.0 * p2) / (max - min)), 1.0);
                            else if (range7 <= p2 && p2 < range6)
                                gl.Color(0.0, 0.5 - 0.5 * ((2.0 * max + min - 8.0 * p2) / (max - min)), 1.0);
                            else if (min <= p2 && p2 < range7)
                                gl.Color(0.0, 0.0, 0.5 + 4.0 * (p2 - min) / (max - min));
                            gl.Vertex(SizingFactor * data.x[j + 1], SizingFactor * data.y[j + 1], SizingFactor * data.z[j + 1] + TranslationFactor);

                            gl.End();
                        }
                    }
                }
            }
        }

        private void DrawScene_plegend(OpenGL gl)
        {
            if (ready_p)
            {
                ViewModels.MeshAndPressurePlotViewModel vm = DataContext as ViewModels.MeshAndPressurePlotViewModel;
                if (null != vm && null != vm.Data)
                {
                    double max = double.NegativeInfinity;
                    double min = double.PositiveInfinity;
                    int nPart = vm.Data.MainData.PartCount;

                    for (int i = 0; i < nPart; ++i)
                    {
                        Models.PressureDisplayData data_r = vm.Data.MainData.PartList[i].PressureDisplayData;
                        if (max < data_r.max)
                            max = data_r.max;
                        if (min > data_r.min)
                            min = data_r.min;
                    }

                    // Position The Text On The Screen
                    gl.DrawText((int)(PressureCanvas_inPlot.ActualWidth) - 120, 170, 0.5f, 0.0f, 0.0f, "Courier New", 12.0f, string.Format("{0:e3} Pa", max));
                    gl.DrawText((int)(PressureCanvas_inPlot.ActualWidth) - 120, 150, 1.0f, 0.0f, 0.0f, "Courier New", 12.0f, string.Format("{0:e3} Pa", (7.0 * max + min) / 8.0));
                    gl.DrawText((int)(PressureCanvas_inPlot.ActualWidth) - 120, 130, 1.0f, 0.5f, 0.0f, "Courier New", 12.0f, string.Format("{0:e3} Pa", (6.0 * max + min) / 8.0));
                    gl.DrawText((int)(PressureCanvas_inPlot.ActualWidth) - 120, 110, 1.0f, 1.0f, 0.0f, "Courier New", 12.0f, string.Format("{0:e3} Pa", (5.0 * max + min) / 8.0));
                    gl.DrawText((int)(PressureCanvas_inPlot.ActualWidth) - 120, 90, 0.5f, 1.0f, 0.0f, "Courier New", 12.0f, string.Format("{0:e3} Pa", (4.0 * max + min) / 8.0));
                    gl.DrawText((int)(PressureCanvas_inPlot.ActualWidth) - 120, 70, 0.0f, 1.0f, 1.0f, "Courier New", 12.0f, string.Format("{0:e3} Pa", (3.0 * max + min) / 8.0));
                    gl.DrawText((int)(PressureCanvas_inPlot.ActualWidth) - 120, 50, 0.0f, 0.5f, 1.0f, "Courier New", 12.0f, string.Format("{0:e3} Pa", (2.0 * max + min) / 8.0));
                    gl.DrawText((int)(PressureCanvas_inPlot.ActualWidth) - 120, 30, 0.0f, 0.0f, 1.0f, "Courier New", 12.0f, string.Format("{0:e3} Pa", (1.0 * max + min) / 8.0));
                    gl.DrawText((int)(PressureCanvas_inPlot.ActualWidth) - 120, 10, 0.0f, 0.0f, 0.5f, "Courier New", 12.0f, string.Format("{0:e3} Pa", min));
                }
            }
        }

        private void ProcessRotating()
        {
            ViewModels.MeshAndPressurePlotViewModel vm = DataContext as ViewModels.MeshAndPressurePlotViewModel;

            if (vm.isRClicked)
            {
                ArcBall.Matrix3DSetIdentity(ref LastRot);
                ArcBall.Matrix3DSetIdentity(ref ThisRot);
                ArcBall.Matrix4DSetRotationFromMatrix3D(ref transform, ThisRot);
            }

            if (!dragging)
            {
                if (vm.isLClicked)
                {
                    dragging = true;
                    LastRot = ThisRot;
                    Vector2D MousePt = new Vector2D();
                    MousePt.X = vm.CursorX;
                    MousePt.Y = vm.CursorY;
                    ArcBall.click(MousePt);
                }
            }
            else
            {
                if (vm.isLClicked)
                {
                    Vector4D ThisQuat = new Vector4D();
                    Vector2D MousePt = new Vector2D();
                    MousePt.X = vm.CursorX;
                    MousePt.Y = vm.CursorY;
                    ArcBall.drag(MousePt, ref ThisQuat);
                    ArcBall.Matrix3DSetRotationFromVector4D(ref ThisRot, ThisQuat);
                    ArcBall.Matrix3DMulMatrix3D(ref ThisRot, ThisRot, LastRot);
                    ArcBall.Matrix4DSetRotationFromMatrix3D(ref transform, ThisRot);
                }
                else
                {
                    dragging = false;
                }
            }
        }

        private void OpenGLControl_OpenGLDraw(object sender, SharpGL.SceneGraph.OpenGLEventArgs args)
        {
            //  Get the OpenGL instance that's been passed to us.
            OpenGL gl = args.OpenGL;

            //  Clear the color and depth buffers.
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            gl.LoadIdentity();
            
            ViewModels.MeshAndPressurePlotViewModel vm = DataContext as ViewModels.MeshAndPressurePlotViewModel;
            if (null == vm)
                return;

            #region Translating

            gl.Translate(vm.x, vm.y + 3.0, vm.z);

            #endregion

            gl.Rotate(-70.0f, 1.0f, 0.0f, 0.0f);    // initial view angle

            gl.PushMatrix();

            #region Rotating

            ProcessRotating();
            if (null != transform)
                gl.MultMatrix(transform);

            #endregion

            DrawScene(gl);

            gl.PopMatrix();
            gl.Flush();
        }

        private void ProcessRotating_p()
        {
            ViewModels.MeshAndPressurePlotViewModel vm = DataContext as ViewModels.MeshAndPressurePlotViewModel;

            if (vm.isRClicked_p)
            {
                ArcBall.Matrix3DSetIdentity(ref LastRot_p);
                ArcBall.Matrix3DSetIdentity(ref ThisRot_p);
                ArcBall.Matrix4DSetRotationFromMatrix3D(ref transform_p, ThisRot_p);
            }

            if (!dragging_p)
            {
                if (vm.isLClicked_p)
                {
                    dragging_p = true;
                    LastRot_p = ThisRot_p;
                    Vector2D MousePt = new Vector2D();
                    MousePt.X = vm.CursorX_p;
                    MousePt.Y = vm.CursorY_p;
                    ArcBall_p.click(MousePt);
                }
            }
            else
            {
                if (vm.isLClicked_p)
                {
                    Vector4D ThisQuat = new Vector4D();
                    Vector2D MousePt = new Vector2D();
                    MousePt.X = vm.CursorX_p;
                    MousePt.Y = vm.CursorY_p;
                    ArcBall_p.drag(MousePt, ref ThisQuat);
                    ArcBall.Matrix3DSetRotationFromVector4D(ref ThisRot_p, ThisQuat);
                    ArcBall.Matrix3DMulMatrix3D(ref ThisRot_p, ThisRot_p, LastRot_p);
                    ArcBall.Matrix4DSetRotationFromMatrix3D(ref transform_p, ThisRot_p);
                }
                else
                {
                    dragging_p = false;
                }
            }
        }

        private void OpenGLControl_OpenGLDraw_p(object sender, SharpGL.SceneGraph.OpenGLEventArgs args)
        {
            //  Get the OpenGL instance that's been passed to us.
            OpenGL gl = args.OpenGL;

            //  Clear the color and depth buffers.
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            gl.LoadIdentity();
            
            ViewModels.MeshAndPressurePlotViewModel vm = DataContext as ViewModels.MeshAndPressurePlotViewModel;
            if (null == vm)
                return;

            #region Translating

            gl.Translate(vm.x_p, vm.y_p + 3.0, vm.z_p);

            #endregion

            gl.Rotate(-70.0f, 1.0f, 0.0f, 0.0f);    // initial view angle

            gl.PushMatrix();

            #region Rotating

            ProcessRotating_p();
            if (null != transform_p)
                gl.MultMatrix(transform_p);

            #endregion

            DrawScene_p(gl);
            DrawScene_plegend(gl);

            gl.PopMatrix();
            gl.Flush();
        }

        private bool ready
        {
            get
            {
                bool bReady = false;
                ViewModels.MeshAndPressurePlotViewModel vm = DataContext as ViewModels.MeshAndPressurePlotViewModel;
                if (null != vm && null != vm.Data)
                {
                    int nPart = vm.Data.MainData.PartCount;

                    for (int i = 0; i < nPart; ++i)
                    {
                        Models.MeshDisplayData data = vm.Data.MainData.PartList[i].MeshDisplayData;
                        if (null == data || 1 > data.Row * data.Column)
                            return false;
                    }

                    bReady = true;
                }

                return bReady;
            }
        }

        private bool ready_p
        {
            get
            {
                bool bReady = false;
                ViewModels.MeshAndPressurePlotViewModel vm = DataContext as ViewModels.MeshAndPressurePlotViewModel;
                if (null != vm && null != vm.Data)
                {
                    int nPart = vm.Data.MainData.PartCount;

                    for (int i = 0; i < nPart; ++i)
                    {
                        Models.PressureDisplayData data = vm.Data.MainData.PartList[i].PressureDisplayData;
                        if (null == data || null == data.p || 1 > data.p.Length)
                            return false;
                    }

                    bReady = true;
                }

                return bReady;
            }
        }

        private void OpenGLControl_MouseEnter(object sender, MouseEventArgs e)
        {
            ViewModels.MeshAndPressurePlotViewModel vm = DataContext as ViewModels.MeshAndPressurePlotViewModel;
            if (null != vm)
                vm.ActiveMeshView = MeshCanvas_inPlot;
        }

        private void OpenGLControl_MouseLeave(object sender, MouseEventArgs e)
        {
            ViewModels.MeshAndPressurePlotViewModel vm = DataContext as ViewModels.MeshAndPressurePlotViewModel;
            if (null != vm)
                vm.ActiveMeshView = null;
        }

        private void MeshCanvas_inPlot_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            ArcBall.setBounds(e.NewSize.Width, e.NewSize.Height);
        }

        private void OpenGLControl_MouseEnter_p(object sender, MouseEventArgs e)
        {
            ViewModels.MeshAndPressurePlotViewModel vm = DataContext as ViewModels.MeshAndPressurePlotViewModel;
            if (null != vm)
                vm.ActivePressureView = PressureCanvas_inPlot;
        }

        private void OpenGLControl_MouseLeave_p(object sender, MouseEventArgs e)
        {
            ViewModels.MeshAndPressurePlotViewModel vm = DataContext as ViewModels.MeshAndPressurePlotViewModel;
            if (null != vm)
                vm.ActivePressureView = null;
        }

        private void PressureCanvas_inPlot_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            ArcBall_p.setBounds(e.NewSize.Width, e.NewSize.Height);
        }

        ArcBall ArcBall;
        Matrix3D LastRot;
        Matrix3D ThisRot;
        double[] transform;
        bool dragging;

        ArcBall ArcBall_p;
        Matrix3D LastRot_p;
        Matrix3D ThisRot_p;
        double[] transform_p;
        bool dragging_p;
    }
}
