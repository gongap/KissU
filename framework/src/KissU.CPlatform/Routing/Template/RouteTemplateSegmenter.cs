using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace KissU.CPlatform.Routing.Template
{
    /// <summary>
    /// 路由模板分割器.
    /// </summary>
    public class RouteTemplateSegmenter
    {
        /// <summary>
        /// 分割指定的路径.
        /// </summary>
        /// <param name="routePath">The route path.</param>
        /// <param name="path">The path.</param>
        /// <returns>Dictionary&lt;System.String, System.Object&gt;.</returns>
        public static Dictionary<string, object> Segment(string routePath, string path)
        {
            var pattern = "/{.*?}";
            var result = new Dictionary<string, object>();
            if (Regex.IsMatch(routePath, pattern))
            {
                var routeTemplate = Regex.Replace(routePath, pattern, string.Empty);
                var routeSegments = routeTemplate.Split('/');
                var pathSegments = path.Split('/');
                var segments = routePath.Split("/");
                for (var i = routeSegments.Length; i < pathSegments.Length; i++)
                {
                    result.Add(segments[i].Replace("{", string.Empty).Replace("}", string.Empty), pathSegments[i]);
                }
            }

            return result;
        }
    }
}