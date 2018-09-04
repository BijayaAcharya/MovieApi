using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MovieApi.Models;

namespace MovieApi.Controllers
{
    public class MovieController : ApiController
    {
        // Get a list of all movies
        public List<Movies> GetAllMovies()
        {

            // create ORM

            MoviesDBEntities1 ORM = new MoviesDBEntities1();

            //get all the movies from ORM

            List<Movies> movieList = ORM.Movies.ToList();


            //return the list of movies
            return movieList;
        }

        // Get a list of all movies in a specific category

        [HttpGet]
        public List<Movies> MoviesByCategory(string category)

        {//http://localhost:port/api/Northwind/MoviesByCategory?Category=SciFi

            MoviesDBEntities1 ORM = new MoviesDBEntities1();

            return ORM.Movies.Where(x => x.Category.ToLower() == category.ToLower()).ToList();
        }

        //Get a list of all movie categories

        public List<string> GetMoviesCategory()
        {

            MoviesDBEntities1 ORM = new MoviesDBEntities1();

            return ORM.Movies.Where(x => x.Category != null).Select(x => x.Category).Distinct().ToList();

        }


        //get a random movie pick
        public string GetRandomMovie()
        {
            MoviesDBEntities1 ORM = new MoviesDBEntities1();

            Random r = new Random();
            int newran = r.Next(1, 20);
            List <Movies> movies = ORM.Movies.ToList();
            return movies[newran].Title;

        }

        //Get random movie by category
       public string GetMovieByCat(string cat)
        {

        MoviesDBEntities1 ORM = new MoviesDBEntities1();
     
            Random ran = new Random();
            int newran = ran.Next(ORM.Movies.Where(x => x.Category == cat).Count());
            List<Movies> movies= ORM.Movies.Where(x=>x.Category== cat).ToList();

            return movies[newran].Title;
       }

        // Get info about specific movie
        public string GetSpecificMovie(string title)
        {
         MoviesDBEntities1 ORM = new MoviesDBEntities1();

            List<Movies> movies = ORM.Movies.Where(x => x.Title.ToLower() == title.ToLower()).ToList();
            return movies[0].Title;

        }

        // get a list of movies which have same keyword as a query parameter

      public List<Movies> GEtMoviesByKeyWord( string title)
      {
            MoviesDBEntities1 ORM = new MoviesDBEntities1();
            List<Movies> movies = ORM.Movies.Where(x => x.Title.Contains(title)).ToList();
            return movies.ToList();       

      }
       






    }
}