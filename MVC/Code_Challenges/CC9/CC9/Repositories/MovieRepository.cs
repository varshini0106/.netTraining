﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CC9.Models;

namespace CC9.Repository
{
    public class MovieRepository : IMovieRepository
    {
        MoviesDbContext db = new MoviesDbContext();

        public IEnumerable<Movie> GetAll() => db.Movies.ToList();

        public Movie GetById(int id) => db.Movies.Find(id);

        public void Add(Movie movie)
        {
            db.Movies.Add(movie);
            db.SaveChanges();
        }

        public void Update(Movie movie)
        {
            var existing = db.Movies.Find(movie.Mid);
            if (existing != null)
            {
                existing.Moviename = movie.Moviename;
                existing.DirectorName = movie.DirectorName;
                existing.DateofRelease = movie.DateofRelease;
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var movie = db.Movies.Find(id);
            if (movie != null)
            {
                db.Movies.Remove(movie);
                db.SaveChanges();
            }
        }

        public IEnumerable<Movie> GetByYear(int year)
        {
            return db.Movies.Where(m => m.DateofRelease.Year == year).ToList();
        }

        public IEnumerable<Movie> GetByDirector(string directorName)
        {
            return db.Movies.Where(m => m.DirectorName == directorName).ToList();
        }
    }
}
