using System;
using System.Windows;
using VM.Managed.License;

namespace HYBAP
{
    public static class VM_LicenseChecker
    {
        internal static void VM_CheckLicense()
        {
            LicenseManagerInitializer.Initialize();
            // check license here
            System.Reflection.Assembly assem = System.Reflection.Assembly.GetEntryAssembly();
            object[] arAttrLic = assem.GetCustomAttributes(typeof(VM.Managed.License.ILicense), false);
            if (null == arAttrLic || 0 == arAttrLic.Length)
                throw new VM.Managed.License.LicenseException(string.Format(HYBAP.Properties.Resources.MSG_NoLicense, assem.FullName));

            ILicense lic = arAttrLic[0] as ILicense;
            if (!typeof(VM.Managed.License.CompanyLicenseAttribute).IsInstanceOfType(lic) &&
                !typeof(VM.Managed.License.OpenLicenseAttribute).IsInstanceOfType(lic))
                throw new VM.Managed.License.LicenseException(string.Format(HYBAP.Properties.Resources.MSG_UnknownLicense
                    , lic.LicenseType.ToString()
                    , assem.FullName));


            if (!lic.IsLicensed)
            {
                throw new VM.Managed.License.LicenseException(GetLicenseErrorMessage(lic));
            }
            VM.Managed.License.CompanyLicenseAttribute licCo = lic as CompanyLicenseAttribute;
            if (null != licCo && licCo.IsDemo)
            {
                string strMesFormat =
                    string.Format(HYBAP.Properties.Resources.ID_INFORM_DemoMessage, licCo.ExpireDate.ToString());
                string strCaption = string.Format(HYBAP.Properties.Resources.ID_INFORM_Caption, assem.FullName);

                MessageBox.Show(strMesFormat.Replace("\\n", "\n"),
                    strCaption,
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
            }
        }

        private static string GetLicenseErrorMessage(ILicense lic)
        {
            System.Diagnostics.Debug.Assert(false == lic.IsLicensed);
            string strErrorMsg = string.Empty;
            string strToolkitName = string.Empty;
            //string strToolkitInfoPath = VM.Managed.CheckLicenseManager.GetToolkitInfoPath();

            if (lic is CompanyLicenseAttribute)
            {
                CompanyLicenseAttribute attr = lic as CompanyLicenseAttribute;

                //ToolkitStructure.ToolkitInfo info = null;
                //try
                //{
                //    info = ToolkitStructure.ToolkitUtility.Open(@"./../Toolkit Manager/ToolkitInfo.xml");
                //}
                //catch (System.Exception)
                //{
                //}

                //if (null != info)
                //{
                //    foreach (ToolkitStructure.Toolkit toolkit in info.ToolkitList)
                //    {
                //        foreach (ToolkitStructure.Feature feature in toolkit.FeatureList)
                //        {
                //            if (feature.ID.Equals(attr.Name))
                //                strToolkitName = toolkit.ID;
                //        }
                //    }
                //}

                strToolkitName = "HYBAP";
                strErrorMsg = string.Format(HYBAP.Properties.Resources.MSG_InvalidLicense
                , strToolkitName
                , attr.Name);
            }
            else if (lic is OpenLicenseAttribute)
            {
                // Open License 는 Key가 있는 경우 DFPRE_API_RUNTIME Feature 사용하면 DAFUL/Core 라이세스에 포함하며, Core 라이센스는 사용자가 Control 할 수 없으므로, 
                // 오류 발생 시 DAFUL_API_DEVELOPMENT 라이센스 오류로 간주한다. 
                // Open License는 License Name 정보를 가져 올 수 없으므로 이와 같이 코드 함.
                OpenLicenseAttribute attr = lic as OpenLicenseAttribute;
                strErrorMsg = string.Format(HYBAP.Properties.Resources.ID_INFORM_DemoMessage
                , "DAFUL_API_DEVELOPMENT"
                , "DFPRE_API_DEVELOPMENT");
            }

            return strErrorMsg;
        }
    }
}
