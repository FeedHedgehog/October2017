using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace October.Component.BimViewer.Controls
{
    public partial class AxRenderUc : UserControl
    {
        public AxRenderUc()
        {
            InitializeComponent();

            string licenseContent = "<?xmlversion=\"1.0\"encoding=\"UTF-8\"?><license><productname>BIM3DViewer</productname><productcode>BIM3D-BIM3DViewer</productcode><productversion>1.0</productversion><clientname>BIM3DManager试用版</clientname><clientcomputercode>66F840AE17CC653B7095AB7D8D2A98AB</clientcomputercode><startdate>2017/11/22</startdate><enddate>2018/01/31</enddate><maxusercount>1</maxusercount><checkcode>A23293CBEEAE2F48D9ACBF3EF37699EAD72A74C9851B2605FCA35D413FC839D8211E378C097119BDE42B4FAFF91A352E03265F89E0D451F22ABA131F545C1B3CDC55B22C0E2B867B7868A867E86EF1AB5CE5F45588E0E22305F5C6177B0D0DA35C4FA69DDED1ABFD86589F212F44AFD117302A570A4FE12A948CA85CBDA25E0FFAF5249D548AA6DF6F035220339BC0FFD98D52904C8EAD8FD84E2086A0805A07DB72F747BF2095ED40CF4122D1D53C225F31B09D8CD52471B41985CE709C67A448104A5EFE54754EE7BD35C5C4D58A1C6F81052AAC3434625D2A3DE289B72A15758AC23835E372C52C852A90E199B5209BDA7053442CACC7DCDDD550C2733F1A4DBAE20A3E3A59974BEA5C65968AF95622DF5DF66CF69D1E1E9FA9D6E34045D5C0F45192DF313D315BCEF0FFB8D7B2BEE37B1AAEEF515FDD39DD687EDE38F64A567AF8909B56D87F7B760D417A942FCF1C5F9F5944B9833A1E4A378685C69218A619AEA833F67AF246A0CC316B27140128975EB4D68A3053E297D4C77D48FA82BC7599592EC9F1FB523D2C29A7F32DC96F91E9279476A4BD1CBCE28857BA98A08B378FBC7B267BA88825FDC888F49D84DE393E80690D1D35CEBF95CCCBE00EE237B350BC60573E5CF1E4655647EE938D0C98221F0D08ED358D95350099DEA91411E07B05E2B03ABCB454F5086EFA341F622ED10F9E78325B3E5FC3C532434A69291CF8434992BA5ADECC461070D6016A9C7C375A9D30377AAD3ADFA444DE2E5338283AA5B7918B3142E9AC86FFBD16BAD68BE4AA0A1285183155753592207692BCC6374C933E6B2485E5F1D7EDF51DA5447620CCAAC530FA808AA5F0AB77664927B21490007315AA43C8DB26FEF4D8313AD3FE8A6833B3802C64FE32366D6AF2386F075A0048A92AB946AE6BF473005360988D050FC81C044AB54BC811A64B931119CAF6069697115216BEB32A364C522E52528D781107AF2512B9F2FAB90A80A035AC0F9B90B71091A1E808AD45C74C7B2E1F589B09C2EC47B62E8944C0A1305116A890D4948DC5EB32D68000E09213E8CAA38CE953AD655F15674893565D08A91E3CB878F9530A68AB7458FE3ADB11</checkcode></license>";
            axBIM3DViewer1.VerifyLicense(licenseContent);
            axBIM3DViewer1.SetOptionAntiAlias(2);
            axBIM3DViewer1.SetOptionCullingThreshold(0);
            //固定帧率打开，开关默认打开
            axBIM3DViewer1.SetFramerate(true, 15, 120);
            axBIM3DViewer1.SetOptionSimpleShadow(true);
            axBIM3DViewer1.SetOptionBloom(false);
            axBIM3DViewer1.SetOptionStatic(false);
            axBIM3DViewer1.SetOptionBackplaneCulling(false);
            axBIM3DViewer1.SetOptionTransparent(0);
            axBIM3DViewer1.SetAxisSize(100);
            axBIM3DViewer1.SetMarkerPolygonEdgeCount(3);
            axBIM3DViewer1.SetOptionFastSilhouette(false);
            axBIM3DViewer1.SetOptionHighlightEdge(false, 3, 0, 255, 0, 0);
            axBIM3DViewer1.SetOptionHighlightFaceAlpha(false, 0);
            axBIM3DViewer1.SetOptionHighlightFaceColor(true, 0, 255, 0);
            axBIM3DViewer1.SetOptionHighlightInverseAlpha(false, 0);
            axBIM3DViewer1.SetMarkerTextSize(15);
            axBIM3DViewer1.SetMarkerTextColor(0, 0, 0);
            axBIM3DViewer1.SetMarkerLineColor(255, 0, 0);
            axBIM3DViewer1.SetMarkerLineWidth(6);
            axBIM3DViewer1.SetOptionModelConfig(2);
            axBIM3DViewer1.SetMarkerLineWidth(2);
            axBIM3DViewer1.ShowDebugInfo(false);
            axBIM3DViewer1.SetModelQuarantineAlpha(190);
            axBIM3DViewer1.SetOptionBackgroundGradient(92, 92, 92, 180, 180, 180);
            axBIM3DViewer1.SetAxisSize(0);
            axBIM3DViewer1.SetOptionBackgroundColor(255, 255, 234);
        }

        /// <summary>
        /// 标题：获取一个值，用以指示 System.ComponentModel.Component 当前是否处于设计模式。
        /// 描述：DesignMode 在 VS中存在 Bug ，使用下面的方式可以解决这个问题。
        /// </summary>
        protected new bool DesignMode
        {
            get
            {
                bool returnFlag = false;
#if DEBUG
                if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime)
                {
                    returnFlag = true;
                }
                else if (System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToUpper().Equals("DEVENV"))
                {
                    returnFlag = true;
                }
#endif
                return returnFlag;
            }
        }
    }
}
