using System.Collections.Generic;
using System.Reflection;
using KissU.Core.Helpers;
using KissU.Util.Ddd.Domains;
using KissU.Util.Tests.Samples;
using Xunit;

namespace KissU.Util.Tests.Helpers
{
    /// <summary>
    /// 测试反射操作
    /// </summary>
    public class ReflectionTest
    {
        /// <summary>
        /// 初始化测试
        /// </summary>
        public ReflectionTest()
        {
            _sample = new Sample();
        }

        /// <summary>
        /// 测试样例
        /// </summary>
        private readonly Sample _sample;

        /// <summary>
        /// 测试获取类成员描述
        /// </summary>
        [Fact]
        public void TestGetDescription()
        {
            Assert.Equal("", Reflection.GetDescription<EnumSample>("X"));
            Assert.Equal("A", Reflection.GetDescription<EnumSample>("A"));
            Assert.Equal("B2", Reflection.GetDescription<EnumSample>("B"));
            Assert.Equal("IntValue", Reflection.GetDescription<Sample>("IntValue"));
        }

        /// <summary>
        /// 测试获取类描述
        /// </summary>
        [Fact]
        public void TestGetDescription_Class()
        {
            Assert.Equal("测试样例", Reflection.GetDescription<Sample>());
            Assert.Equal("Sample2", Reflection.GetDescription<Sample2>());
        }

        /// <summary>
        /// 测试获取类描述或显示名
        /// </summary>
        [Fact]
        public void TestGetDescriptionOrDisplayName()
        {
            Assert.Equal("测试样例", Reflection.GetDisplayNameOrDescription<Sample>());
            Assert.Equal("测试样例2", Reflection.GetDisplayNameOrDescription<Sample2>());
            Assert.Equal("测试样例", Reflection.GetDisplayNameOrDescription<Sample>());
        }

        /// <summary>
        /// 测试显示名
        /// </summary>
        [Fact]
        public void TestGetDisplayName()
        {
            Assert.Equal("", Reflection.GetDisplayName<Sample>());
            Assert.Equal("测试样例2", Reflection.GetDisplayName<Sample2>());
        }

        /// <summary>
        /// 获取元素类型
        /// </summary>
        [Fact]
        public void TestGetElementType_1()
        {
            var sample = new Sample();
            Assert.Equal(typeof(Sample), Reflection.GetElementType(sample.GetType()));
        }

        /// <summary>
        /// 获取元素类型 - 数组
        /// </summary>
        [Fact]
        public void TestGetElementType_2()
        {
            var list = new[] {new Sample()};
            var type = list.GetType();
            Assert.Equal(typeof(Sample), Reflection.GetElementType(type));
        }

        /// <summary>
        /// 获取元素类型 - 集合
        /// </summary>
        [Fact]
        public void TestGetElementType_3()
        {
            var list = new List<Sample> {new Sample()};
            var type = list.GetType();
            Assert.Equal(typeof(Sample), Reflection.GetElementType(type));
        }

        /// <summary>
        /// 测试获取公共属性列表
        /// </summary>
        [Fact]
        public void TestGetPublicProperties()
        {
            var sample = new Sample4
            {
                A = "1",
                B = "2"
            };
            var items = Reflection.GetPublicProperties(sample);
            Assert.Equal(2, items.Count);
            Assert.Equal("A", items[0].Text);
            Assert.Equal("1", items[0].Value);
            Assert.Equal("B", items[1].Text);
            Assert.Equal("2", items[1].Value);
        }

        /// <summary>
        /// 获取顶级基类
        /// </summary>
        [Fact]
        public void TestGetTopBaseType()
        {
            Assert.Null(Reflection.GetTopBaseType(null));
            Assert.Contains("Util.Domains.DomainBase", Reflection.GetTopBaseType<User>().FullName);
            Assert.Contains("Util.Domains.DomainBase", Reflection.GetTopBaseType<DomainBase<User>>().FullName);
            Assert.Contains("Util.Domains.IEntity", Reflection.GetTopBaseType<IEntity>().FullName);
        }

        /// <summary>
        /// 测试是否布尔类型
        /// </summary>
        [Fact]
        public void TestIsBool()
        {
            Assert.True(Reflection.IsBool(_sample.BoolValue.GetType().GetTypeInfo()), "BoolValue GetType");
            Assert.True(Reflection.IsBool(_sample.GetType().GetMember("BoolValue")[0]), "BoolValue");
            Assert.True(Reflection.IsBool(_sample.GetType().GetMember("NullableBoolValue")[0]), "NullableBoolValue");
            Assert.False(Reflection.IsBool(_sample.GetType().GetMember("EnumValue")[0]), "EnumValue");
        }

