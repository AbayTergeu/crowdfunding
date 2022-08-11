create table Currency(
	ID int not null AUTO_INCREMENT,
    code varchar(255) not null,
    name varchar(255),
    primary key (ID)
);

create table AccountType(
	ID int not null AUTO_INCREMENT,
    code varchar(255) not null,
    name varchar(255),
    primary key (ID)
);

create table InvestStatus(
	ID int not null AUTO_INCREMENT,
    code varchar(255) not null,
    name varchar(2555),
    primary key (ID)
);

create table Country(
	ID int not null AUTO_INCREMENT,
    code varchar(255) not null,
    name varchar(2555),
    primary key (ID)
);

create table Investor(
	ID int not null AUTO_INCREMENT,
    Name varchar(255),
    Surname varchar(255),
    InvestorID varchar(255),
    email varchar(255),
    mobile varchar(255),
    login varchar(255),
    password varchar(255),
    isAcceptedContract boolean default false,
    CountryID int,
    primary key (ID),
    foreign key (CountryID) references Country(ID)
);

create table Account(
	ID int not null AUTO_INCREMENT,
    accountNumber varchar(255) not null,
    ClientID int,
    CurrencyId int,
    AccountTypeID int,
    DateStart datetime,
    DateEnd datetime,
    Saldo decimal,
    primary key (ID),
    foreign key (ClientID) references investor(ID),
    foreign key (CurrencyID) references Currency(ID),
    foreign key (AccountTypeID) references accounttype(ID)
);

create table TransationList(
	ID int not null AUTO_INCREMENT,
    AccountId int,
    transactionDate datetime,
    Dt decimal,
    Kt decimal,
    saldo decimal,
    primary key (ID),
    foreign key (AccountId) references account(ID) 
);

create table loan(
	ID int not null AUTO_INCREMENT,
    Name varchar(255),
    Surname varchar(255),
    OrganizationName varchar(255),
    AccountId int,
    CountryID int,
    LoanID varchar(255),
    primary key (ID),
    foreign key(AccountID) references account(ID),
    foreign key(CountryID)references country(ID)
);

create table investments(
	ID int not null AUTO_INCREMENT,
    investmentNumber varchar(255),
    CreateDate datetime,
    StartDate datetime,
    EndDate datetime,
    DaysCountry int,
    StatusId int,
    InvestmentAmount decimal,
    CurrencyId int,
    LoanId int,
    InvestorId int,
    InterestRate decimal,
    primary key(ID),
    foreign key(CurrencyId) references currency(ID),
    foreign key(LoanId) references loan(ID),
    foreign key(InvestorId)references investor(ID)
);





create table BisnessClient(
	ID int not null auto_increment,
    Name varchar(255) not null,
    IBAN varchar(255),
    primary key(ID)
);

create table BisnessAccount(
	ID int not null auto_increment,
    AccountNumber varchar(255) not null,
    CurrencyId int not null,
    DateStart datetime,
    DateEnd datetime,
    Saldo decimal,
    primary key(ID),
    foreign key(CurrencyId) references currency(ID)
);

create table BisnessAccountTransationList(
	ID int not null AUTO_INCREMENT,
    AccountId int,
    transactionDate datetime,
    Dt decimal,
    Kt decimal,
    saldo decimal,
    primary key (ID),
    foreign key (AccountId) references BisnessAccount(ID) 
);