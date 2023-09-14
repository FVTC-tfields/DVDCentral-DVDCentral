BEGIN
	INSERT INTO tblUser(Id, FirstName, LastName, UserName, Password)
	VALUES
	(12345, 'Anakin', 'Skywalker', 'askywalker', 'r2d2'),
	(23456, 'Luke', 'Skywalker', 'lskywalker', 'c3po'),
	(67890, 'Obiwan', 'Kenobi', 'okenobi', 'anakin')
END