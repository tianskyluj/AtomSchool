using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Text;
using Spring.Web.Mvc;
using Spring.Context;
using Spring.Context.Support;
using Service;
using System.Data;
using Atom.Common;

namespace WebSite
{
    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : SpringMvcApplication
    {
        private static log4net.ILog logger = log4net.LogManager.GetLogger("Logger");

        protected override void Application_Start(object sender, EventArgs e)
        {
            //初始化log4net
            log4net.Config.XmlConfigurator.Configure();

            base.Application_Start(sender, e);

            this.SetInitAccount();

            this.SetGlobalSetting();

            this.LoadControllerAndAction();

            this.LoadSystemModel();

            this.LoadTaskLevel();
            this.LoadTaskState();
            this.LoadApplyType();
            this.LoadCustomType();
            this.LoadMaintainMethod();
            this.LoadMaintainType();
            this.LoadRightsType();
        }

        /// <summary>
        /// 设置初始账号
        /// </summary>
        private void SetInitAccount()
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            IUserInfoManager manger = (IUserInfoManager)cxt.GetObject("Manager.UserInfo");

            const string account = "admin";
            var user = manger.Get(account);
            if (user == null)
            {
                user = new Domain.UserInfo
                {
                    Account = account,
                    Name = "管理员",
                    ID = Guid.NewGuid(),
                    CreateTime = DateTime.Now,
                    UpdateTime = DateTime.Now,
                    IsEnabled = true,
                    IsAdmin = true
                };

                manger.Save(user);
            }
        }

        /// <summary>
        /// 设置初始全局变量
        /// </summary>
        private void SetGlobalSetting()
        {
            IApplicationContext cxt = ContextRegistry.GetContext();
            IGlobalSettingManager manger = (IGlobalSettingManager)cxt.GetObject("Manager.GlobalSetting");
            
            var global = manger.LoadAll().FirstOrDefault();
            if (global == null)
            {
                global = new Domain.GlobalSetting
                {
                    ID = Guid.NewGuid(),
                    CompanyName = "原子科技"
                };
                manger.Save(global);
            }
        }

        /// <summary>
        /// 按config文件夹中的viewModel.xml配置文件加载系统模块
        /// </summary>
        private void LoadSystemModel()
        {
            string xmlPath = "~/Config/ViewModel.xml";
            IApplicationContext cxt = ContextRegistry.GetContext();
            ISystemModelManager manger = (ISystemModelManager)cxt.GetObject("Manager.SystemModel");
            IList<Domain.SystemModel> modelList = manger.LoadAll();
            if (modelList.Count == 0)
            {
                //manger.LoadSystemModelWithXML();
                // 把xml文件转换成dataSet
                Atom.Common.XML.XMLProcess xmlProcess = new Atom.Common.XML.XMLProcess();
                DataSet xmlDS = xmlProcess.GetDataSetByXml(xmlPath);
                // 生成目录
                for (int i = 0; i < xmlDS.Tables[0].Rows.Count; i++)
                {
                    int DirectId = xmlDS.Tables[0].Rows[i]["Direct_Id"].ToInt();
                    Guid guid = manger.FastAddSystemModel(new Guid(), "", xmlDS.Tables[0].Rows[i]["Name"].ToString(), i, xmlDS.Tables[0].Rows[i]["Icon"].ToString(), xmlDS.Tables[0].Rows[i]["ShortName"].ToString());
                    // 生成页面
                    DataRow[] drs = xmlDS.Tables[1].Select("Direct_Id=" + DirectId.ToStr());
                    for (int j = 0; j < drs.Length; j++)
                    {
                        manger.FastAddSystemModel(guid, drs[j]["value"].ToString(), drs[j]["Name"].ToString(), j, "", drs[j]["ShortName"].ToString());
                    }
                }
            }
        }

