using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Module.Models
{
    public static class SolvingHelper
    {
        public static bool SolvingExecute(string strRootDirectory, InputData input_data, ref ResultInfo output)
        {
            bool bSuccess = false;
            MeshInput_Proxy meshinput_proxy = new MeshInput_Proxy();
            MeshInfo_Proxy meshinfo_proxy = new MeshInfo_Proxy();
            AnalysisInfo_Proxy analysisinfo_proxy = new AnalysisInfo_Proxy();
            ResultInfo_Proxy resultinfo_proxy = new ResultInfo_Proxy();
            DAFULInfo_Proxy dafulinfo_proxy = new DAFULInfo_Proxy();

            string msg = string.Empty;
            if (!Marshal.ValidationCheck(input_data, ref msg))
            {
                System.Windows.MessageBox.Show(msg, "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                return false;
            }

            Marshal.GetMeshInputProxy(strRootDirectory, input_data, ref meshinput_proxy);
            Marshal.GetAnalysisInfoProxy(input_data.StaticAndDynamicAnalysisData, ref analysisinfo_proxy);

            dafulinfo_proxy.DLLInterface = false;
            if (true == (bSuccess = marshal_function.Mesh(ref meshinput_proxy, ref meshinfo_proxy, ref dafulinfo_proxy)))
                bSuccess = marshal_function.Solver(ref meshinput_proxy, ref meshinfo_proxy, ref analysisinfo_proxy, ref resultinfo_proxy, ref dafulinfo_proxy);

            if (bSuccess)
                output = Marshal.GetOutput(input_data.MainData.PartCount, ref resultinfo_proxy);

            Marshal.ReleaseInputProxy(ref meshinput_proxy);
            marshal_function.Free(ref meshinput_proxy, ref meshinfo_proxy, ref dafulinfo_proxy);
            marshal_function.SolverFree(ref resultinfo_proxy, ref dafulinfo_proxy);

            return bSuccess;
        }

        public static bool ReadPressureResult(string strRootDirectory, InputData input_data)
        {
            int nPart = input_data.MainData.PartCount;
            string path_p = string.Empty;

            for (int i = 0; i < nPart; ++i)
            {
                path_p = System.IO.Path.Combine(strRootDirectory, string.Format("Part_{0:D2}_p.dat", i + 1));
                int row = Marshal.line_row(path_p);
                System.Diagnostics.Debug.Assert(0 < row);
                if (0 == row)
                    return false;
                int num = Marshal.line_NodeNumber(path_p);
                int column = num / row;

                Models.PressureDisplayData data = new Models.PressureDisplayData();
                data.p = Marshal.Read(path_p);
                System.Diagnostics.Debug.Assert(null != data.p);
                System.Diagnostics.Debug.Assert(0 < data.p.Length);
                foreach (double val in data.p)
                {
                    if (data.max < val)
                        data.max = val;
                    if (data.min > val)
                        data.min = val;
                }
                input_data.MainData.PartList[i].PressureDisplayData = data;
            }

            return true;
        }

        private static marshal_function Marshal = new marshal_function();
    }
}
