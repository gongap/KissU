using System;
using System.Collections.Generic;

namespace KissU.Util.Tools.Offices.Tests.Integration.Exports
{
    /// <summary>
    /// OfficeTest.
    /// </summary>
    public class OfficeTest
    {
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="OfficeTest" /> is test1.
        /// </summary>
        public bool Test1 { get; set; }

        /// <summary>
        /// Gets or sets the test2.
        /// </summary>
        public int Test2 { get; set; }

        /// <summary>
        /// Gets or sets the test3.
        /// </summary>
        public DateTime Test3 { get; set; }

        /// <summary>
        /// Gets or sets the test4.
        /// </summary>
        public string Test4 { get; set; }

        /// <summary>
        /// Gets or sets the test5.
        /// </summary>
        public string Test5 { get; set; }

        /// <summary>
        /// Gets or sets the test6.
        /// </summary>
        public string Test6 { get; set; }

        /// <summary>
        /// Gets or sets the test7.
        /// </summary>
        public string Test7 { get; set; }

        /// <summary>
        /// Gets or sets the test8.
        /// </summary>
        public string Test8 { get; set; }

        /// <summary>
        /// Gets or sets the test9.
        /// </summary>
        public string Test9 { get; set; }

        /// <summary>
        /// Gets or sets the test10.
        /// </summary>
        public string Test10 { get; set; }

        /// <summary>
        /// Gets or sets the test11.
        /// </summary>
        public string Test11 { get; set; }

        /// <summary>
        /// Gets or sets the test12.
        /// </summary>
        public string Test12 { get; set; }

        /// <summary>
        /// Gets or sets the test13.
        /// </summary>
        public string Test13 { get; set; }

        /// <summary>
        /// Gets or sets the test14.
        /// </summary>
        public string Test14 { get; set; }

        /// <summary>
        /// Gets or sets the test15.
        /// </summary>
        public string Test15 { get; set; }

        /// <summary>
        /// Gets or sets the test16.
        /// </summary>
        public string Test16 { get; set; }

        /// <summary>
        /// Creates the list.
        /// </summary>
        /// <returns>List&lt;OfficeTest&gt;.</returns>
        public static List<OfficeTest> CreateList()
        {
            return new List<OfficeTest>
            {
                new OfficeTest
                {
                    Test1 = true,
                    Test2 = 2,
                    Test3 = DateTime.Now,
                    Test4 = "4a",
                    Test5 = "a5",
                    Test6 = "a6",
                    Test7 = "a7",
                    Test8 = "a8",
                    Test9 = "a9",
                    Test10 = "a10",
                    Test11 = "a11",
                    Test12 = "a12",
                    Test13 = "a13",
                    Test14 = "a14",
                    Test15 = "a15",
                    Test16 = "a16"
                },
                new OfficeTest
                {
                    Test1 = false,
                    Test2 = 2,
                    Test3 = DateTime.Now,
                    Test4 = "4a",
                    Test5 = "a5",
                    Test6 = "a6",
                    Test7 = "a7",
                    Test8 = "a8",
                    Test9 = "a9",
                    Test10 = "a10",
                    Test11 = "a11",
                    Test12 = "a12",
                    Test13 = "a13",
                    Test14 = "a14",
                    Test15 = "a15",
                    Test16 = "a16"
                }
            };
        }

        /// <summary>
        /// Creates the list2.
        /// </summary>
        /// <returns>List&lt;OfficeTest&gt;.</returns>
        public static List<OfficeTest> CreateList2()
        {
            var list = new List<OfficeTest>();
            for (var i = 0; i < 50000; i++) list.AddRange(CreateList());
            return list;
        }
    }
}