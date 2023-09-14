BEGIN
	INSERT INTO tblOrderItem (Id, OrderId, Quantity, MovieId, Cost)
	VALUES
	(1, 1, 2, 1, 10),
	(2, 2, 4, 2, 20),
	(3, 3, 6, 3, 30)
END