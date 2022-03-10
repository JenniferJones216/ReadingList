using Microsoft.EntityFrameworkCore.Migrations;

namespace ReadingList.Migrations
{
    public partial class updateseeddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Frances", "McDormand" },
                    { 2, "Dan Alexandru", "Condrea" },
                    { 3, "Jason", "Carrion" }
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "FirstName", "Gender", "LastName" },
                values: new object[,]
                {
                    { 1, "Jason", 0, "Motts" },
                    { 2, "Louisa May", 1, "Alcott" },
                    { 3, "Frank", 0, "Herbert" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 2, "Romania" },
                    { 3, "Puerto Rico" },
                    { 1, "United States of America" }
                });

            migrationBuilder.InsertData(
                table: "Directors",
                columns: new[] { "Id", "FirstName", "Gender", "LastName" },
                values: new object[,]
                {
                    { 1, "Chloe", 1, "Zhao" },
                    { 2, "Alexander", 0, "Nanau" },
                    { 3, "Antonio", 0, "Santini" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 7, "Documentary" },
                    { 10, "News" },
                    { 9, "Biography" },
                    { 8, "Crime" },
                    { 6, "Drama" },
                    { 5, "Classic Literature" },
                    { 4, "Science Fiction" },
                    { 3, "Fiction" },
                    { 2, "African American Fiction" },
                    { 1, "Literature" }
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Description", "Name", "URL" },
                values: new object[,]
                {
                    { 1, "Cleveland Public Library", "Clevnet", "https://cpl.org/" },
                    { 2, "", "Lakewood Public Library", "https://www.lakewoodpubliclibrary.org/" },
                    { 3, "", "Netflix", "https://www.netflix.com/browse" }
                });

            migrationBuilder.InsertData(
                table: "Prizes",
                columns: new[] { "Id", "Description", "Name", "URL" },
                values: new object[,]
                {
                    { 1, "The National Book Awards were established in 1950 to celebrate the best writing in America. Since 1989, they have been overseen by the National Book Foundation, a nonprofit organization whose mission is to celebrate the best literature in America, expand its audience, and ensure that books have a prominent place in American culture. Although other categories have been recognized in the past, the Awards currently honors the best Fiction, Nonfiction, Poetry, Translated Literature, and Young People’s Literature published each year.", "National Book Award for Fiction", "https://www.nationalbook.org/national-book-awards/years/" },
                    { 2, "THE GREAT AMERICAN READ was an eight-part PBS series that explored and celebrated the power of reading, told through the prism of America’s 100 best-loved novels (as chosen in a national survey)*.  It investigated how and why writers create their fictional worlds, how we as readers are affected by these stories, and what these 100 different books have to say about our diverse nation and our shared human experience.", "The Great America Read", "https://www.pbs.org/the-great-american-read/books/#/" },
                    { 3, "", "Academy Award For Best Picture", "https://awardsdatabase.oscars.org/" },
                    { 4, "", "Academy Award Nominee For International Feature Film", "https://awardsdatabase.oscars.org/" },
                    { 5, "CTFF celebrates the talents of established and emerging filmmakers of Caribbean and African heritage who practice their art across the Caribbean Diaspora worldwide.", "CaribbeanTales International Film Festival", "https://caribbeantalesfestival.com/" }
                });

            migrationBuilder.InsertData(
                table: "WishLists",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[,]
                {
                    { 1, "Audiobooks I want to listen to.", "Audiobooks" },
                    { 2, "Audiobooks to listen to in the car with my kids", "Family Books For the Car" },
                    { 3, "Movies I want to watch", "Movies" },
                    { 4, "Spanish movies, videos, TV shows, etc.", "Spanish Movies" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "CountryId", "Description", "Language", "Title", "Year" },
                values: new object[,]
                {
                    { 1, 1, 1, "In Jason Mott’s Hell of a Book, a Black author sets out on a cross-country publicity tour to promote his bestselling novel. That storyline drives Hell of a Book and is the scaffolding of something much larger and urgent: since Mott’s novel also tells the story of Soot, a young Black boy living in a rural town in the recent past, and The Kid, a possibly imaginary child who appears to the author on his tour. As these characters’ stories build and build and converge, they astonish.For while this heartbreaking and magical book entertains and is at once about family, love of parents and children, art and money, it’s also about the nation’s reckoning with a tragic police shooting playing over and over again on the news.And with what it can mean to be Black in America. Who has been killed? Who is The Kid ? Will the author finish his book tour, and what kind of world will he leave behind? Unforgettably told, with characters who burn into your mind and an electrifying plot ideal for book club discussion, Hell of a Book is the novel Mott has been writing in his head for the last ten years.And in its final twists it truly becomes its title.", 0, "Hell Of a Book", 2021 },
                    { 2, 2, 1, "Little Women follows the close-knit sisters Meg, Jo, Beth, and Amy March as they grow from children into young women. Its author, Louisa May Alcott, loosely based the Marches on her own sisters, and Jo—a young writer who resists society’s expectations for her behavior and passions—on herself. Living with their mother in Massachusetts, adjusting to their poorer circumstances while their father serves in the Civil War, the March girls grapple with first love, tremendous loss, and the gaps between who they are and who they would like to be. Set in New England during a time of great national crisis, it is a classic coming-of-age story beloved by generations.", 0, "Little Women", 1868 },
                    { 3, 3, 1, "Set on the desert planet Arrakis, Dune is the story of the boy Paul Atreides—who would become known as Muad’Dib—and of a great family’s ambition to bring to fruition humankind’s most ancient and unattainable dream. A stunning blend of adventure and mysticism, environmentalism and politics, Dune won the first Nebula Award, shared the Hugo Award, and formed the basis of what is undoubtedly the grandest epic in science fiction.", 0, "Dune", 1965 }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "CountryId", "Description", "DirectorId", "Language", "Rating", "Title", "Type", "Year" },
                values: new object[,]
                {
                    { 1, 1, "A woman in her sixties, after losing everything in the Great Recession, embarks on a journey through the American West, living as a van-dwelling modern-day nomad.", 1, 0, 3, "Nomadland", 0, 2020 },
                    { 2, 2, "Director Alexander Nanau follows a crack team of investigators at the Romanian newspaper Gazeta Sporturilor as they try to uncover a vast health-care fraud that enriched moguls and politicians and led to the deaths of innocent citizens.", 2, 5, 5, "Collective", 0, 2019 },
                    { 3, 3, "A documentary about the power of transformation told through the eyes of 9 trans-identifying individuals in Puerto Rico.", 3, 3, 5, "Mala Mala", 0, 2014 }
                });

            migrationBuilder.InsertData(
                table: "BookGenres",
                columns: new[] { "Id", "BookId", "GenreId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 2 },
                    { 3, 1, 3 },
                    { 4, 2, 3 },
                    { 6, 2, 5 },
                    { 5, 3, 4 }
                });

            migrationBuilder.InsertData(
                table: "BookLocations",
                columns: new[] { "Id", "Audiobook", "BookId", "LocationId", "URL" },
                values: new object[,]
                {
                    { 1, true, 1, 1, "https://clevnet.overdrive.com/clevnet-cpl/content/media/5904391" },
                    { 2, true, 2, 1, "https://clevnet.overdrive.com/clevnet-cpl/content/media/117851" },
                    { 3, true, 3, 1, "https://clevnet.overdrive.com/clevnet-cpl/content/media/2308988" }
                });

            migrationBuilder.InsertData(
                table: "BookPrizes",
                columns: new[] { "Id", "BookId", "PrizeId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 },
                    { 3, 3, 2 }
                });

            migrationBuilder.InsertData(
                table: "BookWishLists",
                columns: new[] { "Id", "BookId", "WishListId" },
                values: new object[,]
                {
                    { 5, 3, 2 },
                    { 4, 3, 1 },
                    { 3, 2, 1 },
                    { 2, 2, 2 },
                    { 1, 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "MovieActors",
                columns: new[] { "Id", "ActorId", "MovieId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 },
                    { 3, 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "MovieGenres",
                columns: new[] { "Id", "GenreId", "MovieId" },
                values: new object[,]
                {
                    { 7, 10, 3 },
                    { 6, 6, 3 },
                    { 5, 9, 3 },
                    { 4, 7, 3 },
                    { 1, 6, 1 },
                    { 2, 7, 2 },
                    { 3, 8, 2 }
                });

            migrationBuilder.InsertData(
                table: "MovieLocations",
                columns: new[] { "Id", "Cost", "Format", "LocationId", "MovieId", "Price", "SpanishAudio", "URL" },
                values: new object[,]
                {
                    { 3, 0, 0, 1, 2, 0.0, false, "https://search.clevnet.org/client/en_US/cpl-main/search/results?qu=collective&te=" },
                    { 2, 0, 3, 1, 1, 0.0, false, "https://search.clevnet.org/client/en_US/cpl-main/search/results?qu=nomadland&te=" },
                    { 1, 0, 0, 1, 3, 0.0, true, "https://search.clevnet.org/client/en_US/cpl-main/search/results?qu=Mala+mala" }
                });

            migrationBuilder.InsertData(
                table: "MoviePrizes",
                columns: new[] { "Id", "MovieId", "PrizeId" },
                values: new object[,]
                {
                    { 2, 2, 2 },
                    { 1, 1, 1 },
                    { 3, 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "MovieWishLists",
                columns: new[] { "Id", "MovieId", "WishListId" },
                values: new object[,]
                {
                    { 2, 2, 3 },
                    { 1, 1, 3 },
                    { 3, 3, 3 },
                    { 4, 3, 4 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BookGenres",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BookGenres",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BookGenres",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "BookGenres",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "BookGenres",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "BookGenres",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "BookLocations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BookLocations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BookLocations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "BookPrizes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BookPrizes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BookPrizes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "BookWishLists",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BookWishLists",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BookWishLists",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "BookWishLists",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "BookWishLists",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MovieActors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MovieActors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MovieActors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "MovieLocations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MovieLocations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MovieLocations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MoviePrizes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MoviePrizes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MoviePrizes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MovieWishLists",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MovieWishLists",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MovieWishLists",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MovieWishLists",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Prizes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Prizes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Prizes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Prizes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Prizes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "WishLists",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "WishLists",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "WishLists",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "WishLists",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
