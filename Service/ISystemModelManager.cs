using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;

namespace Service
{
    public interface ISystemModelManager : IGenericManager<SystemModel>
    {
        /// <summary>
        /// 快速添加系统模块
        /// </summary>
        /// <param name="parentId">父id</param>
        /// <param name="url">访问路径</param>
        /// <param name="name">名称</param>
        /// <param name="orderIndex">排序码</param>
        Guid FastAddSystemModel(Guid parentId, string url, string name, int orderIndex,string icon,string shortName);

        /// <summary>
        /// 根据xml配置加载系统模块
        /// </summary>
        /// <param name="xmlPath"></param>
        //void LoadSystemModelWithXML();

        /// <summary>
        /// 根据模块名称返回模块实体类集合
        /// </summary>
        /// <returns></returns>
        SystemModel LoadAllByName(string modelName);

        /// <summary>
        /// 加入新的系统模块后重置系统模块排序码
        /// </summary>
        void ResetOrderIndex();

        /// <summary>
        /// 根据父节点读取所有子模块
        /// </summary>
        /// <param name="systemModelID"></param>
        /// <returns></returns>
        IList<SystemModel> LoadAllByParentID(Guid systemModelID);

        /// <summary>
        /// 根据富节点删除所有子节点
        /// </summary>
        /// <param name="parentID"></param>
        void DeleteAllChildrenModel(Guid parentID);

        /// <summary>
        /// 根据orderIndex的值设置统一父节点的兄弟节点的值
        /// </summary>
        /// <param name="parentID"></param>
        void SetSiblingWithParentID(Guid parentID);

        /// <summary>
        /// 根据兄弟节点的值设置统一父节点的orderIndex的值
        /// </summary>
        /// <param name="parentID"></param>
        void SetOrderIndexWithParentID(Guid parentID);
    }
}
