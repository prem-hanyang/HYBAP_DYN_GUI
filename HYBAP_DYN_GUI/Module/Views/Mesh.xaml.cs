using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Threading;
using SharpGL;
using Module.Models;

namespace Module.Views
{
    /// <summary>
    /// Mesh.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Mesh : UserControl
    {
        public Mesh()
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

            //IntPtr quadratic = gl.NewQuadric();
            //gl.QuadricNormals(quadratic, OpenGL.GLU_SMOOTH);
            //gl.QuadricTexture(quadratic, (int)OpenGL.GL_TRUE);

            gl.Enable(OpenGL.GL_LIGHT0);
            gl.Enable(OpenGL.GL_COLOR_MATERIAL);
        }

        private void OpenGLControl_MouseEnter(object sender, MouseEventArgs e)
        {
            ViewModels.MeshViewModel vm = DataContext as ViewModels.MeshViewModel;
            if (null != vm)
                vm.ActiveView = MeshCanvas;
        }

        private void OpenGLControl_MouseLeave(object sender, MouseEventArgs e)
        {
            ViewModels.MeshViewModel vm = DataContext as ViewModels.MeshViewModel;
            if (null != vm)
                vm.ActiveView = null;
        }

        private void MeshCanvas_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            ArcBall.setBounds(e.NewSize.Width, e.NewSize.Height);
        }

        private void DrawScene(OpenGL gl)
        {
            if (ready)
            {
                ViewModels.MeshViewModel vm = DataContext as ViewModels.MeshViewModel;
                if (null != vm)
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

        private void ProcessRotating()
        {
            ViewModels.MeshViewModel vm = DataContext as ViewModels.MeshViewModel;

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

            ViewModels.MeshViewModel vm = DataContext as ViewModels.MeshViewModel;
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += (o, ea) =>
                {
                    ViewModels.MeshViewModel vm = null;
                    Dispatcher.Invoke((Action)(() =>
                        {
                            vm = DataContext as ViewModels.MeshViewModel;
                        }
                    ));

                    if (null != vm && null != vm.Data)
                    {
                        //MeshInfo output = new MeshInfo();
                        if (MeshHelper.MeshExecute(vm.RootDirectory, vm.Data/*, output*/))
                        {
                            if (false == MeshHelper.ReadMeshResult(vm.RootDirectory, vm.Data))
                                MessageBox.Show("Fail to mesh.");
                        }
                    }
                };
            bw.RunWorkerCompleted += (o, ea) =>
                {
                    ViewModels.MeshViewModel vm = null;
                    Dispatcher.Invoke((Action)(() =>
                    {
                        vm = DataContext as ViewModels.MeshViewModel;
                    }
                    ));
                    vm.IsBusy = false;
                    CommandManager.InvalidateRequerySuggested();
                };

            ViewModels.MeshViewModel _vm = DataContext as ViewModels.MeshViewModel;
            _vm.IsBusy = true;
            bw.RunWorkerAsync();
        }

        private bool ready
        {
            get
            {
                bool bReady = false;
                ViewModels.MeshViewModel vm = DataContext as ViewModels.MeshViewModel;
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

        ArcBall ArcBall;
        Matrix3D LastRot;
        Matrix3D ThisRot;
        double[] transform;
        bool dragging;
    }
}
