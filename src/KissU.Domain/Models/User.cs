using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace KissU.Domain.Models
{
    class User
    {
        [DisplayName("创建时间")]
        public DateTime? CreationTime { get; set; }
        /// <summary>
        /// 创建人编号
        /// </summary>
        [DisplayName("创建人编号")]
        public Guid? CreatorId { get; set; }
    }
}
