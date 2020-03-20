﻿using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace KissU.Util.Helpers
{
    /// <summary>
    /// Xml操作 - 工具
    /// </summary>
    public partial class Xml
    {
        /// <summary>
        /// 将Xml字符串转换为XDocument
        /// </summary>
        /// <param name="xml">Xml字符串</param>
        /// <returns>XDocument.</returns>
        public static XDocument ToDocument(string xml)
        {
            return XDocument.Parse(xml);
        }

        /// <summary>
        /// 将Xml字符串转换为XElement列表
        /// </summary>
        /// <param name="xml">Xml字符串</param>
        /// <returns>List&lt;XElement&gt;.</returns>
        public static List<XElement> ToElements(string xml)
        {
            var document = ToDocument(xml);
            if (document?.Root == null)
                return new List<XElement>();
            return document.Root.Elements().ToList();
        }
    }
}