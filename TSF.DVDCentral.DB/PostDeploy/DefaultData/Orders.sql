BEGIN
	INSERT INTO tblOrder (Id, CustomerId, OrderDate, ShipDate, UserId)
	VALUES
	(1, 1, '2023-1-1', '2023-1-2', 12345),
	(2, 2, '2023-1-1', '2023-1-2', 23456),
	(3, 3, '2023-1-1', '2023-1-2', 67890)
END