// <copyright file="Coordinate.cs" company="广州慧睿思通信息科技有限公司">
// Copyright (c) 广州慧睿思通信息科技有限公司. All rights reserved.
// </copyright>

using System;

namespace KissU.Modules.Account.Service.Contracts.Model
{
    /// <summary>
    /// 坐标
    /// </summary>
    public class Coordinate
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Coordinate"/> class.
        /// 初始化
        /// </summary>
        /// <param name="x">x轴</param>
        /// <param name="y">y轴</param>
        /// <param name="z">z轴</param>
        public Coordinate(double x = 0, double y = 0, double z = 0)
        {
            X = x;
            Y = y;
            Z = z;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Coordinate"/> class.
        /// 初始化
        /// </summary>
        private Coordinate()
        {
        }

        /// <summary>
        /// X轴 单位：米（m）。
        /// </summary>
        public double X { get; }

        /// <summary>
        /// Y轴 单位：米（m）。
        /// </summary>
        public double Y { get; }

        /// <summary>
        /// Z轴 单位：米（m）。
        /// </summary>
        public double Z { get; }

        /// <summary>
        /// 转换为GPS位置
        /// </summary>
        /// <param name="meterPerlon">每1度经度对应的长度</param>
        /// <param name="meterPerlat">每1度纬度对应的长度</param>
        /// <returns>三维球坐标</returns>
        public Location ToLocation(double meterPerlon, double meterPerlat)
        {
            return new Location(X / meterPerlon, Y / meterPerlat, (float)Z);
        }

        /// <summary>
        /// 两点的直线距离
        /// </summary>
        /// <param name="other">坐标</param>
        /// <returns>直线距离</returns>
        public double GetDistance(Coordinate other)
        {
            return Math.Sqrt(Math.Pow(other.X - X, 2) + Math.Pow(other.Y - Y, 2) + Math.Pow(other.Z - Z, 2));
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"({X} ⊥ {Y}) ⌒ {Z}m";
        }
    }
}