using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.Helpers
{
    public  class ConvertToSlugHelper
    {
        public static string ConvertToUnaccentedSlug(string input)
        {
            if (string.IsNullOrEmpty(input)) return string.Empty;

            // Thay thế các ký tự đặc biệt tiếng Việt 'Đ' và 'đ'
            input = input.Replace("Đ", "D").Replace("đ", "d");
            input = input.Replace("Ư", "U").Replace("ư", "u");
            input = input.Replace("Ơ", "O").Replace("ơ", "o");
            // Chuẩn hóa chuỗi thành FormD để tách dấu khỏi ký tự gốc
            var normalizedString = input.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark) // Bỏ qua các dấu
                {
                    stringBuilder.Append(c);
                }
            }

            // Chuyển chuỗi không dấu hoàn chỉnh và loại bỏ các ký tự đặc biệt
            var unaccentedString = stringBuilder.ToString().Normalize(NormalizationForm.FormC);
            unaccentedString = Regex.Replace(unaccentedString, @"[^a-zA-Z0-9\s-]", ""); // Loại bỏ ký tự không hợp lệ
            unaccentedString = Regex.Replace(unaccentedString, @"\s+", "-"); // Thay khoảng trắng bằng dấu gạch ngang
            unaccentedString = Regex.Replace(unaccentedString, @"-+", "-"); // Xử lý các dấu gạch ngang liên tiếp

            return unaccentedString.ToLower().Trim('-') + "-" + DateTime.Now.Ticks.ToString(); // Chuyển về chữ thường và loại bỏ dấu gạch ngang đầu/cuối
        }
    }
}
