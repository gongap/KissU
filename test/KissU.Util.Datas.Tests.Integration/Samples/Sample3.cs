﻿using System.ComponentModel;
using KissU.Util.Datas.Sql;

namespace KissU.Util.Datas.Tests.Integration.Samples {
    /// <summary>
    /// 测试样例3
    /// </summary>
    [DisplayName( "测试样例3" )]
    public class Sample3 {
        /// <summary>
        /// string值
        /// </summary>
        public string StringValue { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        public bool IsDeleted { get; set; }
        /// <summary>
        /// 跳过的属性
        /// </summary>
        [Ignore]
        public bool Ignore { get; set; }
    }
}
