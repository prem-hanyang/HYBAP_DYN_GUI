using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
//using System.Windows;

namespace Module.Models
{
    #region MeshInput

    [StructLayout(LayoutKind.Sequential)]
    public struct MainInfo_Proxy
    {
        public int PartCount;
        public double RPM;
        public double Tx;
        public double Ty;
        public double Viscosity;
        public double Theta_div;
        public double CavitationPressure;
        public int RC_flag;
        public int RCCount;
    }

    [StructLayout(LayoutKind.Sequential, CharSet=CharSet.Unicode)]
    public struct MeshInput_Proxy
    {
        public MainInfo_Proxy MainInfo;
        public IntPtr PartInfo;
        public IntPtr RecirInfo;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string RootDirectory;
    }

    #endregion

    #region MeshInfo

    [StructLayout(LayoutKind.Sequential)]
    public struct RecirNodeInfo_Proxy
    {
        public int RecirChannelNumber;
        public IntPtr RecirChannelNodeNumber;
        public IntPtr RecirChannelPart;
        public IntPtr RecirChannelNode;
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct MeshInfo_Proxy
    {
        public RecirNodeInfo_Proxy RecirNodeInfo;
        public IntPtr SectionID;
        public IntPtr NodeCount;
        public IntPtr ElementCount;

        public IntPtr x_global;
        public IntPtr z_global;
        public IntPtr part_ID_global;
        public IntPtr part_IEN_global;
        public IntPtr Gdiv_global;
        public IntPtr Rdiv_global;
        public IntPtr i_g_global;
        public IntPtr H0_global;
        public IntPtr u0_global;
    };

    #endregion

    #region AnalysisInfo

    [StructLayout(LayoutKind.Sequential)]
    public struct AnalysisInfo_Proxy
    {
        public int InternalBoundaryCondition;
        public double ToleranceOfReynoldsBC;
        public int SelectAnalysisCase;
    }

    #endregion

    #region ResultInfo

