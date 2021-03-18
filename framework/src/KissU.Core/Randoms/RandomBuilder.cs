﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KissU.Dependency;
using KissU.Helpers;

namespace KissU.Randoms
{
    /// <summary>
    /// 随机数生成器
    /// </summary>
    public class RandomBuilder : IRandomBuilder, ISingletonDependency
    {
        /// <summary>
        /// 随机数字生成器
        /// </summary>
        private readonly IRandomNumberGenerator _random;

        /// <summary>
        /// 初始化随机数生成器
        /// </summary>
        /// <param name="generator">随机数字生成器</param>
        public RandomBuilder(IRandomNumberGenerator generator = null)
        {
            _random = generator ?? new RandomNumberGenerator();
        }

        /// <summary>
        /// 生成随机字符串
        /// </summary>
        /// <param name="maxLength">最大长度</param>
        /// <param name="text">如果传入该参数，则从该文本中随机抽取</param>
        /// <returns>System.String.</returns>
        public string GenerateString(int maxLength, string text = null)
        {
            if (text == null)
                text = ConstHelper.Letters + ConstHelper.Numbers;
            var result = new StringBuilder();
            for (var i = 0; i < maxLength; i++)
                result.Append(GetRandomChar(text));
            return result.ToString();
        }

        /// <summary>
        /// 生成随机字母
        /// </summary>
        /// <param name="maxLength">最大长度</param>
        /// <returns>System.String.</returns>
        public string GenerateLetters(int maxLength)
        {
            return GenerateString(maxLength, ConstHelper.Letters);
        }

        /// <summary>
        /// 生成随机汉字
        /// </summary>
        /// <param name="maxLength">最大长度</param>
        /// <returns>System.String.</returns>
        public string GenerateChinese(int maxLength)
        {
            return GenerateString(maxLength, ConstHelper.SimplifiedChinese);
        }

        /// <summary>
        /// 生成随机数字
        /// </summary>
        /// <param name="maxLength">最大长度</param>
        /// <returns>System.String.</returns>
        public string GenerateNumbers(int maxLength)
        {
            return GenerateString(maxLength, ConstHelper.Numbers);
        }

        /// <summary>
        /// 生成随机布尔值
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool GenerateBool()
        {
            var random = _random.Generate(1, 100);
            if (random % 2 == 0)
                return false;
            return true;
        }

        /// <summary>
        /// 生成随机整数
        /// </summary>
        /// <param name="maxValue">最大值</param>
        /// <returns>System.Int32.</returns>
        public int GenerateInt(int maxValue)
        {
            return _random.Generate(0, maxValue + 1);
        }

        /// <summary>
        /// 生成随机日期
        /// </summary>
        /// <param name="beginYear">起始年份</param>
        /// <param name="endYear">结束年份</param>
        /// <returns>DateTime.</returns>
        public DateTime GenerateDate(int beginYear = 1980, int endYear = 2080)
        {
            var year = _random.Generate(beginYear, endYear);
            var month = _random.Generate(1, 13);
            var day = _random.Generate(1, 29);
            var hour = _random.Generate(1, 24);
            var minute = _random.Generate(1, 60);
            var second = _random.Generate(1, 60);
            return new DateTime(year, month, day, hour, minute, second);
        }

        /// <summary>
        /// 生成随机枚举
        /// </summary>
        /// <typeparam name="TEnum">枚举类型</typeparam>
        /// <returns>TEnum.</returns>
        public TEnum GenerateEnum<TEnum>()
        {
            var list = EnumHelper.GetItems<TEnum>();
            var index = _random.Generate(0, list.Count);
            return EnumHelper.Parse<TEnum>(list[index].Value);
        }

        /// <summary>
        /// 对集合随机排序
        /// </summary>
        /// <typeparam name="T">集合元素类型</typeparam>
        /// <param name="array">集合</param>
        /// <returns>List&lt;T&gt;.</returns>
        public List<T> Sort<T>(IEnumerable<T> array)
        {
            if (array == null)
                return null;
            var random = new System.Random();
            var list = array.ToList();
            for (var i = 0; i < list.Count; i++)
            {
                var index1 = random.Next(0, list.Count);
                var index2 = random.Next(0, list.Count);
                var temp = list[index1];
                list[index1] = list[index2];
                list[index2] = temp;
            }

            return list;
        }

        /// <summary>
        /// 获取随机长度
        /// </summary>
        private int GetRandomLength(int maxLength)
        {
            return _random.Generate(1, maxLength);
        }

        /// <summary>
        /// 获取随机字符
        /// </summary>
        private string GetRandomChar(string text)
        {
            return text[_random.Generate(1, text.Length)].ToString();
        }
    }
}