        /// <summary>
        /// 按config文件夹中的TaskLevel.xml配置文件加任务等级
        /// </summary>
        private void LoadTaskLevel()
        {
            string xmlPath = "~/Config/TaskLevel.xml";
            IApplicationContext cxt = ContextRegistry.GetContext();
            ITaskLevelManager manger = (ITaskLevelManager)cxt.GetObject("Manager.TaskLevel");
            IList<Domain.TaskLevel> taskLevelList = manger.LoadAll();
            if (taskLevelList.Count == 0)
            {
                //manger.LoadSystemModelWithXML();
                // 把xml文件转换成dataSet
                Atom.Common.XML.XMLProcess xmlProcess = new Atom.Common.XML.XMLProcess();
                DataSet xmlDS = xmlProcess.GetDataSetByXml(xmlPath);
                // 生成目录
                for (int i = 0; i < xmlDS.Tables[0].Rows.Count; i++)
                {
                    Domain.TaskLevel entity = new Domain.TaskLevel();
                    entity.ID = Guid.NewGuid();
                    entity.LevelName = xmlDS.Tables[0].Rows[i]["name"].ToStr();
                    entity.OrderIndex = xmlDS.Tables[0].Rows[i]["orderIndex"].ToInt();
                    manger.Save(entity);
                }
            }
        }

        /// <summary>
        /// 按config文件夹中的TaskState.xml配置文件加任务等级
        /// </summary>
        private void LoadTaskState()
        {
            string xmlPath = "~/Config/TaskState.xml";
            IApplicationContext cxt = ContextRegistry.GetContext();
            ITaskStateManager manger = (ITaskStateManager)cxt.GetObject("Manager.TaskState");
            IList<Domain.TaskState> taskStateList = manger.LoadAll();
            if (taskStateList.Count == 0)
            {
                //manger.LoadSystemModelWithXML();
                // 把xml文件转换成dataSet
                Atom.Common.XML.XMLProcess xmlProcess = new Atom.Common.XML.XMLProcess();
                DataSet xmlDS = xmlProcess.GetDataSetByXml(xmlPath);
                // 生成目录
                for (int i = 0; i < xmlDS.Tables[0].Rows.Count; i++)
                {
                    Domain.TaskState entity = new Domain.TaskState();
                    entity.ID = Guid.NewGuid();
                    entity.StateName = xmlDS.Tables[0].Rows[i]["name"].ToStr();
                    entity.OrderIndex = xmlDS.Tables[0].Rows[i]["orderIndex"].ToInt();
                    manger.Save(entity);
                }
            }
        }

        /// <summary>
        /// 按config文件夹中的ApplyType.xml配置文件加任务等级
        /// </summary>
        private void LoadApplyType()
        {
            string xmlPath = "~/Config/ApplyType.xml";
            IApplicationContext cxt = ContextRegistry.GetContext();
            IApplyTypeManager manger = (IApplyTypeManager)cxt.GetObject("Manager.ApplyType");
            IList<Domain.ApplyType> applyTypeList = manger.LoadAll();
            if (applyTypeList.Count == 0)
            {
                //manger.LoadSystemModelWithXML();
                // 把xml文件转换成dataSet
                Atom.Common.XML.XMLProcess xmlProcess = new Atom.Common.XML.XMLProcess();
                DataSet xmlDS = xmlProcess.GetDataSetByXml(xmlPath);
                // 生成目录
                for (int i = 0; i < xmlDS.Tables[0].Rows.Count; i++)
                {
                    Domain.ApplyType entity = new Domain.ApplyType();
                    entity.ID = Guid.NewGuid();
                    entity.ApplyTypeName = xmlDS.Tables[0].Rows[i]["name"].ToStr();
                    entity.Flow = new Domain.Flow();
                    entity.OrderIndex = xmlDS.Tables[0].Rows[i]["orderIndex"].ToInt();
                    manger.Save(entity);
                }
            }
        }

        /// <summary>
        /// 按config文件夹中的CustomType.xml配置文件加任务等级
        /// </summary>
        private void LoadCustomType()
        {
            string xmlPath = "~/Config/CustomType.xml";
            IApplicationContext cxt = ContextRegistry.GetContext();
            ICustomTypeManager manger = (ICustomTypeManager)cxt.GetObject("Manager.CustomType");
            IList<Domain.CustomType> customTypeList = manger.LoadAll();
            if (customTypeList.Count == 0)
            {
                //manger.LoadSystemModelWithXML();
                // 把xml文件转换成dataSet
                Atom.Common.XML.XMLProcess xmlProcess = new Atom.Common.XML.XMLProcess();
                DataSet xmlDS = xmlProcess.GetDataSetByXml(xmlPath);
                // 生成目录
                for (int i = 0; i < xmlDS.Tables[0].Rows.Count; i++)
                {
                    Domain.CustomType entity = new Domain.CustomType();
                    entity.ID = Guid.NewGuid();
                    entity.TypeName = xmlDS.Tables[0].Rows[i]["name"].ToStr();
                    entity.OrderIndex = xmlDS.Tables[0].Rows[i]["orderIndex"].ToInt();
                    manger.Save(entity);
                }
            }
        }

