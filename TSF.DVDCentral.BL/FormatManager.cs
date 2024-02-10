namespace TSF.DVDCentral.BL
{
    public class FormatManager : GenericManager<tblFormat>
    {
        public FormatManager(DbContextOptions<DVDCentralEntities> options) : base(options) { }

        public int Insert(string description,
                                 Guid id,
                                 bool rollback = false)
        {
            try
            {
                Format format = new Format
                {
                    Description = description
                };

                int results = Insert(format, rollback);

                // IMPORTANT - BACKFILL THE REFERENCE ID
                id = format.Id; ;

                return results;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int Insert(Format format, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();

                    tblFormat entity = new tblFormat();

                    //if(dc.tblFormats.Any())
                    //{
                    //    entity.Id = dc.tblFormats.Max(s => s.Id) + 1;
                    //}
                    //else
                    //{
                    //    entity.Id = 1;
                    //}

                    entity.Id = Guid.NewGuid();
                    entity.Description = format.Description;


                    // IMPORTANT - BACK FILL THE ID
                    format.Id = entity.Id;

                    dc.tblFormats.Add(entity);
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

        public int Update(Format format, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();

                    // Get the row that we are trying to update
                    tblFormat entity = dc.tblFormats.FirstOrDefault(s => s.Id == format.Id);

                    if (entity != null)
                    {
                        entity.Description = format.Description;
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
                    tblFormat entity = dc.tblFormats.FirstOrDefault(s => s.Id == id);

                    if (entity != null)
                    {
                        dc.tblFormats.Remove(entity);
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

        public Format LoadById(Guid id)
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    tblFormat entity = dc.tblFormats.FirstOrDefault(s => s.Id == id);

                    if (entity != null)
                    {
                        return new Format
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

        public List<Format> Load()
        {
            try
            {
                List<Format> list = new List<Format>();

                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    (from s in dc.tblFormats
                     select new
                     {
                         s.Id,
                         s.Description
                     })
                     .ToList()
                    .ForEach(format => list.Add(new Format
                    {
                        Id = format.Id,
                        Description = format.Description
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
