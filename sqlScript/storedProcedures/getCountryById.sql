DELIMITER //
create procedure getCountryById(in IdCountry integer)
begin
	select * from Country where ID = IdCountry;
end
//