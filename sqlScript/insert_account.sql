INSERT INTO `crowdfunding`.`account`
(`accountNumber`,
`ClientID`,
`CurrencyId`,
`DateStart`,
`Saldo`)
VALUES
('08178105000000003',
1,
1,
sysdate(),
1200);

INSERT INTO `crowdfunding`.`account`
(`accountNumber`,
`ClientID`,
`CurrencyId`,
`DateStart`,
`Saldo`)
VALUES
('08178105000000003',
2,
2,
sysdate(),
1700);

select * from account;