        /// <summary>
        /// 按config文件夹中的MaintainMethod.xml配置文件加任务等级
        /// </summary>
        private void LoadMaintainMethod()
        {
            string xmlPath = "~/Config/MaintainMethod.xml";
            IApplicationContext cxt = ContextRegistry.GetContext();
            IMaintainMethodManager manger = (IMaintainMethodManager)cxt.GetObject("Manager.MaintainMethod");
            IList<Domain.MaintainMethod> maintainMethodList = manger.LoadAll();
            if (maintainMethodList.Count == 0)
            {
                //manger.LoadSystemModelWithXML();
                // 把xml文件转换成dataSet
                Atom.Common.XML.XMLProcess xmlProcess = new Atom.Common.XML.XMLProcess();
                DataSet xmlDS = xmlProcess.GetDataSetByXml(xmlPath);
                // 生成目录
                for (int i = 0; i < xmlDS.Tables[0].Rows.Count; i++)
                {
                    Domain.MaintainMethod entity = new Domain.MaintainMethod();
                    entity.ID = Guid.NewGuid();
                    entity.MethodName = xmlDS.Tables[0].Rows[i]["name"].ToStr();
                    entity.OrderIndex = xmlDS.Tables[0].Rows[i]["orderIndex"].ToInt();
                    manger.Save(entity);
                }
            }
        }

        /// <summary>
        /// 按config文件夹中的MaintainMethod.xml配置文件加任务等级
        /// </summary>
        private void LoadMaintainType()
        {
            string xmlPath = "~/Config/MaintainType.xml";
            IApplicationContext cxt = ContextRegistry.GetContext();
            IMaintainTypeManager manger = (IMaintainTypeManager)cxt.GetObject("Manager.MaintainType");
            IList<Domain.MaintainType> maintainTypeList = manger.LoadAll();
            if (maintainTypeList.Count == 0)
            {
                //manger.LoadSystemModelWithXML();
                // 把xml文件转换成dataSet
                Atom.Common.XML.XMLProcess xmlProcess = new Atom.Common.XML.XMLProcess();
                DataSet xmlDS = xmlProcess.GetDataSetByXml(xmlPath);
                // 生成目录
                for (int i = 0; i < xmlDS.Tables[0].Rows.Count; i++)
                {
                    Domain.MaintainType entity = new Domain.MaintainType();
                    entity.ID = Guid.NewGuid();
                    entity.TypeName = xmlDS.Tables[0].Rows[i]["name"].ToStr();
                    entity.OrderIndex = xmlDS.Tables[0].Rows[i]["orderIndex"].ToInt();
                    manger.Save(entity);
                }
            }
        }

        /// <summary>
        /// 按config文件夹中的Rights.xml配置文件加权限类型
        /// </summary>
        private void LoadRightsType()
        {
            string xmlPath = "~/Config/RightsType.xml";
            IApplicationContext cxt = ContextRegistry.GetContext();
            IRightsManager manger = (IRightsManager)cxt.GetObject("Manager.Rights");
            IList<Domain.Rights> rightTypeList = manger.LoadAll();
            if (rightTypeList.Count == 0)
            {
                //manger.LoadSystemModelWithXML();
                // 把xml文件转换成dataSet
                Atom.Common.XML.XMLProcess xmlProcess = new Atom.Common.XML.XMLProcess();
                DataSet xmlDS = xmlProcess.GetDataSetByXml(xmlPath);
                // 生成目录
                for (int i = 0; i < xmlDS.Tables[0].Rows.Count; i++)
                {
                    Domain.Rights entity = new Domain.Rights();
                    entity.ID = Guid.NewGuid();
                    entity.RightName = xmlDS.Tables[0].Rows[i]["name"].ToStr();
                    entity.OrderIndex = xmlDS.Tables[0].Rows[i]["orderIndex"].ToInt();
                    manger.Save(entity);
                }
            }
        }

