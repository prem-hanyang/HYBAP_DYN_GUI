#include "CheckValue.h"

void Connection_check(int ***con_check,int N_part,int *type_ind)
{
	int i,k;

	for (k=1;k<=N_part;k++)
	{
		
		for (i=1;i<=2;i++) 
		{
			if (con_check[k][i][1] != 0 && con_check[k][i][1] != -1)
			{
				switch(con_check[k][i][2])
				{
				case 1:
					if (con_check[con_check[k][i][1]][2][1] != k)
					{
						cout<<" >>>>> Warning!! <<<<<"<<endl;
						cout<<" Check the connection of the part "<<k<<endl;
						cout<<" Press any key to exit"<<endl;
						_getch();
						exit(1);
					}
					break;
				case 2:
					if (con_check[con_check[k][i][1]][1][1] != k)
					{
						cout<<" >>>>> Warning!! <<<<<"<<endl;
						cout<<" Check the connection of the part "<<k<<endl;
						cout<<" Press any key to exit"<<endl;
						_getch();
						exit(1);
					}
					break;
				}
			}
		}
	}

	for (k=1;k<=N_part;k++)
	{
		for (i=1;i<=2;i++) 
		{
			if (con_check[k][i][1] != 0 && con_check[k][i][1] != -1)
			{
				if (type_ind[k]==2 || type_ind[k]==4)
				{
					if (type_ind[con_check[k][i][1]]==2 || type_ind[con_check[k][i][1]]==4)
					{
						cout<<" >>>>> Warning!! <<<<<"<<endl;
						cout<<" Check the connection."<<endl;
						cout<<" Part "<<k<<" and part "<<con_check[k][i][1]<<" are grooved sections"<<endl;
						cout<<" The grooved sections can't be connected with other grooved section."<<endl;
						cout<<" Press any key to exit"<<endl;
						_getch();
						exit(1);
					}
				}
			}
		}
	}
}

