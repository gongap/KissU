using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace KissU.Core.Module
{
    /// <summary>
    /// AssemblyEntry.
    /// Implements the <see cref="IXmlSerializable" />
    /// </summary>
    /// <seealso cref="IXmlSerializable" />
    [XmlRoot("Assembly")]
    public class AssemblyEntry : IXmlSerializable
    {
        /// <summary>
        /// 获取程序集文件名。
        /// </summary>
        public string FileName { get; internal set; }

        /// <summary>
        /// 获取程序集完全名称。
        /// </summary>
        public string FullName { get; internal set; }

        /// <summary>
        /// 获取程序集名称唯一键。
        /// </summary>
        public string Name { get; internal set; }

        /// <summary>
        /// 获取程序集标题文本。
        /// </summary>
        public string Title { get; internal set; }

        /// <summary>
        /// 获取程序集功能描述。
        /// </summary>
        public string Description { get; internal set; }

        /// <summary>
        /// 获取程序集版本号。
        /// </summary>
        public Version Version { get; internal set; }

        /// <summary>
        /// 获取一个值指示该程序集是否是扩展的程序集。
        /// </summary>
        public bool IsExtend { get; internal set; }

        /// <summary>
        /// 获取一个值指示是否禁止停止和卸载。
        /// </summary>
        public bool DisableStopAndUninstalled { get; internal set; }

        /// <summary>
        /// 获取程序集排序顺序。
        /// </summary>
        public int ListOrder { get; set; }

        /// <summary>
        /// 获取程序集模块状态。
        /// </summary>
        public ModuleState State { get; set; }

        /// <summary>
        /// 获取程序集引用列表。
        /// </summary>
        public List<string> Reference { get; internal set; }

        /// <summary>
        /// 获取程序集模块列表。
        /// </summary>
        public List<AbstractModule> AbstractModules { get; set; }

        /// <summary>
        /// 此方法是保留方法，请不要使用。在实现 IXmlSerializable 接口时，应从此方法返回 null（在 Visual Basic 中为 Nothing），如果需要指定自定义架构，应向该类应用
        /// <see cref="T:System.Xml.Serialization.XmlSchemaProviderAttribute" />。
        /// </summary>
        /// <returns>
        /// <see cref="T:System.Xml.Schema.XmlSchema" />，描述由
        /// <see cref="M:System.Xml.Serialization.IXmlSerializable.WriteXml(System.Xml.XmlWriter)" /> 方法产生并由
        /// <see cref="M:System.Xml.Serialization.IXmlSerializable.ReadXml(System.Xml.XmlReader)" /> 方法使用的对象的 XML 表示形式。
        /// </returns>
        public XmlSchema GetSchema()
        {
            return null;
        }

        /// <summary>
        /// 从对象的 XML 表示形式生成该对象。
        /// </summary>
        /// <param name="reader">对象从中进行反序列化的 <see cref="T:System.Xml.XmlReader" /> 流。</param>
        public void ReadXml(XmlReader reader)
        {
            if (reader.IsEmptyElement || !reader.Read())
            {
                return;
            }

            while (reader.NodeType != XmlNodeType.EndElement)
            {
                FileName = reader.ReadElementContentAsString();
                FullName = reader.ReadElementContentAsString();
                Name = reader.ReadElementContentAsString();
                Title = reader.ReadElementContentAsString();
                Description = reader.ReadElementContentAsString();
                Version version;
                Version.TryParse(reader.ReadElementContentAsString(), out version);
                Version = version;
                bool isExtend;
                bool.TryParse(reader.ReadElementContentAsString(), out isExtend);
                IsExtend = isExtend;
                bool disableStopAndUninstalled;
                bool.TryParse(reader.ReadElementContentAsString(), out disableStopAndUninstalled);
                DisableStopAndUninstalled = disableStopAndUninstalled;
                int listOrder;
                int.TryParse(reader.ReadElementContentAsString(), out listOrder);
                ListOrder = listOrder;
                ModuleState state;
                Enum.TryParse(reader.ReadElementContentAsString(), out state);
                State = state;

                Reference = new List<string>();
                if (reader.Name == "Reference")
                {
                    if (!reader.IsEmptyElement)
                    {
                        reader.ReadStartElement("Reference");
                        while (reader.Name == "Assembly")
                        {
                            Reference.Add(reader.ReadElementContentAsString());
                        }

                        reader.ReadEndElement();
                    }
                    else
                    {
                        reader.Skip();
                    }
                }

                AbstractModules = new List<AbstractModule>();
                if (reader.Name == "AbstractModules")
                {
                    if (!reader.IsEmptyElement)
                    {
                        reader.ReadStartElement("AbstractModules");
                        while (reader.Name.EndsWith("Module"))
                        {
                            var type = Type.GetType(reader.GetAttribute("TypeName"), true);
                            var xmlSerializer = new XmlSerializer(type);
                            AbstractModules.Add((AbstractModule) xmlSerializer.Deserialize(reader));
                        }

                        reader.ReadEndElement();
                    }
                    else
                    {
                        reader.Skip();
                    }
                }
            }
        }

        /// <summary>
        /// 将对象转换为其 XML 表示形式。
        /// </summary>
        /// <param name="writer">对象要序列化为的 <see cref="T:System.Xml.XmlWriter" /> 流。</param>
        public void WriteXml(XmlWriter writer)
        {
            writer.WriteElementString("FileName", FileName);
            writer.WriteElementString("FullName", FullName);
            writer.WriteElementString("Name", Name);
            writer.WriteElementString("Title", Title);
            writer.WriteElementString("Description", Description);
            writer.WriteElementString("Version", Version == null ? string.Empty : Version.ToString());
            writer.WriteElementString("IsExtend", IsExtend.ToString().ToLower());
            writer.WriteElementString("DisableStopAndUninstalled", DisableStopAndUninstalled.ToString().ToLower());
            writer.WriteElementString("ListOrder", ListOrder.ToString());
            writer.WriteElementString("State", State.ToString());
            writer.WriteStartElement("Reference");
            if (Reference != null)
            {
                Reference.ForEach(reference => { writer.WriteElementString("Assembly", reference); });
            }

            writer.WriteEndElement();
            writer.WriteStartElement("AbstractModules");
            if (AbstractModules != null)
            {
                AbstractModules.ForEach(module =>
                {
                    var namespaces = new XmlSerializerNamespaces();
                    namespaces.Add(string.Empty, string.Empty);
                    var xmlSerializer = new XmlSerializer(module.GetType());
                    xmlSerializer.Serialize(writer, module, namespaces);
                });
            }

            writer.WriteEndElement();
        }

        /// <summary>
        /// 注册程序集所有抽象模块。
        /// </summary>
        /// <param name="builder">容器构建对象。</param>
        public void RegisterModule(ContainerBuilderWrapper builder)
        {
            AbstractModules.ForEach(module =>
            {
                // module.Initialize();
                builder.RegisterModule(module);
            });
        }

        /// <summary>
        /// 获取指定控制器类型的业务模块实例。
        /// </summary>
        /// <param name="controllerType">Type of the controller.</param>
        /// <returns>BusinessModule.</returns>
        /// <exception cref="Exception"></exception>
        public BusinessModule GetBusinessModuleByControllerType(Type controllerType)
        {
            var businessModule =
                AbstractModules.Find(m => controllerType.Namespace.Contains(m.GetType().Namespace)) as BusinessModule;

            if (businessModule == null)
            {
                throw new Exception(string.Format("无法找到 {0} 控制器所属的业务模块实例对象", controllerType.Name));
            }

            return businessModule;
        }

        /// <summary>
        /// 获取程序集视图目录名称：公司.产品.程序集模块(程序集视图目录名称)。
        /// </summary>
        /// <returns>返回程序集视图目录名称</returns>
        public string GetAssemblyViewDirectoryName()
        {
            return Name.Substring(Name.LastIndexOf('.') + 1);
        }

        /// <summary>
        /// 比较程序集模块版本。
        /// </summary>
        /// <param name="version">版本字符串。</param>
        /// <returns>
        ///     <para>一个有符号整数，它指示两个对象的相对值，如下表所示。返回值含义小于零当前的 System.Version 对象是 version 之前的一个版本。</para>
        ///     <para>零当前的System.Version 对象是与 version 相同的版本。大于零当前 System.Version 对象是 version 之后的一个版本。-或 -version 为 null。</para>
        /// </returns>
        public int CompareVersion(string version)
        {
            return CompareVersion(new Version(version));
        }

        /// <summary>
        /// 比较程序集模块版本。
        /// </summary>
        /// <param name="version">版本对象。</param>
        /// <returns>
        ///     <para>一个有符号整数，它指示两个对象的相对值，如下表所示。返回值含义小于零当前的 System.Version 对象是 version 之前的一个版本。</para>
        ///     <para>零当前的System.Version 对象是与 version 相同的版本。大于零当前 System.Version 对象是 version 之后的一个版本。-或 -version 为 null。</para>
        /// </returns>
        public int CompareVersion(Version version)
        {
            return Version.CompareTo(version);
        }

        /// <summary>
        /// 获取程序集模块的字符串文本描述信息。
        /// </summary>
        /// <returns>返回程序集模块对象的字符串文本描述信息。</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendFormat("程序集文件名：{0}", FileName);
            sb.AppendLine();
            sb.AppendFormat("程序集类型全名：{0}", FullName);
            sb.AppendLine();
            sb.AppendFormat("程序集类型名：{0}", Name);
            sb.AppendLine();
            sb.AppendFormat("程序集标题：{0}", Title);
            sb.AppendLine();
            sb.AppendFormat("程序集描述：{0}", Description);
            sb.AppendLine();
            sb.AppendFormat("程序集版本：{0}", Version);
            sb.AppendLine();
            sb.AppendFormat("扩展的程序集：{0}", IsExtend);
            sb.AppendLine();
            sb.AppendFormat("禁用停止和卸载：{0}", DisableStopAndUninstalled);
            sb.AppendLine();
            sb.AppendFormat("程序集注册顺序：{0}", ListOrder);
            sb.AppendLine();
            sb.AppendFormat("程序集引用 {0}个", Reference.Count);
            sb.AppendLine();
            Reference.ForEach(r => { sb.AppendLine(r); });

            sb.AppendFormat("程序集模块 {0}个", AbstractModules.Count);
            sb.AppendLine();
            AbstractModules.ForEach(m => { sb.Append(m.ToString()); });

            return sb.ToString();
        }
    }
}