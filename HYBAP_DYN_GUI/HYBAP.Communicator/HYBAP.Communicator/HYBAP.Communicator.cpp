// HYBAP.Communicator.cpp : Defines the exported functions for the DLL application.
//

#include "stdafx.h"
#include "HYBAP.Communicator.h"
#include <libxml\parser.h>
#include <libxml\tree.h>

bool ReadPartInfo(int nIndex, xmlNode* node, _InputInfo* input_info)
{
	if (NULL == node || XML_ELEMENT_NODE != node->type)
		return false;

	int PartNo = 0;
	int BearingType = 0;
	int GrooveLocation = 0;
	int PumpingDirection = 0;
	int GrooveType = 0;

	xmlNode* cur_node = node->children->next;

	if (0 != ::strcmp("PartNo", (const char *)cur_node->name))
		return false;
	PartNo = ::atoi((const char *)cur_node->children->content);
	cur_node = cur_node->next->next;

	if (0 != ::strcmp("BearingType", (const char *)cur_node->name))
		return false;
	BearingType = ::atoi((const char *)cur_node->children->content);
	cur_node = cur_node->next->next;

	if (0 != ::strcmp("GrooveLocation", (const char *)cur_node->name))
		return false;
	GrooveLocation = ::atoi((const char *)cur_node->children->content);
	cur_node = cur_node->next->next;

	if (0 != ::strcmp("PumpingDirection", (const char *)cur_node->name))
		return false;
	PumpingDirection = ::atoi((const char *)cur_node->children->content);
	cur_node = cur_node->next->next;

	if (0 != ::strcmp("GrooveType", (const char *)cur_node->name))
		return false;
	GrooveType = ::atoi((const char *)cur_node->children->content);
	cur_node = cur_node->next->next;

	if (0 != ::strcmp("Property", (const char *)cur_node->name))
		return false;

	xmlNode* prop_node = cur_node->children->next;

	switch (BearingType)
    {
        case 1:
			input_info->Parts[nIndex].Value[0] = BearingType;
			input_info->Parts[nIndex].Value[1] = 0.0;
			input_info->Parts[nIndex].Value[2] = 0.0;
			input_info->Parts[nIndex].Value[3] = 0.0;

			if (0 != ::strcmp("RadiusOfJournal", (const char *)prop_node->name))
				return false;
			input_info->Parts[nIndex].Value[4] = ::atof((const char *)prop_node->children->content);
			prop_node = prop_node->next->next;

			if (0 != ::strcmp("ClearanceOfJournal", (const char *)prop_node->name))
				return false;
			input_info->Parts[nIndex].Value[5] = ::atof((const char *)prop_node->children->content);
			prop_node = prop_node->next->next;

			if (0 != ::strcmp("LengthCenterLower", (const char *)prop_node->name))
				return false;
			input_info->Parts[nIndex].Value[6] = ::atof((const char *)prop_node->children->content);
			prop_node = prop_node->next->next;

			if (0 != ::strcmp("LengthCenterUpper", (const char *)prop_node->name))
				return false;
			input_info->Parts[nIndex].Value[7] = ::atof((const char *)prop_node->children->content);
			prop_node = prop_node->next->next;

			if (0 != ::strcmp("ZCoordinate", (const char *)prop_node->name))
				return false;
			input_info->Parts[nIndex].Value[8] = ::atof((const char *)prop_node->children->content);
			prop_node = prop_node->next->next;

			if (0 != ::strcmp("ReservoirDepth", (const char *)prop_node->name))
				return false;
			input_info->Parts[nIndex].Value[9] = ::atof((const char *)prop_node->children->content);
			prop_node = prop_node->next->next;

			if (0 != ::strcmp("EccentricityRatio", (const char *)prop_node->name))
				return false;
			input_info->Parts[nIndex].Value[10] = ::atof((const char *)prop_node->children->content);
			prop_node = prop_node->next->next;

			if (0 != ::strcmp("NumberOfZDivisionOfLower", (const char *)prop_node->name))
				return false;
			input_info->Parts[nIndex].Value[11] = ::atoi((const char *)prop_node->children->content);
			prop_node = prop_node->next->next;

			if (0 != ::strcmp("NumberOfZDivisionOfUpper", (const char *)prop_node->name))
				return false;
			input_info->Parts[nIndex].Value[12] = ::atoi((const char *)prop_node->children->content);
			prop_node = prop_node->next->next;

			if (0 != ::strcmp("ConnectingPartOfUpper", (const char *)prop_node->name))
				return false;
			input_info->Parts[nIndex].Value[13] = ::atoi((const char *)prop_node->children->content);
			prop_node = prop_node->next->next;

			if (0 != ::strcmp("ConnectingPositionOfUpper", (const char *)prop_node->name))
				return false;
			input_info->Parts[nIndex].Value[14] = ::atoi((const char *)prop_node->children->content);
			prop_node = prop_node->next->next;

			if (0 != ::strcmp("ConnectingPartOfLower", (const char *)prop_node->name))
				return false;
			input_info->Parts[nIndex].Value[15] = ::atoi((const char *)prop_node->children->content);
			prop_node = prop_node->next->next;

			if (0 != ::strcmp("ConnectingPositionOfLower", (const char *)prop_node->name))
				return false;
			input_info->Parts[nIndex].Value[16] = ::atoi((const char *)prop_node->children->content);
			prop_node = prop_node->next->next;

			input_info->Parts[nIndex].Value[17] = 0.0;
			input_info->Parts[nIndex].Value[18] = 0.0;
			input_info->Parts[nIndex].Value[19] = 0.0;
			input_info->Parts[nIndex].Value[20] = 0.0;
			input_info->Parts[nIndex].Value[21] = 0.0;
			input_info->Parts[nIndex].Value[22] = 0.0;
			input_info->Parts[nIndex].Value[23] = 0.0;
			input_info->Parts[nIndex].Value[24] = 0.0;
			input_info->Parts[nIndex].Value[25] = 0.0;
			input_info->Parts[nIndex].Value[26] = 0.0;
			input_info->Parts[nIndex].Value[27] = 0.0;
			break;
		case 2:
			input_info->Parts[nIndex].Value[0] = BearingType;
			input_info->Parts[nIndex].Value[1] = GrooveLocation;
			input_info->Parts[nIndex].Value[2] = PumpingDirection;
			input_info->Parts[nIndex].Value[3] = 0.0;

			if (0 != ::strcmp("RadiusOfJournal", (const char *)prop_node->name))
				return false;
			input_info->Parts[nIndex].Value[4] = ::atof((const char *)prop_node->children->content);
			prop_node = prop_node->next->next;

			if (0 != ::strcmp("ClearanceOfJournal", (const char *)prop_node->name))
				return false;
			input_info->Parts[nIndex].Value[5] = ::atof((const char *)prop_node->children->content);
			prop_node = prop_node->next->next;

			if (0 != ::strcmp("LengthCenterLower", (const char *)prop_node->name))
				return false;
			input_info->Parts[nIndex].Value[6] = ::atof((const char *)prop_node->children->content);
			prop_node = prop_node->next->next;

			if (0 != ::strcmp("LengthCenterUpper", (const char *)prop_node->name))
				return false;
			input_info->Parts[nIndex].Value[7] = ::atof((const char *)prop_node->children->content);
			prop_node = prop_node->next->next;

			if (0 != ::strcmp("ZCoordinate", (const char *)prop_node->name))
				return false;
			input_info->Parts[nIndex].Value[8] = ::atof((const char *)prop_node->children->content);
			prop_node = prop_node->next->next;

			if (0 != ::strcmp("NumberOfGrooves", (const char *)prop_node->name))
				return false;
			input_info->Parts[nIndex].Value[9] = ::atoi((const char *)prop_node->children->content);
			prop_node = prop_node->next->next;

			if (0 != ::strcmp("GrooveAngle", (const char *)prop_node->name))
				return false;
			input_info->Parts[nIndex].Value[10] = ::atof((const char *)prop_node->children->content);
			prop_node = prop_node->next->next;

			if (0 != ::strcmp("GrooveDepth", (const char *)prop_node->name))
				return false;
			input_info->Parts[nIndex].Value[11] = ::atof((const char *)prop_node->children->content);
			prop_node = prop_node->next->next;

			if (0 != ::strcmp("RatioOfGrooveToRidge", (const char *)prop_node->name))
				return false;
			input_info->Parts[nIndex].Value[12] = ::atof((const char *)prop_node->children->content);
			prop_node = prop_node->next->next;

			if (0 != ::strcmp("EccentricityRatio", (const char *)prop_node->name))
				return false;
			input_info->Parts[nIndex].Value[13] = ::atof((const char *)prop_node->children->content);
			prop_node = prop_node->next->next;

			if (0 != ::strcmp("NumberOfZDivisionOfLower", (const char *)prop_node->name))
				return false;
			input_info->Parts[nIndex].Value[14] = ::atoi((const char *)prop_node->children->content);
			prop_node = prop_node->next->next;

			if (0 != ::strcmp("NumberOfZDivisionOfUpper", (const char *)prop_node->name))
				return false;
			input_info->Parts[nIndex].Value[15] = ::atoi((const char *)prop_node->children->content);
			prop_node = prop_node->next->next;

			if (0 != ::strcmp("NumberOfXDivisionOfGroove", (const char *)prop_node->name))
				return false;
			input_info->Parts[nIndex].Value[16] = ::atoi((const char *)prop_node->children->content);
			prop_node = prop_node->next->next;

			if (0 != ::strcmp("NumberOfXDivisionOfRidge", (const char *)prop_node->name))
				return false;
			input_info->Parts[nIndex].Value[17] = ::atoi((const char *)prop_node->children->content);
			prop_node = prop_node->next->next;

			if (0 != ::strcmp("NumberOfAdditionalGrooves", (const char *)prop_node->name))
				return false;
			input_info->Parts[nIndex].Value[18] = ::atoi((const char *)prop_node->children->content);
			prop_node = prop_node->next->next;

			if (0 != ::strcmp("LengthOfAdditionalGroove", (const char *)prop_node->name))
				return false;
			input_info->Parts[nIndex].Value[19] = ::atof((const char *)prop_node->children->content);
			prop_node = prop_node->next->next;

			if (0 != ::strcmp("RatioOfGrooveToRidgeInAdditionalGroove", (const char *)prop_node->name))
				return false;
			input_info->Parts[nIndex].Value[20] = ::atof((const char *)prop_node->children->content);
			prop_node = prop_node->next->next;

			if (0 != ::strcmp("NumberOfZDivisionOfAdditionalGroove", (const char *)prop_node->name))
				return false;
			input_info->Parts[nIndex].Value[21] = ::atoi((const char *)prop_node->children->content);
			prop_node = prop_node->next->next;

			if (0 != ::strcmp("NumberOfXDivisionOfAdditionalGroove", (const char *)prop_node->name))
				return false;
			input_info->Parts[nIndex].Value[22] = ::atoi((const char *)prop_node->children->content);
			prop_node = prop_node->next->next;

			if (0 != ::strcmp("NumberOfXDivisionOfAdditionalRidge", (const char *)prop_node->name))
				return false;
			input_info->Parts[nIndex].Value[23] = ::atoi((const char *)prop_node->children->content);
			prop_node = prop_node->next->next;

			if (0 != ::strcmp("ConnectingPartOfUpper", (const char *)prop_node->name))
				return false;
			input_info->Parts[nIndex].Value[24] = ::atoi((const char *)prop_node->children->content);
			prop_node = prop_node->next->next;

			if (0 != ::strcmp("ConnectingPositionOfUpper", (const char *)prop_node->name))
				return false;
			input_info->Parts[nIndex].Value[25] = ::atoi((const char *)prop_node->children->content);
			prop_node = prop_node->next->next;

			if (0 != ::strcmp("ConnectingPartOfLower", (const char *)prop_node->name))
				return false;
			input_info->Parts[nIndex].Value[26] = ::atoi((const char *)prop_node->children->content);
			prop_node = prop_node->next->next;

			if (0 != ::strcmp("ConnectingPositionOfLower", (const char *)prop_node->name))
				return false;
			input_info->Parts[nIndex].Value[27] = ::atoi((const char *)prop_node->children->content);
			prop_node = prop_node->next->next;
			break;
		case 3:
			input_info->Parts[nIndex].Value[0] = BearingType;
			input_info->Parts[nIndex].Value[1] = 0.0;
			input_info->Parts[nIndex].Value[2] = 0.0;
			input_info->Parts[nIndex].Value[3] = 0.0;

			if (0 != ::strcmp("OuterRadiusOfThrust", (const char *)prop_node->name))
				return false;
			input_info->Parts[nIndex].Value[4] = ::atof((const char *)prop_node->children->content);
			prop_node = prop_node->next->next;

			if (0 != ::strcmp("ClearanceOfThrust", (const char *)prop_node->name))
				return false;
			input_info->Parts[nIndex].Value[5] = ::atof((const char *)prop_node->children->content);
			prop_node = prop_node->next->next;

			if (0 != ::strcmp("ZCoordinate", (const char *)prop_node->name))
				return false;
			input_info->Parts[nIndex].Value[6] = ::atof((const char *)prop_node->children->content);
			prop_node = prop_node->next->next;

			if (0 != ::strcmp("ReservoirDepth", (const char *)prop_node->name))
				return false;
			input_info->Parts[nIndex].Value[7] = ::atof((const char *)prop_node->children->content);
			prop_node = prop_node->next->next;

			if (0 != ::strcmp("NumberOfRDivision", (const char *)prop_node->name))
				return false;
			input_info->Parts[nIndex].Value[8] = ::atoi((const char *)prop_node->children->content);
			prop_node = prop_node->next->next;

			if (0 != ::strcmp("ConnectingPartOfUpper", (const char *)prop_node->name))
				return false;
			input_info->Parts[nIndex].Value[9] = ::atoi((const char *)prop_node->children->content);
			prop_node = prop_node->next->next;

			if (0 != ::strcmp("ConnectingPositionOfUpper", (const char *)prop_node->name))
				return false;
			input_info->Parts[nIndex].Value[10] = ::atoi((const char *)prop_node->children->content);
			prop_node = prop_node->next->next;

			if (0 != ::strcmp("ConnectingPartOfLower", (const char *)prop_node->name))
				return false;
			input_info->Parts[nIndex].Value[11] = ::atoi((const char *)prop_node->children->content);
			prop_node = prop_node->next->next;

			if (0 != ::strcmp("ConnectingPositionOfLower", (const char *)prop_node->name))
				return false;
			input_info->Parts[nIndex].Value[12] = ::atoi((const char *)prop_node->children->content);
			prop_node = prop_node->next->next;

			input_info->Parts[nIndex].Value[13] = 0.0;
			input_info->Parts[nIndex].Value[14] = 0.0;
			input_info->Parts[nIndex].Value[15] = 0.0;
			input_info->Parts[nIndex].Value[16] = 0.0;
			input_info->Parts[nIndex].Value[17] = 0.0;
			input_info->Parts[nIndex].Value[18] = 0.0;
			input_info->Parts[nIndex].Value[19] = 0.0;
			input_info->Parts[nIndex].Value[20] = 0.0;
			input_info->Parts[nIndex].Value[21] = 0.0;
			input_info->Parts[nIndex].Value[22] = 0.0;
			input_info->Parts[nIndex].Value[23] = 0.0;
			input_info->Parts[nIndex].Value[24] = 0.0;
			input_info->Parts[nIndex].Value[25] = 0.0;
			input_info->Parts[nIndex].Value[26] = 0.0;
			input_info->Parts[nIndex].Value[27] = 0.0;
			break;
		case 4:
			input_info->Parts[nIndex].Value[0] = BearingType;
			input_info->Parts[nIndex].Value[1] = GrooveLocation;
			input_info->Parts[nIndex].Value[2] = PumpingDirection;
			input_info->Parts[nIndex].Value[3] = GrooveType;

			if (0 != ::strcmp("InnerRadiusOfThrust", (const char *)prop_node->name))
				return false;
			input_info->Parts[nIndex].Value[4] = ::atof((const char *)prop_node->children->content);
			prop_node = prop_node->next->next;

			if (0 != ::strcmp("CenterRadiusOfThrust", (const char *)prop_node->name))
				return false;
			input_info->Parts[nIndex].Value[5] = ::atof((const char *)prop_node->children->content);
			prop_node = prop_node->next->next;

			if (0 != ::strcmp("OuterRadiusOfThrust", (const char *)prop_node->name))
				return false;
			input_info->Parts[nIndex].Value[6] = ::atof((const char *)prop_node->children->content);
			prop_node = prop_node->next->next;

			if (0 != ::strcmp("ClearanceOfThrust", (const char *)prop_node->name))
				return false;
			input_info->Parts[nIndex].Value[7] = ::atof((const char *)prop_node->children->content);
			prop_node = prop_node->next->next;

			if (0 != ::strcmp("ZCoordinate", (const char *)prop_node->name))
				return false;
			input_info->Parts[nIndex].Value[8] = ::atof((const char *)prop_node->children->content);
			prop_node = prop_node->next->next;

			if (0 != ::strcmp("NumberOfGrooves", (const char *)prop_node->name))
				return false;
			input_info->Parts[nIndex].Value[9] = ::atoi((const char *)prop_node->children->content);
			prop_node = prop_node->next->next;

			if (0 != ::strcmp("GrooveAngle", (const char *)prop_node->name))
				return false;
			input_info->Parts[nIndex].Value[10] = ::atof((const char *)prop_node->children->content);
			prop_node = prop_node->next->next;

			if (0 != ::strcmp("GrooveDepth", (const char *)prop_node->name))
				return false;
			input_info->Parts[nIndex].Value[11] = ::atof((const char *)prop_node->children->content);
			prop_node = prop_node->next->next;

			if (0 != ::strcmp("ReservoirDepth", (const char *)prop_node->name))
				return false;
			input_info->Parts[nIndex].Value[12] = ::atof((const char *)prop_node->children->content);
			prop_node = prop_node->next->next;

			if (0 != ::strcmp("RatioOfGrooveToRidge", (const char *)prop_node->name))
				return false;
			input_info->Parts[nIndex].Value[13] = ::atof((const char *)prop_node->children->content);
			prop_node = prop_node->next->next;

			if (0 != ::strcmp("NumberOfRDivisionOfInnerGroove", (const char *)prop_node->name))
				return false;
			input_info->Parts[nIndex].Value[14] = ::atoi((const char *)prop_node->children->content);
			prop_node = prop_node->next->next;

			if (0 != ::strcmp("NumberOfRDivisionOfOuterGroove", (const char *)prop_node->name))
				return false;
			input_info->Parts[nIndex].Value[15] = ::atoi((const char *)prop_node->children->content);
			prop_node = prop_node->next->next;

			if (0 != ::strcmp("NumberOfThetaDivisionOfGroove", (const char *)prop_node->name))
				return false;
			input_info->Parts[nIndex].Value[16] = ::atoi((const char *)prop_node->children->content);
			prop_node = prop_node->next->next;

			if (0 != ::strcmp("NumberOfThetaDivisionOfRidge", (const char *)prop_node->name))
				return false;
			input_info->Parts[nIndex].Value[17] = ::atoi((const char *)prop_node->children->content);
			prop_node = prop_node->next->next;

			if (0 != ::strcmp("WidthOfInnerPlain", (const char *)prop_node->name))
				return false;
			input_info->Parts[nIndex].Value[18] = ::atof((const char *)prop_node->children->content);
			prop_node = prop_node->next->next;

			if (0 != ::strcmp("WidthOfOuterPlain", (const char *)prop_node->name))
				return false;
			input_info->Parts[nIndex].Value[19] = ::atof((const char *)prop_node->children->content);
			prop_node = prop_node->next->next;

			if (0 != ::strcmp("DepthOfInnerPlain", (const char *)prop_node->name))
				return false;
			input_info->Parts[nIndex].Value[20] = ::atof((const char *)prop_node->children->content);
			prop_node = prop_node->next->next;

			if (0 != ::strcmp("DepthOfOuterPlain", (const char *)prop_node->name))
				return false;
			input_info->Parts[nIndex].Value[21] = ::atof((const char *)prop_node->children->content);
			prop_node = prop_node->next->next;

			if (0 != ::strcmp("NumberOfRDivisionOfInnerPlain", (const char *)prop_node->name))
				return false;
			input_info->Parts[nIndex].Value[22] = ::atoi((const char *)prop_node->children->content);
			prop_node = prop_node->next->next;

			if (0 != ::strcmp("NumberOfRDivisionOfOuterPlain", (const char *)prop_node->name))
				return false;
			input_info->Parts[nIndex].Value[23] = ::atoi((const char *)prop_node->children->content);
			prop_node = prop_node->next->next;

			if (0 != ::strcmp("ConnectingPartOfUpper", (const char *)prop_node->name))
				return false;
			input_info->Parts[nIndex].Value[24] = ::atoi((const char *)prop_node->children->content);
			prop_node = prop_node->next->next;

			if (0 != ::strcmp("ConnectingPositionOfUpper", (const char *)prop_node->name))
				return false;
			input_info->Parts[nIndex].Value[25] = ::atoi((const char *)prop_node->children->content);
			prop_node = prop_node->next->next;

			if (0 != ::strcmp("ConnectingPartOfLower", (const char *)prop_node->name))
				return false;
			input_info->Parts[nIndex].Value[26] = ::atoi((const char *)prop_node->children->content);
			prop_node = prop_node->next->next;

			if (0 != ::strcmp("ConnectingPositionOfLower", (const char *)prop_node->name))
				return false;
			input_info->Parts[nIndex].Value[27] = ::atoi((const char *)prop_node->children->content);
			prop_node = prop_node->next->next;
			break;
		case 5:
			input_info->Parts[nIndex].Value[0] = BearingType;
			input_info->Parts[nIndex].Value[1] = 0.0;
			input_info->Parts[nIndex].Value[2] = 0.0;
			input_info->Parts[nIndex].Value[3] = 0.0;

			if (0 != ::strcmp("InnerRadiusOfThrust", (const char *)prop_node->name))
				return false;
			input_info->Parts[nIndex].Value[4] = ::atof((const char *)prop_node->children->content);
			prop_node = prop_node->next->next;

			if (0 != ::strcmp("OuterRadiusOfThrust", (const char *)prop_node->name))
				return false;
			input_info->Parts[nIndex].Value[5] = ::atof((const char *)prop_node->children->content);
			prop_node = prop_node->next->next;

			if (0 != ::strcmp("ClearanceOfThrust", (const char *)prop_node->name))
				return false;
			input_info->Parts[nIndex].Value[6] = ::atof((const char *)prop_node->children->content);
			prop_node = prop_node->next->next;

			if (0 != ::strcmp("ZCoordinate", (const char *)prop_node->name))
				return false;
			input_info->Parts[nIndex].Value[7] = ::atof((const char *)prop_node->children->content);
			prop_node = prop_node->next->next;

			if (0 != ::strcmp("ReservoirDepth", (const char *)prop_node->name))
				return false;
			input_info->Parts[nIndex].Value[8] = ::atof((const char *)prop_node->children->content);
			prop_node = prop_node->next->next;

			if (0 != ::strcmp("NumberOfRDivision", (const char *)prop_node->name))
				return false;
			input_info->Parts[nIndex].Value[9] = ::atoi((const char *)prop_node->children->content);
			prop_node = prop_node->next->next;

			if (0 != ::strcmp("ConnectingPartOfUpper", (const char *)prop_node->name))
				return false;
			input_info->Parts[nIndex].Value[10] = ::atoi((const char *)prop_node->children->content);
			prop_node = prop_node->next->next;

			if (0 != ::strcmp("ConnectingPositionOfUpper", (const char *)prop_node->name))
				return false;
			input_info->Parts[nIndex].Value[11] = ::atoi((const char *)prop_node->children->content);
			prop_node = prop_node->next->next;

			if (0 != ::strcmp("ConnectingPartOfLower", (const char *)prop_node->name))
				return false;
			input_info->Parts[nIndex].Value[12] = ::atoi((const char *)prop_node->children->content);
			prop_node = prop_node->next->next;
			
			if (0 != ::strcmp("ConnectingPositionOfLower", (const char *)prop_node->name))
				return false;
			input_info->Parts[nIndex].Value[13] = ::atoi((const char *)prop_node->children->content);
			prop_node = prop_node->next->next;

			input_info->Parts[nIndex].Value[14] = 0.0;
			input_info->Parts[nIndex].Value[15] = 0.0;
			input_info->Parts[nIndex].Value[16] = 0.0;
			input_info->Parts[nIndex].Value[17] = 0.0;
			input_info->Parts[nIndex].Value[18] = 0.0;
			input_info->Parts[nIndex].Value[19] = 0.0;
			input_info->Parts[nIndex].Value[20] = 0.0;
			input_info->Parts[nIndex].Value[21] = 0.0;
			input_info->Parts[nIndex].Value[22] = 0.0;
			input_info->Parts[nIndex].Value[23] = 0.0;
			input_info->Parts[nIndex].Value[24] = 0.0;
			input_info->Parts[nIndex].Value[25] = 0.0;
			input_info->Parts[nIndex].Value[26] = 0.0;
			input_info->Parts[nIndex].Value[27] = 0.0;
			break;
	}

	if (0 != ::strcmp("RoughnessOfRotatingPart", (const char *)prop_node->name))
		return false;
	input_info->Parts[nIndex].Value[28] = ::atof((const char *)prop_node->children->content);
	prop_node = prop_node->next->next;

	if (0 != ::strcmp("RoughnessOfStationaryPart", (const char *)prop_node->name))
		return false;
	input_info->Parts[nIndex].Value[29] = ::atof((const char *)prop_node->children->content);
	prop_node = prop_node->next->next;

	if (0 != ::strcmp("RoughnessPattern", (const char *)prop_node->name))
		return false;
	input_info->Parts[nIndex].Value[30] = ::atof((const char *)prop_node->children->content);
	prop_node = prop_node->next->next;

	return true;
}

