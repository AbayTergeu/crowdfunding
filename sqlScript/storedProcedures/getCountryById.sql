DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `getCountryById`(in IdCountry integer)
BEGIN
	select * from Country where ID = IdCountry;
END$$
DELIMITER ;
