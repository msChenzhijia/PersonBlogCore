using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Model.VeiwModels
{
    /// <summary>
    /// 菜单展示model
    /// </summary>
    public class SidebarMenuViewModel
    {
        /// <summary>
        /// 无参构造函数
        /// </summary>
        public SidebarMenuViewModel()
        {
            this.ChildMenuList = new List<SidebarMenuViewModel>();
        }

        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Code { get; set; }
        public string LinkUrl { get; set; }
        public string Area { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }

        public List<SidebarMenuViewModel> ChildMenuList { get; set; }
    }
}