bool ReadMainData(xmlNode* node, _InputInfo* input_info)
{
	int PartCount = 0;
	int SelectRecirculationChannel = 0;

	xmlNode* cur_node = node->children->next;
	
	if (0 != ::strcmp("PartCount", (const char *)cur_node->name))
		return false;
	PartCount = ::atoi((const char *)cur_node->children->content);
	input_info->Main.PartCount = PartCount;	// input_info->Main.PartCount
	cur_node = cur_node->next->next;

	if (0 != ::strcmp("PartList", (const char *)cur_node->name))
		return false;

	input_info->Parts = new _PartInfo[PartCount];	// input_info->Parts

	xmlNode* ptinfo_node = cur_node->children->next;
	for (int i = 0; i < PartCount; ++i)
	{
		if (!ReadPartInfo(i, ptinfo_node, input_info))
			return false;
		ptinfo_node = ptinfo_node->next->next;
	}

	cur_node = cur_node->next->next;

	if (0 != ::strcmp("DesignParameter", (const char *)cur_node->name))
		return false;

	xmlNode* dpinfo_node = cur_node->children->next;
	
	if (0 != ::strcmp("RotatingSpeed", (const char *)dpinfo_node->name))
		return false;
	input_info->Main.RPM = ::atof((const char *)dpinfo_node->children->content);
	dpinfo_node = dpinfo_node->next->next;

	if (0 != ::strcmp("Viscosity", (const char *)dpinfo_node->name))
		return false;
	input_info->Main.Viscosity = ::atof((const char *)dpinfo_node->children->content);
	dpinfo_node = dpinfo_node->next->next;

	if (0 != ::strcmp("MisalignmentAngleXaxis", (const char *)dpinfo_node->name))
		return false;
	input_info->Main.tx = ::atof((const char *)dpinfo_node->children->content);
	dpinfo_node = dpinfo_node->next->next;

	if (0 != ::strcmp("MisalignmentAngleYaxis", (const char *)dpinfo_node->name))
		return false;
	input_info->Main.ty = ::atof((const char *)dpinfo_node->children->content);
	dpinfo_node = dpinfo_node->next->next;

	if (0 != ::strcmp("NumberOfTotalDivision", (const char *)dpinfo_node->name))
		return false;
	input_info->Main.Theta_div = ::atof((const char *)dpinfo_node->children->content);
	dpinfo_node = dpinfo_node->next->next;

	if (0 != ::strcmp("CavitationPressure", (const char *)dpinfo_node->name))
		return false;
	input_info->Main.Cavi_pressure = ::atof((const char *)dpinfo_node->children->content);
	dpinfo_node = dpinfo_node->next->next;

	if (0 != ::strcmp("RecirculationChannelFlag", (const char *)dpinfo_node->name))
		return false;
	input_info->Main.Recir_flag = ::atof((const char *)dpinfo_node->children->content);
	dpinfo_node = dpinfo_node->next->next;

	return true;
}

