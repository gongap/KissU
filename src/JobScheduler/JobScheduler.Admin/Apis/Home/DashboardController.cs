using Microsoft.AspNetCore.Mvc;
using Util.Ui.Viser.Data;
using Util.Webs.Controllers;

namespace JobScheduler.Admin.Apis.Home
{
    /// <summary>
    /// Dashboard控制器
    /// </summary>
    public class DashboardController : WebApiControllerBase
    {
        #region Area
        /// <summary>
        /// 获取基础面积图数据
        /// </summary>
        [HttpGet("area")]
        public IActionResult GetBasicArea()
        {
            var data = new ChartData();
            data.Add("1991", 15468);
            data.Add("1992", 16100);
            data.Add("1993", 15900);
            data.Add("1994", 17409);
            data.Add("1995", 17000);
            data.Add("1996", 31056);
            data.Add("1997", 31982);
            data.Add("1998", 32040);
            data.Add("1999", 33233);
            return Success(data.ToResult());
        }

        /// <summary>
        /// 获取多区域面积图数据
        /// </summary>
        [HttpGet("area/multi")]
        public IActionResult GetMultiArea()
        {
            var data = new ChartData();
            data.Add("1996", new Point("north", 322), new Point("south", 162));
            data.Add("1997", new Point("north", 324), new Point("south", 90));
            data.Add("1998", new Point("north", 329), new Point("south", 50));
            data.Add("1999", new Point("north", 342), new Point("south", 77));
            data.Add("2000", new Point("north", 348), new Point("south", 35));
            data.Add("2001", new Point("north", 334), new Point("south", -45));
            data.Add("2002", new Point("north", 325), new Point("south", -88));
            data.Add("2003", new Point("north", 316), new Point("south", -120));
            data.Add("2004", new Point("north", 318), new Point("south", -156));
            data.Add("2005", new Point("north", 330), new Point("south", -123));
            data.Add("2006", new Point("north", 355), new Point("south", -88));
            data.Add("2007", new Point("north", 366), new Point("south", -66));
            data.Add("2008", new Point("north", 337), new Point("south", -45));
            data.Add("2009", new Point("north", 352), new Point("south", -29));
            data.Add("2010", new Point("north", 377), new Point("south", -45));
            data.Add("2011", new Point("north", 383), new Point("south", -88));
            data.Add("2012", new Point("north", 344), new Point("south", -132));
            data.Add("2013", new Point("north", 366), new Point("south", -146));
            data.Add("2014", new Point("north", 389), new Point("south", -169));
            data.Add("2015", new Point("north", 334), new Point("south", -184));
            return Success(data.ToResult());
        }
        #endregion

        #region Bar
        /// <summary>
        /// 获取基础条形图数据
        /// </summary>
        [HttpGet("bar")]
        public IActionResult GetBasicBar()
        {
            var data = new ChartData();
            data.Add("印度", 104970);
            data.Add("美国", 29034);
            data.Add("巴西", 18203);
            data.Add("中国", 131744);
            data.Add("印尼", 23489);
            return Success(data.ToResult());
        }

        /// <summary>
        /// 获取分组条形图数据
        /// </summary>
        [HttpGet("bar/group")]
        public IActionResult GetGroupBar()
        {
            var data = new ChartData();
            data.Add("Mon", new Point("series1", 2800), new Point("series2", 2260));
            data.Add("Fri", new Point("series1", 170), new Point("series2", 100));
            data.Add("Wed", new Point("series1", 950), new Point("series2", 900));
            data.Add("Thur", new Point("series1", 500), new Point("series2", 390));
            data.Add("Tues", new Point("series1", 1800), new Point("series2", 1300));
            return Success(data.ToResult());
        }
        #endregion

        #region Column
        /// <summary>
        /// 获取基础柱状图数据
        /// </summary>
        [HttpGet("column")]
        public IActionResult GetBasicColumn()
        {
            var data = new ChartData();
            data.Add("1991", 3);
            data.Add("1992", 4);
            data.Add("1993", 3.5);
            data.Add("1994", 5);
            data.Add("1995", 4.9);
            data.Add("1996", 6);
            data.Add("1997", 7);
            data.Add("1998", 9);
            data.Add("1999", 13);
            return Success(data.ToColumnResult());
        }