        /// <summary>
        /// 测试是否集合
        /// </summary>
        [Fact]
        public void TestIsCollection()
        {
            Assert.True(Reflection.IsCollection(_sample.StringArray.GetType()));
        }

        /// <summary>
        /// 测试是否日期类型
        /// </summary>
        [Fact]
        public void TestIsDate()
        {
            Assert.True(Reflection.IsDate(_sample.DateValue.GetType().GetTypeInfo()), "DateValue GetType");
            Assert.True(Reflection.IsDate(_sample.GetType().GetMember("DateValue")[0]), "DateValue");
            Assert.True(Reflection.IsDate(_sample.GetType().GetMember("NullableDateValue")[0]), "NullableDateValue");
            Assert.False(Reflection.IsDate(_sample.GetType().GetMember("EnumValue")[0]), "EnumValue");
        }

        /// <summary>
        /// 测试是否枚举类型
        /// </summary>
        [Fact]
        public void TestIsEnum()
        {
            Assert.True(Reflection.IsEnum(_sample.EnumValue.GetType().GetTypeInfo()), "EnumValue GetType");
            Assert.True(Reflection.IsEnum(_sample.GetType().GetMember("EnumValue")[0]), "EnumValue");
            Assert.True(Reflection.IsEnum(_sample.GetType().GetMember("NullableEnumValue")[0]), "NullableEnumValue");
            Assert.False(Reflection.IsEnum(_sample.GetType().GetMember("BoolValue")[0]), "BoolValue");
            Assert.False(Reflection.IsEnum(_sample.GetType().GetMember("NullableBoolValue")[0]), "NullableBoolValue");
        }

        /// <summary>
        /// 测试是否泛型集合
        /// </summary>
        [Fact]
        public void TestIsGenericCollection()
        {
            Assert.True(Reflection.IsGenericCollection(_sample.StringList.GetType()));
        }

        /// <summary>
        /// 测试是否整型
        /// </summary>
        [Fact]
        public void TestIsInt()
        {
            Assert.True(Reflection.IsInt(_sample.IntValue.GetType().GetTypeInfo()), "IntValue GetType");
            Assert.True(Reflection.IsInt(_sample.GetType().GetMember("IntValue")[0]), "IntValue");
            Assert.True(Reflection.IsInt(_sample.GetType().GetMember("NullableIntValue")[0]), "NullableIntValue");

            Assert.True(Reflection.IsInt(_sample.ShortValue.GetType().GetTypeInfo()), "ShortValue GetType");
            Assert.True(Reflection.IsInt(_sample.GetType().GetMember("ShortValue")[0]), "ShortValue");
            Assert.True(Reflection.IsInt(_sample.GetType().GetMember("NullableShortValue")[0]), "NullableShortValue");

            Assert.True(Reflection.IsInt(_sample.LongValue.GetType().GetTypeInfo()), "LongValue GetType");
            Assert.True(Reflection.IsInt(_sample.GetType().GetMember("LongValue")[0]), "LongValue");
            Assert.True(Reflection.IsInt(_sample.GetType().GetMember("NullableLongValue")[0]), "NullableLongValue");
        }

        /// <summary>
        /// 测试是否数值类型
        /// </summary>
        [Fact]
        public void TestIsNumber()
        {
            Assert.True(Reflection.IsNumber(_sample.DoubleValue.GetType().GetTypeInfo()), "DoubleValue GetType");
            Assert.True(Reflection.IsNumber(_sample.GetType().GetMember("DoubleValue")[0]), "DoubleValue");
            Assert.True(Reflection.IsNumber(_sample.GetType().GetMember("NullableDoubleValue")[0]),
                "NullableDoubleValue");

            Assert.True(Reflection.IsNumber(_sample.DecimalValue.GetType().GetTypeInfo()), "DecimalValue GetType");
            Assert.True(Reflection.IsNumber(_sample.GetType().GetMember("DecimalValue")[0]), "DecimalValue");
            Assert.True(Reflection.IsNumber(_sample.GetType().GetMember("NullableDecimalValue")[0]),
                "NullableDecimalValue");

            Assert.True(Reflection.IsNumber(_sample.FloatValue.GetType().GetTypeInfo()), "FloatValue GetType");
            Assert.True(Reflection.IsNumber(_sample.GetType().GetMember("FloatValue")[0]), "FloatValue");
            Assert.True(Reflection.IsNumber(_sample.GetType().GetMember("NullableFloatValue")[0]),
                "NullableFloatValue");

            Assert.True(Reflection.IsNumber(_sample.IntValue.GetType().GetTypeInfo()), "IntValue GetType");
            Assert.True(Reflection.IsNumber(_sample.GetType().GetMember("IntValue")[0]), "IntValue");
            Assert.True(Reflection.IsNumber(_sample.GetType().GetMember("NullableIntValue")[0]), "NullableIntValue");
        }
    }
}