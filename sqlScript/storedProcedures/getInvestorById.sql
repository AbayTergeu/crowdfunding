DELIMITER //
CREATE PROCEDURE getInvestorById(in userId int)
BEGIN
	select * from Investor where ID = userId;
END
//
