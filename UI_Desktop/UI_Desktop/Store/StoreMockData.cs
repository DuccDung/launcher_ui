namespace UI_Desktop.Store;

internal static class StoreMockData
{
    internal static StorePageData Create()
    {
        var games = new List<StoreGame>
        {
            new()
            {
                Title = "Farm Manager 2018",
                Subtitle = "Mùa sale nông trại",
                Category = "Mô phỏng",
                Genres = new[] { "Farming Sim", "Indie", "Management", "Casual" },
                OriginalPrice = 117000,
                SalePrice = 11700,
                Likes = 18,
                Dislikes = 1,
                PurchaseCount = 14,
                PromoLabel = "SALE HOT",
                PrimaryColor = Color.FromArgb(39, 126, 88),
                SecondaryColor = Color.FromArgb(234, 186, 88),
                AccentColor = Color.FromArgb(73, 209, 164)
            },
            new()
            {
                Title = "Borderlands 4",
                Subtitle = "Loot shooter bùng nổ",
                Category = "Hành động",
                Genres = new[] { "Action", "Co-op", "Shooter" },
                OriginalPrice = 381150,
                SalePrice = 377339,
                Likes = 0,
                Dislikes = 0,
                PurchaseCount = 1,
                PromoLabel = "MỚI",
                PrimaryColor = Color.FromArgb(233, 41, 46),
                SecondaryColor = Color.FromArgb(255, 171, 59),
                AccentColor = Color.FromArgb(255, 229, 73)
            },
            new()
            {
                Title = "Retro Rewind - Video Store Simulator",
                Subtitle = "Hoài niệm video store",
                Category = "Mô phỏng",
                Genres = new[] { "Simulator", "Indie", "Business" },
                OriginalPrice = 117000,
                SalePrice = 117000,
                Likes = 0,
                Dislikes = 0,
                PurchaseCount = 2,
                PromoLabel = "MÔ PHỎNG",
                PrimaryColor = Color.FromArgb(46, 74, 156),
                SecondaryColor = Color.FromArgb(21, 203, 243),
                AccentColor = Color.FromArgb(255, 104, 146)
            },
            new()
            {
                Title = "Unspoken",
                Subtitle = "Kinh dị tâm lý",
                Category = "Kinh dị",
                Genres = new[] { "Horror", "Mystery", "Indie" },
                OriginalPrice = 8100,
                SalePrice = 8100,
                Likes = 0,
                Dislikes = 0,
                PurchaseCount = 0,
                PromoLabel = "KINH DỊ",
                PrimaryColor = Color.FromArgb(33, 31, 38),
                SecondaryColor = Color.FromArgb(112, 18, 26),
                AccentColor = Color.FromArgb(168, 223, 95)
            },
            new()
            {
                Title = "FATAL FRAME / PROJECT ZERO: Maiden of Black Water",
                Subtitle = "Bóng tối và ký ức",
                Category = "Kinh dị",
                Genres = new[] { "Survival Horror", "Adventure" },
                OriginalPrice = 123000,
                SalePrice = 97650,
                Likes = 1,
                Dislikes = 0,
                PurchaseCount = 1,
                PromoLabel = "SALE",
                PrimaryColor = Color.FromArgb(18, 38, 60),
                SecondaryColor = Color.FromArgb(82, 109, 137),
                AccentColor = Color.FromArgb(195, 223, 255)
            },
            new()
            {
                Title = "Assetto Corsa EVO",
                Subtitle = "Tốc độ và đường đua",
                Category = "Đua xe",
                Genres = new[] { "Racing", "Simulation", "Sports" },
                OriginalPrice = 245000,
                SalePrice = 220500,
                Likes = 5,
                Dislikes = 0,
                PurchaseCount = 3,
                PromoLabel = "EARLY ACCESS",
                PrimaryColor = Color.FromArgb(10, 14, 22),
                SecondaryColor = Color.FromArgb(181, 19, 28),
                AccentColor = Color.FromArgb(255, 95, 83)
            },
            new()
            {
                Title = "Cooking Simulator",
                Subtitle = "Bếp trưởng tại gia",
                Category = "Mô phỏng",
                Genres = new[] { "Cooking", "Simulation", "Casual" },
                OriginalPrice = 188000,
                SalePrice = 122000,
                Likes = 7,
                Dislikes = 0,
                PurchaseCount = 6,
                PromoLabel = "KHUYẾN MÃI",
                PrimaryColor = Color.FromArgb(64, 108, 38),
                SecondaryColor = Color.FromArgb(226, 112, 26),
                AccentColor = Color.FromArgb(255, 223, 110)
            },
            new()
            {
                Title = "DARK SOULS III",
                Subtitle = "Chiến đấu không khoan nhượng",
                Category = "Nhập vai",
                Genres = new[] { "Action RPG", "Souls-like", "Adventure" },
                OriginalPrice = 520000,
                SalePrice = 299000,
                Likes = 15,
                Dislikes = 1,
                PurchaseCount = 11,
                PromoLabel = "BESTSELLER",
                PrimaryColor = Color.FromArgb(53, 42, 17),
                SecondaryColor = Color.FromArgb(188, 161, 67),
                AccentColor = Color.FromArgb(255, 221, 108)
            },
            new()
            {
                Title = "Granblue Fantasy: Relink",
                Subtitle = "Phiêu lưu fantasy",
                Category = "Nhập vai",
                Genres = new[] { "JRPG", "Action", "Co-op" },
                OriginalPrice = 689000,
                SalePrice = 620100,
                Likes = 9,
                Dislikes = 0,
                PurchaseCount = 4,
                PromoLabel = "JRPG",
                PrimaryColor = Color.FromArgb(198, 206, 222),
                SecondaryColor = Color.FromArgb(171, 145, 102),
                AccentColor = Color.FromArgb(106, 184, 255)
            }
        };

        return new StorePageData
        {
            LauncherName = "NestG Launcher",
            VersionText = "v2.2.18",
            UserName = "nguyenducdung",
            BalanceText = "0 đ",
            NavigationItems = new[] { "CỬA HÀNG", "THƯ VIỆN", "CỘNG ĐỒNG", "NESTFLIX", "NGUYENDUCDUNG" },
            Categories = new[] { "Tất cả", "Mô phỏng", "Hành động", "Kinh dị", "Đua xe", "Nhập vai" },
            FeaturedGame = games[0],
            Games = games
        };
    }
}
