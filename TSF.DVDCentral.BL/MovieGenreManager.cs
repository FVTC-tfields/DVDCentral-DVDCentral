using System.Xml.Linq;

namespace TSF.DVDCentral.BL
{
    public class MovieGenreManager : GenericManager<tblMovieGenre>
    {
        public MovieGenreManager(DbContextOptions<DVDCentralEntities> options) : base(options) { }

        public int Insert(Guid movieId,
                                 Guid id,
                                 Guid genreId,
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

                    entity.Id = Guid.NewGuid();
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

        public int Update(Guid movieGenreId, Guid movieId, Guid genreId, bool rollback = false)
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

        public int Delete(Guid movieGenreId, Guid genreId, bool rollback = false)
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
