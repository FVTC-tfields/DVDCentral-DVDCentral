﻿using Microsoft.Extensions.Logging;

namespace TSF.DVDCentral.BL
{
    public class GenreManager : GenericManager<tblGenre>
    {
        public GenreManager(DbContextOptions<DVDCentralEntities> options) : base(options) { }
        public GenreManager(ILogger logger, DbContextOptions<DVDCentralEntities> options) : base(logger, options) { }

        public int Insert(string description,
                                 Guid id,
                                 bool rollback = false)
        {
            try
            {
                Genre genre = new Genre
                {
                    Description = description
                };

                int results = Insert(genre, rollback);

                // IMPORTANT - BACKFILL THE REFERENCE ID
                id = genre.Id; ;

                return results;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int Insert(Genre genre, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();

                    tblGenre entity = new tblGenre();

                    //if(dc.tblGenres.Any())
                    //{
                    //    entity.Id = dc.tblGenres.Max(s => s.Id) + 1;
                    //}
                    //else
                    //{
                    //    entity.Id = 1;
                    //}

                    entity.Id = Guid.NewGuid();
                    entity.Description = genre.Description;


                    // IMPORTANT - BACK FILL THE ID
                    genre.Id = entity.Id;

                    dc.tblGenres.Add(entity);
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

        public int Update(Genre genre, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();

                    // Get the row that we are trying to update
                    tblGenre entity = dc.tblGenres.FirstOrDefault(s => s.Id == genre.Id);

                    if (entity != null)
                    {
                        entity.Description = genre.Description;
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

        public int Delete(Guid id, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();

                    // Get the row that we are trying to update
                    tblGenre entity = dc.tblGenres.FirstOrDefault(s => s.Id == id);

                    if (entity != null)
                    {
                        dc.tblGenres.Remove(entity);
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

        public Genre LoadById(Guid id)
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    tblGenre entity = dc.tblGenres.FirstOrDefault(s => s.Id == id);

                    if (entity != null)
                    {
                        return new Genre
                        {
                            Id = entity.Id,
                            Description = entity.Description,

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

        public List<Genre> Load(Guid id)
        {
            try
            {
                List<Genre> list = new List<Genre>();

                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    (from s in dc.tblGenres
                     select new
                     {
                         s.Id,
                         s.Description
                     })
                     .ToList()
                    .ForEach(genre => list.Add(new Genre
                    {
                        Id = genre.Id,
                        Description = genre.Description
                    }));
                }

                return list;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string? ToString()
        {
            return base.ToString();
        }
    }
}
