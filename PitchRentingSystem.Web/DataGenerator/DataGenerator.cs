namespace PitchRentingSystem.Web.DataGenerator
{
    using Microsoft.AspNetCore.Identity;
    using PitchRentingSystem.Web.Data.Entities;
    using static PitchRentingSystem.Web.Data.Constants.EntityConstants;
    
    public static class DataGenerator
    {
        public static IEnumerable<IdentityUser> SeedUsers()
        {
            IEnumerable<IdentityUser> users = new List<IdentityUser>()
            {
                new IdentityUser()
                {
                    Id = "dea12856-c198-4129-b3f3-b893d8395082",
                    UserName = "agent@mail.com",
                    NormalizedUserName = "AGENT@MAIL.COM",
                    Email = "agent@mail.com",
                    NormalizedEmail = "AGENT@MAIL.COM"
                },
                new IdentityUser()
                {
                    Id = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                    UserName = "guest@mail.com",
                    NormalizedUserName = "GUEST@MAIL.COM",
                    Email = "guest@mail.com",
                    NormalizedEmail = "GUEST@MAIL.COM"
                }
            };

            var hasher = new PasswordHasher<IdentityUser>();
            foreach (var user in users)
            {
                user.PasswordHash = hasher.HashPassword(user, DefaultPassword);
            }

            return users;
        }

        public static IEnumerable<Agent> SeedAgents()
        {
            var agents = new List<Agent>()
            {
                new Agent()
                {
                    Id = Guid.Parse("44a41a1c-943b-47e2-80e6-47463b6f139b"),
                    PhoneNumber = "+359888888888",
                    UserId = "dea12856-c198-4129-b3f3-b893d8395082",
                },
            };

            return agents;
        }

        public static IEnumerable<Category> SeedCategories()
        {
            var categories = new List<Category>()
            {
                new Category()
                {
                    Id = 1,
                    Name = "NewBuilded"
                },
                new Category()
                {
                    Id = 2,
                    Name = "Modern"
                },
                new Category()
                {
                    Id = 3,
                    Name = "Olimpic"
                },
            };

            return categories;
        }

        public static IEnumerable<Pitch> SeedHouse()
        {
            var pitches = new List<Pitch>()
            {
                new Pitch()
                {
                    Id = 1,
                    Title = "Camp Nou",
                    Address = "Camp Nou Football Stadium",
                    Description = "The stadium's maximum height is 48 metres, and it covers a surface area of 55,000 square metres (250 metres long and 220 metres wide). In accordance with UEFA stipulations, the playing area has been downsized to 105 metres x 68 metres. With a capacity of 99,354, it is now the biggest stadium in Europe.",
                    ImageUrl = "https://www.fcbarcelona.com/photo-resources/2020/02/24/3f1215ed-07e8-47ef-b2c7-8a519f65b9cd/mini_UP3_20200105_FCB_VIS_View_1a_Empty.jpg?width=1200&height=750",
                    PricePerRent = 2200.00M,
                    CategoryId = 1,
                    AgentId = Guid.Parse("44a41a1c-943b-47e2-80e6-47463b6f139b"),
                    RenterId = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e"
                },
                new Pitch()
                {
                    Id = 2,
                    Title = "Maracanã Stadium",
                    Address = "R. Prof. Eurico Rabelo - Maracanã, Rio de Janeiro",
                    Description = "Maracanã Stadium was built in 1950 to commemorate the country's hosting of the 1950 soccer games. Nine of Brazil's leading architects designed the stadium to impress on a global scale, with intentions to create the world's largest soccer stadium.",
                    ImageUrl = "https://dynamic-media-cdn.tripadvisor.com/media/photo-o/0d/e0/b7/00/maracana-stadion.jpg?w=1200&h=-1&s=1",
                    PricePerRent = 2000.00M,
                    CategoryId = 3,
                    AgentId = Guid.Parse("44a41a1c-943b-47e2-80e6-47463b6f139b"),
                },
                new Pitch()
                {
                    Id = 3,
                    Title = "Santiago Bernabéu Stadium",
                    Address = "Av. de Concha Espina, 1, Chamartín",
                    Description = "The Santiago Bernabeu (named after the legendary Madrid manager, who presided over the club from 1943 to 1978) was inaugurated in 1947 and can hold over 80,000 spectators. The stadium is also equipped with more than 240 VIP boxes. The actual entrance to Tour Bernabéu is located on Avenida de Concha Espina, at Gate 28.",
                    ImageUrl = "https://estaticos.esmadrid.com/cdn/farfuture/wwgUeNPLBq8Z-HJOYcUUx_8t1mXAr0eYBgMKLjFy1p4/mtime:1710755365/sites/default/files/styles/content_type_full/public/recursosturisticos/infoturistica/bernabeu.jpg?itok=KvMJw4Dh",
                    PricePerRent = 2100.00M,
                    CategoryId = 2,
                    AgentId = Guid.Parse("44a41a1c-943b-47e2-80e6-47463b6f139b"),
                }
            };

            return pitches;
        }
    }
}