    [StructLayout(LayoutKind.Sequential)]
    public struct ResultMatrixInfo_Proxy
    {
        public double dummy;
        public double value1;
        public double value2;
        public double value3;
        public double value4;
        public double value5;
        public double value6;
        public double value7;
        public double value8;
        public double value9;
        public double value10;
        public double value11;
        public double value12;
        public double value13;
        public double value14;
        public double value15;
        public double value16;
        public double value17;
        public double value18;
        public double value19;
        public double value20;
        public double value21;
        public double value22;
        public double value23;
        public double value24;
        public double value25;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ResultInfo_Proxy
    {
        public IntPtr Friction;
        public IntPtr LoadCapacity;
        public IntPtr Stiffness;
        public IntPtr Damping;
        public ResultMatrixInfo_Proxy Total_Stiffness;
        public ResultMatrixInfo_Proxy Total_Damping;
        public double Total_Friction;
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct DAFULInfo_Proxy
    {
        public bool DLLInterface;
        public int PartCount;
        public double RPM;
        public IntPtr NodeCount;
        public IntPtr ElementCount;
        public IntPtr Geo_X;
        public IntPtr Geo_Y;
        public IntPtr Geo_Z;
        public IntPtr FilmThickness;
        public IntPtr Force;
        public IntPtr Friction;
        public IntPtr NodeForce;
    };

    #endregion

    internal class marshal_function
    {
        [DllImport("HYBAPMesh.dll", CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool Mesh(ref MeshInput_Proxy input, ref MeshInfo_Proxy output, ref DAFULInfo_Proxy outputDF);

        [DllImport("HYBAPMesh.dll", CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool Free(ref MeshInput_Proxy input, ref MeshInfo_Proxy output, ref DAFULInfo_Proxy outputDF);

        [DllImport("HYBAPSolver.dll", CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool Solver(ref MeshInput_Proxy input_param, ref MeshInfo_Proxy mesh_param, ref AnalysisInfo_Proxy analysis_param, ref ResultInfo_Proxy result_param, ref DAFULInfo_Proxy daful_param);

        [DllImport("HYBAPSolver.dll", CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SolverFree(ref ResultInfo_Proxy result_param, ref DAFULInfo_Proxy daful_param);

        public marshal_function()
        {
        }

        protected bool AtLeastOne(int value, string name, ref string msg)
        {
            if (1 > value)
            {
                msg = string.Format(" {0} should be at least one.", name);
                return false;
            }
            return true;
        }

        protected bool GreaterThanZero(double value, string name, ref string msg)
        {
            if (0.0 >= value)
            {
                msg = string.Format(" {0} should be greater than zero.", name);
                return false;
            }
            return true;
        }

        protected bool Connection_check(List<List<List<int>>> con_check, int N_part, List<int> type_ind, ref string msg)
        {
            int i, k;

            for (k = 1; k <= N_part; k++)
            {

                for (i = 1; i <= 2; i++)
                {
                    if (con_check[k][i][1] != 0 && con_check[k][i][1] != -1)
                    {
                        switch (con_check[k][i][2])
                        {
                            case 1:
                                if (con_check[con_check[k][i][1]][2][1] != k)
                                {
                                    msg = string.Format(" Check the connection of the part {0}", k);
                                    return false;
                                }
                                break;
                            case 2:
                                if (con_check[con_check[k][i][1]][1][1] != k)
                                {
                                    msg = string.Format(" Check the connection of the part {0}", k);
                                    return false;
                                }
                                break;
                        }
                    }
                }
            }

            for (k = 1; k <= N_part; k++)
            {
                for (i = 1; i <= 2; i++)
                {
                    if (con_check[k][i][1] != 0 && con_check[k][i][1] != -1)
                    {
                        if (type_ind[k] == 2 || type_ind[k] == 4)
                        {
                            if (type_ind[con_check[k][i][1]] == 2 || type_ind[con_check[k][i][1]] == 4)
                            {
                                msg = " Check the connection.";
                                msg += System.Environment.NewLine;
                                msg += string.Format(" Part {0} and part {1} are grooved sections", k, con_check[k][i][1]);
                                msg += System.Environment.NewLine;
                                msg += " The grooved sections can't be connected with other grooved section.";
                                return false;
                            }
                        }
                    }
                }
            }

            return true;
        }

        protected bool Part_A_is_larger_than_B(int part, double a_value, double b_value, string a_name, string b_name, ref string msg)
        {
			if (b_value >= a_value)
            {
                msg = string.Format(" >>>>>Part [{0}]  warning!! <<<<<", part);
                msg += System.Environment.NewLine;
                msg += string.Format(" {0} ({1}) is invalid value.", a_name, a_value);
                msg += System.Environment.NewLine;
                msg += string.Format(" {0} should be larger than {1}.", a_name, b_name);
                return false;
			}
            return true;
        }

        protected bool Part_A_is_equal_to_or_larger_than_B(int part, double a_value, double b_value, string a_name, string b_name, ref string msg)
        {
            if (b_value > a_value)
            {
                msg = string.Format(" >>>>>Part [{0}]  warning!! <<<<<", part);
                msg += System.Environment.NewLine;
                msg += string.Format(" {0} ({1}) is invalid value.", a_name, a_value);
                msg += System.Environment.NewLine;
                msg += string.Format(" {0} should be equal to or larger than {1}.", a_name, b_name);
                return false;
            }
            return true;
        }

        protected bool Part_A_is_same_with_B(int part, double a_value, double b_value, string a_name, string b_name, ref string msg)
        {
            if (b_value != a_value)
            {
                msg = string.Format(" >>>>>Part [{0}]  warning!! <<<<<", part);
                msg += System.Environment.NewLine;
                msg += string.Format(" {0} ({1}) is invalid value.", a_name, a_value);
                msg += System.Environment.NewLine;
                msg += string.Format(" {0} should be same with {1}.", a_name, b_name);
                return false;
            }
            return true;
        }

        protected bool Part_Positive(int part, double value, string name, ref string msg)
        {
            if (0 >= value)
            {
                msg = string.Format(" >>>>>Part [{0}]  warning!! <<<<<", part);
                msg += System.Environment.NewLine;
                msg += string.Format(" {0} ({1}) is invalid value.", name, value);
                msg += string.Format(" {0} should be positive value.", name);
                return false;
            }
            return true;
        }

        protected bool Part_Zero_or_Positive(int part, double value, string name, ref string msg)
        {
            if (0 > value)
            {
                msg = string.Format(" >>>>>Part [{0}]  warning!! <<<<<", part);
                msg += System.Environment.NewLine;
                msg += string.Format(" {0} ({1}) is invalid value.", name, value);
                msg += string.Format(" {0} should be zero or positive value.", name);
                return false;
            }
            return true;
        }

        public bool ValidationCheck(InputData data, ref string msg)
        {
            if (!AtLeastOne(data.MainData.PartCount, "Total number of parts", ref msg))
                return false;

            if (!GreaterThanZero(data.MainData.DesignParameter.Viscosity, "The viscosity value", ref msg))
                return false;
            
            if (!AtLeastOne(data.MainData.DesignParameter.NumberOfTotalDivision, "The number of total division in circumferential direction", ref msg))
                return false;

            List<List<List<int>>> con_check = new List<List<List<int>>>();
            con_check.Add(new List<List<int>>());
            for (int i = 1; i <= data.MainData.PartCount; ++i)
            {
                con_check.Add(new List<List<int>>());
                for (int j = 0; j < 3; ++j)
                {
                    con_check[i].Add(new List<int>());
                    for (int k = 0; k < 3; ++k)
                        con_check[i][j].Add(0);
                }
            }
            List<int> type_ind = new List<int>();
            type_ind.Add(0);
            for (int i = 1; i <= data.MainData.PartCount; ++i)
            {
                type_ind.Add(data.MainData.PartList[i - 1].BearingType);
                switch (type_ind[i])
                {
                    case 1:
                        {
                            PartPropertyPlainJournal prop1 = (data.MainData.PartList[i - 1].Property as PartPropertyPlainJournal);
                            con_check[i][1][1] = prop1.ConnectingPartOfUpper;
                            con_check[i][1][2] = prop1.ConnectingPositionOfUpper;
                            con_check[i][2][1] = prop1.ConnectingPartOfLower;
                            con_check[i][2][2] = prop1.ConnectingPositionOfLower;
                        }
                        break;
                    case 2:
                        {
                            PartPropertyGroovedJournal prop2 = (data.MainData.PartList[i - 1].Property as PartPropertyGroovedJournal);
                            con_check[i][1][1] = prop2.ConnectingPartOfUpper;
                            con_check[i][1][2] = prop2.ConnectingPositionOfUpper;
                            con_check[i][2][1] = prop2.ConnectingPartOfLower;
                            con_check[i][2][2] = prop2.ConnectingPositionOfLower;
                        }
                        break;
                    case 3:
                        {
                            PartPropertyPlainThrustClosedEnd prop3 = (data.MainData.PartList[i - 1].Property as PartPropertyPlainThrustClosedEnd);
                            con_check[i][1][1] = prop3.ConnectingPartOfUpper;
                            con_check[i][1][2] = prop3.ConnectingPositionOfUpper;
                            con_check[i][2][1] = prop3.ConnectingPartOfLower;
                            con_check[i][2][2] = prop3.ConnectingPositionOfLower;
                        }
                        break;
                    case 4:
                        {
                            PartPropertyGroovedThrustDonut prop4 = (data.MainData.PartList[i - 1].Property as PartPropertyGroovedThrustDonut);
                            con_check[i][1][1] = prop4.ConnectingPartOfUpper;
                            con_check[i][1][2] = prop4.ConnectingPositionOfUpper;
                            con_check[i][2][1] = prop4.ConnectingPartOfLower;
                            con_check[i][2][2] = prop4.ConnectingPositionOfLower;
                        }
                        break;
                    case 5:
                        {
                            PartPropertyPlainThrustDonut prop5 = (data.MainData.PartList[i - 1].Property as PartPropertyPlainThrustDonut);
                            con_check[i][1][1] = prop5.ConnectingPartOfUpper;
                            con_check[i][1][2] = prop5.ConnectingPositionOfUpper;
                            con_check[i][2][1] = prop5.ConnectingPartOfLower;
                            con_check[i][2][2] = prop5.ConnectingPositionOfLower;

                        }
                        break;
                }
            }
            if (!Connection_check(con_check, data.MainData.PartCount, type_ind, ref msg))
                return false;

            for (int i = 1; i <= data.MainData.PartCount; ++i)
            {
                switch (data.MainData.PartList[i - 1].BearingType)
                {
                    #region Case 1
                    case 1:
                    {
                        PartPropertyPlainJournal prop1 = (data.MainData.PartList[i - 1].Property as PartPropertyPlainJournal);

                        if (!Part_A_is_larger_than_B(i, prop1.RadiusOfJournal, prop1.ClearanceOfJournal, "Radius of journal bearing", "Clearance of journal bearing", ref msg))
                            return false;

                        if (!Part_A_is_larger_than_B(i, prop1.RadiusOfJournal, prop1.ReservoirDepth, "Radius of journal bearing", "Reservoir depth", ref msg))
                            return false;
                        
                        if(prop1.EccentricityRatio < 0 || prop1.EccentricityRatio >= 1)
                        {
                            msg = string.Format(" >>>>>Part [{0}]  warning!! <<<<<", i);
                            msg += System.Environment.NewLine;
                            msg += string.Format(" Eccentricity ratio ({0}) is invalid value", prop1.EccentricityRatio);
                            msg += System.Environment.NewLine;
                            msg += " Eccentricity ratio should have a value between 0 and 1. (not allow 1)";
                            return false;
                        }

                        if (!Part_A_is_equal_to_or_larger_than_B(i, prop1.NumberOfZDivisionOfLower, 2, "Number of z-division of loewr part", "2", ref msg))
                            return false;

                        if (!Part_A_is_equal_to_or_larger_than_B(i, prop1.NumberOfZDivisionOfUpper, 2, "Number of z-division of upper part", "2", ref msg))
                            return false;

                        if (!Part_A_is_equal_to_or_larger_than_B(i, prop1.ClearanceOfJournal, prop1.RoughnessOfRotatingPart, "Clearance of journal bearing", "Roughness of rotating part", ref msg))
                            return false;

                        if (!Part_A_is_equal_to_or_larger_than_B(i, prop1.ClearanceOfJournal, prop1.RoughnessOfStationaryPart, "Clearance of journal bearing", "Roughness of stationary part", ref msg))
                            return false;

                        if (!Part_Positive(i, prop1.RadiusOfJournal, "Radius of journal bearing", ref msg))
                            return false;

                        if (!Part_Positive(i, prop1.ClearanceOfJournal, "Clearance of journal bearing", ref msg))
                            return false;

                        if (!Part_Zero_or_Positive(i, prop1.LengthCenterLower, "Length from center line to lower boundary", ref msg))
                            return false;

                        if (!Part_Zero_or_Positive(i, prop1.LengthCenterUpper, "Length from center line to upper boundary", ref msg))
                            return false;

                        if (!Part_Zero_or_Positive(i, prop1.ReservoirDepth, "Reservoir depth", ref msg))
                            return false;

                        if (!Part_Zero_or_Positive(i, prop1.RoughnessOfRotatingPart, "Roughness of rotating part", ref msg))
                            return false;

                        if (!Part_Zero_or_Positive(i, prop1.RoughnessOfStationaryPart, "Roughness of stationary part", ref msg))
                            return false;
                        break;
                    }
                    #endregion
                    #region Case 2
                    case 2:
                    {
                        PartPropertyGroovedJournal prop2 = (data.MainData.PartList[i - 1].Property as PartPropertyGroovedJournal);	

				        if(0 == prop2.NumberOfAdditionalGrooves)
				        {
					        if (data.MainData.DesignParameter.NumberOfTotalDivision !=
					            prop2.NumberOfGrooves * (prop2.NumberOfXDivisionOfGroove + prop2.NumberOfXDivisionOfRidge) )
					        {
                                msg = string.Format(" >>>>>Part [{0}]  warning!! <<<<<", i);
                                msg += System.Environment.NewLine;
                                msg += " Check the number of total division in circumferential direction value at Main page.";
                                msg += System.Environment.NewLine;
                                msg += " Number of total division in circumferential direction";
                                msg += System.Environment.NewLine;
                                msg += "  = Number of grooves * (Number of x-division of groove + Number of x-division of ridge)";
                                return false;
					        }
				        }
				        else 
				        {
                            if (!Part_A_is_same_with_B(i, prop2.NumberOfAdditionalGrooves, prop2.NumberOfGrooves, "Number of additional grooves", "Number of grooves", ref msg))
                                return false;

                            if (Part_A_is_larger_than_B(i, prop2.LengthCenterUpper, prop2.LengthOfAdditionalGroove, "Length from center line to upper boundary", "Length of the additional grooves", ref msg))
                                return false;

                            if (prop2.RatioOfGrooveToRidgeInAdditionalGroove < 0 || prop2.RatioOfGrooveToRidgeInAdditionalGroove > 1)
                            {
                                msg = string.Format(" >>>>>Part [{0}]  warning!! <<<<<", i);
                                msg += System.Environment.NewLine;
                                msg += string.Format(" Ratio of groove to ridge in additional groove ({0}) is invalid value", prop2.RatioOfGrooveToRidgeInAdditionalGroove);
                                msg += System.Environment.NewLine;
                                msg += " Ratio of groove to ridge in additional groove should have a value between 0 and 1.";
                                return false;
                            }

                            if (Part_A_is_larger_than_B(i, prop2.NumberOfZDivisionOfUpper, prop2.NumberOfZDivisionOfAdditionalGroove, "Number of z-division of additional groove", "Number of z-division of upper part in additional groove", ref msg))
                                return false;

					        if ((prop2.NumberOfXDivisionOfGroove + prop2.NumberOfXDivisionOfRidge) != 
						        (prop2.NumberOfXDivisionOfAdditionalGroove + prop2.NumberOfXDivisionOfAdditionalRidge))
					        {
                                msg = string.Format(" >>>>>Part [{0}]  warning!! <<<<<", i);
                                msg += System.Environment.NewLine;
                                msg += " Check the number of x-division of groove and ridge.";
                                msg += System.Environment.NewLine;
                                msg += " (Number of x-division of groove + Number of x-division of ridge)";
                                msg += System.Environment.NewLine;
                                msg += "  = (Number of x-division of additional groove + Number of x-division of additional ridge)";
                                return false;
					        }

                            if (data.MainData.DesignParameter.NumberOfTotalDivision !=
                                (prop2.NumberOfGrooves * (prop2.NumberOfXDivisionOfGroove + prop2.NumberOfXDivisionOfRidge) +
                                prop2.NumberOfAdditionalGrooves * (prop2.NumberOfXDivisionOfAdditionalGroove + prop2.NumberOfXDivisionOfAdditionalRidge)))
                            {
                                msg = string.Format(" >>>>>Part [{0}]  warning!! <<<<<", i);
                                msg += System.Environment.NewLine;
                                msg += " Check the number of total division in circumferential direction value at Main page.";
                                msg += System.Environment.NewLine;
                                msg += " Number of total division in circumferential direction";
                                msg += System.Environment.NewLine;
                                msg += "  = (Number of grooves * (Number of x-division of groove + Number of x-division of ridge)";
                                msg += System.Environment.NewLine;
                                msg += "   + Number of additional grooves * (Number of x-division of additional groove + Number of x-division of additional ridge))";
                                return false;
                            }
                        }

                        if (!Part_A_is_larger_than_B(i, prop2.RadiusOfJournal, prop2.ClearanceOfJournal, "Radius of journal bearing", "Clearance of journal bearing", ref msg))
                            return false;

                        if (!Part_A_is_equal_to_or_larger_than_B(i, prop2.NumberOfGrooves, 2, "Number of grooves", "2", ref msg))
                            return false;

                        if (prop2.GrooveAngle < 0.0 || prop2.GrooveAngle > 90.0)
                        {
                            msg = string.Format(" >>>>>Part [{0}]  warning!! <<<<<", i);
                            msg += System.Environment.NewLine;
                            msg += string.Format(" Groove angle ({0}) is invalid value", prop2.GrooveAngle);
                            msg += System.Environment.NewLine;
                            msg += " Groove angle should have a value between 0 and 90.";
                            return false;
                        }

                        if (!Part_A_is_larger_than_B(i, prop2.RadiusOfJournal, prop2.GrooveDepth, "Radius of journal bearing", "Groove depth", ref msg))
                            return false;

                        if (prop2.RatioOfGrooveToRidge < 0 || prop2.RatioOfGrooveToRidge > 1)
                        {
                            msg = string.Format(" >>>>>Part [{0}]  warning!! <<<<<", i);
                            msg += System.Environment.NewLine;
                            msg += string.Format(" Ratio of groove to ridge ({0}) is invalid value", prop2.RatioOfGrooveToRidge);
                            msg += System.Environment.NewLine;
                            msg += " Ratio of groove to ridge should have a value between 0 and 1.";
                            return false;
                        }

                        if (prop2.EccentricityRatio < 0 || prop2.EccentricityRatio >= 1)
                        {
                            msg = string.Format(" >>>>>Part [{0}]  warning!! <<<<<", i);
                            msg += System.Environment.NewLine;
                            msg += string.Format(" Eccentricity ratio ({0}) is invalid value", prop2.EccentricityRatio);
                            msg += System.Environment.NewLine;
                            msg += " Eccentricity ratio should have a value between 0 and 1. (not allow 1)";
                            return false;
                        }

                        if (!Part_A_is_equal_to_or_larger_than_B(i, prop2.NumberOfZDivisionOfLower, 2, "Number of z-division of loewr part", "2", ref msg))
                            return false;

                        if (!Part_A_is_equal_to_or_larger_than_B(i, prop2.NumberOfZDivisionOfUpper, 2, "Number of z-division of upper part", "2", ref msg))
                            return false;

                        if (!Part_A_is_equal_to_or_larger_than_B(i, prop2.NumberOfXDivisionOfGroove, 2, "Number of x-division of groove", "2", ref msg))
                            return false;

                        if (!Part_A_is_equal_to_or_larger_than_B(i, prop2.NumberOfXDivisionOfRidge, 2, "Number of x-division of ridge", "2", ref msg))
                            return false;

                        if (!Part_A_is_equal_to_or_larger_than_B(i, prop2.ClearanceOfJournal, prop2.RoughnessOfRotatingPart, "Clearance of journal bearing", "Roughness of rotating part", ref msg))
                            return false;

                        if (!Part_A_is_equal_to_or_larger_than_B(i, prop2.ClearanceOfJournal, prop2.RoughnessOfStationaryPart, "Clearance of journal bearing", "Roughness of stationary part", ref msg))
                            return false;

                        if (!Part_Positive(i, prop2.RadiusOfJournal, "Radius of journal bearing", ref msg))
                            return false;

                        if (!Part_Positive(i, prop2.ClearanceOfJournal, "Clearance of journal bearing", ref msg))
                            return false;

                        if (!Part_Zero_or_Positive(i, prop2.LengthCenterLower, "Length from center line to lower boundary", ref msg))
                            return false;

                        if (!Part_Zero_or_Positive(i, prop2.LengthCenterUpper, "Length from center line to upper boundary", ref msg))
                            return false;

                        if (!Part_Zero_or_Positive(i, prop2.GrooveDepth, "Groove depth", ref msg))
                            return false;

                        if (!Part_Zero_or_Positive(i, prop2.RoughnessOfRotatingPart, "Roughness of rotating part", ref msg))
                            return false;

                        if (!Part_Zero_or_Positive(i, prop2.RoughnessOfStationaryPart, "Roughness of stationary part", ref msg))
                            return false;
			            break;
                    }
                    #endregion
                    #region Case 3
                    case 3:
                    {
                        PartPropertyPlainThrustClosedEnd prop3 = (data.MainData.PartList[i - 1].Property as PartPropertyPlainThrustClosedEnd);

                        if (!Part_A_is_equal_to_or_larger_than_B(i, prop3.ClearanceOfThrust, prop3.ReservoirDepth, "Clearance of thrust bearing", "Reservoir depth", ref msg))
                            return false;

                        if (!Part_A_is_equal_to_or_larger_than_B(i, prop3.NumberOfRDivision, 2, "Number of r-division", "2", ref msg))
                            return false;

                        if (!Part_A_is_equal_to_or_larger_than_B(i, prop3.ClearanceOfThrust, prop3.RoughnessOfRotatingPart, "Clearance of thrust bearing", "Roughness of rotating part", ref msg))
                            return false;

                        if (!Part_A_is_equal_to_or_larger_than_B(i, prop3.ClearanceOfThrust, prop3.RoughnessOfStationaryPart, "Clearance of thrust bearing", "Roughness of stationary part", ref msg))
                            return false;

                        if (!Part_Positive(i, prop3.OuterRadiusOfThrust, "Outer radius of thrust bearing", ref msg))
                            return false;

                        if (!Part_Positive(i, prop3.ClearanceOfThrust, "Clearance of thrust bearing", ref msg))
                            return false;

                        if (!Part_Zero_or_Positive(i, prop3.ReservoirDepth, "Reservoir depth", ref msg))
                            return false;

                        if (!Part_Zero_or_Positive(i, prop3.RoughnessOfRotatingPart, "Roughness of rotating part", ref msg))
                            return false;

                        if (!Part_Zero_or_Positive(i, prop3.RoughnessOfStationaryPart, "Roughness of stationary part", ref msg))
                            return false;
                        break;
                    }
                    #endregion
                    #region Case 4
                    case 4:
                    {
                        PartPropertyGroovedThrustDonut prop4 = (data.MainData.PartList[i - 1].Property as PartPropertyGroovedThrustDonut);

                        if (data.MainData.DesignParameter.NumberOfTotalDivision !=
                                prop4.NumberOfGrooves * (prop4.NumberOfThetaDivisionOfGroove + prop4.NumberOfThetaDivisionOfRidge))
                        {
                            msg = string.Format(" >>>>>Part [{0}]  warning!! <<<<<", i);
                            msg += System.Environment.NewLine;
                            msg += " Check the number of total division in circumferential direction value at Main page.";
                            msg += System.Environment.NewLine;
                            msg += " Number of total division in circumferential direction";
                            msg += System.Environment.NewLine;
                            msg += "  = Number of grooves * (Number of theta-division of groove + Number of theta-division of ridge)";
                            return false;
                        }

                        //if (!Part_A_is_same_with_B(i, prop4.CenterRadiusOfThrust, (prop4.InnerRadiusOfThrust + prop4.OuterRadiusOfThrust) / 2, "Center radius of thrust bearing", "average of inner and outer radius of thrust bearing", ref msg))
                        //    return false;

                        if (!Part_A_is_larger_than_B(i, prop4.OuterRadiusOfThrust, prop4.InnerRadiusOfThrust, "Outer radius of thrust bearing", "Inner radius of thrust bearing", ref msg))
                            return false;

                        if (!Part_A_is_larger_than_B(i, prop4.OuterRadiusOfThrust, prop4.CenterRadiusOfThrust, "Outer radius of thrust bearing", "Center radius of thrust bearing", ref msg))
                            return false;

                        if (!Part_A_is_larger_than_B(i, prop4.CenterRadiusOfThrust, prop4.InnerRadiusOfThrust, "Center radius of thrust bearing", "Inner radius of thrust bearing", ref msg))
                            return false;

                        if (!Part_A_is_equal_to_or_larger_than_B(i, prop4.NumberOfGrooves, 2, "Number of grooves", "2", ref msg))
                            return false;

                        if (prop4.GrooveAngle < 0.0 || prop4.GrooveAngle > 90.0)
                        {
                            msg = string.Format(" >>>>>Part [{0}]  warning!! <<<<<", i);
                            msg += System.Environment.NewLine;
                            msg += string.Format(" Groove angle ({0}) is invalid value", prop4.GrooveAngle);
                            msg += System.Environment.NewLine;
                            msg += " Groove angle should have a value between 0 and 90.";
                            return false;
                        }

                        if (!Part_A_is_larger_than_B(i, prop4.OuterRadiusOfThrust, prop4.GrooveDepth, "Outer radius of thrust bearing", "Groove depth", ref msg))
                            return false;

                        if (!Part_A_is_equal_to_or_larger_than_B(i, prop4.ClearanceOfThrust, prop4.ReservoirDepth, "Clearance of thrust bearing", "Reservoir depth", ref msg))
                            return false;


                        if (prop4.RatioOfGrooveToRidge < 0 || prop4.RatioOfGrooveToRidge > 1)
                        {
                            msg = string.Format(" >>>>>Part [{0}]  warning!! <<<<<", i);
                            msg += System.Environment.NewLine;
                            msg += string.Format(" Ratio of groove to ridge ({0}) is invalid value", prop4.RatioOfGrooveToRidge);
                            msg += System.Environment.NewLine;
                            msg += " Ratio of groove to ridge should have a value between 0 and 1.";
                            return false;
                        }

                        if (!Part_A_is_equal_to_or_larger_than_B(i, prop4.NumberOfRDivisionOfInnerGroove, 2, "Number of r-division of inner groove region", "2", ref msg))
                            return false;
                        
                        if (!Part_A_is_equal_to_or_larger_than_B(i, prop4.NumberOfRDivisionOfOuterGroove, 2, "Number of r-division of outer groove region", "2", ref msg))
                            return false;

                        if (!Part_A_is_equal_to_or_larger_than_B(i, prop4.NumberOfThetaDivisionOfGroove, 2, "Number of theta-division of groove region", "2", ref msg))
                            return false;
                        
                        if (!Part_A_is_equal_to_or_larger_than_B(i, prop4.NumberOfThetaDivisionOfRidge, 2, "Number of theta-division of ridge region", "2", ref msg))
                            return false;

                        if (0 < prop4.WidthOfInnerPlain)
                        {
                            if (!Part_A_is_equal_to_or_larger_than_B(i, prop4.NumberOfRDivisionOfInnerPlain, 2, "Number of r-division of inner plain region", "2", ref msg))
                                return false;
                        }

                        if (0 < prop4.WidthOfOuterPlain)
                        {
                            if (!Part_A_is_equal_to_or_larger_than_B(i, prop4.NumberOfRDivisionOfOuterPlain, 2, "Number of r-division of outer plain region", "2", ref msg))
                                return false;
                        }

                        if (!Part_A_is_equal_to_or_larger_than_B(i, prop4.ClearanceOfThrust, prop4.RoughnessOfRotatingPart, "Clearance of thrust bearing", "Roughness of rotating part", ref msg))
                            return false;

                        if (!Part_A_is_equal_to_or_larger_than_B(i, prop4.ClearanceOfThrust, prop4.RoughnessOfStationaryPart, "Clearance of thrust bearing", "Roughness of stationary part", ref msg))
                            return false;

                        if (!Part_Positive(i, prop4.InnerRadiusOfThrust, "Inner radius of thrust bearing", ref msg))
                            return false;

                        if (!Part_Positive(i, prop4.CenterRadiusOfThrust, "Center radius of thrust bearing", ref msg))
                            return false;

                        if (!Part_Positive(i, prop4.OuterRadiusOfThrust, "Outer radius of thrust bearing", ref msg))
                            return false;

                        if (!Part_Zero_or_Positive(i, prop4.GrooveDepth, "Groove depth", ref msg))
                            return false;

                        if (!Part_Zero_or_Positive(i, prop4.ReservoirDepth, "Reservoir depth", ref msg))
                            return false;

                        if (!Part_Zero_or_Positive(i, prop4.WidthOfInnerPlain, "Width of inner plain in r-direction", ref msg))
                            return false;

                        if (!Part_Zero_or_Positive(i, prop4.WidthOfOuterPlain, "Width of outer plain in r-direction", ref msg))
                            return false;

                        if (!Part_Zero_or_Positive(i, prop4.DepthOfInnerPlain, "Depth of inner plain", ref msg))
                            return false;

                        if (!Part_Zero_or_Positive(i, prop4.DepthOfOuterPlain, "Depth of outer plain", ref msg))
                            return false;

                        if (!Part_Zero_or_Positive(i, prop4.RoughnessOfRotatingPart, "Roughness of rotating part", ref msg))
                            return false;

                        if (!Part_Zero_or_Positive(i, prop4.RoughnessOfStationaryPart, "Roughness of stationary part", ref msg))
                            return false;
                        break;
                    }
                    #endregion
                    #region Case 5
                    case 5:
                    {
                        PartPropertyPlainThrustDonut prop5 = (data.MainData.PartList[i - 1].Property as PartPropertyPlainThrustDonut);

                        if (!Part_A_is_larger_than_B(i, prop5.OuterRadiusOfThrust, prop5.InnerRadiusOfThrust, "Outer radius of thrust bearing", "Inner radius of thrust bearing", ref msg))
                            return false;

                        if (!Part_A_is_equal_to_or_larger_than_B(i, prop5.ClearanceOfThrust, prop5.ReservoirDepth, "Clearance of thrust bearing", "Reservoir depth", ref msg))
                            return false;

                        if (!Part_A_is_equal_to_or_larger_than_B(i, prop5.NumberOfRDivision, 2, "Number of r-division", "2", ref msg))
                            return false;

                        if (!Part_A_is_equal_to_or_larger_than_B(i, prop5.ClearanceOfThrust, prop5.RoughnessOfRotatingPart, "Clearance of thrust bearing", "Roughness of rotating part", ref msg))
                            return false;

                        if (!Part_A_is_equal_to_or_larger_than_B(i, prop5.ClearanceOfThrust, prop5.RoughnessOfStationaryPart, "Clearance of thrust bearing", "Roughness of stationary part", ref msg))
                            return false;

                        if (!Part_Positive(i, prop5.InnerRadiusOfThrust, "Inner radius of thrust bearing", ref msg))
                            return false;

                        if (!Part_Positive(i, prop5.OuterRadiusOfThrust, "Outer radius of thrust bearing", ref msg))
                            return false;

                        if (!Part_Zero_or_Positive(i, prop5.ReservoirDepth, "Reservoir depth", ref msg))
                            return false;

                        if (!Part_Zero_or_Positive(i, prop5.RoughnessOfRotatingPart, "Roughness of rotating part", ref msg))
                            return false;

                        if (!Part_Zero_or_Positive(i, prop5.RoughnessOfStationaryPart, "Roughness of stationary part", ref msg))
                            return false;
                        break;
                    }
                    #endregion
                }
            }

            return true;
        }

        public void GetMeshInputProxy(string strRootDirectory, InputData data, ref MeshInput_Proxy proxy)
        {
            #region Set MainInfo

            proxy.MainInfo.PartCount = data.MainData.PartCount;
            proxy.MainInfo.RPM = data.MainData.DesignParameter.RotatingSpeed;
            proxy.MainInfo.Tx = data.MainData.DesignParameter.MisalignmentAngleXaxis;
            proxy.MainInfo.Ty = data.MainData.DesignParameter.MisalignmentAngleYaxis;
            proxy.MainInfo.Viscosity = data.MainData.DesignParameter.Viscosity;
            proxy.MainInfo.Theta_div = data.MainData.DesignParameter.NumberOfTotalDivision;
            proxy.MainInfo.CavitationPressure = data.MainData.DesignParameter.CavitationPressure;
            proxy.MainInfo.RC_flag = data.MainData.DesignParameter.RecirculationChannelFlag;
            proxy.MainInfo.RCCount = data.RecirculationChannelData.NumberOfRecirculationChannel;
            proxy.RootDirectory = strRootDirectory;

            #endregion

            #region Set PartInfo

            double[] part = new double[31 * data.MainData.PartCount];

            for (int i = 0; i < proxy.MainInfo.PartCount; ++i)
            {
                switch (data.MainData.PartList[i].BearingType)
                {
                    case 1:
                        PartPropertyPlainJournal prop1 = (data.MainData.PartList[i].Property as PartPropertyPlainJournal);

                        part[31 * i + 0] = data.MainData.PartList[i].BearingType;
                        part[31 * i + 1] = 0.0;
                        part[31 * i + 2] = 0.0;
                        part[31 * i + 3] = 0.0;

                        part[31 * i + 4] = prop1.RadiusOfJournal;
                        part[31 * i + 5] = prop1.ClearanceOfJournal;
                        part[31 * i + 6] = prop1.LengthCenterLower;
                        part[31 * i + 7] = prop1.LengthCenterUpper;
                        part[31 * i + 8] = prop1.ZCoordinate;
                        part[31 * i + 9] = prop1.ReservoirDepth;
                        part[31 * i + 10] = prop1.EccentricityRatio;
                        part[31 * i + 11] = prop1.NumberOfZDivisionOfLower;
                        part[31 * i + 12] = prop1.NumberOfZDivisionOfUpper;
                        part[31 * i + 13] = prop1.ConnectingPartOfUpper;
                        part[31 * i + 14] = prop1.ConnectingPositionOfUpper;
                        part[31 * i + 15] = prop1.ConnectingPartOfLower;
                        part[31 * i + 16] = prop1.ConnectingPositionOfLower;
                        part[31 * i + 17] = 0.0;
                        part[31 * i + 18] = 0.0;
                        part[31 * i + 19] = 0.0;
                        part[31 * i + 20] = 0.0;
                        part[31 * i + 21] = 0.0;
                        part[31 * i + 22] = 0.0;
                        part[31 * i + 23] = 0.0;
                        part[31 * i + 24] = 0.0;
                        part[31 * i + 25] = 0.0;
                        part[31 * i + 26] = 0.0;
                        part[31 * i + 27] = 0.0;

                        part[31 * i + 28] = prop1.RoughnessOfRotatingPart;
                        part[31 * i + 29] = prop1.RoughnessOfStationaryPart;
                        part[31 * i + 30] = prop1.RoughnessPattern;
                        break;
                    case 2:
                        PartPropertyGroovedJournal prop2 = (data.MainData.PartList[i].Property as PartPropertyGroovedJournal);

                        part[31 * i + 0] = data.MainData.PartList[i].BearingType;
                        part[31 * i + 1] = data.MainData.PartList[i].GrooveLocation;
                        part[31 * i + 2] = data.MainData.PartList[i].PumpingDirection;
                        part[31 * i + 3] = 0.0;

                        part[31 * i + 4] = prop2.RadiusOfJournal;
                        part[31 * i + 5] = prop2.ClearanceOfJournal;
                        part[31 * i + 6] = prop2.LengthCenterLower;
                        part[31 * i + 7] = prop2.LengthCenterUpper;
                        part[31 * i + 8] = prop2.ZCoordinate;
                        part[31 * i + 9] = prop2.NumberOfGrooves;
                        part[31 * i + 10] = prop2.GrooveAngle;
                        part[31 * i + 11] = prop2.GrooveDepth;
                        part[31 * i + 12] = prop2.RatioOfGrooveToRidge;
                        part[31 * i + 13] = prop2.EccentricityRatio;
                        part[31 * i + 14] = prop2.NumberOfZDivisionOfLower;
                        part[31 * i + 15] = prop2.NumberOfZDivisionOfUpper;
                        part[31 * i + 16] = prop2.NumberOfXDivisionOfGroove;
                        part[31 * i + 17] = prop2.NumberOfXDivisionOfRidge;
                        part[31 * i + 18] = prop2.NumberOfAdditionalGrooves;
                        part[31 * i + 19] = prop2.LengthOfAdditionalGroove;
                        part[31 * i + 20] = prop2.RatioOfGrooveToRidgeInAdditionalGroove;
                        part[31 * i + 21] = prop2.NumberOfZDivisionOfAdditionalGroove;
                        part[31 * i + 22] = prop2.NumberOfXDivisionOfAdditionalGroove;
                        part[31 * i + 23] = prop2.NumberOfXDivisionOfAdditionalRidge;
                        part[31 * i + 24] = prop2.ConnectingPartOfUpper;
                        part[31 * i + 25] = prop2.ConnectingPositionOfUpper;
                        part[31 * i + 26] = prop2.ConnectingPartOfLower;
                        part[31 * i + 27] = prop2.ConnectingPositionOfLower;

                        part[31 * i + 28] = prop2.RoughnessOfRotatingPart;
                        part[31 * i + 29] = prop2.RoughnessOfStationaryPart;
                        part[31 * i + 30] = prop2.RoughnessPattern;
                        break;
                    case 3:
                        PartPropertyPlainThrustClosedEnd prop3 = (data.MainData.PartList[i].Property as PartPropertyPlainThrustClosedEnd);

                        part[31 * i + 0] = data.MainData.PartList[i].BearingType;
                        part[31 * i + 1] = 0.0;
                        part[31 * i + 2] = 0.0;
                        part[31 * i + 3] = 0.0;

                        part[31 * i + 4] = prop3.OuterRadiusOfThrust;
                        part[31 * i + 5] = prop3.ClearanceOfThrust;
                        part[31 * i + 6] = prop3.ZCoordinate;
                        part[31 * i + 7] = prop3.ReservoirDepth;
                        part[31 * i + 8] = prop3.NumberOfRDivision;
                        part[31 * i + 9] = prop3.ConnectingPartOfUpper;
                        part[31 * i + 10] = prop3.ConnectingPositionOfUpper;
                        part[31 * i + 11] = prop3.ConnectingPartOfLower;
                        part[31 * i + 12] = prop3.ConnectingPositionOfLower;
                        part[31 * i + 13] = 0.0;
                        part[31 * i + 14] = 0.0;
                        part[31 * i + 15] = 0.0;
                        part[31 * i + 16] = 0.0;
                        part[31 * i + 17] = 0.0;
                        part[31 * i + 18] = 0.0;
                        part[31 * i + 19] = 0.0;
                        part[31 * i + 20] = 0.0;
                        part[31 * i + 21] = 0.0;
                        part[31 * i + 22] = 0.0;
                        part[31 * i + 23] = 0.0;
                        part[31 * i + 24] = 0.0;
                        part[31 * i + 25] = 0.0;
                        part[31 * i + 26] = 0.0;
                        part[31 * i + 27] = 0.0;

                        part[31 * i + 28] = prop3.RoughnessOfRotatingPart;
                        part[31 * i + 29] = prop3.RoughnessOfStationaryPart;
                        part[31 * i + 30] = prop3.RoughnessPattern;
                        break;
                    case 4:
                        PartPropertyGroovedThrustDonut prop4 = (data.MainData.PartList[i].Property as PartPropertyGroovedThrustDonut);

                        part[31 * i + 0] = data.MainData.PartList[i].BearingType;
                        part[31 * i + 1] = data.MainData.PartList[i].GrooveLocation;
                        part[31 * i + 2] = data.MainData.PartList[i].PumpingDirection;
                        part[31 * i + 3] = data.MainData.PartList[i].GrooveType;

                        part[31 * i + 4] = prop4.InnerRadiusOfThrust;
                        part[31 * i + 5] = prop4.CenterRadiusOfThrust;
                        part[31 * i + 6] = prop4.OuterRadiusOfThrust;
                        part[31 * i + 7] = prop4.ClearanceOfThrust;
                        part[31 * i + 8] = prop4.ZCoordinate;
                        part[31 * i + 9] = prop4.NumberOfGrooves;
                        part[31 * i + 10] = prop4.GrooveAngle;
                        part[31 * i + 11] = prop4.GrooveDepth;
                        part[31 * i + 12] = prop4.ReservoirDepth;
                        part[31 * i + 13] = prop4.RatioOfGrooveToRidge;
                        part[31 * i + 14] = prop4.NumberOfRDivisionOfInnerGroove;
                        part[31 * i + 15] = prop4.NumberOfRDivisionOfOuterGroove;
                        part[31 * i + 16] = prop4.NumberOfThetaDivisionOfGroove;
                        part[31 * i + 17] = prop4.NumberOfThetaDivisionOfRidge;
                        part[31 * i + 18] = prop4.WidthOfInnerPlain;
                        part[31 * i + 19] = prop4.WidthOfOuterPlain;
                        part[31 * i + 20] = prop4.DepthOfInnerPlain;
                        part[31 * i + 21] = prop4.DepthOfOuterPlain;
                        part[31 * i + 22] = prop4.NumberOfRDivisionOfInnerPlain;
                        part[31 * i + 23] = prop4.NumberOfRDivisionOfOuterPlain;
                        part[31 * i + 24] = prop4.ConnectingPartOfUpper;
                        part[31 * i + 25] = prop4.ConnectingPositionOfUpper;
                        part[31 * i + 26] = prop4.ConnectingPartOfLower;
                        part[31 * i + 27] = prop4.ConnectingPositionOfLower;

                        part[31 * i + 28] = prop4.RoughnessOfRotatingPart;
                        part[31 * i + 29] = prop4.RoughnessOfStationaryPart;
                        part[31 * i + 30] = prop4.RoughnessPattern;
                        break;
                    case 5:
                        PartPropertyPlainThrustDonut prop5 = (data.MainData.PartList[i].Property as PartPropertyPlainThrustDonut);

                        part[31 * i + 0] = data.MainData.PartList[i].BearingType;
                        part[31 * i + 1] = 0.0;
                        part[31 * i + 2] = 0.0;
                        part[31 * i + 3] = 0.0;

                        part[31 * i + 4] = prop5.InnerRadiusOfThrust;
                        part[31 * i + 5] = prop5.OuterRadiusOfThrust;
                        part[31 * i + 6] = prop5.ClearanceOfThrust;
                        part[31 * i + 7] = prop5.ZCoordinate;
                        part[31 * i + 8] = prop5.ReservoirDepth;
                        part[31 * i + 9] = prop5.NumberOfRDivision;
                        part[31 * i + 10] = prop5.ConnectingPartOfUpper;
                        part[31 * i + 11] = prop5.ConnectingPositionOfUpper;
                        part[31 * i + 12] = prop5.ConnectingPartOfLower;
                        part[31 * i + 13] = prop5.ConnectingPositionOfLower;
                        part[31 * i + 14] = 0.0;
                        part[31 * i + 15] = 0.0;
                        part[31 * i + 16] = 0.0;
                        part[31 * i + 17] = 0.0;
                        part[31 * i + 18] = 0.0;
                        part[31 * i + 19] = 0.0;
                        part[31 * i + 20] = 0.0;
                        part[31 * i + 21] = 0.0;
                        part[31 * i + 22] = 0.0;
                        part[31 * i + 23] = 0.0;
                        part[31 * i + 24] = 0.0;
                        part[31 * i + 25] = 0.0;
                        part[31 * i + 26] = 0.0;
                        part[31 * i + 27] = 0.0;

                        part[31 * i + 28] = prop5.RoughnessOfRotatingPart;
                        part[31 * i + 29] = prop5.RoughnessOfStationaryPart;
                        part[31 * i + 30] = prop5.RoughnessPattern;
                        break;
                }
            }

            proxy.PartInfo = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(double)) * 31 * proxy.MainInfo.PartCount);
            Marshal.Copy(part, 0, proxy.PartInfo, part.Length);

            #endregion

            #region Set RecirInfo

            double[] rc = new double[17 * data.RecirculationChannelData.NumberOfRecirculationChannel];

            for (int i = 0; i < proxy.MainInfo.RCCount; ++i)
            {
                rc[17 * i + 0] = data.RecirculationChannelData.Density;
                rc[17 * i + 1] = data.RecirculationChannelData.NumberOfRecirculationChannel;
                rc[17 * i + 2] = data.RecirculationChannelData.RecirculationChannelInfoList[i].RadiusOfRecirculationChannel;
                rc[17 * i + 3] = data.RecirculationChannelData.RecirculationChannelInfoList[i].LengthOfRecirculationChannel;
                rc[17 * i + 4] = data.RecirculationChannelData.RecirculationChannelInfoList[i].HeightOfRecirculationChannel;

                rc[17 * i + 5] = data.RecirculationChannelData.RecirculationChannelInfoList[i].SelectBearingTypeOfUpper;
                if (1 == data.RecirculationChannelData.RecirculationChannelInfoList[i].SelectBearingTypeOfUpper)
                {
                    rc[17 * i + 6] = (data.RecirculationChannelData.RecirculationChannelInfoList[i].Upper as RecirculationChannelTypePropertyThrust).PartNumber;
                    rc[17 * i + 7] = (data.RecirculationChannelData.RecirculationChannelInfoList[i].Upper as RecirculationChannelTypePropertyThrust).AngularPosition;
                    rc[17 * i + 8] = (data.RecirculationChannelData.RecirculationChannelInfoList[i].Upper as RecirculationChannelTypePropertyThrust).Dtheta;
                    rc[17 * i + 9] = (data.RecirculationChannelData.RecirculationChannelInfoList[i].Upper as RecirculationChannelTypePropertyThrust).InnerRadius;
                    rc[17 * i + 10] = (data.RecirculationChannelData.RecirculationChannelInfoList[i].Upper as RecirculationChannelTypePropertyThrust).OuterRadius;
                }
                else if (2 == data.RecirculationChannelData.RecirculationChannelInfoList[i].SelectBearingTypeOfUpper)
                {
                    rc[17 * i + 6] = (data.RecirculationChannelData.RecirculationChannelInfoList[i].Upper as RecirculationChannelTypePropertyJournal).PartNumber;
                    rc[17 * i + 7] = (data.RecirculationChannelData.RecirculationChannelInfoList[i].Upper as RecirculationChannelTypePropertyJournal).AngularPosition;
                    rc[17 * i + 8] = (data.RecirculationChannelData.RecirculationChannelInfoList[i].Upper as RecirculationChannelTypePropertyJournal).Dtheta;
                    rc[17 * i + 9] = (data.RecirculationChannelData.RecirculationChannelInfoList[i].Upper as RecirculationChannelTypePropertyJournal).ZCoordinateOfLower;
                    rc[17 * i + 10] = (data.RecirculationChannelData.RecirculationChannelInfoList[i].Upper as RecirculationChannelTypePropertyJournal).ZCoordinateOfUpper;
                }

                rc[17 * i + 11] = data.RecirculationChannelData.RecirculationChannelInfoList[i].SelectBearingTypeOfLower;
                if (1 == data.RecirculationChannelData.RecirculationChannelInfoList[i].SelectBearingTypeOfLower)
                {
                    rc[17 * i + 12] = (data.RecirculationChannelData.RecirculationChannelInfoList[i].Lower as RecirculationChannelTypePropertyThrust).PartNumber;
                    rc[17 * i + 13] = (data.RecirculationChannelData.RecirculationChannelInfoList[i].Lower as RecirculationChannelTypePropertyThrust).AngularPosition;
                    rc[17 * i + 14] = (data.RecirculationChannelData.RecirculationChannelInfoList[i].Lower as RecirculationChannelTypePropertyThrust).Dtheta;
                    rc[17 * i + 15] = (data.RecirculationChannelData.RecirculationChannelInfoList[i].Lower as RecirculationChannelTypePropertyThrust).InnerRadius;
                    rc[17 * i + 16] = (data.RecirculationChannelData.RecirculationChannelInfoList[i].Lower as RecirculationChannelTypePropertyThrust).OuterRadius;
                }
                else if (2 == data.RecirculationChannelData.RecirculationChannelInfoList[i].SelectBearingTypeOfLower)
                {
                    rc[17 * i + 12] = (data.RecirculationChannelData.RecirculationChannelInfoList[i].Lower as RecirculationChannelTypePropertyJournal).PartNumber;
                    rc[17 * i + 13] = (data.RecirculationChannelData.RecirculationChannelInfoList[i].Lower as RecirculationChannelTypePropertyJournal).AngularPosition;
                    rc[17 * i + 14] = (data.RecirculationChannelData.RecirculationChannelInfoList[i].Lower as RecirculationChannelTypePropertyJournal).Dtheta;
                    rc[17 * i + 15] = (data.RecirculationChannelData.RecirculationChannelInfoList[i].Lower as RecirculationChannelTypePropertyJournal).ZCoordinateOfLower;
                    rc[17 * i + 16] = (data.RecirculationChannelData.RecirculationChannelInfoList[i].Lower as RecirculationChannelTypePropertyJournal).ZCoordinateOfUpper;
                }
            }

            proxy.RecirInfo = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(double)) * 17 * proxy.MainInfo.RCCount);
            Marshal.Copy(rc, 0, proxy.RecirInfo, rc.Length);

            #endregion
        }

        public void ReleaseInputProxy(ref MeshInput_Proxy proxy)
        {
            Marshal.FreeHGlobal(proxy.PartInfo);
            proxy.PartInfo = IntPtr.Zero;
            Marshal.FreeHGlobal(proxy.RecirInfo);
            proxy.RecirInfo = IntPtr.Zero;
        }

        public MeshInfo GetOutput(int PartCount, ref MeshInfo_Proxy mesh_info)
        {
            MeshInfo output = new MeshInfo();

            #region Get Part

            output.PartCount = PartCount;

            // 1 차원 [PartCount + 1]
            int[] SectionID = new int[PartCount + 1];
            Marshal.Copy(mesh_info.SectionID, SectionID, 0, PartCount + 1);
            for (int i = 0; i < PartCount; ++i)
                output.SectionID.Add(SectionID[i + 1]);

            // 1 차원 [PartCount + 1]
            int[] NodeCount = new int[PartCount + 1];
            Marshal.Copy(mesh_info.NodeCount, NodeCount, 0, PartCount + 1);
            for (int i = 0; i < PartCount; ++i)
                output.NodeCount.Add(NodeCount[i + 1]);

            // 1 차원 [PartCount + 1]
            int[] ElementCount = new int[PartCount + 1];
            Marshal.Copy(mesh_info.ElementCount, ElementCount, 0, PartCount + 1);
            for (int i = 0; i < PartCount; ++i)
                output.ElementCount.Add(ElementCount[i + 1]);

            // 2 차원 [PartCount + 1] [NumOfNode[PartIndex] + 1]
            IntPtr[] x_global = new IntPtr[PartCount + 1];
            Marshal.Copy(mesh_info.x_global, x_global, 0, PartCount + 1);
            for (int i = 0; i < PartCount; ++i)
            {
                List<double> lst_x_global = new List<double>();
                double[] values = new double[output.NodeCount[i] + 1];
                Marshal.Copy(x_global[i + 1], values, 0, output.NodeCount[i] + 1);
                for (int j = 0; j < output.NodeCount[i]; ++j)
                    lst_x_global.Add(values[j + 1]);
                output.x_global.Add(lst_x_global);
            }

            // 2 차원 [PartCount + 1] [NumOfNode[PartIndex] + 1]
            IntPtr[] z_global = new IntPtr[PartCount + 1];
            Marshal.Copy(mesh_info.z_global, z_global, 0, PartCount + 1);
            for (int i = 0; i < PartCount; ++i)
            {
                List<double> lst_z_global = new List<double>();
                double[] values = new double[output.NodeCount[i] + 1];
                Marshal.Copy(z_global[i + 1], values, 0, output.NodeCount[i] + 1);
                for (int j = 0; j < output.NodeCount[i]; ++j)
                    lst_z_global.Add(values[j + 1]);
                output.z_global.Add(lst_z_global);
            }

            // 2 차원 [PartCount + 1] [NumOfNode[PartIndex] + 1]
            IntPtr[] part_ID_global = new IntPtr[PartCount + 1];
            Marshal.Copy(mesh_info.part_ID_global, part_ID_global, 0, PartCount + 1);
            for (int i = 0; i < PartCount; ++i)
            {
                List<int> lst_part_ID_global = new List<int>();
                int[] values = new int[output.NodeCount[i] + 1];
                Marshal.Copy(part_ID_global[i + 1], values, 0, output.NodeCount[i] + 1);
                for (int j = 0; j < output.NodeCount[i]; ++j)
                    lst_part_ID_global.Add(values[j + 1]);
                output.part_ID_global.Add(lst_part_ID_global);
            }

            // 2 차원 [PartCount + 1] [NumOfNode[PartIndex] + 1]
            IntPtr[] u0_global = new IntPtr[PartCount + 1];
            Marshal.Copy(mesh_info.u0_global, u0_global, 0, PartCount + 1);
            for (int i = 0; i < PartCount; ++i)
            {
                List<int> lst_u0_global = new List<int>();
                int[] values = new int[output.NodeCount[i] + 1];
                Marshal.Copy(u0_global[i + 1], values, 0, output.NodeCount[i] + 1);
                for (int j = 0; j < output.NodeCount[i]; ++j)
                    lst_u0_global.Add(values[j + 1]);
                output.u0_global.Add(lst_u0_global);
            }

            // 2 차원 [PartCount + 1] [20 + 1]
            IntPtr[] Gdiv_global = new IntPtr[PartCount + 1];
            Marshal.Copy(mesh_info.Gdiv_global, Gdiv_global, 0, PartCount + 1);
            for (int i = 0; i < PartCount; ++i)
            {
                List<int> lst_Gdiv_global = new List<int>();
                int[] values = new int[20 + 1];
                Marshal.Copy(Gdiv_global[i + 1], values, 0, 20 + 1);
                for (int j = 0; j < 20; ++j)
                    lst_Gdiv_global.Add(values[j + 1]);
                output.Gdiv_global.Add(lst_Gdiv_global);
            }

            // 2 차원 [PartCount + 1] [20 + 1]
            IntPtr[] Rdiv_global = new IntPtr[PartCount + 1];
            Marshal.Copy(mesh_info.Rdiv_global, Rdiv_global, 0, PartCount + 1);
            for (int i = 0; i < PartCount; ++i)
            {
                List<int> lst_Rdiv_global = new List<int>();
                int[] values = new int[20 + 1];
                Marshal.Copy(Rdiv_global[i + 1], values, 0, 20 + 1);
                for (int j = 0; j < 20; ++j)
                    lst_Rdiv_global.Add(values[j + 1]);
                output.Rdiv_global.Add(lst_Rdiv_global);
            }

            // 2 차원 [PartCount + 1] [NumOfElement[PartIndex] + 1]
            IntPtr[] i_g_global = new IntPtr[PartCount + 1];
            Marshal.Copy(mesh_info.i_g_global, i_g_global, 0, PartCount + 1);
            for (int i = 0; i < PartCount; ++i)
            {
                List<int> lst_i_g_global = new List<int>();
                int[] values = new int[output.ElementCount[i] + 1];
                Marshal.Copy(i_g_global[i + 1], values, 0, output.ElementCount[i] + 1);
                for (int j = 0; j < output.ElementCount[i]; ++j)
                    lst_i_g_global.Add(values[j + 1]);
                output.i_g_global.Add(lst_i_g_global);
            }

            // 2 차원 [PartCount + 1] [NumOfElement[PartIndex] + 1]
            IntPtr[] H0_global = new IntPtr[PartCount + 1];
            Marshal.Copy(mesh_info.H0_global, H0_global, 0, PartCount + 1);
            for (int i = 0; i < PartCount; ++i)
            {
                List<int> lst_H0_global = new List<int>();
                int[] values = new int[output.ElementCount[i] + 1];
                Marshal.Copy(H0_global[i + 1], values, 0, output.ElementCount[i] + 1);
                for (int j = 0; j < output.ElementCount[i]; ++j)
                    lst_H0_global.Add(values[j + 1]);
                output.H0_global.Add(lst_H0_global);
            }

            // 3 차원 [PartCount + 1] [NumOfElement[PartIndex] + 1] [4 + 1]
            IntPtr[] part_IEN_global = new IntPtr[PartCount + 1];
            Marshal.Copy(mesh_info.part_IEN_global, part_IEN_global, 0, PartCount + 1);
            for (int i = 0; i < PartCount; ++i)
            {
                part_IEN_global[] values = new part_IEN_global[output.ElementCount[i]];
                int[] temp = new int[(output.ElementCount[i] + 1) * 5];
                Marshal.Copy(part_IEN_global[i + 1], temp, 0, (output.ElementCount[i] + 1) * 5);
                for (int j = 0; j < output.ElementCount[i]; ++j)
                {
                    values[j].value1 = temp[(j + 1) * 5 + 1];
                    values[j].value2 = temp[(j + 1) * 5 + 2];
                    values[j].value3 = temp[(j + 1) * 5 + 3];
                    values[j].value4 = temp[(j + 1) * 5 + 4];
                }
                output.part_IEN_global.Add(values);
            }

            #endregion

            #region Get RecirChannel

            output.RecirChannelCount = mesh_info.RecirNodeInfo.RecirChannelNumber;

            if (0 < output.RecirChannelCount)
            {
                // 1 차원 [RecirChannelCount + 1]
                int[] RecirChannelNodeNumber = new int[output.RecirChannelCount + 1];
                Marshal.Copy(mesh_info.RecirNodeInfo.RecirChannelNodeNumber, RecirChannelNodeNumber, 0, output.RecirChannelCount + 1);
                for (int i = 0; i < output.RecirChannelCount; ++i)
                    output.RecirChannelNodeNumber.Add(RecirChannelNodeNumber[i + 1]);

                // 2 차원 [RecirChannelCount + 1] [RecirChannelNodeNumber[RecirChannelIndex] + 1] 
                IntPtr[] RecirChannelPart = new IntPtr[output.RecirChannelCount + 1];
                Marshal.Copy(mesh_info.RecirNodeInfo.RecirChannelPart, RecirChannelPart, 0, output.RecirChannelCount + 1);
                for (int i = 0; i < output.RecirChannelCount; ++i)
                {
                    List<int> lst_RecirChannelPart = new List<int>();
                    int[] values = new int[output.RecirChannelNodeNumber[i] + 1];
                    Marshal.Copy(RecirChannelPart[i + 1], values, 0, output.RecirChannelNodeNumber[i] + 1);
                    for (int j = 0; j < output.RecirChannelNodeNumber[i]; ++j)
                        lst_RecirChannelPart.Add(values[j + 1]);
                    output.RecirChannelPart.Add(lst_RecirChannelPart);
                }

                // 2 차원 [RecirChannelCount * 2 + 1] [RecirChannelNodeNumber[RecirChannelIndex] + 1] 
                IntPtr[] RecirChannelNode = new IntPtr[output.RecirChannelCount * 2 + 1];
                Marshal.Copy(mesh_info.RecirNodeInfo.RecirChannelNode, RecirChannelNode, 0, output.RecirChannelCount * 2 + 1);
                for (int i = 0; i < output.RecirChannelCount * 2; ++i)
                {
                    List<int> lst_RecirChannelNode = new List<int>();
                    int[] values = new int[output.RecirChannelNodeNumber[i] + 1];
                    Marshal.Copy(RecirChannelNode[i + 1], values, 0, output.RecirChannelNodeNumber[i] + 1);
                    for (int j = 0; j < output.RecirChannelNodeNumber[i]; ++j)
                        lst_RecirChannelNode.Add(values[j + 1]);
                    output.RecirChannelNode.Add(lst_RecirChannelNode);
                }
            }

            #endregion

            return output;
        }

        public ResultInfo GetOutput(int PartCount, ref ResultInfo_Proxy result_info)
        {
            ResultInfo output = new ResultInfo();

            double[] Friction = new double[PartCount + 1];
            Marshal.Copy(result_info.Friction, Friction, 0, PartCount + 1);
            for (int i = 0; i < PartCount; ++i)
                output.Friction.Add(Friction[i + 1]);

            double[] LoadCapacity = new double[PartCount + 1];
            Marshal.Copy(result_info.LoadCapacity, LoadCapacity, 0, PartCount + 1);
            for (int i = 0; i < PartCount; ++i)
                output.LoadCapacity.Add(LoadCapacity[i + 1]);

            double[] Stiffness = new double[(PartCount + 1) * (1 + 25)];
            Marshal.Copy(result_info.Stiffness, Stiffness, 0, (PartCount + 1) * (1 + 25));
            for (int i = 0; i < PartCount; ++i)
            {
                Matrix5X5 mat = new Matrix5X5();
                for (int j = 0; j < 25; ++j)
                    mat.value[j] = Stiffness[((i + 1) * (1 + 25)) + j + 1];
                output.Stiffness.Add(mat);
            }

            double[] Damping = new double[(PartCount + 1) * (1 + 25)];
            Marshal.Copy(result_info.Damping, Damping, 0, (PartCount + 1) * (1 + 25));
            for (int i = 0; i < PartCount; ++i)
            {
                Matrix5X5 mat = new Matrix5X5();
                for (int j = 0; j < 25; ++j)
                    mat.value[j] = Damping[((i + 1) * (1 + 25)) + j + 1];
                output.Damping.Add(mat);
            }

            output.Total_Stiffness.value[0] = result_info.Total_Stiffness.value1;
            output.Total_Stiffness.value[1] = result_info.Total_Stiffness.value2;
            output.Total_Stiffness.value[2] = result_info.Total_Stiffness.value3;
            output.Total_Stiffness.value[3] = result_info.Total_Stiffness.value4;
            output.Total_Stiffness.value[4] = result_info.Total_Stiffness.value5;
            output.Total_Stiffness.value[5] = result_info.Total_Stiffness.value6;
            output.Total_Stiffness.value[6] = result_info.Total_Stiffness.value7;
            output.Total_Stiffness.value[7] = result_info.Total_Stiffness.value8;
            output.Total_Stiffness.value[8] = result_info.Total_Stiffness.value9;
            output.Total_Stiffness.value[9] = result_info.Total_Stiffness.value10;
            output.Total_Stiffness.value[10] = result_info.Total_Stiffness.value11;
            output.Total_Stiffness.value[11] = result_info.Total_Stiffness.value12;
            output.Total_Stiffness.value[12] = result_info.Total_Stiffness.value13;
            output.Total_Stiffness.value[13] = result_info.Total_Stiffness.value14;
            output.Total_Stiffness.value[14] = result_info.Total_Stiffness.value15;
            output.Total_Stiffness.value[15] = result_info.Total_Stiffness.value16;
            output.Total_Stiffness.value[16] = result_info.Total_Stiffness.value17;
            output.Total_Stiffness.value[17] = result_info.Total_Stiffness.value18;
            output.Total_Stiffness.value[18] = result_info.Total_Stiffness.value19;
            output.Total_Stiffness.value[19] = result_info.Total_Stiffness.value20;
            output.Total_Stiffness.value[20] = result_info.Total_Stiffness.value21;
            output.Total_Stiffness.value[21] = result_info.Total_Stiffness.value22;
            output.Total_Stiffness.value[22] = result_info.Total_Stiffness.value23;
            output.Total_Stiffness.value[23] = result_info.Total_Stiffness.value24;
            output.Total_Stiffness.value[24] = result_info.Total_Stiffness.value25;

            output.Total_Damping.value[0] = result_info.Total_Damping.value1;
            output.Total_Damping.value[1] = result_info.Total_Damping.value2;
            output.Total_Damping.value[2] = result_info.Total_Damping.value3;
            output.Total_Damping.value[3] = result_info.Total_Damping.value4;
            output.Total_Damping.value[4] = result_info.Total_Damping.value5;
            output.Total_Damping.value[5] = result_info.Total_Damping.value6;
            output.Total_Damping.value[6] = result_info.Total_Damping.value7;
            output.Total_Damping.value[7] = result_info.Total_Damping.value8;
            output.Total_Damping.value[8] = result_info.Total_Damping.value9;
            output.Total_Damping.value[9] = result_info.Total_Damping.value10;
            output.Total_Damping.value[10] = result_info.Total_Damping.value11;
            output.Total_Damping.value[11] = result_info.Total_Damping.value12;
            output.Total_Damping.value[12] = result_info.Total_Damping.value13;
            output.Total_Damping.value[13] = result_info.Total_Damping.value14;
            output.Total_Damping.value[14] = result_info.Total_Damping.value15;
            output.Total_Damping.value[15] = result_info.Total_Damping.value16;
            output.Total_Damping.value[16] = result_info.Total_Damping.value17;
            output.Total_Damping.value[17] = result_info.Total_Damping.value18;
            output.Total_Damping.value[18] = result_info.Total_Damping.value19;
            output.Total_Damping.value[19] = result_info.Total_Damping.value20;
            output.Total_Damping.value[20] = result_info.Total_Damping.value21;
            output.Total_Damping.value[21] = result_info.Total_Damping.value22;
            output.Total_Damping.value[22] = result_info.Total_Damping.value23;
            output.Total_Damping.value[23] = result_info.Total_Damping.value24;
            output.Total_Damping.value[24] = result_info.Total_Damping.value25;

            output.Total_Friction = result_info.Total_Friction;

            return output;
        }

        public void GetAnalysisInfoProxy(StaticAndDynamicAnalysisData data, ref AnalysisInfo_Proxy proxy)
        {
            proxy.InternalBoundaryCondition = data.InternalBoundaryCondition;
            proxy.ToleranceOfReynoldsBC = data.ToleranceOfReynoldsBC;
            proxy.SelectAnalysisCase = data.SelectAnalysisCase;
        }

        public int line_row(string path)
        {
            int row = 0;

            try
            {
                string[] lines = System.IO.File.ReadAllLines(path);
                row = lines.Length;
            }
            catch (Exception /*e*/)
            {
                //MessageBox.Show(e.Message);
            }

            return row;
        }

        public int line_NodeNumber(string path)
        {
            int nodecount = 0;

            try
            {
                string text = System.IO.File.ReadAllText(path);
                string[] source = text.Split(new char[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                var match1 = from word in source
                             where word.Equals("0")
                             select word;
                nodecount += match1.Count();
                var match2 = from word in source
                             where word.Equals("1")
                             select word;
                nodecount += match2.Count();
                var match3 = from word in source
                             where word.Equals("2")
                             select word;
                nodecount += match3.Count();
                var match4 = from word in source
                             where word.Equals("3")
                             select word;
                nodecount += match4.Count();
            }
            catch (Exception)
            {
            }

            return nodecount;
        }

        public double[] Read(string path)
        {
            string text = System.IO.File.ReadAllText(path);
            string[] source = text.Split(new char[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            double[] data = new double[source.Length];
            int nIndex = 0;
            foreach (string value in source)
            {
                data[nIndex] = double.Parse(value);
                ++nIndex;
            }

            return data;
        }

        public double[] Read(string path, double offset)
        {
            string text = System.IO.File.ReadAllText(path);
            string[] source = text.Split(new char[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            double[] data = new double[source.Length];
            int nIndex = 0;
            foreach (string value in source)
            {
                data[nIndex] = double.Parse(value) * offset;
                ++nIndex;
            }

            return data;
        }
    }

    public static class MeshHelper
    {
        public static bool MeshExecute(string strRootDirectory, InputData input_data, ref MeshInfo output)
        {
            bool bSuccess = false;
            MeshInput_Proxy input_proxy = new MeshInput_Proxy();
            MeshInfo_Proxy output_proxy = new MeshInfo_Proxy();
            DAFULInfo_Proxy outputDF_proxy = new DAFULInfo_Proxy();
            outputDF_proxy.DLLInterface = false;

            string msg = string.Empty;
            if (!Marshal.ValidationCheck(input_data, ref msg))
            {
                System.Windows.MessageBox.Show(msg, "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                return false;
            }

            Marshal.GetMeshInputProxy(strRootDirectory, input_data, ref input_proxy);

            bSuccess = marshal_function.Mesh(ref input_proxy, ref output_proxy, ref outputDF_proxy);

            if (bSuccess)
                output = Marshal.GetOutput(input_data.MainData.PartCount, ref output_proxy);

            Marshal.ReleaseInputProxy(ref input_proxy);
            marshal_function.Free(ref input_proxy, ref output_proxy, ref outputDF_proxy);

            return bSuccess;
        }

        public static bool MeshExecute(string strRootDirectory, InputData input_data)
        {
            bool bSuccess = false;
            MeshInput_Proxy input_proxy = new MeshInput_Proxy();
            MeshInfo_Proxy output_proxy = new MeshInfo_Proxy();
            DAFULInfo_Proxy outputDF_proxy = new DAFULInfo_Proxy();
            outputDF_proxy.DLLInterface = false;

            string msg = string.Empty;
            if (!Marshal.ValidationCheck(input_data, ref msg))
            {
                System.Windows.MessageBox.Show(msg, "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                return false;
            }

            Marshal.GetMeshInputProxy(strRootDirectory, input_data, ref input_proxy);

            bSuccess = marshal_function.Mesh(ref input_proxy, ref output_proxy, ref outputDF_proxy);

            Marshal.ReleaseInputProxy(ref input_proxy);
            marshal_function.Free(ref input_proxy, ref output_proxy, ref outputDF_proxy);

            return bSuccess;
        }

        public static bool ReadMeshResult(string strRootDirectory, InputData input_data)
        {
            int nPart = input_data.MainData.PartCount;
            string path_z = string.Empty;
            string path_r = string.Empty;
            string path_th = string.Empty;
            string path_ind = string.Empty;

            for (int i = 0; i < nPart; ++i)
            {
                path_z = System.IO.Path.Combine(strRootDirectory, string.Format("Part_{0:D2}_z.dat", i + 1));
                path_r = System.IO.Path.Combine(strRootDirectory, string.Format("Part_{0:D2}_r.dat", i + 1));
                path_th = System.IO.Path.Combine(strRootDirectory, string.Format("Part_{0:D2}_th.dat", i + 1));
                path_ind = System.IO.Path.Combine(strRootDirectory, string.Format("Part_{0:D2}_grv_ind.dat", i + 1));
                int row = Marshal.line_row(path_r);
                System.Diagnostics.Debug.Assert(0 < row);
                if (0 == row)
                    return false;
                int num = Marshal.line_NodeNumber(path_ind);
                int column = num / row;

                Models.MeshDisplayData data = new Models.MeshDisplayData();
                data.Row = row;
                data.Column = column;
                data.z = Marshal.Read(path_z, 1000.0);
                System.Diagnostics.Debug.Assert(num == data.z.Length);
                double[] r = Marshal.Read(path_r);
                double[] th = Marshal.Read(path_th);
                data.x = new double[num];
                data.y = new double[num];
                for (int j = 0; j < num; ++j)
                {
                    data.x[j] = 1000.0 * Math.Cos(th[j]) * r[j];
                    data.y[j] = 1000.0 * Math.Sin(th[j]) * r[j];
                }
                data.ind = Marshal.Read(path_ind);
                input_data.MainData.PartList[i].MeshDisplayData = data;
            }
            
            return true;
        }

        private static marshal_function Marshal = new marshal_function();
    }
}
