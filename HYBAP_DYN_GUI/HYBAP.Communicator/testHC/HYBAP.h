#pragma once

#include <map>

struct _MainInfo
{
	int PartCount;
	double RPM;
	double tx;
	double ty;
	double Viscosity;
	double Theta_div;
	double Cavi_pressure;
	int Recir_flag;
	int RecirCount;
};

struct _PartInfo
{
	double Value[28+3];
};

struct _RecirInfo
{
	double Value[17];
};

struct _InputInfo
{
	_MainInfo Main;
	_PartInfo* Parts;
	_RecirInfo* RCs;
	wchar_t* RootDirectory;
};

struct _RecirChannelNodeNumber
{
	int RecirChannelNodeNumber;
};

struct _RecirChannelPart
{
	int *RecirChannelPart;
};

struct _RecirChannelNode
{
	int *RecirChannelNode;
};

struct _RecirNodeInfo
{	
	int RecirChannelNumber;	
	_RecirChannelNodeNumber* RecirChannelNodeNumber;
	_RecirChannelPart* RecirChannelPart;
	_RecirChannelNode* RecirChannelNode;
};

struct _NodeCount
{
	int NodeCount;
};

struct _ElementCount
{
	int ElementCount;
};

struct _x_global
{
	double *x_global;
};

struct _z_global
{
	double *z_global;
};

struct _part_ID_global
{
	int *part_ID_global;
};

struct _4Integer
{
	int value1;
	int value2;
	int value3;
	int value4;
};

struct _part_IEN_global
{
	_4Integer* part_IEN_global;
};

struct _Gdiv_global
{
	int *Gdiv_global;
};

struct _Rdiv_global
{
	int *Rdiv_global;
};

struct _i_g_global
{
	int *i_g_global;
};

struct _H0_global
{
	double *H0_global;
};

struct _u0_global
{
	int *u0_global;
};

struct _SectionID
{
	int SectionID;
};

struct _MeshInfo
{	
	_RecirNodeInfo RecirNodeInfo;
	_SectionID* SectionID;
	_NodeCount* NodeCount;
	_ElementCount* ElementCount;

	_x_global* x_global;
	_z_global* z_global;
	_part_ID_global* part_ID_global;
	_part_IEN_global* part_IEN_global;
	_Gdiv_global* Gdiv_global;
	_Rdiv_global* Rdiv_global;
	_i_g_global* i_g_global;
	_H0_global* H0_global;
	_u0_global* u0_global;
};

struct _AnalysisInfo
{
	int InternalBoundaryCondition;
	double ToleranceOfReynoldsBC;
	int SelectAnalysisCase;
};

struct _Friction
{
	double Friction;
};

struct _LoadCapacity
{
	double LoadCapacity;
};

struct _Stiffness
{
	double Stiffness[1+25];
};

struct _Damping
{
	double Damping[1+25];
};

struct _ResultInfo
{
	_Friction*		Friction;
	_LoadCapacity*	LoadCapacity;
	_Stiffness*		Stiffness;
	_Damping*		Damping;

	double			Total_Stiffness[1+25];
	double			Total_Damping[1+25];
	double			Total_Friction;
};

struct _FilmThickness
{
	double *FilmThickness;
};

struct _Force
{
	double *Force;
};

struct _NodeForce
{
	double *NodeForce;
};

struct _Geo_X
{
	double *Geo_X;
};

struct _Geo_Y
{
	double *Geo_Y;
};

struct _Geo_Z
{
	double *Geo_Z;
};

struct _DAFULInfo
{
	bool DLLInterface;
	int PartCount;
	double RPM;
	_NodeCount* NodeCount;
	_ElementCount* ElementCount;
	
	_Geo_X* Geo_X;
	_Geo_Y* Geo_Y;
	_Geo_Z* Geo_Z;

	_FilmThickness* FilmThickness;  // DAFUL input
	_Force* Force;					// DAFUL output
	_Friction* Friction;			// DAFUL output
	_NodeForce*  NodeForce;  
	// FilmThickness -> [part number][node nomber]
	// Force -> [part number][element nomber]
};

typedef int (*pFunctionReadHYBAPInputFile)(const char*, _InputInfo*, _AnalysisInfo*);
extern pFunctionReadHYBAPInputFile fnReadFile;
typedef void (*pFunctionCommunicatorFree)(_InputInfo*);
extern pFunctionCommunicatorFree fnCommunicatorFree;
extern const char* HYBAP_Communicator_DLL_PATH;

typedef bool (*pFunctionMesh)(const _InputInfo*, _MeshInfo*, _DAFULInfo*);
extern pFunctionMesh fnMesh;
typedef bool (*pFunctionMesherFree)(const _InputInfo*, _MeshInfo*, _DAFULInfo*);
extern pFunctionMesherFree fnMesherFree;
extern const char* HYBAP_Mesher_DLL_PATH;

typedef bool (*pFunctionSolve)(const _InputInfo*, _MeshInfo*, const _AnalysisInfo*, _ResultInfo*, _DAFULInfo*);
extern pFunctionSolve fnSolve;
typedef bool (*pFunctionSolverFree)(_ResultInfo*, _DAFULInfo*);
extern pFunctionSolverFree fnSolverFree;
extern const char* HYBAP_Solver_DLL_PATH;

extern std::map<long long int, _InputInfo> mapInputInfo;
extern std::map<long long int, _MeshInfo> mapMeshInfo;
extern std::map<long long int, _AnalysisInfo> mapAnalysisInfo;
extern std::map<long long int, _DAFULInfo> mapDAFULInfo;

bool InitHYBAP(const long long int, const char*);