void main(void)
{
	int i;
	int ***con_check;
	int *type_ind;
	
	// connectivity check
	for(i=1;i<=data.MainData.PartCount;i++) 
	{
		type_ind[i] = data.MainData.PartList[i].BearingType;			
		switch(type_ind[i])
		{
		case 1:
			{
				PartPropertyPlainJournal prop1 = (data.MainData.PartList[i].Property as PartPropertyPlainJournal);
				con_check[i][1][1] = prop1.ConnectingPartOfUpper;
				con_check[i][1][2] = prop1.ConnectingPositionOfUpper;
				con_check[i][2][1] = prop1.ConnectingPartOfLower;
				con_check[i][2][2] = prop1.ConnectingPositionOfLower;
			}
			break;
		case 2:
			{
				PartPropertyGroovedJournal prop2 = (data.MainData.PartList[i].Property as PartPropertyGroovedJournal);
				con_check[i][1][1] = prop2.ConnectingPartOfUpper;
				con_check[i][1][2] = prop2.ConnectingPositionOfUpper;
				con_check[i][2][1] = prop2.ConnectingPartOfLower;
				con_check[i][2][2] = prop2.ConnectingPositionOfLower;
			}
			break;
		case 3:
			{
				PartPropertyPlainThrustClosedEnd prop3 = (data.MainData.PartList[i].Property as PartPropertyPlainThrustClosedEnd);
				con_check[i][1][1] = prop3.ConnectingPartOfUpper;
				con_check[i][1][2] = prop3.ConnectingPositionOfUpper;
				con_check[i][2][1] = prop3.ConnectingPartOfLower;
				con_check[i][2][2] = prop3.ConnectingPositionOfLower;
			}
			break;
		case 4:
			{
				PartPropertyGroovedThrustDonut prop4 = (data.MainData.PartList[i].Property as PartPropertyGroovedThrustDonut);
				con_check[i][1][1] = prop4.ConnectingPartOfUpper;
				con_check[i][1][2] = prop4.ConnectingPositionOfUpper;
				con_check[i][2][1] = prop4.ConnectingPartOfLower;
				con_check[i][2][2] = prop4.ConnectingPositionOfLower;
			}
			break;
		case 5:
			{
				PartPropertyPlainThrustDonut prop5 = (data.MainData.PartList[i].Property as PartPropertyPlainThrustDonut);
				con_check[i][1][1] = prop5.ConnectingPartOfUpper;
				con_check[i][1][2] = prop5.ConnectingPositionOfUpper;
				con_check[i][2][1] = prop5.ConnectingPartOfLower;
				con_check[i][2][2] = prop5.ConnectingPositionOfLower;

			}
			break;
		}
	}
	Connection_check(con_check,  data.MainData.PartCount,  type_ind);

	//  Part parameters check
	for(i=1;i<=data.MainData.PartCount;i++) 
	{
		switch(data.MainData.PartList[i].BearingType)
		{
		case 1:
			{
				PartPropertyPlainJournal prop1 = (data.MainData.PartList[i].Property as PartPropertyPlainJournal);
				
				if(prop1.ClearanceOfJournal > prop1.RadiusOfJournal)
				{
					cout<<" >>>>>Part ["<<i<<"]  warning!! <<<<<"<<endl;
					cout<<" Check the radius and clearance."<<endl;
					cout<<" Clearance is larger than radius."<<endl;
					cout<<" Clearance should be smaller than radius."<<endl;
				}
				if(prop1.ReservoirDepth > prop1.RadiusOfJournal)
				{
					cout<<" >>>>>Part ["<<i<<"]  warning!! <<<<<"<<endl;
					cout<<" Check the radius and reservoir depth."<<endl;
					cout<<" Reservoir depth is larger than radius."<<endl;
					cout<<" Reservoir depth should be smaller than radius."<<endl;
				}
				if(prop1.EccentricityRatio < 0 || prop1.EccentricityRatio >= 1)
				{
					cout<<" >>>>>Part ["<<i<<"]  warning!! <<<<<"<<endl;
					cout<<" Check the eccentricity ratio."<<endl;
					cout<<" Eccentricity ratio ["<<prop1.EccentricityRatio<<"] is invalid value"<<endl;
					cout<<" Eccentricity ratio should have a value betwwen 0 and 1."<<endl;					
				}
				if(prop1.NumberOfZDivisionOfLower < 2)
				{
					cout<<" >>>>>Part ["<<i<<"]  warning!! <<<<<"<<endl;
					cout<<" Check the number of z-division of loewr part."<<endl;
					cout<<" Number of z-division of loewr part ["<<prop1.NumberOfZDivisionOfLower<<"] is invalid value."<<endl;
					cout<<" Number of z-division of loewr part should be larger than 2."<<endl;	
				}
				if (prop1.NumberOfZDivisionOfUpper < 2)
				{
					cout<<" >>>>>Part ["<<i<<"]  warning!! <<<<<"<<endl;
					cout<<" Check the number of z-division of upper part."<<endl;
					cout<<" Number of z-division of upper part ["<<prop1.NumberOfZDivisionOfLower<<"] is invalid value."<<endl;
					cout<<" Number of z-division of upper part should be larger than 2."<<endl;	
				}
				if(prop1.RoughnessOfRotatingPart > prop1.ClearanceOfJournal || prop1.RoughnessOfStationaryPart > prop1.ClearanceOfJournal
					|| prop1.RoughnessOfRotatingPart < 0 || prop1.RoughnessOfStationaryPart < 0)
				{
					cout<<" >>>>>Part ["<<i<<"]  warning!! <<<<<"<<endl;
					cout<<" Check the roughness value."<<endl;
					cout<<" Roughness is invalid value."<<endl;
					cout<<" Roughness should smaller than clearance and have a positive number."<<endl;
				}

				// 음수 에러

				if (prop1.RadiusOfJournal < 0)
				{
					cout<<" >>>>>Part ["<<i<<"]  warning!! <<<<<"<<endl;
					cout<<" Check the radius."<<endl;
					cout<<" Radius ["<<prop1.RadiusOfJournal<<"] is nagative value."<<endl;
					cout<<" Radius should be positive value."<<endl;	
				}
				if (prop1.ClearanceOfJournal < 0)
				{
					cout<<" >>>>>Part ["<<i<<"]  warning!! <<<<<"<<endl;
					cout<<" Check the clearance."<<endl;
					cout<<" Clearance ["<<prop1.ClearanceOfJournal<<"] is nagative value."<<endl;
					cout<<" Clearance should be positive value."<<endl;	
				}
				if (prop1.LengthCenterLower < 0)
				{
					cout<<" >>>>>Part ["<<i<<"]  warning!! <<<<<"<<endl;
					cout<<" Check the Lower length."<<endl;
					cout<<" Lower length ["<<prop1.LengthCenterLower<<"] is nagative value."<<endl;
					cout<<" Lower length should be positive value."<<endl;	
				}
				if (prop1.LengthCenterUpper < 0)
				{
					cout<<" >>>>>Part ["<<i<<"]  warning!! <<<<<"<<endl;
					cout<<" Check the Upper length."<<endl;
					cout<<" Upper length ["<<prop1.LengthCenterUpper<<"] is nagative value."<<endl;
					cout<<" Upper length should be positive value."<<endl;	
				}
				if (prop1.ReservoirDepth < 0)
				{
					cout<<" >>>>>Part ["<<i<<"]  warning!! <<<<<"<<endl;
					cout<<" Check the reservoir depth."<<endl;
					cout<<" Reservoir depth ["<<prop1.ReservoirDepth<<"] is nagative value."<<endl;
					cout<<" Reservoir depth should be positive value."<<endl;	
				}
			}
			break;
		case 2:
			{
				PartPropertyGroovedJournal prop2 = (data.MainData.PartList[i].Property as PartPropertyGroovedJournal);	

				if(prop2.NumberOfAdditionalGrooves == 0)
				{
					if (data.MainData.DesignParameter.NumberOfTotalDivision !=
					prop2.NumberOfGrooves * (prop2.NumberOfXDivisionOfGroove + prop2.NumberOfXDivisionOfRidge) )
					{
						cout<<" >>>>>Part ["<<i<<"]  warning!! <<<<<"<<endl;
						cout<<" Check the number of total and x division."<<endl;
						cout<<" Number of total division is not matched with number of x-division."<<endl;
						cout<<" Total division = number of groove * (x-division of groove + x-division of ridge)"<<endl;
					}
				}
				else 
				{
					if (prop2.NumberOfGrooves != prop2.NumberOfAdditionalGrooves)
					{
						cout<<" >>>>>Part ["<<i<<"]  warning!! <<<<<"<<endl;
						cout<<" Check the number of additional grooves."<<endl;
						cout<<" Number of additional grooves is not matched with number of grooves."<<endl;
						cout<<" Number of additional grooves should be same with number of grooves."<<endl;
					}
					if (prop2.LengthOfAdditionalGroove >= prop2.LengthCenterUpper)
					{
						cout<<" >>>>>Part ["<<i<<"]  warning!! <<<<<"<<endl;
						cout<<" Check the length of the additional grooves."<<endl;
						cout<<" Length of the additional grooves is larger than upper length."<<endl;
						cout<<" Length of the additional grooves should be smaller than upper length."<<endl;
					}
					if(prop2.RatioOfGrooveToRidgeInAdditionalGroove < 0 || prop2.RatioOfGrooveToRidgeInAdditionalGroove > 1)
					{
						cout<<" >>>>>Part ["<<i<<"]  warning!! <<<<<"<<endl;
						cout<<" Check the ratio of groove to ridge in additional groove."<<endl;
						cout<<" Ratio of groove to ridge in additional groove is invalid value."<<endl;
						cout<<" Ratio of groove to ridge in additional groove should have a value betwwen 0 and 1."<<endl;
					}
					if (prop2.NumberOfZDivisionOfAdditionalGroove >= prop2.NumberOfZDivisionOfUpper)
					{
						cout<<" >>>>>Part ["<<i<<"]  warning!! <<<<<"<<endl;
						cout<<" Check the number of z-division of upper part in additional groove."<<endl;
						cout<<" Number of z-division of upper part in additional groove is larger than z-division of upper part."<<endl;
						cout<<" Number of z-division of upper part in additional groove should be smaller than z-division of upper part."<<endl;
					}
					if ((prop2.NumberOfXDivisionOfGroove + prop2.NumberOfXDivisionOfRidge) != 
						(prop2.NumberOfXDivisionOfAdditionalGroove + prop2.NumberOfXDivisionOfAdditionalRidge) )
					{
						cout<<" >>>>>Part ["<<i<<"]  warning!! <<<<<"<<endl;
						cout<<" Check the x-division of groove and ridge."<<endl;
						cout<<" Number of total division is not matched with number of total division of additional groove."<<endl;
						cout<<" x-division of groove and ridge = x-division of groove and ridge of additional groove"<<endl;
					}

					if (data.MainData.DesignParameter.NumberOfTotalDivision !=
					(prop2.NumberOfGrooves * (prop2.NumberOfXDivisionOfGroove + prop2.NumberOfXDivisionOfRidge) +
					prop2.NumberOfAdditionalGrooves * (prop2.NumberOfXDivisionOfAdditionalGroove + prop2.NumberOfXDivisionOfAdditionalRidge) ))
					{
						cout<<" >>>>>Part ["<<i<<"]  warning!! <<<<<"<<endl;
						cout<<" Check the number of total and x division."<<endl;
						cout<<" Number of total division is not matched with number of x-division."<<endl;
						cout<<" Total division = number of groove * (x-division of groove + x-division of ridge)"<<endl;
					}
				}

				
				if(prop2.ClearanceOfJournal > prop2.RadiusOfJournal)
				{
					cout<<" >>>>>Part ["<<i<<"]  warning!! <<<<<"<<endl;
					cout<<" Check the radius and clearance."<<endl;
					cout<<" Clearance is larger than radius."<<endl;
					cout<<" Clearance should be smaller than radius."<<endl;
				}
				if(prop2.NumberOfGrooves < 2)
				{
					cout<<" >>>>>Part ["<<i<<"]  warning!! <<<<<"<<endl;
					cout<<" Check the numberof grooves."<<endl;
					cout<<" Number of grooves is smaller than 2."<<endl;
					cout<<" Number of grooves should be larger than 2."<<endl;
				}
				if(prop2.GrooveAngle < 0 || prop2.GrooveAngle > 90)
				{
					cout<<" >>>>>Part ["<<i<<"]  warning!! <<<<<"<<endl;
					cout<<" Check the groove angle."<<endl;
					cout<<" Groove angle is invalid value."<<endl;
					cout<<" Groove angle should have a value betwwen 0 and 90."<<endl;
				}
				if(prop2.GrooveDepth > prop2.RadiusOfJournal)
				{
					cout<<" >>>>>Part ["<<i<<"]  warning!! <<<<<"<<endl;
					cout<<" Check the radius and groove depth."<<endl;
					cout<<" Groove depth is larger than radius."<<endl;
					cout<<" Groove depth should be smaller than radius."<<endl;
				}				
				if(prop2.RatioOfGrooveToRidge < 0 || prop2.RatioOfGrooveToRidge > 1)
				{
					cout<<" >>>>>Part ["<<i<<"]  warning!! <<<<<"<<endl;
					cout<<" Check the ratio of groove to ridge."<<endl;
					cout<<" Ratio of groove to ridge is invalid value."<<endl;
					cout<<" Ratio of groove to ridge should have a value betwwen 0 and 1."<<endl;
				}
				if(prop2.EccentricityRatio < 0 || prop2.EccentricityRatio >= 1)
				{
					cout<<" >>>>>Part ["<<i<<"]  warning!! <<<<<"<<endl;
					cout<<" Check the eccentricity ratio."<<endl;
					cout<<" Eccentricity ratio ["<<prop2.EccentricityRatio<<"] is invalid value"<<endl;
					cout<<" Eccentricity ratio should have a value betwwen 0 and 1."<<endl;		
				}
				if(prop2.NumberOfZDivisionOfLower < 2)
				{
					cout<<" >>>>>Part ["<<i<<"]  warning!! <<<<<"<<endl;
					cout<<" Check the number of z-division of loewr part."<<endl;
					cout<<" Number of z-division of loewr part ["<<prop2.NumberOfZDivisionOfLower<<"] is invalid value."<<endl;
					cout<<" Number of z-division of loewr part should be larger than 2."<<endl;	
				}
				if (prop2.NumberOfZDivisionOfUpper < 2)
				{
					cout<<" >>>>>Part ["<<i<<"]  warning!! <<<<<"<<endl;
					cout<<" Check the number of z-division of upper part."<<endl;
					cout<<" Number of z-division of upper part ["<<prop2.NumberOfZDivisionOfLower<<"] is invalid value."<<endl;
					cout<<" Number of z-division of upper part should be larger than 2."<<endl;
				}
				if(prop2.NumberOfXDivisionOfGroove < 2)
				{
					cout<<" >>>>>Part ["<<i<<"]  warning!! <<<<<"<<endl;
					cout<<" Check the number of x-division of groove."<<endl;
					cout<<" Number of x-division of groove ["<<prop2.NumberOfXDivisionOfGroove<<"] is invalid value."<<endl;
					cout<<" Number of x-division of groove should be larger than 2."<<endl;
				}
				if(prop2.NumberOfXDivisionOfRidge < 2)
				{
					cout<<" >>>>>Part ["<<i<<"]  warning!! <<<<<"<<endl;
					cout<<" Check the number of x-division of groove."<<endl;
					cout<<" Number of x-division of ridge ["<<prop2.NumberOfXDivisionOfRidge<<"] is invalid value."<<endl;
					cout<<" Number of x-division of ridge should be larger than 2."<<endl;
				}
				if(prop2.RoughnessOfRotatingPart > prop2.ClearanceOfJournal || prop2.RoughnessOfStationaryPart > prop2.ClearanceOfJournal
					|| prop2.RoughnessOfRotatingPart < 0 || prop2.RoughnessOfStationaryPart < 0)
				{
					cout<<" >>>>>Part ["<<i<<"]  warning!! <<<<<"<<endl;
					cout<<" Check the roughness value."<<endl;
					cout<<" Roughness is invalid value."<<endl;
					cout<<" Roughness should smaller than clearance and have a positive number."<<endl;
				}

				// 음수
				if (prop2.RadiusOfJournal < 0)
				{
					cout<<" >>>>>Part ["<<i<<"]  warning!! <<<<<"<<endl;
					cout<<" Check the radius."<<endl;
					cout<<" Radius ["<<prop2.RadiusOfJournal<<"] is nagative value."<<endl;
					cout<<" Radius should be positive value."<<endl;	
				}
				if(prop2.ClearanceOfJournal < 0)
				{
					cout<<" >>>>>Part ["<<i<<"]  warning!! <<<<<"<<endl;
					cout<<" Check the groove depth."<<endl;
					cout<<" Groove depth ["<<prop2.ClearanceOfJournal<<"] is nagative value."<<endl;
					cout<<" Groove depth should be positive value."<<endl;
				}
				if(prop2.LengthCenterLower < 0)
				{
					cout<<" >>>>>Part ["<<i<<"]  warning!! <<<<<"<<endl;
					cout<<" Check the lower length."<<endl;
					cout<<" Lower length ["<<prop2.LengthCenterLower<<"] is nagative value."<<endl;
					cout<<" Lower length should be positive value."<<endl;
				}
				if(prop2.LengthCenterUpper < 0)
				{
					cout<<" >>>>>Part ["<<i<<"]  warning!! <<<<<"<<endl;
					cout<<" Check the upper length."<<endl;
					cout<<" Upper length ["<<prop2.LengthCenterUpper<<"] is nagative value."<<endl;
					cout<<" Upper length should be positive value."<<endl;
				}
				if(prop2.GrooveDepth < 0)
				{
					cout<<" >>>>>Part ["<<i<<"]  warning!! <<<<<"<<endl;
					cout<<" Check the groove depth."<<endl;
					cout<<" Groove depth ["<<prop2.GrooveDepth<<"] is nagative value."<<endl;
					cout<<" Groove depth should be positive value."<<endl;
				}
				

			}
			break;
		case 3:
			{
				PartPropertyPlainThrustClosedEnd prop3 = (data.MainData.PartList[i].Property as PartPropertyPlainThrustClosedEnd);
				
				if(prop3.ReservoirDepth > prop3.ClearanceOfThrust)
				{
					cout<<" >>>>>Part ["<<i<<"]  warning!! <<<<<"<<endl;
					cout<<" Check the clearance and reservoir depth."<<endl;
					cout<<" Reservoir depth is larger than clearance."<<endl;
					cout<<" Reservoir depth should be smaller than clearance."<<endl;
				}
				if(prop3.NumberOfRDivision < 2)
				{
					cout<<" >>>>>Part ["<<i<<"]  warning!! <<<<<"<<endl;
					cout<<" Check the number of r-division."<<endl;
					cout<<" Number of r-division ["<<prop3.NumberOfRDivision<<"] is invalid value."<<endl;
					cout<<" Number of r-division should be larger than 2."<<endl;
				}
				if(prop3.RoughnessOfRotatingPart > prop3.ClearanceOfJournal || prop3.RoughnessOfStationaryPart > prop3.ClearanceOfJournal
					|| prop3.RoughnessOfRotatingPart < 0 || prop3.RoughnessOfStationaryPart < 0)
				{
					cout<<" >>>>>Part ["<<i<<"]  warning!! <<<<<"<<endl;
					cout<<" Check the roughness value."<<endl;
					cout<<" Roughness is invalid value."<<endl;
					cout<<" Roughness should smaller than clearance and have a positive number."<<endl;
				}

				// 음수
				if (prop3.OuterRadiusOfThrust < 0)
				{
					cout<<" >>>>>Part ["<<i<<"]  warning!! <<<<<"<<endl;
					cout<<" Check the outer radius."<<endl;
					cout<<" outer radius ["<<prop3.OuterRadiusOfThrust<<"] is nagative value."<<endl;
					cout<<" outer radius should be positive value."<<endl;	
				}
				if (prop3.ClearanceOfThrust < 0)
				{
					cout<<" >>>>>Part ["<<i<<"]  warning!! <<<<<"<<endl;
					cout<<" Check the clearance."<<endl;
					cout<<" Clearance ["<<prop3.ClearanceOfThrust<<"] is nagative value."<<endl;
					cout<<" Clearance should be positive value."<<endl;	
				}
				if (prop3.ReservoirDepth < 0)
				{
					cout<<" >>>>>Part ["<<i<<"]  warning!! <<<<<"<<endl;
					cout<<" Check the reservoir depth."<<endl;
					cout<<" Reservoir depth ["<<prop3.ReservoirDepth<<"] is nagative value."<<endl;
					cout<<" Reservoir depth should be positive value."<<endl;	
				}
			}
			break;
		case 4:
			{
				PartPropertyGroovedThrustDonut prop4 = (data.MainData.PartList[i].Property as PartPropertyGroovedThrustDonut);
				
				if (data.MainData.DesignParameter.NumberOfTotalDivision !=
					prop4.NumberOfGrooves * (prop4.NumberOfThetaDivisionOfGroove + prop4.NumberOfThetaDivisionOfRidge) )
				{
					cout<<" >>>>>Part ["<<i<<"]  warning!! <<<<<"<<endl;
					cout<<" Check the number of total and theta division."<<endl;
					cout<<" Number of total division is not matched with number of theta-division."<<endl;
					cout<<" Total division = number of groove * (theta-division of groove + theta-division of ridge)"<<endl;
				}
				
				if(prop4.CenterRadiusOfThrust != (prop4.InnerRadiusOfThrust + prop4.OuterRadiusOfThrust)/2)
				{
					cout<<" >>>>>Part ["<<i<<"]  warning!! <<<<<"<<endl;
					cout<<" Check the inner, center, and outer radius."<<endl;
					cout<<" Center radius is not same with average of inner and outer radius."<<endl;
					cout<<" Center radius should be same with average of inner and outer radius."<<endl;
				}
				if(prop4.InnerRadiusOfThrust > prop4.OuterRadiusOfThrust)
				{
					cout<<" >>>>>Part ["<<i<<"]  warning!! <<<<<"<<endl;
					cout<<" Check the inner and outer radius."<<endl;
					cout<<" Inner radius is larger than outer radius."<<endl;
					cout<<" Inner radius should be smaller than outer radius."<<endl;
				}				
				if(prop4.NumberOfGrooves < 2)
				{
					cout<<" >>>>>Part ["<<i<<"]  warning!! <<<<<"<<endl;
					cout<<" Check the numberof grooves."<<endl;
					cout<<" Number of grooves is smaller than 2."<<endl;
					cout<<" Number of grooves should be larger than 2."<<endl;
				}
				if(prop4.GrooveAngle < 0 || prop4.GrooveAngle > 90)
				{
					cout<<" >>>>>Part ["<<i<<"]  warning!! <<<<<"<<endl;
					cout<<" Check the groove angle."<<endl;
					cout<<" Groove angle is invalid value."<<endl;
					cout<<" Groove angle should have a value betwwen 0 and 90."<<endl;
				}
				if(prop4.GrooveDepth > prop4.OuterRadiusOfThrust)
				{
					cout<<" >>>>>Part ["<<i<<"]  warning!! <<<<<"<<endl;
					cout<<" Check the radius and groove depth."<<endl;
					cout<<" Groove depth is larger than radius of part "<<i<<" ."<<endl;
					cout<<" Groove depth should be smaller than radius."<<endl;
				}
				if(prop4.ReservoirDepth > prop4.ClearanceOfThrust)
				{
					cout<<" >>>>>Part ["<<i<<"]  warning!! <<<<<"<<endl;
					cout<<" Check the clearance and reservoir depth."<<endl;
					cout<<" Reservoir depth is larger than clearance."<<endl;
					cout<<" Reservoir depth should be smaller than clearance."<<endl;
				}
				if(prop4.RatioOfGrooveToRidge < 0 || prop4.RatioOfGrooveToRidge > 1)
				{
					cout<<" >>>>>Part ["<<i<<"]  warning!! <<<<<"<<endl;
					cout<<" Check the ratio of groove to ridge."<<endl;
					cout<<" Ratio of groove to ridge is invalid value."<<endl;
					cout<<" Ratio of groove to ridge should have a value betwwen 0 and 1."<<endl;
				}
				if(prop4.NumberOfRDivisionOfInnerGroove < 2)
				{
					cout<<" >>>>>Part ["<<i<<"]  warning!! <<<<<"<<endl;
					cout<<" Check the number of r-division of inner groove region."<<endl;
					cout<<" Number of r-division of inner groove region ["<<prop4.NumberOfRDivisionOfInnerGroove<<"] is invalid value."<<endl;
					cout<<" Number of r-division of inner groove region should be larger than 2."<<endl;	
				}
				else if(prop4.NumberOfRDivisionOfOuterGroove < 2)
				{
					cout<<" >>>>>Part ["<<i<<"]  warning!! <<<<<"<<endl;
					cout<<" Check the number of r-division of outer groove region."<<endl;
					cout<<" Number of r-division of outer groove region ["<<prop4.NumberOfRDivisionOfOuterGroove<<"] is invalid value."<<endl;
					cout<<" Number of r-division of outer groove region should be larger than 2."<<endl;
				} 
				if(prop4.NumberOfThetaDivisionOfGroove < 2)
				{
					cout<<" >>>>>Part ["<<i<<"]  warning!! <<<<<"<<endl;
					cout<<" Check the number of theta-division of groove region."<<endl;
					cout<<" Number of theta-division of groove region ["<<prop4.NumberOfThetaDivisionOfGroove<<"] is invalid value."<<endl;
					cout<<" Number of theta-division of groove region should be larger than 2."<<endl;
				}
				else if(prop4.NumberOfThetaDivisionOfRidge < 2)
				{
					cout<<" >>>>>Part ["<<i<<"]  warning!! <<<<<"<<endl;
					cout<<" Check the number of theta-division of ridge region."<<endl;
					cout<<" Number of theta-division of ridge region ["<<prop4.NumberOfThetaDivisionOfRidge<<"] is invalid value."<<endl;
					cout<<" Number of theta-division of ridge region should be larger than 2."<<endl;
				} 				
				if(prop4.WidthOfInnerPlain > 0 && prop4.NumberOfRDivisionOfInnerPlain < 2)
				{
					cout<<" >>>>>Part ["<<i<<"]  warning!! <<<<<"<<endl;
					cout<<" Check the number of r-division of inner plain region."<<endl;
					cout<<" Number of r-division of inner plain region ["<<prop4.NumberOfRDivisionOfInnerPlain<<"] is invalid value."<<endl;
					cout<<" Number of r-division of inner plain region should be larger than 2."<<endl;	
				}
				if(prop4.WidthOfOuterPlain > 0 && prop4.NumberOfRDivisionOfOuterPlain < 2)
				{
					cout<<" >>>>>Part ["<<i<<"]  warning!! <<<<<"<<endl;
					cout<<" Check the number of r-division of outer plain region."<<endl;
					cout<<" Number of r-division of outer plain region ["<<prop4.NumberOfRDivisionOfOuterPlain<<"] is invalid value."<<endl;
					cout<<" Number of r-division of outer plain region should be larger than 2."<<endl;	
				} 
				if(prop4.RoughnessOfRotatingPart > prop4.ClearanceOfJournal || prop4.RoughnessOfStationaryPart > prop4.ClearanceOfJournal
					|| prop4.RoughnessOfRotatingPart < 0 || prop4.RoughnessOfStationaryPart < 0)
				{
					cout<<" >>>>>Part ["<<i<<"]  warning!! <<<<<"<<endl;
					cout<<" Check the roughness value."<<endl;
					cout<<" Roughness is invalid value."<<endl;
					cout<<" Roughness should smaller than clearance and have a positive number."<<endl;
				}

				// 음수
				if (prop4.InnerRadiusOfThrust < 0)
				{
					cout<<" >>>>>Part ["<<i<<"]  warning!! <<<<<"<<endl;
					cout<<" Check the inner radius."<<endl;
					cout<<" Inner radius ["<<prop4.InnerRadiusOfThrust<<"] is nagative value."<<endl;
					cout<<" Inner radius should be positive value."<<endl;	
				}
				if (prop4.CenterRadiusOfThrust < 0)
				{
					cout<<" >>>>>Part ["<<i<<"]  warning!! <<<<<"<<endl;
					cout<<" Check the center radius."<<endl;
					cout<<" Center radius ["<<prop4.CenterRadiusOfThrust<<"] is nagative value."<<endl;
					cout<<" Center radius should be positive value."<<endl;	
				}
				if (prop4.OuterRadiusOfThrust < 0)
				{
					cout<<" >>>>>Part ["<<i<<"]  warning!! <<<<<"<<endl;
					cout<<" Check the outer radius."<<endl;
					cout<<" Outer radius ["<<prop4.OuterRadiusOfThrust<<"] is nagative value."<<endl;
					cout<<" Outer radius should be positive value."<<endl;	
				}
				if (prop4.GrooveDepth < 0)
				{
					cout<<" >>>>>Part ["<<i<<"]  warning!! <<<<<"<<endl;
					cout<<" Check the groove depth."<<endl;
					cout<<" Groove depth ["<<prop4.GrooveDepth<<"] is nagative value."<<endl;
					cout<<" Groove depth should be positive value."<<endl;	
				}
				if (prop4.ReservoirDepth < 0)
				{
					cout<<" >>>>>Part ["<<i<<"]  warning!! <<<<<"<<endl;
					cout<<" Check the reservoir depth."<<endl;
					cout<<" Reservoir depth ["<<prop4.ReservoirDepth<<"] is nagative value."<<endl;
					cout<<" Reservoir depth should be positive value."<<endl;	;	
				}
				if (prop4.WidthOfInnerPlain < 0)
				{
					cout<<" >>>>>Part ["<<i<<"]  warning!! <<<<<"<<endl;
					cout<<" Check the width of inner plain."<<endl;
					cout<<" Width of inner plain ["<<prop4.WidthOfInnerPlain<<"] is nagative value."<<endl;
					cout<<" Width of inner plain should be positive value."<<endl;	
				}
				if (prop4.WidthOfOuterPlain < 0)
				{
					cout<<" >>>>>Part ["<<i<<"]  warning!! <<<<<"<<endl;
					cout<<" Check the width of outer plain."<<endl;
					cout<<" Width of outer plain ["<<prop4.WidthOfOuterPlain<<"] is nagative value."<<endl;
					cout<<" Width of outer plain should be positive value."<<endl;	
				}
				if (prop4.DepthOfInnerPlain < 0)
				{
					cout<<" >>>>>Part ["<<i<<"]  warning!! <<<<<"<<endl;
					cout<<" Check the depth of inner plain."<<endl;
					cout<<" Depth of inner plain ["<<prop4.DepthOfInnerPlain<<"] is nagative value."<<endl;
					cout<<" Depth of inner plain should be positive value."<<endl;	
				}
				if (prop4.DepthOfOuterPlain  < 0)
				{
					cout<<" >>>>>Part ["<<i<<"]  warning!! <<<<<"<<endl;
					cout<<" Check the depth of outer plain."<<endl;
					cout<<" Depth of outer plain ["<<prop4.DepthOfOuterPlain<<"] is nagative value."<<endl;
					cout<<" Depth of outer plain should be positive value."<<endl;	
				}
			}
			break;
		case 5:
			{
				PartPropertyPlainThrustDonut prop5 = (data.MainData.PartList[i].Property as PartPropertyPlainThrustDonut);

				if(prop5.InnerRadiusOfThrust > prop5.OuterRadiusOfThrust)
				{
					cout<<" >>>>>Part ["<<i<<"]  warning!! <<<<<"<<endl;
					cout<<" Check the inner and outer radius."<<endl;
					cout<<" Inner radius is larger than outer radius."<<endl;
					cout<<" Inner radius should be smaller than outer radius."<<endl;
				}
				if(prop5.ReservoirDepth > prop5.ClearanceOfThrust)
				{
					cout<<" >>>>>Part ["<<i<<"]  warning!! <<<<<"<<endl;
					cout<<" Check the clearance and reservoir depth."<<endl;
					cout<<" Reservoir depth is larger than clearance."<<endl;
					cout<<" Reservoir depth should be smaller than clearance."<<endl;
				}
				if(prop5.NumberOfRDivision < 2)
				{
					cout<<" >>>>>Part ["<<i<<"]  warning!! <<<<<"<<endl;
					cout<<" Check the number of r-division."<<endl;
					cout<<" Number of r-division ["<<prop5.NumberOfRDivision<<"] is invalid value."<<endl;
					cout<<" Number of r-division should be larger than 2."<<endl;
				}
				if(prop5.RoughnessOfRotatingPart > prop5.ClearanceOfJournal || prop5.RoughnessOfStationaryPart > prop5.ClearanceOfJournal
					|| prop5.RoughnessOfRotatingPart < 0 || prop5.RoughnessOfStationaryPart < 0)
				{
					cout<<" >>>>>Part ["<<i<<"]  warning!! <<<<<"<<endl;
					cout<<" Check the roughness value."<<endl;
					cout<<" Roughness is invalid value."<<endl;
					cout<<" Roughness should smaller than clearance and have a positive number."<<endl;
				}
				
				// 음수
				if (prop5.InnerRadiusOfThrust < 0)
				{
					cout<<" >>>>>Part ["<<i<<"]  warning!! <<<<<"<<endl;
					cout<<" Check the inner radius."<<endl;
					cout<<" Inner radius ["<<prop5.InnerRadiusOfThrust<<"] is nagative value."<<endl;
					cout<<" Inner radius should be positive value."<<endl;	
				}				
				if (prop5.OuterRadiusOfThrust < 0)
				{
					cout<<" >>>>>Part ["<<i<<"]  warning!! <<<<<"<<endl;
					cout<<" Check the outer radius."<<endl;
					cout<<" Outer radius ["<<prop5.OuterRadiusOfThrust<<"] is nagative value."<<endl;
					cout<<" Outer radius should be positive value."<<endl;	
				}
				if (prop5.ReservoirDepth < 0)
				{
					cout<<" >>>>>Part ["<<i<<"]  warning!! <<<<<"<<endl;
					cout<<" Check the reservoir depth."<<endl;
					cout<<" Reservoir depth ["<<prop5.ReservoirDepth<<"] is nagative value."<<endl;
					cout<<" Reservoir depth should be positive value."<<endl;	;	
				}
			}
			break;
		}
	}


}



