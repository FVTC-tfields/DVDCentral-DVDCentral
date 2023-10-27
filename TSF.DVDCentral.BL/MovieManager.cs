using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TSF.DVDCentral.BL.Models;
using TSF.DVDCentral.PL;

namespace TSF.DVDCentral.BL
{
    public static class MovieManager
    {
        public static int Insert(string title,
                                 string description,
                                 ref int id,
                                 int formatid,
                                 int directorid,
                                 int ratingid,
                                 float cost,
                                 int instkqty,
                                 string imagepath,
                                 bool rollback = false)
        {
            try
            {
                Movie movie = new Movie
                {
                    Title = title,
                    Description = description,
                    FormatId = formatid,
                    DirectorId = directorid,
                    RatingId = ratingid,
                    Cost = cost,
                    InStkQty = instkqty,
                    ImagePath = imagepath
                };

                int results = Insert(movie, rollback);

                // IMPORTANT - BACKFILL THE REFERENCE ID
                id = movie.Id; ;

                return results;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static int Insert(Movie movie, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();

                    tblMovie entity = new tblMovie();

                    //if(dc.tblMovies.Any())
                    //{
                    //    entity.Id = dc.tblMovies.Max(s => s.Id) + 1;
                    //}
                    //else
                    //{
                    //    entity.Id = 1;
                    //}

                    entity.Id = dc.tblMovies.Any() ? dc.tblMovies.Max(s => s.Id) + 1 : 1;
                    entity.Title = movie.Title;
                    entity.Description = movie.Description;
                    entity.FormatId = movie.FormatId;
                    entity.DirectorId = movie.DirectorId;
                    entity.RatingId = movie.RatingId;
                    entity.Cost = movie.Cost;
                    entity.InStkQty = movie.InStkQty;
                    entity.ImagePath = movie.ImagePath;


                    // IMPORTANT - BACK FILL THE ID
                    movie.Id = entity.Id;

                    dc.tblMovies.Add(entity);
                    results = dc.SaveChanges();

                    if (rollback) transaction.Rollback();

                }

                return results;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static int Update(Movie movie, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();

                    // Get the row that we are trying to update
                    tblMovie entity = dc.tblMovies.FirstOrDefault(s => s.Id == movie.Id);

                    if (entity != null)
                    {
                        entity.Title = movie.Title;
                        entity.Description = movie.Description;
                        entity.FormatId = movie.FormatId;
                        entity.DirectorId = movie.DirectorId;
                        entity.RatingId = movie.RatingId;
                        entity.Cost = movie.Cost;
                        entity.InStkQty = movie.InStkQty;
                        entity.ImagePath = movie.ImagePath;
                        results = dc.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Row does not exist");
                    }

                    if (rollback) transaction.Rollback();
                }
                return results;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static int Delete(int id, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();

                    // Get the row that we are trying to update
                    tblMovie entity = dc.tblMovies.FirstOrDefault(s => s.Id == id);

                    if (entity != null)
                    {
                        dc.tblMovies.Remove(entity);
                        results = dc.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Row does not exist");
                    }

                    if (rollback) transaction.Rollback();
                }
                return results;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static Movie LoadById(int id)
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    tblMovie entity = dc.tblMovies.FirstOrDefault(s => s.Id == id);

                    if (entity != null)
                    {
                        return new Movie
                        {
                            Id = entity.Id,
                            Title = entity.Title,
                            Description = entity.Description,
                            FormatId = entity.FormatId,
                            DirectorId = entity.DirectorId,
                            RatingId = entity.RatingId,
                            Cost = (float)entity.Cost,
                            InStkQty = entity.InStkQty,
                            ImagePath = entity.ImagePath

                        };
                    }
                    else
                    {
                        throw new Exception();
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public static List<Movie> Load(int? genreId = null)
        {
            try
            {
                List<Movie> list = new List<Movie>();

                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    (from s in dc.tblMovies
                     join p in dc.tblMovieGenres on s.Id equals p.MovieId
                     where p.GenreId == genreId || genreId == null
                     select new
                     {
                         s.Id,
                         s.Title,
                         s.Description,
                         s.FormatId,
                         s.DirectorId,
                         s.RatingId,
                         s.Cost,
                         s.InStkQty,
                         s.ImagePath,
                         p.GenreId
                     })
                     .ToList()
                    .ForEach(movie => list.Add(new Movie
                    {
                        Id = movie.Id,
                        Title = movie.Title,
                        Description = movie.Description,
                        FormatId = movie.FormatId,
                        DirectorId = movie.DirectorId,
                        RatingId = movie.RatingId,
                        Cost = (float)movie.Cost,
                        InStkQty = movie.InStkQty,
                        ImagePath = movie.ImagePath,
                    }));
                }

                return list;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
