using GameShop.Models;
using Microsoft.EntityFrameworkCore;

namespace GameShopProject.Data;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new GameShopDbContext(
                   serviceProvider.GetRequiredService<
                       DbContextOptions<GameShopDbContext>>()))
        {
            if (context == null || context.Games == null)
            {
                throw new ArgumentNullException("DbContext doesn't exist");
            }
            
            if (context.Games.Any())
            {
                return;   // DB has been seeded
            }
            
            context.Games.AddRange(
            new Game()
            {
                Id = 1,
                Name = "The Witcher 3: Wild hunt",
                Description = @"The Witcher 3: Wild Hunt is an action role-playing game 
                                developed by Polish developer CD Projekt Red, 
                                and first published in 2015.",
                Price = 30
            },
            new Game()
            {
                Id = 2,
                Name = "Genshin Impact",
                Description = @"Genshin Impact is an action role-playing game developed
                                 by Chinese developer miHoYo, and first published in 2020.",
                Price = 0
            },
            new Game()
            {
                Id = 3,
                Name = "Dying Light 2 Stay Human",
                Description =
                    "Вирус победил, а для цивилизации вновь наступили темные века. Город, одно из последних поселений людей, находится на грани разрушения.",
                Price = 2499
            },
            new Game()
            {
                Id = 4,
                Name = "CS:GO PRIME STATUS UPGRADE",
                Description =
                    "Counter-Strike: Global Offensive (CS:GO) расширяет границы ураганной командной игры, представленной ещё 19 лет назад",
                Price = 1080
            },
            new Game()
            {
                Id = 5,
                Name = "God of War",
                Description = "Отомстив богам Олимпа, Кратос живет в царстве скандинавских божеств и чудовищ",
                Price = 3149
            },
            new Game()
            {
                Id = 6,
                Name = "Red Dead Redemption 2",
                Description =
                    "Игра RDR2, получившая более 175 наград и 250 высших оценок от игровых изданий, – это грандиозная история о судьбе бандита Артура Моргана и банды Ван дер Линде, бегущих от закона через всю Америку на заре современной эпохи",
                Price = 2499
            },
            new Game()
            {
                Id = 7,
                Name = "Dishonored 2",
                Description = "В игре Dishonored 2, вы снова окажетесь в роли ассасина со сверхъестественными способностями.",
                Price = 1299

            },
            new Game()
            {
                Id = 8,
                Name = "DayZ",
                Description = "Как долго вы сможете выжить в пост-апокалипсисе? Мир пал под натиском зараженных.",
                Price = 1199
            }
            );
            context.SaveChanges();
        }
        
    }
}