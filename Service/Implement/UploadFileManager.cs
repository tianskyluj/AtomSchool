using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;
using System.IO;
using Atom.Common.Sys;
using System.Web;

namespace Service.Implement
{
    public class UploadFileManager : GenericManagerBase<UploadFile>, IUploadFileManager
    {
        /// <summary>
        /// 上传文件
        /// </summary>
        /// <returns></returns>
        public UploadFile UploadFile(HttpPostedFileBase request, UserInfo user)
        {
            string fileURL = "";
            fileURL = Atom.Common.inc.getApplicationPath() + "/Upload/Files/" + user.Account.ToString()+"/"+DateTime.Now.ToShortDateString()+"/"+DateTime.Now.ToShortTimeString().Replace(":","");
            if (!Directory.Exists(fileURL))
            {
                Directory.CreateDirectory(System.Web.HttpContext.Current.Server.MapPath(fileURL));
            }
            request.SaveAs(System.Web.HttpContext.Current.Server.MapPath(fileURL) + "/" + request.FileName);

            UploadFile entity = new UploadFile();
            entity.ID = Guid.NewGuid();
            entity.BaseID = new Guid();
            entity.FileName = request.FileName;
            entity.FileURL = fileURL + "/" + request.FileName;
            entity.FileType = "";
            entity.CreateUser = user;
            entity.CreateTime = DateTime.Now;
            entity.success = true;
            base.Save(entity);

            return entity;
        }
    }
}
