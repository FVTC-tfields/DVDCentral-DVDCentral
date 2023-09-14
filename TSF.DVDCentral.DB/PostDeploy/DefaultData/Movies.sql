BEGIN
	INSERT INTO tblMovie (Id, Title, Description, FormatId, DirectorId, RatingId, Cost, InStkQty, ImagePath)
	VALUES
	(1, 'Cars', 'Car Racing', 123, 123, 123, 5, 100, 'tbd'),
	(2, 'Cars 2', 'Car Racing Version 2', 234, 234, 234, 5, 100, 'tbd'),
	(3, 'Cars 3', 'Car Racing Version 3', 345, 345, 345, 5, 100, 'tbd')
END