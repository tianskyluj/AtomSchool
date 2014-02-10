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

            this.LoadRightsType();

            this.LoadGradeType();
            this.LoadGrade();
            this.LoadSubject();
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

        /// <summary>
        /// 按config文件夹中的GradeType.xml配置文件加载年级类型
        /// </summary>
        private void LoadGradeType()
        {
            string xmlPath = "~/Config/GradeType.xml";
            IApplicationContext cxt = ContextRegistry.GetContext();
            IGradeTypeManager manger = (IGradeTypeManager)cxt.GetObject("Manager.GradeType");
            IList<Domain.GradeType> GradeTypeList = manger.LoadAll();
            if (GradeTypeList.Count == 0)
            {
                //manger.LoadSystemModelWithXML();
                // 把xml文件转换成dataSet
                Atom.Common.XML.XMLProcess xmlProcess = new Atom.Common.XML.XMLProcess();
                DataSet xmlDS = xmlProcess.GetDataSetByXml(xmlPath);
                // 生成目录
                for (int i = 0; i < xmlDS.Tables[0].Rows.Count; i++)
                {
                    Domain.GradeType entity = new Domain.GradeType();
                    entity.ID = Guid.NewGuid();
                    entity.Name = xmlDS.Tables[0].Rows[i]["name"].ToStr();
                    manger.Save(entity);
                }
            }
        }

        /// <summary>
        /// 按config文件夹中的Grade.xml配置文件加载年级
        /// </summary>
        private void LoadGrade()
        {
            string xmlPath = "~/Config/Grade.xml";
            IApplicationContext cxt = ContextRegistry.GetContext();
            IGradeManager manger = (IGradeManager)cxt.GetObject("Manager.Grade");
            IGradeTypeManager gradeTypeManger = (IGradeTypeManager)cxt.GetObject("Manager.GradeType");
            IList<Domain.Grade> GradeList = manger.LoadAll();
            if (GradeList.Count == 0)
            {
                //manger.LoadSystemModelWithXML();
                // 把xml文件转换成dataSet
                Atom.Common.XML.XMLProcess xmlProcess = new Atom.Common.XML.XMLProcess();
                DataSet xmlDS = xmlProcess.GetDataSetByXml(xmlPath);
                // 生成目录
                string  parentId = "0";
                for (int i = 0; i < xmlDS.Tables[0].Rows.Count; i++)
                {
                    Domain.Grade entity = new Domain.Grade();
                    entity.ID = Guid.NewGuid();
                    entity.Name = xmlDS.Tables[0].Rows[i]["name"].ToStr();
                    entity.GradeType = gradeTypeManger.LoadAll().FirstOrDefault(f => f.Name == xmlDS.Tables[0].Rows[i]["gradeTypeName"].ToStr());
                    entity.ParentGrade = parentId;
                    manger.Save(entity);
                    parentId = entity.ID.ToStr();
                }
            }
        }

        /// <summary>
        /// 按config文件夹中的Subject.xml配置文件加载科目
        /// </summary>
        private void LoadSubject()
        {
            string xmlPath = "~/Config/Subject.xml";
            IApplicationContext cxt = ContextRegistry.GetContext();
            ISubjectManager manger = (ISubjectManager)cxt.GetObject("Manager.Subject");
            IList<Domain.Subject> SubjectList = manger.LoadAll();
            if (SubjectList.Count == 0)
            {
                //manger.LoadSystemModelWithXML();
                // 把xml文件转换成dataSet
                Atom.Common.XML.XMLProcess xmlProcess = new Atom.Common.XML.XMLProcess();
                DataSet xmlDS = xmlProcess.GetDataSetByXml(xmlPath);
                // 生成目录
                for (int i = 0; i < xmlDS.Tables[0].Rows.Count; i++)
                {
                    Domain.Subject entity = new Domain.Subject();
                    entity.ID = Guid.NewGuid();
                    entity.Name = xmlDS.Tables[0].Rows[i]["name"].ToStr();
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