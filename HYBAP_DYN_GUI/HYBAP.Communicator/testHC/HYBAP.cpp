#include "stdafx.h"
#include <windows.h>

#include "HYBAP.h"
#include <string>

pFunctionReadHYBAPInputFile fnReadFile = NULL;
pFunctionCommunicatorFree fnCommunicatorFree = NULL;
const char* HYBAP_Communicator_DLL_PATH = "HYBAP.Communicator.dll";

pFunctionMesh fnMesh = NULL;
pFunctionMesherFree fnMesherFree = NULL;
const char* HYBAP_Mesher_DLL_PATH = "HYBAPMesh.dll";

pFunctionSolve fnSolve = NULL;
pFunctionSolverFree fnSolverFree = NULL;
const char* HYBAP_Solver_DLL_PATH = "HYBAPSolver.dll";

std::string strFilePath;
std::string strFolderPath;
std::map<long long int, std::wstring> mapRootDirectory;
std::map<long long int, _InputInfo> mapInputInfo;	// _InputInfo 구조체의 모든 동적 할당 메모리 해제 안됨
std::map<long long int, _MeshInfo> mapMeshInfo;	// _MeshInfo 구조체의 모든 동적 할당 메모리 해제 안됨
std::map<long long int, _AnalysisInfo> mapAnalysisInfo;
std::map<long long int, _DAFULInfo> mapDAFULInfo;	// _DAFULInfo 구조체의 NodeCount, ElementCount, Geo_X, Geo_Y, Geo_Z 메모리 해제 안됨

bool InitHYBAP()
{
	HMODULE hModuleCommunicator = LoadLibraryA(HYBAP_Communicator_DLL_PATH);
	if (NULL == hModuleCommunicator)
		return false;
	PVOID funcGetInputInfo = GetProcAddress(hModuleCommunicator, "GetInputInfo");
	fnReadFile = (pFunctionReadHYBAPInputFile)funcGetInputInfo;
	if (NULL == fnReadFile)
		return false;
	PVOID funcFreeInputInfo = GetProcAddress(hModuleCommunicator, "FreeInputInfo");
	fnCommunicatorFree = (pFunctionCommunicatorFree)funcFreeInputInfo;
	if (NULL == fnCommunicatorFree)
		return false;

	HMODULE hModuleMesher = LoadLibraryA(HYBAP_Mesher_DLL_PATH);
	if (NULL == hModuleMesher)
		return false;
	PVOID funcMesh = GetProcAddress(hModuleMesher, "Mesh");
	fnMesh = (pFunctionMesh)funcMesh;
	if (NULL == fnMesh)
		return false;
	PVOID funcFree = GetProcAddress(hModuleMesher, "Free");
	fnMesherFree = (pFunctionMesherFree)funcFree;
	if (NULL == fnMesherFree)
		return false;

	HMODULE hModuleSolver = LoadLibraryA(HYBAP_Solver_DLL_PATH);
	if (NULL == hModuleSolver)
		return false;
	PVOID funcSolver = GetProcAddress(hModuleSolver, "Solver");
	fnSolve = (pFunctionSolve)funcSolver;
	if (NULL == fnSolve)
		return false;
	PVOID funcSolverFree = GetProcAddress(hModuleSolver, "SolverFree");
	fnSolverFree = (pFunctionSolverFree)funcSolverFree;
	if (NULL == fnSolverFree)
		return false;

	return true;
}

bool InitHYBAP(const long long int ID, const char* hybap_filepath)
{
	if (!InitHYBAP())
		return false;

	_InputInfo input_info;
	_AnalysisInfo analysis_info;
	_MeshInfo mesh_info;
	_DAFULInfo daful_info;

	strFilePath = hybap_filepath;
	size_t found = strFilePath.find_last_of('\\');
	strFolderPath = strFilePath.substr(0,found);
	std::wstring wstrFolderPath;
	wstrFolderPath.assign(strFolderPath.begin(), strFolderPath.end());
	if (mapRootDirectory.end() == mapRootDirectory.find(ID))
		mapRootDirectory.insert(std::pair<long long int, std::wstring>(ID, wstrFolderPath));
	else
		mapRootDirectory[ID] = wstrFolderPath;
	input_info.RootDirectory = const_cast<wchar_t*>(mapRootDirectory[ID].c_str());
	
	// Read File
	if (0 > fnReadFile(strFilePath.c_str(), &input_info, &analysis_info))
		return false;

	if (mapInputInfo.end() == mapInputInfo.find(ID))
		mapInputInfo.insert(std::pair<long long int, _InputInfo>(ID, input_info));
	else
		mapInputInfo[ID] = input_info;

	if (mapAnalysisInfo.end() == mapAnalysisInfo.find(ID))
		mapAnalysisInfo.insert(std::pair<long long int, _AnalysisInfo>(ID, analysis_info));
	else
		mapAnalysisInfo[ID] = analysis_info;

	// Mesh
	fnMesh(&mapInputInfo[ID], &mesh_info, &daful_info);
	daful_info.DLLInterface = true;
	daful_info.FilmThickness = new _FilmThickness[daful_info.PartCount + 1];
	for (int i = 0; i < daful_info.PartCount; ++i)
		daful_info.FilmThickness[i + 1].FilmThickness = new double[daful_info.NodeCount[i + 1].NodeCount + 1];

	if (mapMeshInfo.end() == mapMeshInfo.find(ID))
		mapMeshInfo.insert(std::pair<long long int, _MeshInfo>(ID, mesh_info));
	else
		mapMeshInfo[ID] = mesh_info;

	if (mapDAFULInfo.end() == mapDAFULInfo.find(ID))
		mapDAFULInfo.insert(std::pair<long long int, _DAFULInfo>(ID, daful_info));
	else
		mapDAFULInfo[ID] = daful_info;

	return true;
}