DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `getUserByLoginOrMobile`(in userLogin nvarchar(255), in userMobile varchar(255))
BEGIN
	select * from Investor where login = userLogin or mobile = userMobile;
END$$
DELIMITER ;
