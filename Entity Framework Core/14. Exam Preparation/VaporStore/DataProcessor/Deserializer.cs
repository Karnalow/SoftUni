namespace VaporStore.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Text;
    using System.Xml.Serialization;
    using Castle.Core.Internal;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.Data.Models;
    using VaporStore.Data.Models.Enums;
    using VaporStore.DataProcessor.ImportDto;

    public static class Deserializer
    {
        public const string ErrorMessage = "Invalid Data";

        public const string SuccessfullyImportedGame = "Added {0} ({1}) with {2} tags";

        public const string SuccessfullyImportedUser = "Imported {0} with {1} cards";

        public const string SuccessfullyImportedPurchase = "Imported {0} for {1}";

        public static string ImportGames(VaporStoreDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            
            var gameDtos = JsonConvert.DeserializeObject<IEnumerable<ImportGameDto>>(jsonString);

            List<Game> games = new List<Game>();
            List<Developer> developers = new List<Developer>();
            List<Genre> genres = new List<Genre>();
            List<Tag> tags = new List<Tag>();

            foreach (var gameDto in gameDtos)
            {
                if (!IsValid(gameDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime releaseDate;

                bool isReleaseDateValid = DateTime.TryParseExact(gameDto.ReleaseDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out releaseDate);

                if (!isReleaseDateValid) 
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (gameDto.Tags.Length == 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Game game = new Game
                {
                    Name = gameDto.Name,
                    Price = gameDto.Price,
                    ReleaseDate = releaseDate
                };

                var gameDev = developers.FirstOrDefault(d => d.Name == gameDto.Developer);

                if (gameDev == null) 
                {
                    Developer newGameDev = new Developer()
                    {
                        Name = gameDto.Developer
                    };

                    developers.Add(newGameDev);

                    game.Developer = newGameDev;
                }
                else
                {
                    game.Developer = gameDev;
                }

                var gameGenre = genres.FirstOrDefault(g => g.Name == gameDto.Genre);

                if (gameGenre == null)
                {
                    Genre newGenre = new Genre
                    {
                        Name = gameDto.Genre
                    };

                    genres.Add(newGenre);

                    game.Genre = newGenre;
                }
                else
                {
                    game.Genre = gameGenre;
                }

                foreach (var tagName in gameDto.Tags) 
                {
                    if (tagName.IsNullOrEmpty())
                    {
                        continue;
                    }

                    var gameTag = tags.FirstOrDefault(t => t.Name == tagName);

                    if (gameTag == null)
                    {
                        var newGameTag = new Tag()
                        {
                            Name = tagName
                        };

                        tags.Add(newGameTag);

                        game.GameTags.Add(new GameTag
                        {
                            Game = game,
                            Tag = newGameTag
                        });
                    }
                    else
                    {
                        game.GameTags.Add(new GameTag()
                        {
                            Game = game,
                            Tag = gameTag
                        });
                    }
                }

                if (game.GameTags.Count == 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                games.Add(game);

                sb.AppendLine(String.Format(SuccessfullyImportedGame, game.Name, game.Genre.Name, game.GameTags.Count));
            }

            context.Games.AddRange(games);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportUsers(VaporStoreDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            var userDtos = JsonConvert.DeserializeObject<IEnumerable<ImportUsersDto>>(jsonString);

            List<User> users = new List<User>();

            foreach (var userDto in userDtos)
            {
                if (!IsValid(userDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                List<Card> userCards = new List<Card>();

                bool areAllCardsValid = true;

                foreach (var cardDto in userDto.Cards)
                {
                    if (!IsValid(cardDto))
                    {
                        areAllCardsValid = false;
                        break;
                    }

                    Object cardTypeRes;

                    bool isCardTypeValid = Enum.TryParse(typeof(CardType), cardDto.Type, out cardTypeRes);

                    if (!isCardTypeValid)
                    {
                        areAllCardsValid = false;
                        break;
                    }

                    CardType cardType = (CardType)cardTypeRes;

                    userCards.Add(new Card()
                    {
                        Number = cardDto.Number,
                        Cvc = cardDto.Cvc,
                        Type = cardType
                    });
                }

                if (!areAllCardsValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (userCards.Count == 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                User user = new User()
                {
                    Username = userDto.Username,
                    FullName = userDto.FullName,
                    Email = userDto.Email,
                    Age = userDto.Age,
                    Cards = userCards
                };

                users.Add(user);
                sb.AppendLine(String.Format(SuccessfullyImportedUser, user.Username, user.Cards.Count));
            }

            context.Users.AddRange(users);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            var xmlSerializer = new XmlSerializer(typeof(IEnumerable<ImportPurchasesDto>), new XmlRootAttribute("Purchases"));

            using StringReader stringReader = new StringReader(xmlString);

            var purchaseDtos = (IEnumerable<ImportPurchasesDto>)xmlSerializer.Deserialize(stringReader);

            List<Purchase> purchases = new List<Purchase>();

            foreach (var purchaseDto in purchaseDtos)
            {
                if (!IsValid(purchaseDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                object purchaseTypeObj;

                bool isPurchaseTypeValid =
                    Enum.TryParse(typeof(PurchaseType), purchaseDto.PurchaseType, out purchaseTypeObj);

                if (!isPurchaseTypeValid) 
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var purchaseType = (PurchaseType)purchaseTypeObj;

                DateTime date;

                bool isDateTimeValid = DateTime.TryParseExact(purchaseDto.Date, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out date);

                if (!isDateTimeValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var card = context.Cards.FirstOrDefault(c => c.Number == purchaseDto.CardNumber);

                if (card == null) 
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var game = context.Games.FirstOrDefault(g => g.Name == purchaseDto.GameTitle);

                if (game == null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var purchase = new Purchase
                {
                    Type = purchaseType,
                    ProductKey = purchaseDto.Key,
                    Date = date,
                    Card = card,
                    Game = game
                };

                purchases.Add(purchase);

                sb.AppendLine(String.Format(SuccessfullyImportedPurchase, purchase.Game.Name, purchase.Card.User));
            }

            context.AddRange(purchases);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}