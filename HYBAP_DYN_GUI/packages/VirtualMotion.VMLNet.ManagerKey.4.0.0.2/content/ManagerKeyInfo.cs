using VM.Managed.Licnese;
namespace VM.Managed.License
{
	class LicenseManagerInitializer
	{
		static string Key{
			get
			{
				return ""
				;
			}
		}
		public static void Initialize()
		{
			CompanyLicenseAttribute.Initialize(
				Key
			);
		}
		public static void Initialize(string strArgument)
		{
			CompanyLicenseAttribute.Initialize(
				Key, strArgument
			);
		}
	}
}
