using Microsoft.EntityFrameworkCore;
using ReadingList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadingList
{
    public class ReadingContext: DbContext
    {
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookGenre> BookGenres { get; set; }
        public DbSet<BookLocation> BookLocations { get; set; }
        public DbSet<BookPrize> BookPrizes { get; set; }
        public DbSet<BookWishList> BookWishLists { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieActor> MovieActors { get; set; }
        public DbSet<MovieGenre> MovieGenres { get; set; }
        public DbSet<MovieLocation> MovieLocations { get; set; }
        public DbSet<MoviePrize> MoviePrizes { get; set; }
        public DbSet<MovieWishList> MovieWishLists { get; set; }
        public DbSet<Prize> Prizes { get; set; }
        public DbSet<WishList> WishLists { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Server=(localdb)\\mssqllocaldb; Database=ReadingDB_011922; Trusted_Connection=True";

            optionsBuilder.UseSqlServer(connectionString).UseLazyLoadingProxies();

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Book>().HasData(
                new Book() { Id = 1, Title = "Hell Of a Book", AuthorId = 1, CountryId = 1, Year = 2021, Language = Language.English, Description = "In Jason Mott’s Hell of a Book, a Black author sets out on a cross-country publicity tour to promote his bestselling novel. That storyline drives Hell of a Book and is the scaffolding of something much larger and urgent: since Mott’s novel also tells the story of Soot, a young Black boy living in a rural town in the recent past, and The Kid, a possibly imaginary child who appears to the author on his tour. As these characters’ stories build and build and converge, they astonish.For while this heartbreaking and magical book entertains and is at once about family, love of parents and children, art and money, it’s also about the nation’s reckoning with a tragic police shooting playing over and over again on the news.And with what it can mean to be Black in America. Who has been killed? Who is The Kid ? Will the author finish his book tour, and what kind of world will he leave behind? Unforgettably told, with characters who burn into your mind and an electrifying plot ideal for book club discussion, Hell of a Book is the novel Mott has been writing in his head for the last ten years.And in its final twists it truly becomes its title." },
                new Book() { Id = 2, Title = "Little Women", AuthorId = 2, CountryId = 1, Year = 1868, Language = Language.English, Description = "Little Women follows the close-knit sisters Meg, Jo, Beth, and Amy March as they grow from children into young women. Its author, Louisa May Alcott, loosely based the Marches on her own sisters, and Jo—a young writer who resists society’s expectations for her behavior and passions—on herself. Living with their mother in Massachusetts, adjusting to their poorer circumstances while their father serves in the Civil War, the March girls grapple with first love, tremendous loss, and the gaps between who they are and who they would like to be. Set in New England during a time of great national crisis, it is a classic coming-of-age story beloved by generations." },
                new Book() { Id = 3, Title = "Dune", AuthorId = 3, CountryId = 1, Year = 1965, Language = Language.English, Description = "Set on the desert planet Arrakis, Dune is the story of the boy Paul Atreides—who would become known as Muad’Dib—and of a great family’s ambition to bring to fruition humankind’s most ancient and unattainable dream. A stunning blend of adventure and mysticism, environmentalism and politics, Dune won the first Nebula Award, shared the Hugo Award, and formed the basis of what is undoubtedly the grandest epic in science fiction." }
                );

            modelbuilder.Entity<Author>().HasData(
                new Author() { Id = 1, FirstName = "Jason", LastName = "Motts", Gender = Gender.Male },
                new Author() { Id = 2, FirstName = "Louisa May", LastName = "Alcott", Gender = Gender.Female },
                new Author() { Id = 3, FirstName = "Frank", LastName = "Herbert", Gender = Gender.Male }
                );

            modelbuilder.Entity<Country>().HasData(
                new Country() { Id = 1, Name = "United States of America" },
                new Country() { Id = 2, Name = "Romania" },
                new Country() { Id = 3, Name = "Puerto Rico" }
                );

            modelbuilder.Entity<Genre>().HasData(
                new Genre() { Id = 1, Name = "Literature" },
                new Genre() { Id = 2, Name = "African American Fiction"},
                new Genre() { Id = 3, Name = "Fiction"},
                new Genre() { Id = 4, Name = "Science Fiction"},
                new Genre() { Id = 5, Name = "Classic Literature"},
                new Genre() { Id = 6, Name = "Drama" },
                new Genre() { Id = 7, Name = "Documentary" },
                new Genre() { Id = 8, Name = "Crime" },
                new Genre() { Id = 9, Name = "Biography" },
                new Genre() { Id = 10, Name = "News" }
                );

            modelbuilder.Entity<BookGenre>().HasData(
                new BookGenre() { Id = 1, BookId = 1, GenreId = 1 },
                new BookGenre() { Id = 2, BookId = 1, GenreId = 2 }, 
                new BookGenre() { Id = 3, BookId = 1, GenreId = 3 }, 
                new BookGenre() { Id = 4, BookId = 2, GenreId = 3 }, 
                new BookGenre() { Id = 5, BookId = 3, GenreId = 4 },
                new BookGenre() { Id = 6, BookId = 2, GenreId = 5}
                );

            modelbuilder.Entity<Location>().HasData(
                new Location() { Id = 1, Name = "Clevnet", Description = "Cleveland Public Library", URL = "https://cpl.org/" },
                new Location() { Id = 2, Name = "Lakewood Public Library", Description = "", URL = "https://www.lakewoodpubliclibrary.org/" },
                new Location() { Id = 3, Name = "Netflix", Description = "", URL = "https://www.netflix.com/browse" }
                );

            modelbuilder.Entity<BookLocation>().HasData(
                new BookLocation() { Id = 1, BookId = 1, LocationId = 1, Audiobook = true, URL = "https://clevnet.overdrive.com/clevnet-cpl/content/media/5904391" },
                new BookLocation() { Id = 2, BookId = 2, LocationId = 1, Audiobook = true, URL = "https://clevnet.overdrive.com/clevnet-cpl/content/media/117851" },
                new BookLocation() { Id = 3, BookId = 3, LocationId = 1, Audiobook = true, URL = "https://clevnet.overdrive.com/clevnet-cpl/content/media/2308988" }
                );

            modelbuilder.Entity<Prize>().HasData(
                new Prize() { Id = 1, Name = "National Book Award for Fiction", Description = "The National Book Awards were established in 1950 to celebrate the best writing in America. Since 1989, they have been overseen by the National Book Foundation, a nonprofit organization whose mission is to celebrate the best literature in America, expand its audience, and ensure that books have a prominent place in American culture. Although other categories have been recognized in the past, the Awards currently honors the best Fiction, Nonfiction, Poetry, Translated Literature, and Young People’s Literature published each year.", URL = "https://www.nationalbook.org/national-book-awards/years/" },
                new Prize() { Id = 2, Name = "The Great America Read", Description = "THE GREAT AMERICAN READ was an eight-part PBS series that explored and celebrated the power of reading, told through the prism of America’s 100 best-loved novels (as chosen in a national survey)*.  It investigated how and why writers create their fictional worlds, how we as readers are affected by these stories, and what these 100 different books have to say about our diverse nation and our shared human experience.", URL = "https://www.pbs.org/the-great-american-read/books/#/" },
                new Prize() { Id = 3, Name = "Academy Award For Best Picture", Description = "", URL = "https://awardsdatabase.oscars.org/" },
                new Prize() { Id = 4, Name = "Academy Award Nominee For International Feature Film", Description = "", URL = "https://awardsdatabase.oscars.org/" },
                new Prize() { Id = 5, Name = "CaribbeanTales International Film Festival", Description = "CTFF celebrates the talents of established and emerging filmmakers of Caribbean and African heritage who practice their art across the Caribbean Diaspora worldwide.", URL = "https://caribbeantalesfestival.com/" }
                );

            modelbuilder.Entity<BookPrize>().HasData(
                new BookPrize() { Id = 1, BookId = 1, PrizeId = 1 },
                new BookPrize() { Id = 2, BookId = 2, PrizeId = 2 },
                new BookPrize() { Id = 3, BookId = 3, PrizeId = 2 }
                );

            modelbuilder.Entity<WishList>().HasData(
                new WishList() { Id = 1, Title = "Audiobooks", Description = "Audiobooks I want to listen to." },
                new WishList() { Id = 2, Title = "Family Books For the Car", Description = "Audiobooks to listen to in the car with my kids" },
                new WishList() { Id = 3, Title = "Movies", Description = "Movies I want to watch" },
                new WishList() { Id = 4, Title = "Spanish Movies", Description = "Spanish movies, videos, TV shows, etc." }
                );

            modelbuilder.Entity<BookWishList>().HasData(
                new BookWishList() { Id = 1, BookId = 1, WishListId = 1 },
                new BookWishList() { Id = 2, BookId = 2, WishListId = 2 },
                new BookWishList() { Id = 3, BookId = 2, WishListId = 1 }, 
                new BookWishList() { Id = 4, BookId = 3, WishListId = 1 }, 
                new BookWishList() { Id = 5, BookId = 3, WishListId = 2 }
                );

            modelbuilder.Entity<Movie>().HasData(
                new Movie() { Id = 1, Title = "Nomadland", DirectorId = 1, CountryId = 1, Year = 2020, Language = Language.English, Description = "A woman in her sixties, after losing everything in the Great Recession, embarks on a journey through the American West, living as a van-dwelling modern-day nomad.", Type = VideoType.Movie, Rating = Rating.R },
             new Movie() { Id = 2, Title = "Collective", DirectorId = 2, CountryId = 2, Year = 2019, Language = Language.Other, Description = "Director Alexander Nanau follows a crack team of investigators at the Romanian newspaper Gazeta Sporturilor as they try to uncover a vast health-care fraud that enriched moguls and politicians and led to the deaths of innocent citizens.", Type = VideoType.Movie, Rating = Rating.NR },
             new Movie() { Id = 3, Title = "Mala Mala", DirectorId = 3, CountryId = 3, Year = 2014, Language = Language.LatinAmerica, Description = "A documentary about the power of transformation told through the eyes of 9 trans-identifying individuals in Puerto Rico.", Type = VideoType.Movie, Rating = Rating.NR }
             );

            modelbuilder.Entity<Actor>().HasData(
                new Actor() { Id = 1, FirstName = "Frances", LastName = "McDormand" },
                new Actor() { Id = 2, FirstName = "Dan Alexandru", LastName = "Condrea" },
                new Actor() { Id = 3, FirstName = "Jason", LastName = "Carrion" }
                );

            modelbuilder.Entity<MovieActor>().HasData(
                new MovieActor() { Id = 1, MovieId = 1, ActorId = 1 },
                new MovieActor() { Id = 2, MovieId = 2, ActorId = 2 },
                new MovieActor() { Id = 3, MovieId = 3, ActorId = 3 }
                );

            modelbuilder.Entity<Director>().HasData(
                new Director() { Id = 1, FirstName = "Chloe", LastName = "Zhao", Gender = Gender.Female },
                new Director() { Id = 2, FirstName = "Alexander", LastName = "Nanau", Gender = Gender.Male },
                new Director() { Id = 3, FirstName = "Antonio", LastName = "Santini", Gender = Gender.Male }
                );

            modelbuilder.Entity<MovieGenre>().HasData(
               new MovieGenre() { Id = 1, MovieId = 1, GenreId = 6 },
               new MovieGenre() { Id = 2, MovieId = 2, GenreId = 7 },
               new MovieGenre() { Id = 3, MovieId = 2, GenreId = 8 },
               new MovieGenre() { Id = 4, MovieId = 3, GenreId = 7 },
               new MovieGenre() { Id = 5, MovieId = 3, GenreId = 9 },
               new MovieGenre() { Id = 6, MovieId = 3, GenreId = 6 },
               new MovieGenre() { Id = 7, MovieId = 3, GenreId = 10 }
               );

            modelbuilder.Entity<MovieLocation>().HasData(
                new MovieLocation() { Id = 1, MovieId = 3, LocationId = 1, SpanishAudio = true, URL = "https://search.clevnet.org/client/en_US/cpl-main/search/results?qu=Mala+mala", Format = Format.DVD, Cost = Cost.Free, Price = 0 },
                new MovieLocation() { Id = 2, MovieId = 1, LocationId = 1, SpanishAudio = false, URL = "https://search.clevnet.org/client/en_US/cpl-main/search/results?qu=nomadland&te=", Format = Format.Blueray, Cost = Cost.Free, Price = 0 },
                new MovieLocation() { Id = 3, MovieId = 2, LocationId = 1, SpanishAudio = false, URL = "https://search.clevnet.org/client/en_US/cpl-main/search/results?qu=collective&te=", Format = Format.DVD, Cost = Cost.Free, Price = 0 }
                );

            modelbuilder.Entity<MoviePrize>().HasData(
                new MoviePrize() { Id = 1, MovieId = 1, PrizeId = 1 },
                new MoviePrize() { Id = 2, MovieId = 2, PrizeId = 2 },
                new MoviePrize() { Id = 3, MovieId = 3, PrizeId = 3 }
                );

            modelbuilder.Entity<MovieWishList>().HasData(
                new MovieWishList() { Id = 1, MovieId = 1, WishListId = 3 },
                new MovieWishList() { Id = 2, MovieId = 2, WishListId = 3 },
                new MovieWishList() { Id = 3, MovieId = 3, WishListId = 3 },
                new MovieWishList() { Id = 4, MovieId = 3, WishListId = 4 }
                );
        }
    }
}