        /// <summary>
        /// 获取分组柱状图数据
        /// </summary>
        [HttpGet("column/group")]
        public IActionResult GetGroupColumn()
        {
            var data = new ChartData();
            data.Add("Jan", new Point("Tokyo", 7.0), new Point("London", 3.9));
            data.Add("Feb", new Point("Tokyo", 6.9), new Point("London", 4.2));
            data.Add("Mar", new Point("Tokyo", 9.5), new Point("London", 5.7));
            data.Add("Apr", new Point("Tokyo", 14.5), new Point("London", 8.5));
            data.Add("May", new Point("Tokyo", 18.4), new Point("London", 11.9));
            data.Add("Jun", new Point("Tokyo", 21.5), new Point("London", 15.2));
            data.Add("Jul", new Point("Tokyo", 25.2), new Point("London", 17.0));
            data.Add("Aug", new Point("Tokyo", 26.5), new Point("London", 16.6));
            data.Add("Sep", new Point("Tokyo", 23.3), new Point("London", 14.2));
            data.Add("Oct", new Point("Tokyo", 18.3), new Point("London", 10.3));
            data.Add("Nov", new Point("Tokyo", 13.9), new Point("London", 6.6));
            data.Add("Dec", new Point("Tokyo", 9.6), new Point("London", 4.8));
            return Success(data.ToColumnResult());
        }
        #endregion

        #region Line
        /// <summary>
        /// 获取基础折线图数据
        /// </summary>
        [HttpGet("line")]
        public IActionResult GetBasicLine()
        {
            var data = new ChartData();
            data.Add("1991", 3);
            data.Add("1992", 4);
            data.Add("1993", 3.5);
            data.Add("1994", 5);
            data.Add("1995", 4.9);
            data.Add("1996", 6);
            data.Add("1997", 7);
            data.Add("1998", 9);
            data.Add("1999", 13);
            return Success(data.ToResult());
        }
        /// <summary>
        /// 获取空折线图数据
        /// </summary>
        [HttpGet("line/empty")]
        public IActionResult GetEmptyLine()
        {
            var data = new ChartData();
            return Success(data.ToResult());
        }

        /// <summary>
        /// 获取多条折线图数据
        /// </summary>
        [HttpGet("line/multi")]
        public IActionResult GetMultiLine()
        {
            var data = new ChartData();
            data.Add("Jan", new Point("Tokyo", 7.0), new Point("London", 3.9));
            data.Add("Feb", new Point("Tokyo", 6.9), new Point("London", 4.2));
            data.Add("Mar", new Point("Tokyo", 9.5), new Point("London", 5.7));
            data.Add("Apr", new Point("Tokyo", 14.5), new Point("London", 8.5));
            data.Add("May", new Point("Tokyo", 18.4), new Point("London", 11.9));
            data.Add("Jun", new Point("Tokyo", 21.5), new Point("London", 15.2));
            data.Add("Jul", new Point("Tokyo", 25.2), new Point("London", 17.0));
            data.Add("Aug", new Point("Tokyo", 26.5), new Point("London", 16.6));
            data.Add("Sep", new Point("Tokyo", 23.3), new Point("London", 14.2));
            data.Add("Oct", new Point("Tokyo", 18.3), new Point("London", 10.3));
            data.Add("Nov", new Point("Tokyo", 13.9), new Point("London", 6.6));
            data.Add("Dec", new Point("Tokyo", 9.6), new Point("London", 4.8));
            return Success(data.ToResult());
        }
        #endregion

        #region Pie
        /// <summary>
        /// 获取基础饼图数据
        /// </summary>
        [HttpGet("pie")]
        public IActionResult GetBasicPie()
        {
            var data = new ChartData();
            data.Add("事例一", 40);
            data.Add("事例二", 21);
            data.Add("事例三", 17);
            data.Add("事例四", 13);
            data.Add("事例五", 9);
            return Success(data.ToResult());
        }

        /// <summary>
        /// 获取南丁格尔玫瑰图数据
        /// </summary>
        [HttpGet("pie/rose")]
        public IActionResult GetRosePie()
        {
            var data = new ChartData();
            data.Add("2001", 41.8);
            data.Add("2002", 38);
            data.Add("2003", 33.7);
            data.Add("2004", 30.7);
            data.Add("2005", 25.8);
            data.Add("2006", 31.7);
            data.Add("2007", 33);
            data.Add("2008", 46);
            data.Add("2009", 38.3);
            data.Add("2010", 28);
            data.Add("2011", 42.5);
            data.Add("2012", 30.3);
            return Success(data.ToResult());
        }
        #endregion
    }
}