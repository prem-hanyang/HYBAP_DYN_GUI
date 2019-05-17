// The following ifdef block is the standard way of creating macros which make exporting 
// from a DLL simpler. All files within this DLL are compiled with the HYBAPCOMMUNICATOR_EXPORTS
// symbol defined on the command line. This symbol should not be defined on any project
// that uses this DLL. This way any other project whose source files include this file see 
// HYBAPCOMMUNICATOR_API functions as being imported from a DLL, whereas this DLL sees symbols
// defined with this macro as being exported.
#ifdef HYBAPCOMMUNICATOR_EXPORTS
#define HYBAPCOMMUNICATOR_API __declspec(dllexport)
#else
#define HYBAPCOMMUNICATOR_API __declspec(dllimport)
#endif

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

struct _DAFULInfo
{
	bool DLLInterface;
	double RPM;
	_NodeCount* NodeCount;
	_ElementCount* ElementCount;

	_FilmThickness* FilmThickness;  // DAFUL input
	_Force* Force;					// DAFUL output
	_Friction* Friction;			// DAFUL output
	// FilmThickness -> [part number][node nomber]
	// Force -> [part number][element nomber]
};

extern "C"
{
	HYBAPCOMMUNICATOR_API int GetInputInfo(const char* strInputFilePath, _InputInfo* input_info, _AnalysisInfo* analysis_info);
	HYBAPCOMMUNICATOR_API void FreeInputInfo(_InputInfo* input_info);
}
