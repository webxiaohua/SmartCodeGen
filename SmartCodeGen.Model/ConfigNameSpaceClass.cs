using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartCodeGen.Model
{
    /// <summary>
    /// @Author:robin
    /// @Date:20150922
    /// @Desc:命名空间配置
    /// </summary>
    public class ConfigNameSpaceClass
    {
        /// <summary>
        /// 实体
        /// </summary>
        public string Model { get; set; }
        /// <summary>
        /// 数据
        /// </summary>
        public string Data { get; set; }
        /// <summary>
        /// 业务
        /// </summary>
        public string Business { get; set; }
        /// <summary>
        /// 接口
        /// </summary>
        public string Interface { get; set; }
        /// <summary>
        /// 工厂
        /// </summary>
        public string Factory { get; set; }
    }
}