bool ReadRecirculationChannelInfo(int nIndex, double Density, int NumberOfRecirculationChannel, int SelectRecirculationChannel, xmlNode* node, _InputInfo* input_info)
{
	if (NULL == node || XML_ELEMENT_NODE != node->type)
		return false;
	
	input_info->RCs[nIndex].Value[0] = Density;
	input_info->RCs[nIndex].Value[1] = NumberOfRecirculationChannel;

	xmlNode* cur_node = node->children->next;

	if (0 != ::strcmp("RecirculationChannelInfoNo", (const char *)cur_node->name))
		return false;
	cur_node = cur_node->next->next;

	if (0 != ::strcmp("RadiusOfRecirculationChannel", (const char *)cur_node->name))
		return false;
	input_info->RCs[nIndex].Value[2] = ::atof((const char *)cur_node->children->content);
	cur_node = cur_node->next->next;

	if (0 != ::strcmp("LengthOfRecirculationChannel", (const char *)cur_node->name))
		return false;
	input_info->RCs[nIndex].Value[3] = ::atof((const char *)cur_node->children->content);
	cur_node = cur_node->next->next;

	if (0 != ::strcmp("HeightOfRecirculationChannel", (const char *)cur_node->name))
		return false;
	input_info->RCs[nIndex].Value[4] = ::atof((const char *)cur_node->children->content);
	cur_node = cur_node->next->next;

	if (0 != ::strcmp("SelectBearingTypeOfUpper", (const char *)cur_node->name))
		return false;
	input_info->RCs[nIndex].Value[5] = ::atoi((const char *)cur_node->children->content);
	cur_node = cur_node->next->next;

	if (0 != ::strcmp("Upper", (const char *)cur_node->name))
		return false;

	{
		xmlNode* upper_node = cur_node->children->next;

		if (0 != ::strcmp("PartNumber", (const char *)upper_node->name))
			return false;
		input_info->RCs[nIndex].Value[6] = ::atoi((const char *)upper_node->children->content);
		upper_node = upper_node->next->next;

		if (0 != ::strcmp("AngularPosition", (const char *)upper_node->name))
			return false;
		input_info->RCs[nIndex].Value[7] = ::atof((const char *)upper_node->children->content);
		upper_node = upper_node->next->next;

		if (0 != ::strcmp("Dtheta", (const char *)upper_node->name))
			return false;
		input_info->RCs[nIndex].Value[8] = ::atof((const char *)upper_node->children->content);
		upper_node = upper_node->next->next;

		if (0 != ::strcmp("InnerRadius", (const char *)upper_node->name) && 0 != ::strcmp("ZCoordinateOfLower", (const char *)upper_node->name))
			return false;
		input_info->RCs[nIndex].Value[9] = ::atof((const char *)upper_node->children->content);
		upper_node = upper_node->next->next;

		if (0 != ::strcmp("OuterRadius", (const char *)upper_node->name) && 0 != ::strcmp("ZCoordinateOfUpper", (const char *)upper_node->name))
			return false;
		input_info->RCs[nIndex].Value[10] = ::atof((const char *)upper_node->children->content);
		upper_node = upper_node->next->next;
	}

	cur_node = cur_node->next->next;
	
	if (0 != ::strcmp("SelectBearingTypeOfLower", (const char *)cur_node->name))
		return false;
	input_info->RCs[nIndex].Value[11] = ::atoi((const char *)cur_node->children->content);
	cur_node = cur_node->next->next;

	if (0 != ::strcmp("Lower", (const char *)cur_node->name))
		return false;

	{
		xmlNode* lower_node = cur_node->children->next;

		if (0 != ::strcmp("PartNumber", (const char *)lower_node->name))
			return false;
		input_info->RCs[nIndex].Value[12] = ::atoi((const char *)lower_node->children->content);
		lower_node = lower_node->next->next;

		if (0 != ::strcmp("AngularPosition", (const char *)lower_node->name))
			return false;
		input_info->RCs[nIndex].Value[13] = ::atof((const char *)lower_node->children->content);
		lower_node = lower_node->next->next;

		if (0 != ::strcmp("Dtheta", (const char *)lower_node->name))
			return false;
		input_info->RCs[nIndex].Value[14] = ::atof((const char *)lower_node->children->content);
		lower_node = lower_node->next->next;

		if (0 != ::strcmp("InnerRadius", (const char *)lower_node->name) && 0 != ::strcmp("ZCoordinateOfLower", (const char *)lower_node->name))
			return false;
		input_info->RCs[nIndex].Value[15] = ::atof((const char *)lower_node->children->content);
		lower_node = lower_node->next->next;

		if (0 != ::strcmp("OuterRadius", (const char *)lower_node->name) && 0 != ::strcmp("ZCoordinateOfUpper", (const char *)lower_node->name))
			return false;
		input_info->RCs[nIndex].Value[16] = ::atof((const char *)lower_node->children->content);
		lower_node = lower_node->next->next;
	}

	return true;
}

