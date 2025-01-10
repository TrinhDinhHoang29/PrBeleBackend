using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PrBeleBackend.Core.Domain.Entities;
using PrBeleBackend.Infrastructure.DbContexts;
using static System.Net.WebRequestMethods;


namespace PrBeleBackend.Infrastructure.Seeder
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            BeleStoreContext _context = app.ApplicationServices.CreateScope().ServiceProvider
                .GetRequiredService<BeleStoreContext>();
            //if (_context.Database.GetPendingMigrations().Any())
            //{
            //    _context.Database.Migrate();
            //}
            if (!_context.categories.Any())
            {
                var categoriesSeed = new List<Category>(){
                   new Category {
                    Name = "Áo Nam",
                    Status = 1,
                    Slug = "ao-nam",
                    Deleted = false,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                },
                          new Category {
                    Name = "Quần Nam",
                    Status = 1,
                    Slug = "quan-nam",
                    Deleted = false,
                        CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                },
                          new Category {
                    Name = "Phụ kiện",
                    Status = 1,
                    Slug = "phu-kien",
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
            if (!_context.discounts.Any())
            {
                var discountSeed = new List<Discount>()
                {
                        new Discount { Name = "No Discount", DiscountValue = 0, ExpireDate = DateTime.MaxValue, Status = 1, Deleted = false, CreatedAt = DateTime.Now },
                        new Discount { Name = "New Year Sale", DiscountValue = 10, ExpireDate = DateTime.Now.AddDays(30), Status = 1, Deleted = false, CreatedAt = DateTime.Now,UpdatedAt = DateTime.Now },
                        new Discount { Name = "Christmas Deal", DiscountValue = 20, ExpireDate = DateTime.Now.AddDays(15), Status = 1, Deleted = false, CreatedAt = DateTime.Now,UpdatedAt = DateTime.Now },
                        new Discount { Name = "Black Friday", DiscountValue = 30, ExpireDate = DateTime.Now.AddDays(45), Status = 1, Deleted = false, CreatedAt = DateTime.Now,UpdatedAt = DateTime.Now },
                        new Discount { Name = "Summer Sale", DiscountValue = 15, ExpireDate = DateTime.Now.AddDays(60), Status = 1, Deleted = false, CreatedAt = DateTime.Now,UpdatedAt = DateTime.Now },
                        new Discount { Name = "Flash Deal", DiscountValue = 5, ExpireDate = DateTime.Now.AddDays(5), Status = 1, Deleted = false, CreatedAt = DateTime.Now,UpdatedAt = DateTime.Now }
                };
                _context.discounts.AddRange(discountSeed);
                _context.SaveChanges();
            }
            if (!_context.products.Any() && !_context.attributeValues.Any() && !_context.variantAttributeValues.Any() && !_context.attributeTypes.Any() && !_context.variants.Any() && !_context.keywords.Any())
            {

                var productsSeed = new List<Product>{
                             new Product
{
    Name = "Áo giữ nhiệt Ex-Warm Lenzing Modal cổ cao",
    Description = "Áo giữ nhiệt Ex-Warm Lenzing Modal cổ cao cho mùa đông ấm áp.",
    //DescriptionPlainText = "Áo giữ nhiệt Ex-Warm Lenzing Modal cổ cao.",
    CategoryId = 4,
    Thumbnail = "https://media3.coolmate.me/cdn-cgi/image/quality=80,format=auto/uploads/November2024/24CMHU.GN003_-TRANG.jpg",
    BasePrice = 209000M,
    DiscountId = 1,
    View = 150,
    Like = 50,
    Slug = "ao-giu-nhiet-ex-warm-modal-co-cao",
    Status = 1,
    KeyWord = "ao,giu nhiet,ex-warm,lenzing modal,co cao,mua dong,am ap",
    Deleted = false,
    CreatedAt = DateTime.Now,
    UpdatedAt = DateTime.Now
},
                            new Product
                            {
                                Name = "Áo giữ nhiệt Essential Brush Poly cổ thấp",
                                Description = "Áo giữ nhiệt Essential Brush Poly cổ thấp, chất liệu mềm mại và giữ ấm tốt.",
                                //DescriptionPlainText = "Áo giữ nhiệt Essential Brush Poly cổ thấp.",
                                CategoryId = 4,
                                Thumbnail = "https://media3.coolmate.me/cdn-cgi/image/quality=80,format=auto/uploads/November2024/24CMHU.GN003_-TRANG.jpg",
                                BasePrice = 127000M,
                                    DiscountId = 1,
                                View = 120,
                                Like = 40,
                                Slug = "ao-giu-nhiet-brush-poly-co-thap",
                                Status = 1,
                                KeyWord = "ao,giunhiet,essential,brushpoly,cothap,muadong,amap,memmai",
                                Deleted = false,
    CreatedAt = DateTime.Now,
    UpdatedAt = DateTime.Now
                            },
                            new Product
                            {
                                Name = "Áo giữ nhiệt Essential Brush Poly cổ trung",
                                Description = "Áo giữ nhiệt Essential Brush Poly cổ trung, thiết kế đơn giản và hiệu quả giữ ấm.",
                                //DescriptionPlainText = "Áo giữ nhiệt Essential Brush Poly cổ trung.",
                                CategoryId = 4,
                                Thumbnail = "https://media3.coolmate.me/cdn-cgi/image/quality=80,format=auto/uploads/November2024/24CMHU.GN003_-TRANG.jpg",
                                BasePrice = 127000M,
                                    DiscountId = 1,
                                View = 130,
                                Like = 45,
                                Slug = "ao-giu-nhiet-brush-poly-co-trung",
                                Status = 1,
                                  KeyWord = "ao,giunhiet,essential,brushpoly,cotrung,muadong,amap,memmai",
                                Deleted = false,
    CreatedAt = DateTime.Now,
    UpdatedAt = DateTime.Now
                            },
                            new Product
                            {
                                Name = "Áo giữ nhiệt Ex-Warm Lenzing Modal cổ trung",
                                Description = "Áo giữ nhiệt Ex-Warm Lenzing Modal cổ trung, lựa chọn hoàn hảo cho mùa lạnh.",
                                //DescriptionPlainText = "Áo giữ nhiệt Ex-Warm Lenzing Modal cổ trung.",
                                CategoryId = 4,
                                Thumbnail = "https://media3.coolmate.me/cdn-cgi/image/quality=80,format=auto/uploads/November2024/24CMHU.GN003_-TRANG.jpg",
                                BasePrice = 209000M,
                                    DiscountId = 1,
                                View = 180,
                                Like = 60,
                                Slug = "ao-giu-nhiet-ex-warm-modal-co-trung",
                                Status = 1,
                                 KeyWord = "ao,giunhiet,ex-warm,lenzingmodal,cotrung,muadong,amap",
                                Deleted = false,
    CreatedAt = DateTime.Now,
    UpdatedAt = DateTime.Now
                            },
                            new Product
                            {
                                Name = "Áo thun Relaxed Fit 84RISING Venom Signature",
                                Description = "Áo thun Relaxed Fit 84RISING Venom Signature phong cách trẻ trung, nổi bật.",
                                //DescriptionPlainText = "Áo thun Relaxed Fit 84RISING Venom Signature.",
                                CategoryId = 4,
                                Thumbnail = "https://media3.coolmate.me/cdn-cgi/image/quality=80,format=auto/uploads/November2024/24CMHU.GN003_-TRANG.jpg",
                                BasePrice = 399000M,
                                    DiscountId = 1,
                                View = 200,
                                Like = 70,
                                Slug = "ao-thun-relaxed-fit-84rising-venom-signature",
                                Status = 1,
                                 KeyWord = "ao,aothun,relaxedfit,84rising,venom,signature,phongcach,tretrung,noibat",
                                Deleted = false,
    CreatedAt = DateTime.Now,
    UpdatedAt = DateTime.Now
                            },
                            new Product
                            {
                                Name = "Áo thun Relaxed Fit 84RISING HEHEHE",
                                Description = "Áo thun Relaxed Fit 84RISING HEHEHE năng động, thoải mái khi sử dụng.",
                                //DescriptionPlainText = "Áo thun Relaxed Fit 84RISING HEHEHE.",
                                CategoryId = 4,
                                    DiscountId = 1,
                                Thumbnail = "https://media3.coolmate.me/cdn-cgi/image/quality=80,format=auto/uploads/November2024/24CMHU.GN003_-TRANG.jpg",
                                BasePrice = 399000M,
                                View = 180,
                                Like = 65,
                                Slug = "ao-thun-relaxed-fit-84rising-hehehe",
                                Status = 1,
                                KeyWord = "ao,aothun,relaxedfit,84rising,nangdong,thoaimai",
                                Deleted = false,
    CreatedAt = DateTime.Now,
    UpdatedAt = DateTime.Now
                            },
                            new Product
                            {
                                Name = "Áo giữ nhiệt Ex-Warm Lenzing Modal cổ ngắn",
                                Description = "Áo giữ nhiệt Ex-Warm Lenzing Modal cổ ngắn, lựa chọn tiện lợi cho mùa lạnh.",
                                //DescriptionPlainText = "Áo giữ nhiệt Ex-Warm Lenzing Modal cổ ngắn.",
                                CategoryId = 4,
                                    DiscountId = 1,
                                Thumbnail = "https://media3.coolmate.me/cdn-cgi/image/quality=80,format=auto/uploads/November2024/24CMHU.GN003_-TRANG.jpg",
                                BasePrice = 209000M,
                                View = 150,
                                Like = 50,
                                Slug = "ao-giu-nhiet-ex-warm-lenzing-modal-co-ngan",
                                Status = 1,
                                KeyWord = "ao,giunhiet,ex-warm,lenzingmodal,congan,thoaimai,mualanh,muadong,amap,tienloi",
                                Deleted = false,
    CreatedAt = DateTime.Now,
    UpdatedAt = DateTime.Now
                            },
                            new Product
                            {
                                Name = "Áo Thun Nam Chạy Bộ Graphic Dot",
                                Description = "Áo Thun Nam Chạy Bộ Graphic Dot, thiết kế thể thao với phong cách hiện đại.",
                                //DescriptionPlainText = "Áo Thun Nam Chạy Bộ Graphic Dot.",
                                CategoryId = 4,
                                    DiscountId = 2,
                                Thumbnail = "https://media3.coolmate.me/cdn-cgi/image/quality=80,format=auto/uploads/November2024/24CMHU.GN003_-TRANG.jpg",
                                BasePrice = 199000M,
                                View = 170,
                                Like = 55,
                                Slug = "ao-thun-nam-chay-bo-graphic-dot",
                                Status = 1,
                                KeyWord = "ao,aothun,nam,chaybo,graphicdot,thethao,phongcach,hiendai",
                                Deleted = false,
    CreatedAt = DateTime.Now,
    UpdatedAt = DateTime.Now
                            },
                             new Product
{
    Name = "Quần shorts ECC Ripstop",
    Description = "Quần shorts ECC Ripstop thiết kế thoải mái, chất liệu bền bỉ phù hợp với hoạt động thể thao.",
    //DescriptionPlainText = "Quần shorts ECC Ripstop.",
    CategoryId = 11,
        DiscountId = 3,
    Thumbnail = "https://media3.coolmate.me/cdn-cgi/image/width=672,height=990,quality=85/uploads/July2024/24CMAW.QS022.36_70.jpg",
    BasePrice = 239000M,
    View = 140,
    Like = 60,
    Slug = "quan-shorts-ecc-ripstop",
    Status = 1,
    KeyWord = "quan,quanshort,eccripstop,thoaimai,benbi,thethao",
    Deleted = false,
    CreatedAt = DateTime.Now,
    UpdatedAt = DateTime.Now
},
                            new Product
                            {
                                Name = "Quần shorts 6 inch Racquet Sports",
                                Description = "Quần shorts 6 inch Racquet Sports, thiết kế chuyên dụng cho các môn thể thao vợt.",
                                //DescriptionPlainText = "Quần shorts 6 inch Racquet Sports.",
                                CategoryId = 11,
                                Thumbnail = "https://media3.coolmate.me/cdn-cgi/image/width=672,height=990,quality=85/uploads/July2024/24CMAW.QS022.36_70.jpg",
                                BasePrice = 189000M,
                                View = 130,
                                    DiscountId = 1,
                                Like = 55,
                                Slug = "quan-shorts-6-inch-racquet-sports",
                                Status = 1,
                                 KeyWord = "quan,quanshort,6inch,racquetsports,chuyendung,thethao,thethaovot",
                                Deleted = false,
    CreatedAt = DateTime.Now,
    UpdatedAt = DateTime.Now
                            },
                            new Product
                            {
                                Name = "Quần Shorts chạy bộ Advanced Vent Tech",
                                Description = "Quần Shorts chạy bộ Advanced Vent Tech, thoáng khí và thoải mái cho người chạy.",
                                //DescriptionPlainText = "Quần Shorts chạy bộ Advanced Vent Tech.",
                                CategoryId = 11,
                                Thumbnail = "https://media3.coolmate.me/cdn-cgi/image/width=672,height=990,quality=85/uploads/July2024/24CMAW.QS022.36_70.jpg",
                                BasePrice = 209000M,
                                View = 150,
                                Like = 70,
                                    DiscountId = 1,
                                Slug = "quan-shorts-chay-bo-advanced-vent-tech",
                                Status = 1,
                                 KeyWord = "quan,quanshort,chaybo,advanceventtech",
                                Deleted = false,
    CreatedAt = DateTime.Now,
    UpdatedAt = DateTime.Now
                            },
                            new Product
                            {
                                Name = "Quần shorts nam chạy bộ CoolFast 3.5 inch",
                                Description = "Quần shorts nam chạy bộ CoolFast 3.5 inch với thiết kế nhẹ và công nghệ CoolFast.",
                                //DescriptionPlainText = "Quần shorts nam chạy bộ CoolFast 3.5 inch.",
                                CategoryId = 11,
                                    DiscountId = 3,
                                Thumbnail = "https://media3.coolmate.me/cdn-cgi/image/width=672,height=990,quality=85/uploads/July2024/24CMAW.QS022.36_70.jpg",
                                BasePrice = 249000M,
                                View = 160,
                                Like = 65,
                                Slug = "quan-shorts-nam-coolfast-3-5-inch",
                                Status = 1,
                                KeyWord = "quan,quanshort,quanshortnam,chaybo,coolfast,3.5,3.5inch,thietkenhe,congnghecoolfast",
                                Deleted = false,
    CreatedAt = DateTime.Now,
    UpdatedAt = DateTime.Now
                            },
                            new Product
                            {
                                Name = "Quần shorts nam chạy bộ CoolFast 5 inch",
                                Description = "Quần shorts nam chạy bộ CoolFast 5 inch với thiết kế thoáng khí và công nghệ CoolFast.",
                                //DescriptionPlainText = "Quần shorts nam chạy bộ CoolFast 5 inch.",
                                CategoryId = 11,
                                    DiscountId = 4,
                                Thumbnail = "https://media3.coolmate.me/cdn-cgi/image/width=672,height=990,quality=85/uploads/July2024/24CMAW.QS022.36_70.jpg",
                                BasePrice = 329000M,
                                View = 170,
                                Like = 75,
                                Slug = "quan-shorts-nam-coolfast-5-inch",
                                Status = 1,
                                 KeyWord = "quan,quanshort,quanshortnam,chaybo,coolfast,5,5inch,thietkenhe,congnghecoolfast",
                                Deleted = false,
    CreatedAt = DateTime.Now,
    UpdatedAt = DateTime.Now
                            },
                            new Product
                            {
                                Name = "Quần Shorts Chạy Bộ 2 lớp Fast & Free III",
                                Description = "Quần Shorts Chạy Bộ 2 lớp Fast & Free III, thiết kế năng động và linh hoạt khi tập luyện.",
                                //DescriptionPlainText = "Quần Shorts Chạy Bộ 2 lớp Fast & Free III.",
                                CategoryId = 11,
                                    DiscountId = 1,
                                Thumbnail = "https://media3.coolmate.me/cdn-cgi/image/width=672,height=990,quality=85/uploads/July2024/24CMAW.QS022.36_70.jpg",
                                BasePrice = 379000M,
                                View = 190,
                                Like = 80,
                                Slug = "quan-shorts-chay-bo-2-lop-fast-free-iii",
                                Status = 1,
                                 KeyWord = "quan,quanshort,chaybo,2lop,fast,free3,nangdong,linhhoat,tapluyen",
                                Deleted = false,
    CreatedAt = DateTime.Now,
    UpdatedAt = DateTime.Now
                            },
                            new Product
                            {
                                Name = "Quần Shorts thể thao 7 inch đa năng",
                                Description = "Quần Shorts thể thao 7 inch đa năng, tiện lợi cho nhiều hoạt động thể thao.",
                                //DescriptionPlainText = "Quần Shorts thể thao 7 inch đa năng.",
                                CategoryId = 11,
                                Thumbnail = "https://media3.coolmate.me/cdn-cgi/image/width=672,height=990,quality=85/uploads/July2024/24CMAW.QS022.36_70.jpg",
                                BasePrice = 179000M,
                                    DiscountId = 1,
                                View = 160,
                                Like = 65,
                                Slug = "quan-shorts-the-thao-7-inch-da-nang",
                                Status = 1,
                                 KeyWord = "quan,quanshort,thethao,7,7inch,danang,tienloi,hoatdong",
                                Deleted = false,
    CreatedAt = DateTime.Now,
    UpdatedAt = DateTime.Now
                            },
                            new Product
                            {
                                Name = "Quần Shorts Chạy Bộ 7 inch Essentials",
                                Description = "Quần Shorts Chạy Bộ 7 inch Essentials, thiết kế đơn giản và hiệu quả cho việc chạy bộ.",
                                //DescriptionPlainText = "Quần Shorts Chạy Bộ 7 inch Essentials.",
                                CategoryId = 11,
                                Thumbnail = "https://media3.coolmate.me/cdn-cgi/image/width=672,height=990,quality=85/uploads/July2024/24CMAW.QS022.36_70.jpg",
                                BasePrice = 174000M,
                                View = 150,
                                Like = 60,
                                    DiscountId = 1,
                                Slug = "quan-shorts-chay-bo-7-inch-essentials",
                                Status = 1,
                                 KeyWord = "quan,quanshort,chaybo,7,7inch,essential,dongian,hieuqua",
                                Deleted = false,
    CreatedAt = DateTime.Now,
    UpdatedAt = DateTime.Now
                            },
                             new Product
{
    Name = "Pack 3 Tất Active cổ trung",
    Description = "Pack 3 đôi tất Active cổ trung thoải mái, phù hợp cho mọi hoạt động thể thao và hàng ngày.",
    //DescriptionPlainText = "Pack 3 Tất Active cổ trung.",
    CategoryId = 17,
    Thumbnail = "https://media3.coolmate.me/cdn-cgi/image/width=672,height=990,quality=85/uploads/November2024/TCTCRIBCM_IMG_4300_TRANG_4_36.jpg",
    BasePrice = 99000M,
    View = 120,
    Like = 45,
    Slug = "pack-3-tat-active-co-trung",
    Status = 1,
     KeyWord = "pack,3tat,tat,3,active,cotrung,thoaimai,thethao,hangngay",
        DiscountId = 1,
    Deleted = false,
    CreatedAt = DateTime.Now,
    UpdatedAt = DateTime.Now
},
                            new Product
                            {
                                Name = "Pack 3 Tất Active cổ ngắn",
                                Description = "Pack 3 đôi tất Active cổ ngắn mềm mại, tiện dụng và thoáng khí.",
                                //DescriptionPlainText = "Pack 3 Tất Active cổ ngắn.",
                                CategoryId = 17,
                                Thumbnail = "https://media3.coolmate.me/cdn-cgi/image/width=672,height=990,quality=85/uploads/November2024/TCTCRIBCM_IMG_4300_TRANG_4_36.jpg",
                                BasePrice = 99000M,
                                    DiscountId = 1,
                                View = 110,
                                Like = 40,
                                Slug = "pack-3-tat-active-co-ngan",
                                Status = 1,
                                     KeyWord = "pack,3tat,tat,3,active,congan,memmmai,tiendung,thoangkhi",
                                Deleted = false,
    CreatedAt = DateTime.Now,
    UpdatedAt = DateTime.Now
                            },
                            new Product
                            {
                                Name = "Combo 2 đôi Tất cổ trung Cotton Ribbed Coolmate",
                                Description = "Combo 2 đôi tất cổ trung làm từ Cotton Ribbed Coolmate, mang lại cảm giác mềm mại và bền bỉ.",
                                //DescriptionPlainText = "Combo 2 đôi Tất cổ trung Cotton Ribbed Coolmate.",
                                CategoryId = 17,
                                Thumbnail = "https://media3.coolmate.me/cdn-cgi/image/width=672,height=990,quality=85/uploads/November2024/TCTCRIBCM_IMG_4300_TRANG_4_36.jpg",
                                BasePrice = 109000M,
                                    DiscountId = 1,
                                View = 130,
                                Like = 50,
                                Slug = "combo-2-doi-tat-co-trung-cotton-ribbed",
                                Status = 1,
                                KeyWord = "combo,2doitat,2,cotrung,ribbeb,coolmate,memmai,benbi",
                                Deleted = false,
    CreatedAt = DateTime.Now,
    UpdatedAt = DateTime.Now
                            },
                            new Product
                            {
                                Name = "Combo 2 đôi Tất cổ dài Cotton Ribbed Coolmate",
                                Description = "Combo 2 đôi tất cổ dài Cotton Ribbed Coolmate, thiết kế thời trang và thoáng khí.",
                                //DescriptionPlainText = "Combo 2 đôi Tất cổ dài Cotton Ribbed Coolmate.",
                                CategoryId = 17,
                                Thumbnail = "https://media3.coolmate.me/cdn-cgi/image/width=672,height=990,quality=85/uploads/November2024/TCTCRIBCM_IMG_4300_TRANG_4_36.jpg",
                                BasePrice = 129000M,
                                    DiscountId = 1,
                                View = 140,
                                Like = 55,
                                Slug = "combo-2-doi-tat-co-dai-cotton-ribbed",
                                Status = 1,
                                 KeyWord = "combo,2doitat,2,codai,cotton,ribbeb,coolmate,thoitrang,thoangkhi",
                                Deleted = false,
    CreatedAt = DateTime.Now,
    UpdatedAt = DateTime.Now
                            },
                            new Product
                            {
                                Name = "Tất bóng đá cổ cao",
                                Description = "Tất bóng đá cổ cao, thiết kế chuyên dụng và thoáng khí cho các hoạt động thể thao.",
                                //DescriptionPlainText = "Tất bóng đá cổ cao.",
                                CategoryId = 17,
                                Thumbnail = "https://media3.coolmate.me/cdn-cgi/image/width=672,height=990,quality=85/uploads/November2024/TCTCRIBCM_IMG_4300_TRANG_4_36.jpg",
                                BasePrice = 55000M,
                                    DiscountId = 1,
                                View = 100,
                                Like = 40,
                                Slug = "tat-bong-da-co-cao",
                                Status = 1,
                                 KeyWord = "tat,bongda,cocao,chuyendung,thoangkhi,thethao",
                                Deleted = false,
    CreatedAt = DateTime.Now,
    UpdatedAt = DateTime.Now
                            },
                            new Product
                            {
                                Name = "Tất Nam Cổ Trung Tập Gym Essentials",
                                Description = "Tất Nam cổ trung Tập Gym Essentials, mềm mại, thoải mái khi tập luyện.",
                                //DescriptionPlainText = "Tất Nam Cổ Trung Tập Gym Essentials.",
                                CategoryId = 17,
                                Thumbnail = "https://media3.coolmate.me/cdn-cgi/image/width=672,height=990,quality=85/uploads/November2024/TCTCRIBCM_IMG_4300_TRANG_4_36.jpg",
                                BasePrice = 69000M,
                                    DiscountId = 1,
                                View = 120,
                                Like = 45,
                                Slug = "tat-nam-co-trung-tap-gym-essentials",
                                Status = 1,
                                 KeyWord = "tat,tatnam,cotrung,tapgym,essential,memmai,thoaimai,tapluyen",
                                Deleted = false,
    CreatedAt = DateTime.Now,
    UpdatedAt = DateTime.Now
                            },
                            new Product
                            {
                                Name = "Tất Thể Thao Seamless Cổ Dài",
                                Description = "Tất thể thao Seamless cổ dài, mang lại cảm giác thoải mái và bền bỉ.",
                                //DescriptionPlainText = "Tất Thể Thao Seamless Cổ Dài.",
                                CategoryId = 17,
                                Thumbnail = "https://media3.coolmate.me/cdn-cgi/image/width=672,height=990,quality=85/uploads/November2024/TCTCRIBCM_IMG_4300_TRANG_4_36.jpg",
                                BasePrice = 59000M,
                                    DiscountId = 1,
                                View = 110,
                                Like = 50,
                                Slug = "tat-the-thao-seamless-co-dai",
                                Status = 1,
                                 KeyWord = "tat,thethao,seamless,codai,thoaimai,benbi",
                                Deleted = false,
    CreatedAt = DateTime.Now,
    UpdatedAt = DateTime.Now
                            },
                            new Product
                            {
                                Name = "Combo 10 Đôi Tất Nam Basics",
                                Description = "Combo 10 đôi tất nam Basics, lựa chọn kinh tế và tiện lợi cho sử dụng hàng ngày.",
                                //DescriptionPlainText = "Combo 10 Đôi Tất Nam Basics.",
                                CategoryId = 17,
                                Thumbnail = "https://media3.coolmate.me/cdn-cgi/image/width=672,height=990,quality=85/uploads/November2024/TCTCRIBCM_IMG_4300_TRANG_4_36.jpg",
                                BasePrice = 149000M,
                                    DiscountId = 1,
                                View = 150,
                                Like = 70,
                                Slug = "combo-10-doi-tat-nam-basics",
                                Status = 1,
                                 KeyWord = "combo,10,doitat,tatnam,bacsics,kinhte,tienloi,hangngay",
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
                        new AttributeValue { Name = "Black", Value = "#000", AttributeTypeId = 1, Deleted = false, Status = 1,
    CreatedAt = DateTime.Now,
    UpdatedAt = DateTime.Now },
                        new AttributeValue { Name = "White", Value = "#fff", AttributeTypeId = 1, Deleted = false, Status = 1,
    CreatedAt = DateTime.Now,
    UpdatedAt = DateTime.Now },
                        new AttributeValue { Name = "Small", Value = "S", AttributeTypeId = 2, Deleted = false, Status = 1,
    CreatedAt = DateTime.Now,
    UpdatedAt = DateTime.Now },
                        new AttributeValue { Name = "Large", Value = "L", AttributeTypeId = 2, Deleted = false, Status = 1,
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
                        FullName = "Bele Admin",
                        PhoneNumber = "1234567890",
                        Email = "bele@gmail.com",
                        Sex = "Male",
                        Password = "AQAAAAIAAYagAAAAEA1cyOY5Og1rZ8/WmW28h13EWVwjRW0nnmt4d2TB0cP8xqjKczVOYsuyvDBAX50YCg==",
                        Status = 1,
                        Deleted = false,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                    },
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
            if (!_context.permissions.Any())
            {
                var permissionsSeeder = new List<Permission>()
{
    // Quản lý sản phẩm
    new Permission { Name = "Product Create", Code = "P-C" },
    new Permission { Name = "Product Read", Code = "P-R" },
    new Permission { Name = "Product Update", Code = "P-U" },
    new Permission { Name = "Product Delete", Code = "P-D" },

    // Quản lý thuộc tính sản phẩm
    new Permission { Name = "Product Attribute Create", Code = "PA-C" },
    new Permission { Name = "Product Attribute Read", Code = "PA-R" },
    new Permission { Name = "Product Attribute Update", Code = "PA-U" },
    new Permission { Name = "Product Attribute Delete", Code = "PA-D" },

    // Quản lý biến thể sản phẩm
    new Permission { Name = "Product Variant Create", Code = "PV-C" },
    new Permission { Name = "Product Variant Read", Code = "PV-R" },
    new Permission { Name = "Product Variant Update", Code = "PV-U" },
    new Permission { Name = "Product Variant Delete", Code = "PV-D" },

    // Quản lý danh mục
    new Permission { Name = "Category Create", Code = "C-C" },
    new Permission { Name = "Category Read", Code = "C-R" },
    new Permission { Name = "Category Update", Code = "C-U" },
    new Permission { Name = "Category Delete", Code = "C-D" },
    // Quản lý liên hệ
    new Permission { Name = "Contact Read", Code = "CT-R" },
    new Permission { Name = "Contact Update", Code = "CT-U" },
    new Permission { Name = "Contact Delete", Code = "CT-D" },
    //Quản lý Dashborad
        new Permission { Name = "Dashboard Read", Code = "D-R" },
        //Quản lý giảm giá
        new Permission { Name = "Discount Create", Code = "DC-C" },
        new Permission { Name = "Discount Read", Code = "DC-R" },
        new Permission { Name = "Discount Update", Code = "DC-U" },
        new Permission { Name = "Discount Delete", Code = "DC-D" },

    // Quản lý nhân viên
    new Permission { Name = "Account Create", Code = "A-C" },
    new Permission { Name = "Account Read", Code = "A-R" },
    new Permission { Name = "Account Update", Code = "A-U" },
    new Permission { Name = "Account Delete", Code = "A-D" },

    // Quản lý đánh giá
    new Permission { Name = "Rate Reply", Code = "R-C" },
   new Permission { Name = "Rate Read", Code = "R-R" },
      new Permission { Name = "Rate Update", Code = "R-U" },

     new Permission { Name = "Rate Delete", Code = "R-D" },


    // Quản lý đơn hàng
    new Permission { Name = "Order Read", Code = "O-R" },
    new Permission { Name = "Order Update", Code = "O-U" },
    new Permission { Name = "Order Delete", Code = "O-D" },

    // Quản lý khách hàng (Không có thêm)
    new Permission { Name = "Customer Read", Code = "CU-R" },
    new Permission { Name = "Customer Update", Code = "CU-U" },
    new Permission { Name = "Customer Delete", Code = "CU-D" },

    // Quản lý quyền
    new Permission { Name = "Permission Management", Code = "P-M" },
    // Quản lý quyền
    new Permission { Name = "Setting Read", Code = "S-R" },
        new Permission { Name = "Setting Update", Code = "S-U" },

};


                _context.permissions.AddRange(permissionsSeeder);
                _context.SaveChanges();

                var rolePermissionsSeed = new List<RolePermission>()
                {
                    new RolePermission { RoleId = 2, PermissionId = 1 },
                    new RolePermission { RoleId = 2, PermissionId = 2 },
                    new RolePermission { RoleId = 2, PermissionId = 3 },
                    new RolePermission { RoleId = 2, PermissionId = 4 },
                    new RolePermission { RoleId = 1, PermissionId = 1 },
                    new RolePermission { RoleId = 1, PermissionId = 2 },
                    new RolePermission { RoleId = 1, PermissionId = 3 },
                    new RolePermission { RoleId = 1, PermissionId = 4 },
                    new RolePermission { RoleId = 1, PermissionId = 5 },
                    new RolePermission { RoleId = 1, PermissionId = 6 },
                    new RolePermission { RoleId = 1, PermissionId = 7 },
                    new RolePermission { RoleId = 1, PermissionId = 8 },
                    new RolePermission { RoleId = 1, PermissionId = 9 },
                    new RolePermission { RoleId = 1, PermissionId = 10 },
                    new RolePermission { RoleId = 1, PermissionId = 11 },
                    new RolePermission { RoleId = 1, PermissionId = 12 },
                    new RolePermission { RoleId = 1, PermissionId = 13 },
                    new RolePermission { RoleId = 1, PermissionId = 14 },
                    new RolePermission { RoleId = 1, PermissionId = 15 },
                    new RolePermission { RoleId = 1, PermissionId = 16 },
                    new RolePermission { RoleId = 1, PermissionId = 17 },
                    new RolePermission { RoleId = 1, PermissionId = 18 },
                    new RolePermission { RoleId = 1, PermissionId = 19 },
                    new RolePermission { RoleId = 1, PermissionId = 20 },
                    new RolePermission { RoleId = 1, PermissionId = 21 },
                    new RolePermission { RoleId = 1, PermissionId = 22 },
                    new RolePermission { RoleId = 1, PermissionId = 23 },
                    new RolePermission { RoleId = 1, PermissionId = 24 },
                    new RolePermission { RoleId = 1, PermissionId = 25 },
                    new RolePermission { RoleId = 1, PermissionId = 26 },
                    new RolePermission { RoleId = 1, PermissionId = 27 },
                    new RolePermission { RoleId = 1, PermissionId = 28 },
                    new RolePermission { RoleId = 1, PermissionId = 29 },
                    new RolePermission { RoleId = 1, PermissionId = 30 },
                    new RolePermission { RoleId = 1, PermissionId = 31 },
                    new RolePermission { RoleId = 1, PermissionId = 32 },
                    new RolePermission { RoleId = 1, PermissionId = 33 },
                    new RolePermission { RoleId = 1, PermissionId = 34 },
                    new RolePermission { RoleId = 1, PermissionId = 35 },
                    new RolePermission { RoleId = 1, PermissionId = 36 },
                    new RolePermission { RoleId = 1, PermissionId = 37 },
                    new RolePermission { RoleId = 1, PermissionId = 38 },
                    new RolePermission { RoleId = 1, PermissionId = 39 },
                    new RolePermission { RoleId = 1, PermissionId = 40 },
                    new RolePermission { RoleId = 1, PermissionId = 41 },



                    //tới 31 
                };
                _context.rolePermissions.AddRange(rolePermissionsSeed);
                _context.SaveChanges();
            }
            if (!_context.customers.Any())
            {
                var customerSeed = new List<Customer>() {
                 new Customer {  FullName = "John Doe", PhoneNumber = "123456789", Email = "john.doe@example.com", Sex = "Male", Birthday = new DateTime(1985, 5, 15), Password = "password123", TotalSpending = 1500, Status = 1, Deleted = false, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Customer { FullName = "Jane Smith", PhoneNumber = "987654321", Email = "jane.smith@example.com", Sex = "Female", Birthday = new DateTime(1990, 7, 22), Password = "securepass", TotalSpending = 2000, Status = 1, Deleted = false, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Customer { FullName = "Alice Johnson", PhoneNumber = "567890123", Email = "alice.johnson@example.com", Sex = "Female", Birthday = new DateTime(1995, 3, 10), Password = "alicepass", TotalSpending = 3000, Status = 1, Deleted = false, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Customer {FullName = "Bob Brown", PhoneNumber = "654321789", Email = "bob.brown@example.com", Sex = "Male", Birthday = new DateTime(1987, 1, 25), Password = "bobsecure", TotalSpending = 2500,  Status = 1, Deleted = false, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Customer { FullName = "Charlie White", PhoneNumber = "987123456", Email = "charlie.white@example.com", Sex = "Male", Birthday = new DateTime(1992, 11, 11), Password = "charlie123", TotalSpending = 1000, Status = 1, Deleted = false, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Customer {  FullName = "Diana Green", PhoneNumber = "321654987", Email = "diana.green@example.com", Sex = "Female", Birthday = new DateTime(1988, 8, 8), Password = "dianapass", TotalSpending = 3500, Status = 1, Deleted = false, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Customer {  FullName = "Ethan Blue", PhoneNumber = "876543219", Email = "ethan.blue@example.com", Sex = "Male", Birthday = new DateTime(1993, 9, 19), Password = "ethansecure", TotalSpending = 4000,Status = 1, Deleted = false, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Customer {  FullName = "Fiona Black", PhoneNumber = "456789321", Email = "fiona.black@example.com", Sex = "Female", Birthday = new DateTime(1997, 4, 4), Password = "fiona123", TotalSpending = 2800,Status = 1, Deleted = false, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Customer {  FullName = "George Gray", PhoneNumber = "789123654", Email = "george.gray@example.com", Sex = "Male", Birthday = new DateTime(1991, 2, 20), Password = "georgepass", TotalSpending = 1700,Status = 1, Deleted = false, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Customer {FullName = "Hannah Purple", PhoneNumber = "123789456", Email = "hannah.purple@example.com", Sex = "Female", Birthday = new DateTime(1994, 6, 15), Password = "hannahsecure", TotalSpending = 2200, Status = 1, Deleted = false, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now }
                };
                _context.customers.AddRange(customerSeed);
                _context.SaveChanges();
            };
            if (!_context.addressCustomers.Any())
            {
                var addressCustomersSeed = new List<AddressCustomer>() {
                    new AddressCustomer {CustomerId = 1, FullName = "John Doe", Phone = "123456789", Address = "123 Main St, Cityville", IsDefault = true, CreateAt = DateTime.Now, UpdateAt = DateTime.Now },
                    new AddressCustomer {CustomerId = 2, FullName = "Jane Smith", Phone = "987654321", Address = "456 Elm St, Townville", IsDefault = true, CreateAt = DateTime.Now, UpdateAt = DateTime.Now },
                    new AddressCustomer {CustomerId = 3, FullName = "Alice Johnson", Phone = "567890123", Address = "789 Pine St, Suburbia", IsDefault = true, CreateAt = DateTime.Now, UpdateAt = DateTime.Now },
                    new AddressCustomer {CustomerId = 4, FullName = "Bob Brown", Phone = "654321789", Address = "321 Oak St, Metropolis", IsDefault = true, CreateAt = DateTime.Now, UpdateAt = DateTime.Now },
                    new AddressCustomer {CustomerId = 5, FullName = "Charlie White", Phone = "987123456", Address = "654 Cedar St, Uptown", IsDefault = true, CreateAt = DateTime.Now, UpdateAt = DateTime.Now },
                    new AddressCustomer {CustomerId = 6, FullName = "Diana Green", Phone = "321654987", Address = "987 Maple St, Downtown", IsDefault = true, CreateAt = DateTime.Now, UpdateAt = DateTime.Now },
                    new AddressCustomer {CustomerId = 7, FullName = "Ethan Blue", Phone = "876543219", Address = "123 Birch St, Rivertown", IsDefault = true, CreateAt = DateTime.Now, UpdateAt = DateTime.Now },
                    new AddressCustomer {CustomerId = 8, FullName = "Fiona Black", Phone = "456789321", Address = "456 Ash St, Harbor City", IsDefault = true, CreateAt = DateTime.Now, UpdateAt = DateTime.Now },
                    new AddressCustomer {CustomerId = 9, FullName = "George Gray", Phone = "789123654", Address = "789 Spruce St, Mountainville", IsDefault = true, CreateAt = DateTime.Now, UpdateAt = DateTime.Now },
                    new AddressCustomer {CustomerId = 10, FullName = "Hannah Purple", Phone = "123789456", Address = "321 Walnut St, Lakeside", IsDefault = true, CreateAt = DateTime.Now, UpdateAt = DateTime.Now }
                };
                _context.addressCustomers.AddRange(addressCustomersSeed);
                _context.SaveChanges();
            }
            if (!_context.contacts.Any())
            {
                var contactsSeed = new List<Contact>
{
    new Contact
    {
        Title = "Owner run at her person almost.",
        Message = "Perhaps product answer Democrat together so. Really.",
        FullName = "Michael Franklin",
        Email = "karen39@frey-jennings.info",
        PhoneNumber = "001-215-834-8337x288",
        Status = 1,
        Deleted = false,
        CreatedAt = new DateTime(2025, 01, 01, 16, 14, 49)
    },
    new Contact
    {
        Title = "Garden that him receive question cost.",
        Message = "Magazine current region something. Myself physical view.",
        FullName = "Jennifer Burke",
        Email = "vmiller@hotmail.com",
        PhoneNumber = "+1-268-724-5627",
        Status = 1,
        Deleted = false,
        CreatedAt = new DateTime(2025, 01, 01, 08, 57, 08)
    },
    new Contact
    {
        Title = "Vote focus writer yourself.",
        Message = "Visit kind budget. Chair low training language now.",
        FullName = "Renee Lee",
        Email = "fitzpatrickmegan@patton.org",
        PhoneNumber = "390.198.1725x614",
        Status = 0,
        Deleted = false,
        CreatedAt = new DateTime(2025, 01, 01, 03, 56, 43)
    },
    new Contact
    {
        Title = "War late special employee.",
        Message = "Make study writer state. Well force difference note.",
        FullName = "Jessica Wiggins",
        Email = "alvaradoerica@hotmail.com",
        PhoneNumber = "911.477.0584",
        Status = 0,
        Deleted = false,
        CreatedAt = new DateTime(2025, 01, 01, 00, 25, 03)
    },
    new Contact
    {
        Title = "Piece reality choose.",
        Message = "Financial compare various better. Customer up idea.",
        FullName = "David Wood",
        Email = "william93@hotmail.com",
        PhoneNumber = "6486655030",
        Status = 1,
        Deleted = false,
        CreatedAt = new DateTime(2025, 01, 01, 14, 34, 24)
    },
    new Contact
    {
        Title = "Beautiful analysis deal matter answer.",
        Message = "Dream movement offer remain door data.",
        FullName = "Emma Robinson",
        Email = "emma.robinson@example.com",
        PhoneNumber = "555-623-1245",
        Status = 1,
        Deleted = false,
        CreatedAt = new DateTime(2025, 01, 01, 11, 00, 45)
    },
    new Contact
    {
        Title = "Provide public before door.",
        Message = "Over sport call sometimes art project.",
        FullName = "John Doe",
        Email = "john.doe@example.com",
        PhoneNumber = "+1-800-123-4567",
        Status = 0,
        Deleted = false,
        CreatedAt = new DateTime(2025, 01, 01, 12, 30, 22)
    },
    new Contact
    {
        Title = "Lead about himself spring rest.",
        Message = "Table official later play hotel policy act.",
        FullName = "Sophia Johnson",
        Email = "sophia.johnson@example.net",
        PhoneNumber = "123-456-7890",
        Status = 1,
        Deleted = false,
        CreatedAt = new DateTime(2025, 01, 01, 10, 20, 33)
    },
    new Contact
    {
        Title = "Possible learn despite service second.",
        Message = "Reality professional work each summer quite director.",
        FullName = "Liam White",
        Email = "liam.white@example.org",
        PhoneNumber = "+1-555-987-6543",
        Status = 0,
        Deleted = false,
        CreatedAt = new DateTime(2025, 01, 01, 15, 45, 50)
    },
    new Contact
    {
        Title = "Remember remain child across whole.",
        Message = "World around including heart certainly left.",
        FullName = "Olivia Brown",
        Email = "olivia.brown@example.com",
        PhoneNumber = "987-654-3210",
        Status = 1,
        Deleted = false,
        CreatedAt = new DateTime(2025, 01, 01, 18, 10, 55)
    }
};
                _context.contacts.AddRange(contactsSeed);
                _context.SaveChanges();
            }
            if (!_context.tags.Any())
            {
                var tagsSeed = new List<Tag>
                {
                    new Tag()
                    {
                        Name = "New"
                    },
                    new Tag()
                    {
                        Name = "Outlet"
                    },
                    new Tag()
                    {
                        Name = "Đáng mua"
                    }

                };
                _context.tags.AddRange(tagsSeed);
                _context.SaveChanges();
            }
            if (!_context.productTags.Any())
            {
                var productTagsSeed = new List<ProductTag>()
                {
                    new ProductTag()
                    {
                        ProductId = 1,
                        TagId = 1,
                    },
                    new ProductTag()
                    {
                        ProductId = 2,
                        TagId = 2,
                    },
                    new ProductTag()
                    {
                        ProductId = 3,
                        TagId = 1,
                    },
                };
                _context.productTags.AddRange(productTagsSeed);
                _context.SaveChanges();
            }
            if (!_context.orders.Any())
            {
                List<Order> ordersSeed = new List<Order>()
                {
                   new Order
        {
            UserId = 6,
            FullName = "Nguyễn Văn A",
            PhoneNumber = "0123456789",
            Address = "123 Đường ABC, TP.HCM",
            Note = "Giao hàng nhanh",
            TotalMoney = 500000,
            PayMethod = "COD",
            ShipDate = DateTime.Now.AddDays(2),
            ReceiveDate = DateTime.Now.AddDays(4),
            Status = 1,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        },
        new Order
        {
            UserId = 6,
            FullName = "Trần Thị B",
            PhoneNumber = "0987654321",
            Address = "456 Đường XYZ, Hà Nội",
            Note = "Gói hàng cẩn thận",
            TotalMoney = 300000,
            PayMethod = "VNPAY",
            ShipDate = DateTime.Now.AddDays(1),
            ReceiveDate = DateTime.Now.AddDays(3),
            Status = 1,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        },
        new Order
        {
            UserId = 6,
            FullName = "Lê Văn C",
            PhoneNumber = "0345678901",
            Address = "789 Đường DEF, Đà Nẵng",
            Note = "Giao hàng vào buổi sáng",
            TotalMoney = 200000,
            PayMethod = "COD",
            ShipDate = DateTime.Now.AddDays(3),
            ReceiveDate = DateTime.Now.AddDays(5),
            Status = 1,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        },
        new Order
        {
            UserId = 6,
            FullName = "Phạm Thị D",
            PhoneNumber = "0567890123",
            Address = "321 Đường GHI, Cần Thơ",
            Note = "Không gọi điện trước",
            TotalMoney = 400000,
            PayMethod = "VNPAY",
            ShipDate = DateTime.Now.AddDays(2),
            ReceiveDate = DateTime.Now.AddDays(4),
            Status = 1,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        }
                };
                _context.orders.AddRange(ordersSeed);
                _context.SaveChanges();
                var productOrder = new List<ProductOrder>()
                {
                     new ProductOrder
        {
            OrderId = 1,
            VariantId = 1,
            Quantity = 2,
            OriginalPrice = 150000,
            DiscountValue = 10,
            FinalPrice = 135000,
            IsRating = false
        },
        new ProductOrder
        {
            OrderId = 1,
            VariantId = 2,
            Quantity = 1,
            OriginalPrice = 230000,
            DiscountValue = 5,
            FinalPrice = 218500,
            IsRating = false
        },

        // Hóa đơn 2: 1 sản phẩm
        new ProductOrder
        {
            OrderId = 2,
            VariantId = 3,
            Quantity = 3,
            OriginalPrice = 100000,
            DiscountValue = 0,
            FinalPrice = 100000,
            IsRating = false
        },

        // Hóa đơn 3: 4 sản phẩm
        new ProductOrder
        {
            OrderId = 3,
            VariantId = 4,
            Quantity = 1,
            OriginalPrice = 50000,
            DiscountValue = 20,
            FinalPrice = 40000,
            IsRating = false
        },
        new ProductOrder
        {
            OrderId = 3,
            VariantId = 5,
            Quantity = 2,
            OriginalPrice = 75000,
            DiscountValue = 10,
            FinalPrice = 67500,
            IsRating = false
        },
        new ProductOrder
        {
            OrderId = 3,
            VariantId = 6,
            Quantity = 1,
            OriginalPrice = 120000,
            DiscountValue = 15,
            FinalPrice = 102000,
            IsRating = false
        },
        new ProductOrder
        {
            OrderId = 3,
            VariantId = 7,
            Quantity = 1,
            OriginalPrice = 80000,
            DiscountValue = 5,
            FinalPrice = 76000,
            IsRating = false
        },

        // Hóa đơn 4: 3 sản phẩm
        new ProductOrder
        {
            OrderId = 4,
            VariantId = 8,
            Quantity = 2,
            OriginalPrice = 90000,
            DiscountValue = 10,
            FinalPrice = 81000,
            IsRating = false
        },
        new ProductOrder
        {
            OrderId = 4,
            VariantId = 9,
            Quantity = 1,
            OriginalPrice = 150000,
            DiscountValue = 0,
            FinalPrice = 150000,
            IsRating = false
        },
        new ProductOrder
        {
            OrderId = 4,
            VariantId = 10,
            Quantity = 1,
            OriginalPrice = 250000,
            DiscountValue = 20,
            FinalPrice = 200000,
            IsRating = false
        }
                };
           
                _context.productOrders.AddRange(productOrder);
                _context.SaveChanges();

            }
            if (!_context.rates.Any())
            {
                List<Rate> ratesSeed = new List<Rate>()
                {
                    new Rate
        {
            ProductId = 1,
            UserType = "Customer",
            UserId = 1,
            Star = 5,
            Content = "Great product! Highly recommend.",
            ReferenceRateId = 0,
            Status = 1,
            Deleted = false,
            CreatedAt = DateTime.UtcNow.AddDays(-10),
            UpdatedAt = DateTime.UtcNow.AddDays(-5)
        },
                    new Rate
        {
            ProductId = 1,
            UserType = "Admin",
            UserId = 2,
            Star = 5,
            Content = "Good quality, but shipping was slow.",
            ReferenceRateId = 1,
            Status = 1,
            Deleted = false,
            CreatedAt = DateTime.UtcNow.AddDays(-7),
            UpdatedAt = DateTime.UtcNow.AddDays(-3)
        }
                };
                _context.rates.AddRange(ratesSeed);
                _context.SaveChanges();
            }

            if (!_context.settings.Any())
            {
                var settings = new Setting
                {
                    MainLogo = "https://res.cloudinary.com/dwewnjnbm/image/upload/v1736411156/bele/Settings/wvwhol9ag1xn6jc5dhjy.png",
                    SloganLogo = "https://res.cloudinary.com/dwewnjnbm/image/upload/v1736411158/bele/Settings/tayvoazxyd0kqjyjcnon.png",
                    Slogan = "Best Choice For Good Styles",
                    Hotline = "0306221498",
                    Email = "bele@gmail.com",
                    BranchName1 = "Văn phòng Hà Nội",
                    BranchAddress1 = "Tầng 3 Tòa nhà BMM, KM2, Đường Phùng Hưng, Phường Phúc La, Quận Hà Đông, TP Hà Nội",
                    BranchName2 = "Văn phòng và Trung tâm vận hành TP. HCM",
                    BranchAddress2 = "Lô C3, đường D2, KCN Cát Lái, Thạnh Mỹ Lợi, TP. Thủ Đức, TP. Hồ Chí Minh",
                    FacebookLink = "https://www.facebook.com/trung.kien.302814",
                    InstagramLink = "https://www.instagram.com/cutchienbotoi/",
                    YoutubeLink = "https://www.youtube.com/@NOOB-zl8os",
                    MainBanner = "https://res.cloudinary.com/dwewnjnbm/image/upload/v1736411159/bele/Settings/ahsquh48itwoxo6n6a7t.png",
                    SubBanner1 =  "https://res.cloudinary.com/dwewnjnbm/image/upload/v1736411160/bele/Settings/pma1cpwotnw5c1dxxyio.png",
                    SubBanner2 = "https://res.cloudinary.com/dwewnjnbm/image/upload/v1736411161/bele/Settings/d4v112vxzjzarvmistwz.png",
                    SlideshowBanner1 = "https://res.cloudinary.com/dwewnjnbm/image/upload/v1736411162/bele/Settings/c4ufjs0jp6fos7gylg1y.webp",
                    SlideshowBanner2 = "https://res.cloudinary.com/dwewnjnbm/image/upload/v1736411163/bele/Settings/cjkscbypev8vb6h7tdjb.webp",
                    SlideshowBanner3 = "https://res.cloudinary.com/dwewnjnbm/image/upload/v1736411165/bele/Settings/neosvdg0k87bfffqw6dq.webp",
                    Description = "Bele là thương hiệu thời trang tiên phong, cung cấp các sản phẩm thời trang nam chất lượng cao, hiện đại và phong cách. Được thành lập từ 1989, Bele nhanh chóng trở thành lựa chọn hàng đầu cho những tín đồ thời trang yêu thích sự đơn giản, tiện lợi và tinh tế.",
                    ServiceTitle1 = "Miễn phí giao hàng",
                    ServiceInfo1 = "Đảm bảo chất lượng đã được kiểm tra",
                    ServiceTitle2 = "Thanh toán khi nhận hàng",
                    ServiceInfo2 = "Nhanh chóng, an toàn và tiện lợi",
                    ServiceTitle3 = "Đổi trả trong 45 ngày",
                    ServiceInfo3 = "Cam kết hoàn tiền hoặc đổi sản phẩm dễ dàng",
                    ServiceTitle4 = "Mở cửa cả tuần",
                    ServiceInfo4 = "Sẵn sàng phục vụ mọi ngày trong tuần"
                };
                _context.settings.AddRange(settings);
                _context.SaveChanges();
            }
        }
    }
}
