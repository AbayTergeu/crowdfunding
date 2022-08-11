INSERT INTO `crowdfunding`.`investor`
(`Name`,
`Surname`,
`InvestorID`,
`email`,
`mobile`,
`login`,
`password`,
`isAcceptedContract`,
`CountryID`)
VALUES
('Саша',
'Иванов',
'2137',
'mail@mail.ru',
'+99812376458',
'sash',
'12345678',
true,
1);

INSERT INTO `crowdfunding`.`investor`
(`Name`,
`Surname`,
`InvestorID`,
`email`,
`mobile`,
`login`,
`password`,
`isAcceptedContract`,
`CountryID`)
VALUES
('Ruslan',
'Zagitov',
'2139',
'rus2@mail.ru',
'+9981209876',
'rus',
'12345678',
true,
2);

select * from investor;