bool ReadRecirculationChannelData(xmlNode* node, _InputInfo* input_info)
{
	double Density = 0.0;
	int NumberOfRecirculationChannel = 0;
	int SelectRecirculationChannel = 0;

	xmlNode* cur_node = node->children->next;
	
	if (0 != ::strcmp("Density", (const char *)cur_node->name))
		return false;
	Density = ::atof((const char *)cur_node->children->content);
	cur_node = cur_node->next->next;
		
	if (0 != ::strcmp("NumberOfRecirculationChannel", (const char *)cur_node->name))
		return false;
	NumberOfRecirculationChannel = ::atoi((const char *)cur_node->children->content);
	input_info->Main.RecirCount = NumberOfRecirculationChannel;	// input_info->Main.RecirCount
	cur_node = cur_node->next->next;
		
	if (0 != ::strcmp("SelectRecirculationChannel", (const char *)cur_node->name))
		return false;
	SelectRecirculationChannel = ::atoi((const char *)cur_node->children->content);
	cur_node = cur_node->next->next;

	if (0 != ::strcmp("RecirculationChannelInfoList", (const char *)cur_node->name))
		return false;

	if (0 < NumberOfRecirculationChannel)
	{
		input_info->RCs = new _RecirInfo[NumberOfRecirculationChannel];	// input_info->RCs

		xmlNode* rcinfo_node = cur_node->children->next;
		for (int i = 0; i < NumberOfRecirculationChannel; ++i)
		{
			if (!ReadRecirculationChannelInfo(i, Density, NumberOfRecirculationChannel, SelectRecirculationChannel, rcinfo_node, input_info))
				return false;
			rcinfo_node = rcinfo_node->next->next;
		}
	}
	else
	{
		input_info->RCs = NULL;
	}

	return true;
}

