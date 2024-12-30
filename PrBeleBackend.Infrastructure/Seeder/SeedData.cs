using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PrBeleBackend.Core.Domain.Entities;
using PrBeleBackend.Infrastructure.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Infrastructure.Seeder
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            BeleStoreContext _context = app.ApplicationServices.CreateScope().ServiceProvider
                .GetRequiredService<BeleStoreContext>();
            if (_context.Database.GetPendingMigrations().Any())
            {
                _context.Database.Migrate();
            }
            if (!_context.categories.Any())
            {
                var categoriesSeed = new List<Category>(){
                   new Category {
                    Name = "Tất cả Áo Nam",
                    Status = 1,
                    Slug = "tat-ca-ao-nam",
                    Deleted = false,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                },
                          new Category {
                    Name = "Tất cả Quần Nam",
                    Status = 1,
                    Slug = "tat-ca-quan-nam",
                    Deleted = false,
                        CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                },
                          new Category {
                    Name = "Tất cả phụ kiện",
                    Status = 1,
                    Slug = "tat-ca-phu-kien",
                    Deleted = false,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                },
                new Category {
                    Name = "Áo thun",
                    ReferenceCategoryId = 1,
                    Status = 1,
                    Slug = "ao-thun",
                    Deleted = false,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                },
                new Category {
                    Name = "Áo sơ mi",
                    ReferenceCategoryId = 1,
                    Status = 1,
                    Slug = "ao-so-mi",
                    Deleted = false,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                },
                new Category {
                    Name = "Áo polo",
                    ReferenceCategoryId = 1,
                    Status = 1,
                    Slug = "ao-polo",
                    Deleted = false,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                },
                new Category {
                    Name = "Áo dài tay",
                    ReferenceCategoryId = 1,
                    Status = 1,
                    Slug = "ao-dai-tay",
                    Deleted = false,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                },
                new Category {
                    Name = "Áo khoác",
                    ReferenceCategoryId = 1,
                    Status = 1,
                    Slug = "ao-khoac",
                    Deleted = false,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                },
                new Category {
                    Name = "Áo Tanktop",
                    ReferenceCategoryId = 1,
                    Status = 1,
                    Slug = "ao-tanktop",
                    Deleted = false,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                },
                new Category {
                    Name = "Áo thể thao",
                    ReferenceCategoryId = 1,
                    Status = 1,
                    Slug = "ao-the-thao",
                    Deleted = false,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                },

                new Category {
                    Name = "Quần shorts",
                    ReferenceCategoryId = 2,
                    Status = 1,
                    Slug = "quan-shorts",
                    Deleted = false,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                },
                new Category {
                    Name = "Quần jeans",
                    ReferenceCategoryId = 2,
                    Status = 1,
                    Slug = "quan-jeans",
                    Deleted = false,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                },
                new Category {
                    Name = "Quần dài",
                    ReferenceCategoryId = 2,
                    Status = 1,
                    Slug = "quan-dai",
                    Deleted = false,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                },
                new Category {
                    Name = "Quần thể thao",
                    ReferenceCategoryId = 2,
                    Status = 1,
                    Slug = "quan-the-thao",
                    Deleted = false,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                },
                new Category {
                    Name = "Quần lót",
                    ReferenceCategoryId = 2,
                    Status = 1,
                    Slug = "quan-lot",
                    Deleted = false,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                },
                new Category {
                    Name = "Quần bơi",
                    ReferenceCategoryId = 2,
                    Status = 1,
                    Slug = "quan-boi",
                    Deleted = false,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                },

                new Category {
                    Name = "Tất/Vớ",
                    ReferenceCategoryId = 3,
                    Status = 1,
                    Slug = "tat-vo",
                    Deleted = false,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                },
                new Category {
                    Name = "Mũ/Nón",
                    ReferenceCategoryId = 3,
                    Status = 1,
                    Slug = "mu-non",
                    Deleted = false,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                },
                new Category {
                    Name = "Túi",
                    ReferenceCategoryId = 3,
                    Status = 1,
                    Slug = "tui",
                    Deleted = false,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                },
                new Category {
                    Name = "Ví/Thắt lưng",
                    ReferenceCategoryId = 3,
                    Status = 1,
                    Slug = "vi-that-lung",
                    Deleted = false,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                },
                new Category {
                    Name = "Ly/Cốc",
                    ReferenceCategoryId = 3,
                    Status = 1,
                    Slug = "ly-coc",
                    Deleted = false,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                },

                                };
                _context.categories.AddRange(categoriesSeed);
                _context.SaveChanges();

            }
            if (!_context.products.Any()&& !_context.attributeValues.Any()&& !_context.variantAttributeValues.Any() && !_context.attributeTypes.Any() && !_context.variants.Any())
            {
                var productsSeed = new List<Product>{
                             new Product
{
    Name = "Áo giữ nhiệt Ex-Warm Lenzing Modal cổ cao",
    Description = "Áo giữ nhiệt Ex-Warm Lenzing Modal cổ cao cho mùa đông ấm áp.",
    DescriptionPlainText = "Áo giữ nhiệt Ex-Warm Lenzing Modal cổ cao.",
    CategoryId = 4,
    Thumbnail = "https://media3.coolmate.me/cdn-cgi/image/quality=80,format=auto/uploads/November2024/24CMHU.GN003_-TRANG.jpg",
    BasePrice = 209000M,
    View = 150,
    Like = 50,
    Slug = "ao-giu-nhiet-ex-warm-modal-co-cao",
    Status = 1,
    Deleted = false,
    CreatedAt = DateTime.Now,
    UpdatedAt = DateTime.Now
},
                            new Product
                            {
                                Name = "Áo giữ nhiệt Essential Brush Poly cổ thấp",
                                Description = "Áo giữ nhiệt Essential Brush Poly cổ thấp, chất liệu mềm mại và giữ ấm tốt.",
                                DescriptionPlainText = "Áo giữ nhiệt Essential Brush Poly cổ thấp.",
                                CategoryId = 4,
                                Thumbnail = "https://media3.coolmate.me/cdn-cgi/image/quality=80,format=auto/uploads/November2024/24CMHU.GN003_-TRANG.jpg",
                                BasePrice = 127000M,
                                View = 120,
                                Like = 40,
                                Slug = "ao-giu-nhiet-brush-poly-co-thap",
                                Status = 1,
                                Deleted = false,
    CreatedAt = DateTime.Now,
    UpdatedAt = DateTime.Now
                            },
                            new Product
                            {
                                Name = "Áo giữ nhiệt Essential Brush Poly cổ trung",
                                Description = "Áo giữ nhiệt Essential Brush Poly cổ trung, thiết kế đơn giản và hiệu quả giữ ấm.",
                                DescriptionPlainText = "Áo giữ nhiệt Essential Brush Poly cổ trung.",
                                CategoryId = 4,
                                Thumbnail = "https://media3.coolmate.me/cdn-cgi/image/quality=80,format=auto/uploads/November2024/24CMHU.GN003_-TRANG.jpg",
                                BasePrice = 127000M,
                                View = 130,
                                Like = 45,
                                Slug = "ao-giu-nhiet-brush-poly-co-trung",
                                Status = 1,
                                Deleted = false,
    CreatedAt = DateTime.Now,
    UpdatedAt = DateTime.Now
                            },
                            new Product
                            {
                                Name = "Áo giữ nhiệt Ex-Warm Lenzing Modal cổ trung",
                                Description = "Áo giữ nhiệt Ex-Warm Lenzing Modal cổ trung, lựa chọn hoàn hảo cho mùa lạnh.",
                                DescriptionPlainText = "Áo giữ nhiệt Ex-Warm Lenzing Modal cổ trung.",
                                CategoryId = 4,
                                Thumbnail = "https://media3.coolmate.me/cdn-cgi/image/quality=80,format=auto/uploads/November2024/24CMHU.GN003_-TRANG.jpg",
                                BasePrice = 209000M,
                                View = 180,
                                Like = 60,
                                Slug = "ao-giu-nhiet-ex-warm-modal-co-trung",
                                Status = 1,
                                Deleted = false,
    CreatedAt = DateTime.Now,
    UpdatedAt = DateTime.Now
                            },
                            new Product
                            {
                                Name = "Áo thun Relaxed Fit 84RISING Venom Signature",
                                Description = "Áo thun Relaxed Fit 84RISING Venom Signature phong cách trẻ trung, nổi bật.",
                                DescriptionPlainText = "Áo thun Relaxed Fit 84RISING Venom Signature.",
                                CategoryId = 4,
                                Thumbnail = "https://media3.coolmate.me/cdn-cgi/image/quality=80,format=auto/uploads/November2024/24CMHU.GN003_-TRANG.jpg",
                                BasePrice = 399000M,
                                View = 200,
                                Like = 70,
                                Slug = "ao-thun-relaxed-fit-84rising-venom-signature",
                                Status = 1,
                                Deleted = false,
    CreatedAt = DateTime.Now,
    UpdatedAt = DateTime.Now
                            },
                            new Product
                            {
                                Name = "Áo thun Relaxed Fit 84RISING HEHEHE",
                                Description = "Áo thun Relaxed Fit 84RISING HEHEHE năng động, thoải mái khi sử dụng.",
                                DescriptionPlainText = "Áo thun Relaxed Fit 84RISING HEHEHE.",
                                CategoryId = 4,
                                Thumbnail = "https://media3.coolmate.me/cdn-cgi/image/quality=80,format=auto/uploads/November2024/24CMHU.GN003_-TRANG.jpg",
                                BasePrice = 399000M,
                                View = 180,
                                Like = 65,
                                Slug = "ao-thun-relaxed-fit-84rising-hehehe",
                                Status = 1,
                                Deleted = false,
    CreatedAt = DateTime.Now,
    UpdatedAt = DateTime.Now
                            },
                            new Product
                            {
                                Name = "Áo giữ nhiệt Ex-Warm Lenzing Modal cổ ngắn",
                                Description = "Áo giữ nhiệt Ex-Warm Lenzing Modal cổ ngắn, lựa chọn tiện lợi cho mùa lạnh.",
                                DescriptionPlainText = "Áo giữ nhiệt Ex-Warm Lenzing Modal cổ ngắn.",
                                CategoryId = 4,
                                Thumbnail = "https://media3.coolmate.me/cdn-cgi/image/quality=80,format=auto/uploads/November2024/24CMHU.GN003_-TRANG.jpg",
                                BasePrice = 209000M,
                                View = 150,
                                Like = 50,
                                Slug = "ao-giu-nhiet-ex-warm-lenzing-modal-co-ngan",
                                Status = 1,
                                Deleted = false,
    CreatedAt = DateTime.Now,
    UpdatedAt = DateTime.Now
                            },
                            new Product
                            {
                                Name = "Áo Thun Nam Chạy Bộ Graphic Dot",
                                Description = "Áo Thun Nam Chạy Bộ Graphic Dot, thiết kế thể thao với phong cách hiện đại.",
                                DescriptionPlainText = "Áo Thun Nam Chạy Bộ Graphic Dot.",
                                CategoryId = 4,
                                Thumbnail = "https://media3.coolmate.me/cdn-cgi/image/quality=80,format=auto/uploads/November2024/24CMHU.GN003_-TRANG.jpg",
                                BasePrice = 199000M,
                                View = 170,
                                Like = 55,
                                Slug = "ao-thun-nam-chay-bo-graphic-dot",
                                Status = 1,
                                Deleted = false,
    CreatedAt = DateTime.Now,
    UpdatedAt = DateTime.Now
                            },
                             new Product
{
    Name = "Quần shorts ECC Ripstop",
    Description = "Quần shorts ECC Ripstop thiết kế thoải mái, chất liệu bền bỉ phù hợp với hoạt động thể thao.",
    DescriptionPlainText = "Quần shorts ECC Ripstop.",
    CategoryId = 11,
    Thumbnail = "https://media3.coolmate.me/cdn-cgi/image/width=672,height=990,quality=85/uploads/July2024/24CMAW.QS022.36_70.jpg",
    BasePrice = 239000M,
    View = 140,
    Like = 60,
    Slug = "quan-shorts-ecc-ripstop",
    Status = 1,
    Deleted = false,
    CreatedAt = DateTime.Now,
    UpdatedAt = DateTime.Now
},
                            new Product
                            {
                                Name = "Quần shorts 6 inch Racquet Sports",
                                Description = "Quần shorts 6 inch Racquet Sports, thiết kế chuyên dụng cho các môn thể thao vợt.",
                                DescriptionPlainText = "Quần shorts 6 inch Racquet Sports.",
                                CategoryId = 11,
                                Thumbnail = "https://media3.coolmate.me/cdn-cgi/image/width=672,height=990,quality=85/uploads/July2024/24CMAW.QS022.36_70.jpg",
                                BasePrice = 189000M,
                                View = 130,
                                Like = 55,
                                Slug = "quan-shorts-6-inch-racquet-sports",
                                Status = 1,
                                Deleted = false,
    CreatedAt = DateTime.Now,
    UpdatedAt = DateTime.Now
                            },
                            new Product
                            {
                                Name = "Quần Shorts chạy bộ Advanced Vent Tech",
                                Description = "Quần Shorts chạy bộ Advanced Vent Tech, thoáng khí và thoải mái cho người chạy.",
                                DescriptionPlainText = "Quần Shorts chạy bộ Advanced Vent Tech.",
                                CategoryId = 11,
                                Thumbnail = "https://media3.coolmate.me/cdn-cgi/image/width=672,height=990,quality=85/uploads/July2024/24CMAW.QS022.36_70.jpg",
                                BasePrice = 209000M,
                                View = 150,
                                Like = 70,
                                Slug = "quan-shorts-chay-bo-advanced-vent-tech",
                                Status = 1,
                                Deleted = false,
    CreatedAt = DateTime.Now,
    UpdatedAt = DateTime.Now
                            },
                            new Product
                            {
                                Name = "Quần shorts nam chạy bộ CoolFast 3.5 inch",
                                Description = "Quần shorts nam chạy bộ CoolFast 3.5 inch với thiết kế nhẹ và công nghệ CoolFast.",
                                DescriptionPlainText = "Quần shorts nam chạy bộ CoolFast 3.5 inch.",
                                CategoryId = 11,
                                Thumbnail = "https://media3.coolmate.me/cdn-cgi/image/width=672,height=990,quality=85/uploads/July2024/24CMAW.QS022.36_70.jpg",
                                BasePrice = 249000M,
                                View = 160,
                                Like = 65,
                                Slug = "quan-shorts-nam-coolfast-3-5-inch",
                                Status = 1,
                                Deleted = false,
    CreatedAt = DateTime.Now,
    UpdatedAt = DateTime.Now
                            },
                            new Product
                            {
                                Name = "Quần shorts nam chạy bộ CoolFast 5 inch",
                                Description = "Quần shorts nam chạy bộ CoolFast 5 inch với thiết kế thoáng khí và công nghệ CoolFast.",
                                DescriptionPlainText = "Quần shorts nam chạy bộ CoolFast 5 inch.",
                                CategoryId = 11,
                                Thumbnail = "https://media3.coolmate.me/cdn-cgi/image/width=672,height=990,quality=85/uploads/July2024/24CMAW.QS022.36_70.jpg",
                                BasePrice = 329000M,
                                View = 170,
                                Like = 75,
                                Slug = "quan-shorts-nam-coolfast-5-inch",
                                Status = 1,
                                Deleted = false,
    CreatedAt = DateTime.Now,
    UpdatedAt = DateTime.Now
                            },
                            new Product
                            {
                                Name = "Quần Shorts Chạy Bộ 2 lớp Fast & Free III",
                                Description = "Quần Shorts Chạy Bộ 2 lớp Fast & Free III, thiết kế năng động và linh hoạt khi tập luyện.",
                                DescriptionPlainText = "Quần Shorts Chạy Bộ 2 lớp Fast & Free III.",
                                CategoryId = 11,
                                Thumbnail = "https://media3.coolmate.me/cdn-cgi/image/width=672,height=990,quality=85/uploads/July2024/24CMAW.QS022.36_70.jpg",
                                BasePrice = 379000M,
                                View = 190,
                                Like = 80,
                                Slug = "quan-shorts-chay-bo-2-lop-fast-free-iii",
                                Status = 1,
                                Deleted = false,
    CreatedAt = DateTime.Now,
    UpdatedAt = DateTime.Now
                            },
                            new Product
                            {
                                Name = "Quần Shorts thể thao 7 inch đa năng",
                                Description = "Quần Shorts thể thao 7 inch đa năng, tiện lợi cho nhiều hoạt động thể thao.",
                                DescriptionPlainText = "Quần Shorts thể thao 7 inch đa năng.",
                                CategoryId = 11,
                                Thumbnail = "https://media3.coolmate.me/cdn-cgi/image/width=672,height=990,quality=85/uploads/July2024/24CMAW.QS022.36_70.jpg",
                                BasePrice = 179000M,
                                View = 160,
                                Like = 65,
                                Slug = "quan-shorts-the-thao-7-inch-da-nang",
                                Status = 1,
                                Deleted = false,
    CreatedAt = DateTime.Now,
    UpdatedAt = DateTime.Now
                            },
                            new Product
                            {
                                Name = "Quần Shorts Chạy Bộ 7 inch Essentials",
                                Description = "Quần Shorts Chạy Bộ 7 inch Essentials, thiết kế đơn giản và hiệu quả cho việc chạy bộ.",
                                DescriptionPlainText = "Quần Shorts Chạy Bộ 7 inch Essentials.",
                                CategoryId = 11,
                                Thumbnail = "https://media3.coolmate.me/cdn-cgi/image/width=672,height=990,quality=85/uploads/July2024/24CMAW.QS022.36_70.jpg",
                                BasePrice = 174000M,
                                View = 150,
                                Like = 60,
                                Slug = "quan-shorts-chay-bo-7-inch-essentials",
                                Status = 1,
                                Deleted = false,
    CreatedAt = DateTime.Now,
    UpdatedAt = DateTime.Now
                            },
                             new Product
{
    Name = "Pack 3 Tất Active cổ trung",
    Description = "Pack 3 đôi tất Active cổ trung thoải mái, phù hợp cho mọi hoạt động thể thao và hàng ngày.",
    DescriptionPlainText = "Pack 3 Tất Active cổ trung.",
    CategoryId = 17,
    Thumbnail = "https://media3.coolmate.me/cdn-cgi/image/width=672,height=990,quality=85/uploads/November2024/TCTCRIBCM_IMG_4300_TRANG_4_36.jpg",
    BasePrice = 99000M,
    View = 120,
    Like = 45,
    Slug = "pack-3-tat-active-co-trung",
    Status = 1,
    Deleted = false,
    CreatedAt = DateTime.Now,
    UpdatedAt = DateTime.Now
},
                            new Product
                            {
                                Name = "Pack 3 Tất Active cổ ngắn",
                                Description = "Pack 3 đôi tất Active cổ ngắn mềm mại, tiện dụng và thoáng khí.",
                                DescriptionPlainText = "Pack 3 Tất Active cổ ngắn.",
                                CategoryId = 17,
                                Thumbnail = "https://media3.coolmate.me/cdn-cgi/image/width=672,height=990,quality=85/uploads/November2024/TCTCRIBCM_IMG_4300_TRANG_4_36.jpg",
                                BasePrice = 99000M,
                                View = 110,
                                Like = 40,
                                Slug = "pack-3-tat-active-co-ngan",
                                Status = 1,
                                Deleted = false,
    CreatedAt = DateTime.Now,
    UpdatedAt = DateTime.Now
                            },
                            new Product
                            {
                                Name = "Combo 2 đôi Tất cổ trung Cotton Ribbed Coolmate",
                                Description = "Combo 2 đôi tất cổ trung làm từ Cotton Ribbed Coolmate, mang lại cảm giác mềm mại và bền bỉ.",
                                DescriptionPlainText = "Combo 2 đôi Tất cổ trung Cotton Ribbed Coolmate.",
                                CategoryId = 17,
                                Thumbnail = "https://media3.coolmate.me/cdn-cgi/image/width=672,height=990,quality=85/uploads/November2024/TCTCRIBCM_IMG_4300_TRANG_4_36.jpg",
                                BasePrice = 109000M,
                                View = 130,
                                Like = 50,
                                Slug = "combo-2-doi-tat-co-trung-cotton-ribbed",
                                Status = 1,
                                Deleted = false,
    CreatedAt = DateTime.Now,
    UpdatedAt = DateTime.Now
                            },
                            new Product
                            {
                                Name = "Combo 2 đôi Tất cổ dài Cotton Ribbed Coolmate",
                                Description = "Combo 2 đôi tất cổ dài Cotton Ribbed Coolmate, thiết kế thời trang và thoáng khí.",
                                DescriptionPlainText = "Combo 2 đôi Tất cổ dài Cotton Ribbed Coolmate.",
                                CategoryId = 17,
                                Thumbnail = "https://media3.coolmate.me/cdn-cgi/image/width=672,height=990,quality=85/uploads/November2024/TCTCRIBCM_IMG_4300_TRANG_4_36.jpg",
                                BasePrice = 129000M,
                                View = 140,
                                Like = 55,
                                Slug = "combo-2-doi-tat-co-dai-cotton-ribbed",
                                Status = 1,
                                Deleted = false,
    CreatedAt = DateTime.Now,
    UpdatedAt = DateTime.Now
                            },
                            new Product
                            {
                                Name = "Tất bóng đá cổ cao",
                                Description = "Tất bóng đá cổ cao, thiết kế chuyên dụng và thoáng khí cho các hoạt động thể thao.",
                                DescriptionPlainText = "Tất bóng đá cổ cao.",
                                CategoryId = 17,
                                Thumbnail = "https://media3.coolmate.me/cdn-cgi/image/width=672,height=990,quality=85/uploads/November2024/TCTCRIBCM_IMG_4300_TRANG_4_36.jpg",
                                BasePrice = 55000M,
                                View = 100,
                                Like = 40,
                                Slug = "tat-bong-da-co-cao",
                                Status = 1,
                                Deleted = false,
    CreatedAt = DateTime.Now,
    UpdatedAt = DateTime.Now
                            },
                            new Product
                            {
                                Name = "Tất Nam Cổ Trung Tập Gym Essentials",
                                Description = "Tất Nam cổ trung Tập Gym Essentials, mềm mại, thoải mái khi tập luyện.",
                                DescriptionPlainText = "Tất Nam Cổ Trung Tập Gym Essentials.",
                                CategoryId = 17,
                                Thumbnail = "https://media3.coolmate.me/cdn-cgi/image/width=672,height=990,quality=85/uploads/November2024/TCTCRIBCM_IMG_4300_TRANG_4_36.jpg",
                                BasePrice = 69000M,
                                View = 120,
                                Like = 45,
                                Slug = "tat-nam-co-trung-tap-gym-essentials",
                                Status = 1,
                                Deleted = false,
    CreatedAt = DateTime.Now,
    UpdatedAt = DateTime.Now
                            },
                            new Product
                            {
                                Name = "Tất Thể Thao Seamless Cổ Dài",
                                Description = "Tất thể thao Seamless cổ dài, mang lại cảm giác thoải mái và bền bỉ.",
                                DescriptionPlainText = "Tất Thể Thao Seamless Cổ Dài.",
                                CategoryId = 17,
                                Thumbnail = "https://media3.coolmate.me/cdn-cgi/image/width=672,height=990,quality=85/uploads/November2024/TCTCRIBCM_IMG_4300_TRANG_4_36.jpg",
                                BasePrice = 59000M,
                                View = 110,
                                Like = 50,
                                Slug = "tat-the-thao-seamless-co-dai",
                                Status = 1,
                                Deleted = false,
    CreatedAt = DateTime.Now,
    UpdatedAt = DateTime.Now
                            },
                            new Product
                            {
                                Name = "Combo 10 Đôi Tất Nam Basics",
                                Description = "Combo 10 đôi tất nam Basics, lựa chọn kinh tế và tiện lợi cho sử dụng hàng ngày.",
                                DescriptionPlainText = "Combo 10 Đôi Tất Nam Basics.",
                                CategoryId = 17,
                                Thumbnail = "https://media3.coolmate.me/cdn-cgi/image/width=672,height=990,quality=85/uploads/November2024/TCTCRIBCM_IMG_4300_TRANG_4_36.jpg",
                                BasePrice = 149000M,
                                View = 150,
                                Like = 70,
                                Slug = "combo-10-doi-tat-nam-basics",
                                Status = 1,
                                Deleted = false,
                                CreatedAt = DateTime.Now,
                                UpdatedAt = DateTime.Now
                            }

                                            };
                var productAttributeTypesSeed = new List<ProductAttributeType>();
                _context.products.AddRange(productsSeed);
                _context.SaveChanges();
                var attributeTypesSeed = new List<AttributeType>(){
                    new AttributeType { Name = "Color",
    CreatedAt = DateTime.Now,
    UpdatedAt = DateTime.Now },
                    new AttributeType { Name = "Size",
    CreatedAt = DateTime.Now,
    UpdatedAt = DateTime.Now },
                                                        };
                _context.attributeTypes.AddRange(attributeTypesSeed);
                _context.SaveChanges();
                var attributeValuesSeed = new List<AttributeValue>()
                    {
                        new AttributeValue { Name = "Black", Value = "Black", AttributeTypeId = 1, Deleted = false,
    CreatedAt = DateTime.Now,
    UpdatedAt = DateTime.Now },
                        new AttributeValue { Name = "White", Value = "White", AttributeTypeId = 1, Deleted = false,
    CreatedAt = DateTime.Now,
    UpdatedAt = DateTime.Now },
                        new AttributeValue { Name = "Small", Value = "S", AttributeTypeId = 2, Deleted = false,
    CreatedAt = DateTime.Now,
    UpdatedAt = DateTime.Now },
                        new AttributeValue { Name = "Large", Value = "L", AttributeTypeId = 2, Deleted = false,
    CreatedAt = DateTime.Now,
    UpdatedAt = DateTime.Now },
                    };
                _context.attributeValues.AddRange(attributeValuesSeed);
                _context.SaveChanges();

                for (int i = 1; i <= 24; i++) 
                {
                    productAttributeTypesSeed.Add(new ProductAttributeType { ProductId = i, AttributeTypeId = 1 }); // Color
                    productAttributeTypesSeed.Add(new ProductAttributeType { ProductId = i, AttributeTypeId = 2 }); // Size
                }
                _context.productAttributeTypes.AddRange(productAttributeTypesSeed);
                _context.SaveChanges();
                var variantsSeed = new List<Variant>();
                int variantId = 1;

                for (int productId = 1; productId <= 8; productId++) // 32 sản phẩm
                {
                    // Black - Small
                    variantsSeed.Add(new Variant
                    {
                        ProductId = productId,
                        Price = 209000M,
                        Stock = 10,
                        Thumbnail = $"https://media3.coolmate.me/cdn-cgi/image/width=672,height=990,quality=85/uploads/November2024/24CMHU.GN003_-DEN.jpg",
                        Status = 1,
                        Deleted = false,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    });

                    // Black - Large
                    variantsSeed.Add(new Variant
                    {
                        ProductId = productId,
                        Price = 209000M,
                        Stock = 8,
                        Thumbnail = $"https://media3.coolmate.me/cdn-cgi/image/width=672,height=990,quality=85/uploads/November2024/24CMHU.GN003_-DEN.jpg",
                        Status = 1,
                        Deleted = false,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    });

                    // White - Small
                    variantsSeed.Add(new Variant
                    {
                        ProductId = productId,
                        Price = 209000M,
                        Stock = 12,
                        Thumbnail = $"https://media3.coolmate.me/cdn-cgi/image/width=672,height=990,quality=85/uploads/November2024/24CMHU.GN003_-TRANG.jpg",
                        Status = 1,
                        Deleted = false,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    });

                    // White - Large
                    variantsSeed.Add(new Variant
                    {
                        ProductId = productId,
                        Price = 209000M,
                        Stock = 6,
                        Thumbnail = $"https://media3.coolmate.me/cdn-cgi/image/width=672,height=990,quality=85/uploads/November2024/24CMHU.GN003_-TRANG.jpg",
                        Status = 1,
                        Deleted = false,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    });

                    variantId += 4;
                }
                for (int productId = 9; productId <= 16; productId++) // 32 sản phẩm
                {
                    // Black - Small
                    variantsSeed.Add(new Variant
                    {
                        ProductId = productId,
                        Price = 209000M,
                        Stock = 10,
                        Thumbnail = $"https://media3.coolmate.me/cdn-cgi/image/width=672,height=990,quality=85/uploads/August2024/Den_1.1.jpg",
                        Status = 1,
                        Deleted = false,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    });

                    // Black - Large
                    variantsSeed.Add(new Variant
                    {
                        ProductId = productId,
                        Price = 209000M,
                        Stock = 8,
                        Thumbnail = $"https://media3.coolmate.me/cdn-cgi/image/width=672,height=990,quality=85/uploads/August2024/Den_1.1.jpg",
                        Status = 1,
                        Deleted = false,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    });

                    // White - Small
                    variantsSeed.Add(new Variant
                    {
                        ProductId = productId,
                        Price = 209000M,
                        Stock = 12,
                        Thumbnail = $"https://media3.coolmate.me/cdn-cgi/image/width=672,height=990,quality=85/uploads/September2024/Xam_Sang_1.jpg",
                        Status = 1,
                        Deleted = false,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    });

                    // White - Large
                    variantsSeed.Add(new Variant
                    {
                        ProductId = productId,
                        Price = 209000M,
                        Stock = 6,
                        Thumbnail = $"https://media3.coolmate.me/cdn-cgi/image/width=672,height=990,quality=85/uploads/September2024/Xam_Sang_1.jpg",
                        Status = 1,
                        Deleted = false,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    });

                    variantId += 4;
                }
                for (int productId = 17; productId <= 24; productId++) // 32 sản phẩm
                {
                    // Black - Small
                    variantsSeed.Add(new Variant
                    {
                        ProductId = productId,
                        Price = 209000M,
                        Stock = 10,
                        Thumbnail = $"https://media3.coolmate.me/cdn-cgi/image/width=672,height=990,quality=85/uploads/March2024/tatgymlogomoithumb.2_39.jpg",
                        Status = 1,
                        Deleted = false,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    });

                    // Black - Large
                    variantsSeed.Add(new Variant
                    {
                        ProductId = productId,
                        Price = 209000M,
                        Stock = 8,
                        Thumbnail = $"https://media3.coolmate.me/cdn-cgi/image/width=672,height=990,quality=85/uploads/March2024/tatgymlogomoithumb.2_39.jpg",
                        Status = 1,
                        Deleted = false,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    });

                    // White - Small
                    variantsSeed.Add(new Variant
                    {
                        ProductId = productId,
                        Price = 209000M,
                        Stock = 12,
                        Thumbnail = $"https://media3.coolmate.me/cdn-cgi/image/width=672,height=990,quality=85/uploads/March2024/tatgymlogomoithumb.1_75.jpg",
                        Status = 1,
                        Deleted = false,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    });

                    // White - Large
                    variantsSeed.Add(new Variant
                    {
                        ProductId = productId,
                        Price = 209000M,
                        Stock = 6,
                        Thumbnail = $"https://media3.coolmate.me/cdn-cgi/image/width=672,height=990,quality=85/uploads/March2024/tatgymlogomoithumb.1_75.jpg",
                        Status = 1,
                        Deleted = false,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    });

                    variantId += 4;
                }
                _context.variants.AddRange(variantsSeed);
                _context.SaveChanges();
                var variantAttributeValuesSeed = new List<VariantAttributeValue>();
                int variantCounter = 1;

                for (int productId = 1; productId <= 24; productId++) // Duyệt qua tất cả 32 sản phẩm
                {
                    // Black - Small
                    variantAttributeValuesSeed.Add(new VariantAttributeValue { VariantId = variantCounter, AttributeValueId = 1 }); // Black
                    variantAttributeValuesSeed.Add(new VariantAttributeValue { VariantId = variantCounter++, AttributeValueId = 3 }); // S

                    variantAttributeValuesSeed.Add(new VariantAttributeValue { VariantId = variantCounter, AttributeValueId = 1 }); // Black
                    variantAttributeValuesSeed.Add(new VariantAttributeValue { VariantId = variantCounter++, AttributeValueId = 4 }); // L

                    // Black - Large
                    variantAttributeValuesSeed.Add(new VariantAttributeValue { VariantId = variantCounter, AttributeValueId = 2 }); // White
                    variantAttributeValuesSeed.Add(new VariantAttributeValue { VariantId = variantCounter++, AttributeValueId = 3 }); // S

                    variantAttributeValuesSeed.Add(new VariantAttributeValue { VariantId = variantCounter, AttributeValueId = 2 }); // White
                    variantAttributeValuesSeed.Add(new VariantAttributeValue { VariantId = variantCounter++, AttributeValueId = 4 }); // L


                }
                _context.variantAttributeValues.AddRange(variantAttributeValuesSeed);
                _context.SaveChanges();
            }

            if (!_context.roles.Any())
            {
                var rolesSeeder = new List<Role>()
                {
                    new Role()
                    {
                        Name = "Admin",
                    },
                    new Role()
                    {
                        Name = "Product Management",
                    }
                };
                _context.roles.AddRange(rolesSeeder);
                _context.SaveChanges();
            }
            if (!_context.accounts.Any())
            {
                var accountsSeeder = new List<Account>()
                {
                    new Account()
                    {
                        RoleId = 1,
                        FullName = "John Doe",
                        PhoneNumber = "1234567890",
                        Email = "johndoe@example.com",
                        Sex = "Male",
                        Password = "hashed_password1",
                        Status = 1,
                        Deleted = false,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                    },
                    new Account()
                    {
                        RoleId = 1,
                        FullName = "Jane Smith",
                        PhoneNumber = "0987654321",
                        Email = "janesmith@example.com",
                        Sex = "Male",
                        Password = "hashed_password2",
                        Status = 1,
                        Deleted = false,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                    },
                    new Account()
                    {
                        RoleId = 2,
                        FullName = "Alice Johnson",
                        PhoneNumber = "5678901234",
                        Email = "alicej@example.com",
                        Sex = "Male",
                        Password = "hashed_password3",
                        Status = 1,
                        Deleted = false,
                        CreatedAt = DateTime.Now,
                            UpdatedAt = DateTime.Now,
                    },
                    new Account()
                    {
                        RoleId = 2,
                        FullName = "Bob Brown",
                        PhoneNumber = "4321098765",
                        Email = "bobb@example.com",
                        Sex = "Male",
                        Password = "hashed_password4",
                        Status = 0,
                        Deleted = false,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                    },
                    new Account()
                    {
                        RoleId = 1,
                        FullName = "Charlie White",
                        PhoneNumber = "1112223333",
                        Email = "charliew@example.com",
                        Sex = "Male",
                        Password = "hashed_password5",
                        Status = 1,
                        Deleted = false,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                    }
                };
                _context.accounts.AddRange(accountsSeeder);
                _context.SaveChanges();
            }
        }
    }
}
