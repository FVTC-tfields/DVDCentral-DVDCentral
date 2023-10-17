using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TSF.DVDCentral.BL.Models;
using TSF.DVDCentral.PL;

namespace TSF.DVDCentral.BL
{
    public static class MovieGenreManager
    {
        public static int Insert(int movieId,
                                 ref int id,
                                 int genreId,
                                 bool rollback = false)
        {
            try
            {
                int results = 0;
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();

                    tblMovieGenre entity = new tblMovieGenre();

                    //if(dc.tblMovieGenres.Any())
                    //{
                    //    entity.Id = dc.tblMovieGenres.Max(s => s.Id) + 1;
                    //}
                    //else
                    //{
                    //    entity.Id = 1;
                    //}

                    entity.Id = dc.tblMovieGenres.Any() ? dc.tblMovieGenres.Max(s => s.Id) + 1 : 1;
                    entity.MovieId = movieId;
                    entity.GenreId = genreId;


                    // IMPORTANT - BACK FILL THE ID
                    id = entity.Id;

                    dc.tblMovieGenres.Add(entity);
                    results = dc.SaveChanges();

                    if (rollback) transaction.Rollback();

                }

                return results;
            }
            catch (Exception)
            {

                throw;
            }

            //try
            //{
            //    MovieGenre moviegenre = new MovieGenre
            //    {
            //        MovieId = movieid,
            //        GenreId = genreid
            //    };

            //    int results = Insert(moviegenre, rollback);

            //    // IMPORTANT - BACKFILL THE REFERENCE ID
            //    id = moviegenre.Id; ;

            //    return results;
            //}
            //catch (Exception)
            //{

            //    throw;
            //}
        }

        //public static int Insert(MovieGenre moviegenre, bool rollback = false)
        //{
        //    try
        //    {
        //        int results = 0;
        //        using (DVDCentralEntities dc = new DVDCentralEntities())
        //        {
        //            IDbContextTransaction transaction = null;
        //            if (rollback) transaction = dc.Database.BeginTransaction();

        //            tblMovieGenre entity = new tblMovieGenre();

        //            //if(dc.tblMovieGenres.Any())
        //            //{
        //            //    entity.Id = dc.tblMovieGenres.Max(s => s.Id) + 1;
        //            //}
        //            //else
        //            //{
        //            //    entity.Id = 1;
        //            //}

        //            entity.Id = dc.tblMovieGenres.Any() ? dc.tblMovieGenres.Max(s => s.Id) + 1 : 1;
        //            entity.MovieId = moviegenre.MovieId;
        //            entity.GenreId = moviegenre.GenreId;


        //            // IMPORTANT - BACK FILL THE ID
        //            moviegenre.Id = entity.Id;

        //            dc.tblMovieGenres.Add(entity);
        //            results = dc.SaveChanges();

        //            if (rollback) transaction.Rollback();

        //        }

        //        return results;
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        public static int Update(int movieGenreId, int movieId, int genreId, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();

                    // Get the row that we are trying to update
                    tblMovieGenre entity = dc.tblMovieGenres.FirstOrDefault(s => s.Id == movieGenreId);

                    if (entity != null)
                    {
                        entity.MovieId = movieId;
                        entity.GenreId = genreId;
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

        public static int Delete(int movieGenreId, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();

                    // Get the row that we are trying to update
                    tblMovieGenre entity = dc.tblMovieGenres.FirstOrDefault(s => s.Id == movieGenreId);

                    if (entity != null)
                    {
                        dc.tblMovieGenres.Remove(entity);
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
    }
}
