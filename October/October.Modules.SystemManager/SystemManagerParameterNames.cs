using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace October.Modules.SystemManager
{
    public class SystemManagerParameterNames
    {
        #region User
        public readonly static string UserList = "UserList";
        public readonly static string UserDetails = "UserDetails";
        public readonly static string UserEdit = "UserEdit";
        public readonly static string PersonalInfo = "PersonalInfo";
        public readonly static string PasswordSettings = "PasswordSettings";
        public readonly static string UserId = "UserId";
        #endregion

        #region Company管线单位

        public readonly static string CompanyList = "CompanyList";

        public readonly static string CompanyDetails = "CompanyDetails";

        public readonly static string CompanyEdit = "CompanyEdit";

        #endregion

        #region Role 角色

        public readonly static string RoleList = "RoleList";

        public readonly static string RoleDetails = "RoleDetails";

        public readonly static string RoleEdit = "RoleEdit";

        public readonly static string RolePrivilegeEdit = "RolePrivilegeEdit";

        #endregion

        #region 设备图片资源管理
        public readonly static string ResourceManage = "ResourceManage";      
        #endregion

        #region 字典管理
        public readonly static string DictionaryManage = "DictionaryManage";
        public readonly static string DictionaryEdit = "DictionaryEdit";
        public readonly static string DictionaryId= "DictionaryId";
        public readonly static string DictionaryParent = "DictionaryParent";
        #endregion

        #region 模型管理

        public readonly static string ModelList = "ModelList";        

        public readonly static string ModelEdit = "ModelEdit";

        public readonly static string ModelConfig = "ModelConfig";

        #endregion

        #region 资源权限管理
        public readonly static string PrivilegeList = "PrivilegeList";
        public readonly static string PrivilegeDetails = "PrivilegeDetails";
        public readonly static string PrivilegeEdit = "PrivilegeEdit";
        public readonly static string PrivilegeId = "PrivilegeId";
        public readonly static string PrivilegeParent = "PrivilegeParent";
        #endregion

        #region 设备二维码管理
        public readonly static string DeviceQRCodeManage = "DeviceQRCodeManage";
        #endregion

        #region 系统配置管理
        public readonly static string SystemConfigure = "SystemConfigure";
        #endregion

        #region 系统公告
        public readonly static string SystemNotice = "SystemNotice";
        public readonly static string SystemNoticeEdit = "SystemNoticeEdit";
        public readonly static string SystemNoticeId = "SystemNoticeId";
        public readonly static string SystemNoticeDetails = "SystemNoticeDetails";
        #endregion

        #region 部件分类
        public readonly static string PartType = "PartType";
        public readonly static string PartTypeEdit = "PartTypeEdit";
        public readonly static string PartTypeId = "PartTypeId";
        public readonly static string PartTypeParent = "PartTypeParent";
        #endregion

        #region 模型编码映射
        public readonly static string ModalCodingMap = "ModalCodingMap";
        public readonly static string ModalCodingMapEdit = "ModalCodingMapEdit";
        public readonly static string ModalCodingMapObj = "ModalCodingMapObj";
        public readonly static string PlatformDevice = "PlatformDevice";
        #endregion
    }
}