bool ReadStaticAndDynamicAnalysisData(xmlNode* node, _AnalysisInfo* analysis_info)
{
	xmlNode* cur_node = node->children->next;

	if (0 != ::strcmp("InternalBoundaryCondition", (const char *)cur_node->name))
		return false;
	analysis_info->InternalBoundaryCondition = ::atoi((const char *)cur_node->children->content);
	cur_node = cur_node->next->next;

	if (0 != ::strcmp("ToleranceOfReynoldsBC", (const char *)cur_node->name))
		return false;
	analysis_info->ToleranceOfReynoldsBC = ::atof((const char *)cur_node->children->content);
	cur_node = cur_node->next->next;

	if (0 != ::strcmp("SelectAnalysisCase", (const char *)cur_node->name))
		return false;
	analysis_info->SelectAnalysisCase = ::atoi((const char *)cur_node->children->content);
	cur_node = cur_node->next->next;

	return true;
}

void FreeXML(xmlDoc* doc)
{
	xmlFreeDoc(doc);
	xmlCleanupParser();
}

int GetInputInfo(const char* strInputFilePath, _InputInfo* input_info, _AnalysisInfo* analysis_info)
{
	xmlDoc* doc = NULL;
	xmlNode* root_element = NULL;
	xmlNode* cur_node = NULL;

	LIBXML_TEST_VERSION

	doc = xmlReadFile(strInputFilePath, "utf-8", XML_PARSE_RECOVER);
	if (NULL == doc)
		return -1;

	root_element = xmlDocGetRootElement(doc);
	for (cur_node = root_element->children; cur_node; cur_node = cur_node->next)
	{
		if (XML_ELEMENT_NODE == cur_node->type)
		{
			if (0 == ::strcmp("MainData", (const char *)cur_node->name))
			{
				if (!ReadMainData(cur_node, input_info))
				{
					FreeXML(doc);
					return -2;
				}
			}
			else if (0 == ::strcmp("RecirculationChannelData", (const char *)cur_node->name))
			{
				if (!ReadRecirculationChannelData(cur_node, input_info))
				{
					FreeXML(doc);
					return -3;
				}
			}
			else if (0 == ::strcmp("StaticAndDynamicAnalysisData", (const char *)cur_node->name))
			{
				if (!ReadStaticAndDynamicAnalysisData(cur_node, analysis_info))
				{
					FreeXML(doc);
					return -4;
				}
			}
		}
	}

	FreeXML(doc);

	return 0;
}

void FreeInputInfo(_InputInfo* input_info)
{
	if (NULL != input_info)
	{
		if (NULL != input_info->Parts)
		{
			delete[] input_info->Parts;
			input_info->Parts = NULL;
		}
		if (NULL != input_info->RCs)
		{
			delete[] input_info->RCs;
			input_info->RCs = NULL;
		}
	}
}
