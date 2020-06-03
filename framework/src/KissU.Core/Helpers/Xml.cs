using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using KissU.Extensions;

namespace KissU.Helpers
{
    /// <summary>
    /// Xml操作 - 生成器
    /// </summary>
    public partial class Xml
    {
        /// <summary>
        /// 初始化Xml操作
        /// </summary>
        /// <param name="xml">Xml字符串</param>
        /// <exception cref="ArgumentException">xml</exception>
        public Xml(string xml = null)
        {
            Document = new XmlDocument();
            Document.LoadXml(GetXml(xml));
            Root = Document.DocumentElement;
            if (Root == null)
                throw new ArgumentException(nameof(xml));
        }

        /// <summary>
        /// Xml文档
        /// </summary>
        public XmlDocument Document { get; }

        /// <summary>
        /// Xml根节点
        /// </summary>
        public XmlElement Root { get; }

        /// <summary>
        /// 获取Xml字符串
        /// </summary>
        private string GetXml(string xml)
        {
            return string.IsNullOrWhiteSpace(xml) ? "<xml></xml>" : xml;
        }

        /// <summary>
        /// 添加节点
        /// </summary>
        /// <param name="name">节点名称</param>
        /// <param name="value">值</param>
        /// <param name="parent">父节点</param>
        /// <returns>XmlNode.</returns>
        public XmlNode AddNode(string name, object value = null, XmlNode parent = null)
        {
            var node = CreateNode(name, value, XmlNodeType.Element);
            GetParent(parent).AppendChild(node);
            return node;
        }

        /// <summary>
        /// 创建节点
        /// </summary>
        private XmlNode CreateNode(string name, object value, XmlNodeType type)
        {
            var node = Document.CreateNode(type, name, string.Empty);
            if (string.IsNullOrWhiteSpace(value.SafeString()) == false)
                node.InnerText = value.SafeString();
            return node;
        }

        /// <summary>
        /// 获取父节点
        /// </summary>
        private XmlNode GetParent(XmlNode parent)
        {
            if (parent == null)
                return Root;
            return parent;
        }

        /// <summary>
        /// 添加CDATA节点
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="parent">父节点</param>
        /// <returns>XmlNode.</returns>
        public XmlNode AddCDataNode(object value, XmlNode parent = null)
        {
            var node = CreateNode(Id.Guid(), value, XmlNodeType.CDATA);
            GetParent(parent).AppendChild(node);
            return node;
        }

        /// <summary>
        /// 添加CDATA节点
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="parentName">父节点名称</param>
        /// <returns>XmlNode.</returns>
        public XmlNode AddCDataNode(object value, string parentName)
        {
            var parent = CreateNode(parentName, null, XmlNodeType.Element);
            Root.AppendChild(parent);
            return AddCDataNode(value, parent);
        }

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

        /// <summary>
        /// 输出Xml
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            return Document.OuterXml;
        }
    }
}