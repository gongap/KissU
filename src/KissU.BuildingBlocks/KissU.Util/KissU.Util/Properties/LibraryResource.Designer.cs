﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Util.Properties {
    using System;
    
    
    /// <summary>
    ///   一个强类型的资源类，用于查找本地化的字符串等。
    /// </summary>
    // 此类是由 StronglyTypedResourceBuilder
    // 类通过类似于 ResGen 或 Visual Studio 的工具自动生成的。
    // 若要添加或移除成员，请编辑 .ResX 文件，然后重新运行 ResGen
    // (以 /str 作为命令选项)，或重新生成 VS 项目。
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class LibraryResource {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal LibraryResource() {
        }
        
        /// <summary>
        ///   返回此类使用的缓存的 ResourceManager 实例。
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("KissU.Util.Properties.LibraryResource", typeof(LibraryResource).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   重写当前线程的 CurrentUICulture 属性
        ///   重写当前线程的 CurrentUICulture 属性。
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   查找类似 当前操作的数据已被其他人修改，请刷新后重试 的本地化字符串。
        /// </summary>
        public static string ConcurrencyExceptionMessage {
            get {
                return ResourceManager.GetString("ConcurrencyExceptionMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 身份证不正确 的本地化字符串。
        /// </summary>
        public static string InvalidIdCard {
            get {
                return ResourceManager.GetString("InvalidIdCard", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 手机号不正确 的本地化字符串。
        /// </summary>
        public static string InvalidMobilePhone {
            get {
                return ResourceManager.GetString("InvalidMobilePhone", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 不允许将节点移动到自己或子节点下 的本地化字符串。
        /// </summary>
        public static string NotSupportMoveToChildren {
            get {
                return ResourceManager.GetString("NotSupportMoveToChildren", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 仅允许添加一个条件,条件：{0} 的本地化字符串。
        /// </summary>
        public static string OnlyOnePredicate {
            get {
                return ResourceManager.GetString("OnlyOnePredicate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 分页必须设置排序字段 的本地化字符串。
        /// </summary>
        public static string OrderIsEmptyForPage {
            get {
                return ResourceManager.GetString("OrderIsEmptyForPage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 必须设置表名 的本地化字符串。
        /// </summary>
        public static string TableIsEmpty {
            get {
                return ResourceManager.GetString("TableIsEmpty", resourceCulture);
            }
        }
    }
}
