BEGIN
	INSERT INTO tblCustomer (Id, FirstName, LastName, UserId, Address, City, State, ZIP, Phone)
	VALUES
	(1, 'Anakin', 'Skywalker', 1, '1001 Death Star Drive', 'Appleton', 'WI', '54914', '1234567890'),
	(2, 'Luke', 'Skywalker', 2, '2002 Taco Bell Court', 'Neenah', 'WI', '54956', '0987654321'),
	(3, 'Obiwan', 'Kenobi', 3, '3003 Culvers Lane', 'Oshkosh', 'WI', '54902', '1023945867')
END