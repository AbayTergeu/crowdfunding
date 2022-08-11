INSERT INTO `crowdfunding`.`loan`
(`Name`,
`Surname`,
`AccountId`,
`CountryID`,
`LoanID`)
VALUES
('Polina',
'Polscaya',
3,
2,
'123-8');SELECT `account`.`ID`,
    `account`.`accountNumber`,
    `account`.`ClientID`,
    `account`.`CurrencyId`,
    `account`.`AccountTypeID`,
    `account`.`DateStart`,
    `account`.`DateEnd`,
    `account`.`Saldo`
FROM `crowdfunding`.`account`;


select * from loan;