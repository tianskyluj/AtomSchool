using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;
using System.Web;

namespace Service
{
    public interface IUploadFileManager : IGenericManager<UploadFile>
    {
        /// <summary>
        /// 上传文件
        /// </summary>
        /// <returns></returns>
        UploadFile UploadFile(HttpPostedFileBase request, UserInfo user);
    }
}
