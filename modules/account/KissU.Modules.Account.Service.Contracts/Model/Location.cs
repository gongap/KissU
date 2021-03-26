// <copyright file="Location.cs" company="广州慧睿思通信息科技有限公司">
// Copyright (c) 广州慧睿思通信息科技有限公司. All rights reserved.
// </copyright>

using System;

namespace KissU.Modules.Account.Service.Contracts.Model
{
    /// <summary>
    /// 地点
    /// </summary>
    public class Location
    {
        /// <summary>
        /// 无效
        /// </summary>
        public static readonly Location Invalid = new Location(double.NaN, double.NaN, float.NaN);

        /// <summary>
        /// Initializes a new instance of the <see cref="Location"/> class.
        /// 初始化
        /// </summary>
        /// <param name="longitude">经度</param>
        /// <param name="latitude">纬度</param>
        /// <param name="altitude">海拔高度</param>
        public Location(double longitude = 0, double latitude = 0, float altitude = 0)
        {
            Longitude = longitude;
            Latitude = latitude;
            Altitude = altitude;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Location"/> class.
        /// 初始化
        /// </summary>
        private Location()
        {
        }

        /// <summary>
        /// 经度 单位：度（°），取值：-180.0 ~ 180.0，小数点后保留6位。
        /// </summary>
        public double Longitude { get; }

        /// <summary>
        /// 纬度 单位：度（°），取值：-90.0 ~ 90.0，小数点后保留6位。
        /// </summary>
        public double Latitude { get; }

        /// <summary>
        /// 海拔高度 单位：米（m），小数点后保留2位。
        /// </summary>
        public float Altitude { get; }

        /// <summary>
        /// 计算经纬度范围
        /// </summary>
        /// <param name="radius">半径</param>
        /// <returns>经纬度范围</returns>
        public (double West, double East, double North, double South) Calculate(double radius)
        {
            if (this == Location.Invalid)
            {
                return default;
            }

            var (meterPerLongitude, meterPerLatitude) = MeterPerLonLat();
            var west = Longitude - (radius / meterPerLongitude);
            var east = Longitude + (radius / meterPerLongitude);
            var north = Latitude + (radius / meterPerLatitude);
            var south = Latitude - (radius / meterPerLatitude);
            return (west, east, north, south);
        }

        /// <summary>
        /// 每1度经纬度对应的长度
        /// </summary>
        /// <returns>每1度经纬度对应的长度</returns>
        public (double meterPerLongitude, double meterPerLatitude) MeterPerLonLat()
        {
            var p1 = new Location(Longitude - 0.5, Latitude).ToCoordinate();
            var p2 = new Location(Longitude + 0.5, Latitude).ToCoordinate();
            var p3 = new Location(Longitude, Latitude - 0.5).ToCoordinate();
            var p4 = new Location(Longitude, Latitude + 0.5).ToCoordinate();
            return (p1.GetDistance(p2), p3.GetDistance(p4));
        }

        /// <summary>
        /// 转换垂直坐标系
        /// </summary>
        /// <param name="location">参考位置</param>
        /// <returns>垂直坐标系</returns>
        public Coordinate ToXyz(Location location)
        {
            var (meterPerLongitude, meterPerLatitude) = location.MeterPerLonLat();
            var x = Longitude * meterPerLongitude;
            var y = Latitude * meterPerLatitude;
            return new Coordinate(x, y, Altitude);
        }

        /// <summary>
        /// 转换为三维球坐标模型
        /// </summary>
        /// <param name="radius">地球半径（默认为地球平均半径：6371004）</param>
        /// <returns>三维球坐标</returns>
        public Coordinate ToCoordinate(float radius = 6371004)
        {
            // 转换为弧度
            var lonRadian = Longitude / 180 * Math.PI;
            var latRadian = Latitude / 180 * Math.PI;
            var x = radius * Math.Cos(latRadian) * Math.Cos(lonRadian);
            var y = radius * Math.Cos(latRadian) * Math.Sin(lonRadian);
            var z = radius * Math.Sin(latRadian);
            return new Coordinate(x, y, z);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"({Longitude}, {Latitude}) / {Altitude}m";
        }
    }
}