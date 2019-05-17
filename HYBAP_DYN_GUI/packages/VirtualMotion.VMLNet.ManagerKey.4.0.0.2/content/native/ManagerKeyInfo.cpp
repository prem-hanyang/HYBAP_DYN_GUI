#include "stdafx.h"

#include "ManagerKeyInfo.h"

namespace VM
{
	namespace Managed
	{
		namespace License
		{
			void InitializeLicense()
			{
				CompanyLicenseAttribute::Initialize(
					VMLICENSING_LICENSEMANAGER_KEY);
			}
			void InitializeLicense(System::String^ strOptions)
			{
				CompanyLicenseAttribute::Initialize(
					VMLICENSING_LICENSEMANAGER_KEY, strOptions);
			}
		}
	}
}
