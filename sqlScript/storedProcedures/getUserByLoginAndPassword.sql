DELIMITER //
CREATE PROCEDURE getUserByLoginAndPassword(in userLogin nvarchar(255), in userPassword nvarchar(255))
BEGIN
	select * from Investor where login = userLogin and password = userPassword;
END
//
