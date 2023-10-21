using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AuthSimulator.Business.Utility
{
    /// <summary>
    /// Utility
    /// </summary>
    public static class Utility
    {
        /// <summary>
        /// Convert an object to a query string
        /// </summary>
        /// <typeparam name="T">Generic Type for object</typeparam>
        /// <param name="model">Object</param>
        /// <returns></returns>
        public static string ToQueryString<T>(this T model)
        {
            var json = JsonSerializer.Serialize(model);
            var dic = JsonSerializer.Deserialize<Dictionary<string, object>>(json);
            if (dic == null)
                return "";
            var result = dic.Where(x => x.Value != null)
                   .Select(x => string.Format($"{Uri.EscapeDataString(x.Key)}={Uri.EscapeDataString(x.Value.ToString() ?? "")}"));

            return string.Join("&", result);

        }

        /// <summary>
        /// Generate a random code
        /// </summary>
        /// <param name="length">Code length</param>
        /// <returns>Generated code</returns>
        public static string GenerateCode(int length)
        {
            Random random = new(Environment.TickCount);
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
