using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.Helpers
{
    public static class RemoveDiacritics
    {
        public static string Handle(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            input = input.Replace("đ", "d").Replace("Đ", "D");

            // Bước 1: Chuẩn hóa chuỗi thành dạng FormD (Decomposed)
            var normalizedString = input.Normalize(NormalizationForm.FormD);

            // Bước 2: Lọc bỏ các ký tự dấu (diacritics)
            var stringBuilder = new StringBuilder();
            foreach (var c in normalizedString)
            {
                var unicodeCategory = System.Globalization.CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != System.Globalization.UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            // Bước 3: Chuẩn hóa chuỗi về dạng FormC (Composed) và trả về kết quả
            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }
    }
}
