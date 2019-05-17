// testHC.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <windows.h>
#include <iostream>
#include "HYBAP.h"

void print(_InputInfo& input_info, _AnalysisInfo& analysis_info)
{
	std::cout << "Number of part : " << input_info.Main.PartCount << std::endl;
	std::cout << std::endl;
	for (int i = 0; i < input_info.Main.PartCount; ++i)
	{
		std::cout << (i + 1) << " : " << input_info.Parts[i].Value[0];
		std::cout << ", " << input_info.Parts[i].Value[1];
		std::cout << ", " << input_info.Parts[i].Value[2];
		std::cout << ", " << input_info.Parts[i].Value[3];
		std::cout << ", " << input_info.Parts[i].Value[4];
		std::cout << ", " << input_info.Parts[i].Value[5];
		std::cout << ", " << input_info.Parts[i].Value[6];
		std::cout << ", " << input_info.Parts[i].Value[7];
		std::cout << ", " << input_info.Parts[i].Value[8];
		std::cout << ", " << input_info.Parts[i].Value[9];
		std::cout << ", " << input_info.Parts[i].Value[10];
		std::cout << ", " << input_info.Parts[i].Value[11];
		std::cout << ", " << input_info.Parts[i].Value[12];
		std::cout << ", " << input_info.Parts[i].Value[13];
		std::cout << ", " << input_info.Parts[i].Value[14];
		std::cout << ", " << input_info.Parts[i].Value[15];
		std::cout << ", " << input_info.Parts[i].Value[16];
		std::cout << ", " << input_info.Parts[i].Value[17];
		std::cout << ", " << input_info.Parts[i].Value[18];
		std::cout << ", " << input_info.Parts[i].Value[19];
		std::cout << ", " << input_info.Parts[i].Value[20];
		std::cout << ", " << input_info.Parts[i].Value[21];
		std::cout << ", " << input_info.Parts[i].Value[22];
		std::cout << ", " << input_info.Parts[i].Value[23];
		std::cout << ", " << input_info.Parts[i].Value[24];
		std::cout << ", " << input_info.Parts[i].Value[25];
		std::cout << ", " << input_info.Parts[i].Value[26];
		std::cout << ", " << input_info.Parts[i].Value[27];
		std::cout << ", " << input_info.Parts[i].Value[28];
		std::cout << ", " << input_info.Parts[i].Value[29];
		std::cout << ", " << input_info.Parts[i].Value[30];
		std::cout << std::endl;
	}
	std::cout << std::endl;
	
	std::cout << "RotatingSpeed : " << input_info.Main.RPM << std::endl;
	std::cout << "Viscosity : " << input_info.Main.Viscosity << std::endl;
	std::cout << "MisalignmentAngleXaxis : " << input_info.Main.tx << std::endl;
	std::cout << "MisalignmentAngleYaxis : " << input_info.Main.ty << std::endl;
	std::cout << "NumberOfTotalDivision : " << input_info.Main.Theta_div << std::endl;
	std::cout << "CavitationPressure : " << input_info.Main.Cavi_pressure << std::endl;
	std::cout << "RecirculationChannelFlag : " << input_info.Main.Recir_flag << std::endl;
	std::cout << std::endl;

	std::cout << "Number of RC : " << input_info.Main.RecirCount << std::endl;
	std::cout << std::endl;
	for (int i = 0; i < input_info.Main.RecirCount; ++i)
	{
		std::cout << (i + 1) << " : " << input_info.RCs[i].Value[0];
		std::cout << ", " << input_info.RCs[i].Value[1];
		std::cout << ", " << input_info.RCs[i].Value[2];
		std::cout << ", " << input_info.RCs[i].Value[3];
		std::cout << ", " << input_info.RCs[i].Value[4];
		std::cout << ", " << input_info.RCs[i].Value[5];
		std::cout << ", " << input_info.RCs[i].Value[6];
		std::cout << ", " << input_info.RCs[i].Value[7];
		std::cout << ", " << input_info.RCs[i].Value[8];
		std::cout << ", " << input_info.RCs[i].Value[9];
		std::cout << ", " << input_info.RCs[i].Value[10];
		std::cout << ", " << input_info.RCs[i].Value[11];
		std::cout << ", " << input_info.RCs[i].Value[12];
		std::cout << ", " << input_info.RCs[i].Value[13];
		std::cout << ", " << input_info.RCs[i].Value[14];
		std::cout << ", " << input_info.RCs[i].Value[15];
		std::cout << ", " << input_info.RCs[i].Value[16];
		std::cout << std::endl;
	}
	std::cout << std::endl;

	std::cout << "InternalBoundaryCondition : " << analysis_info.InternalBoundaryCondition << std::endl;
	std::cout << "ToleranceOfReynoldsBC : " << analysis_info.ToleranceOfReynoldsBC << std::endl;
	std::cout << "SelectAnalysisCase : " << analysis_info.SelectAnalysisCase << std::endl;
	std::cout << std::endl;
}

int _tmain(int argc, _TCHAR* argv[])
{
	int nRes = 0;
	long long int nID = 1;
	_ResultInfo result_info;

	if (false == InitHYBAP(nID, "C:\\Users\\tenshi19\\Documents\\HYBAP\\Input_New.hybap"))
		return -1;
	//print(mapInputInfo[nID], mapAnalysisInfo[nID]);

	for (int nStepIdx = 0; nStepIdx < 10; ++nStepIdx)
	{
		mapDAFULInfo[nID].RPM = nStepIdx * 1000.0; // 계산
		for (int i = 0; i < mapDAFULInfo[nID].PartCount; ++i)
		{
			for (int j = 0; j < mapDAFULInfo[nID].NodeCount[i + 1].NodeCount; ++j)
				mapDAFULInfo[nID].FilmThickness[i + 1].FilmThickness[j + 1] = 0.000001;	// 계산
		}

		if (NULL != fnSolve)
			fnSolve(&mapInputInfo[nID], &mapMeshInfo[nID], &mapAnalysisInfo[nID], &result_info, &mapDAFULInfo[nID]);
	
		if (NULL != fnSolverFree)
			fnSolverFree(&result_info, &mapDAFULInfo[nID]);
	}

	return 0;
}