        protected override void RegisterRoutes(RouteCollection routes)
        {
            var guidRegx = @"^\w{8}-(\w{4}-){3}\w{12}$";

            routes.MapRoute(
                "Admin", // 路由名称
                "Admin", // 带有参数的 URL
                new { controller = "Home", action = "Admin" } // 参数默认值
            );

            routes.MapRoute(
                "LogOn", // 路由名称
                "LogOn", // 带有参数的 URL
                new { controller = "Home", action = "LogOn" } // 参数默认值
            );

            routes.MapRoute(
                "CategoryById", // 路由名称
                "{forumId}/{id}/Category.html", // 带有参数的 URL
                new { controller = "Category", action = "List", id = UrlParameter.Optional }, // 参数默认值
                new { forumId = guidRegx, id = guidRegx }
            );

            routes.MapRoute(
                "Category", // 路由名称
                "{forumId}/Category.html", // 带有参数的 URL
                new { controller = "Category", action = "List" }, // 参数默认值
                new { forumId = guidRegx }
            );

            routes.MapRoute(
                "Article", // 路由名称
                "Article/{id}.html", // 带有参数的 URL
                new { controller = "Article", action = "Get" }, // 参数默认值
                new { id = guidRegx }
            );

            routes.MapRoute(
                "Index", // 路由名称
                "Index.html", // 带有参数的 URL
                new { controller = "Home", action = "Index" } // 参数默认值
            );

            base.RegisterRoutes(routes);
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            if (this.Server.GetLastError() == null)
            {
                return;
            }

            Exception ex = this.Server.GetLastError().GetBaseException();
            StringBuilder sb = new StringBuilder();

            sb.Append(ex.Message);
            sb.Append("\r\nSOURCE: " + ex.Source);
            if (Request.Form != null)
            {
                sb.Append("\r\nFORM: " + this.Request.Form.ToString());
            }
            if (Request.QueryString != null)
            {
                sb.Append("\r\nQUERYSTRING: " + this.Request.QueryString.ToString());
            }

            sb.Append("\r\n引发当前异常的原因: " + ex.TargetSite);
            sb.Append("\r\n堆栈跟踪: " + ex.StackTrace);
            logger.Error(sb.ToString());

            var key = System.Configuration.ConfigurationManager.AppSettings["IsDebug"];
            bool isDebug;
            if (!bool.TryParse(key, out isDebug) || !isDebug)
            {
                this.Server.ClearError();
            }
        }

        protected void Session_Start()
        {
            this.Session["isCN"] = this.Request.UserLanguages.Length < 1 
                || string.IsNullOrEmpty(this.Request.UserLanguages[0]) 
                || this.Request.UserLanguages[0].ToLower() == "zh-cn";
        }

        public void LoadControllerAndAction() 
        {
            GetControllerNames();
        }

        /// <summary>
        /// 遍历得到所有Contrller和Actions
        /// </summary>
        /// <returns></returns>
        public List<string> GetControllerNames()
        {
            List<string> controllerNames = new List<string>();
            foreach (var t in GetSubClasses<Controller>())
            {
                controllerNames.Add(t.Name);
                List<System.Reflection.MethodInfo> mfCollection = GetSubMethods(t);
                mfCollection.ForEach(method => controllerNames.Add("---" + method.Name));
            }
            return controllerNames;
        }

        /// <summary>
        /// 获取所有的controller
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        private static List<Type> GetSubClasses<T>()
        {
            return System.Reflection.Assembly.GetCallingAssembly().GetTypes().Where(
                type => type.IsSubclassOf(typeof(T))).ToList();
        }

        /// <summary>
        /// 获取Controller下的action
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        private static List<System.Reflection.MethodInfo> GetSubMethods(Type t)
        {
            return t.GetMethods().Where(m => m.ReturnType == typeof(ActionResult) && m.IsPublic == true).ToList();
        }

    }

    //public class MvcApplication : System.Web.HttpApplication
    //{
    //    public static void RegisterRoutes(RouteCollection routes)
    //    {
    //        routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

    //        routes.MapRoute(
    //            "Default", // 路由名称
    //            "{controller}/{action}/{id}", // 带有参数的 URL
    //            new { controller = "Home", action = "Index", id = UrlParameter.Optional } // 参数默认值
    //        );

    //    }

    //    protected void Application_Start()
    //    {
    //        AreaRegistration.RegisterAllAreas();

    //        RegisterRoutes(RouteTable.Routes);
    //    }
    //}
}