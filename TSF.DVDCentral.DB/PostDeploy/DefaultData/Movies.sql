BEGIN
	INSERT INTO tblMovie (Id, Title, Description, FormatId, DirectorId, RatingId, Cost, InStkQty, ImagePath)
	VALUES
	(1, 'Cars', 'Humanoid cars racing.', 1, 1, 1, 5, 100, 'tbd'),
	(2, 'Cars 2', 'Humanoid cars racing but James Bond.', 2, 2, 2, 5, 100, 'tbd'),
	(3, 'Cars 3', 'Humanoid cars racing but electric.', 3, 3, 3, 5, 100, 'tbd')
END